using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SendGrid;
using SendGrid.Helpers.Mail;

using Amphibian.Oep.Api.Models;
using System.Net;
using Amphibian.Oep.Api.Extensions;
using Microsoft.Extensions.Logging;
using System.IO;
using Amphibian.Oep.Configuration;

namespace Amphibian.Oep.Api.Services
{
    public class SendGridEmailException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Body { get; set; }
    }
    public class EmailService:IEmailService
    {
        private string _apiKey;
        private string _overrideTo;
        private string _fromName;
        private string _fromEmail;
        private string _urlRoot;
        private string _profileRoute;
        private ILogger<EmailService> _logger;
        private string _userFileRelativeUrl;
        private string _userFilePath;
        

        public EmailService(EmailConfiguration emailConfig,AppConfiguration appConfig, ILogger<EmailService> logger)
        {
            _apiKey = emailConfig.SendGridApiKey;
            _overrideTo = emailConfig.SendAllEmailsTo;
            _fromName = emailConfig.FromName;
            _fromEmail = emailConfig.FromEmail;
            _urlRoot = appConfig.RootUrl;
            _profileRoute = emailConfig.ProfileRoute;
            _logger = logger;

            _userFilePath = appConfig.UserFilePath;
            _userFileRelativeUrl = appConfig.UserFileRelativeUrl;
        }
        public async Task SendRegistrationEmail(User user)
        {
            var msg = new SendGridMessage()
            {
                Subject = "Patrol.Ski Registration Complete",
                PlainTextContent = 
                @$"Hello {user.FirstName}, 
Thank you for registering with Patrol.Ski.",
                HtmlContent = @$"Hello {user.FirstName},<br/>Thank you for registering with Patrol.Ski.",
            };

            AddToUnsubscribe(msg);

            var response = await Send(msg,null, user);
        }

        public async Task SendResetEmail(User user,string resetRoute)
        {
            var msg = new SendGridMessage()
            {
                Subject = "Patrol.Ski Password Reset",
                PlainTextContent =
                @$"Hello {user.FirstName}, 
Please follow use link to reset your password {_urlRoot}{resetRoute}",
                HtmlContent = @$"Hello {user.FirstName},<br/>Please follow <a href='{_urlRoot}{resetRoute}'>this</a> link ({_urlRoot}{resetRoute}) to reset your password.",
            };

            //fake user allow email notifications to true for this one, if they asked for a reset we can asume this email is ok
            user.AllowEmailNotifications = true;

            var response = await Send(msg, null, user);
        }

        public async Task SendNewUserWelcomeEmail(User user, string welcomeRoute)
        {
            var msg = new SendGridMessage()
            {
                Subject = $"Welcome to ",
                PlainTextContent = $"You have been added to .\n{_urlRoot}{welcomeRoute}",
                HtmlContent = $"You have been added to .<br/>{_urlRoot}{welcomeRoute}",
            };
            AddToUnsubscribe(msg);
            var response = await Send(msg, null, user);
        }
        public async Task SendExistingUserWelcomeEmail(User user, string welcomeRoute)
        {
            var msg = new SendGridMessage()
            {
                Subject = $"Welcome to ",
                PlainTextContent = $"You have been added to .\n{_urlRoot}{welcomeRoute}",
                HtmlContent = $"You have been added to .<br/>{_urlRoot}{welcomeRoute}",
            };
            AddToUnsubscribe(msg);
            var response = await Send(msg, null, user);
        }

        private void AttachEmbeddedImages(SendGridMessage message)
        {
            var html = message.HtmlContent;

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var imageNodes = htmlDoc.DocumentNode.Descendants("img");

            foreach (var node in imageNodes)
            {
                if (node.Attributes.Contains("src"))
                {
                    var src = node.Attributes["src"].Value;
                    if (src.StartsWith("data:image"))
                    {
                        continue;
                    }
                    else
                    {
                        Attachment attachment = new Attachment();
                        string fileName = src;
                        if (fileName.Contains("/"))
                        {
                            fileName = fileName.Substring(fileName.LastIndexOf("/") + 1);
                        }


                        if (src.StartsWith("/"))
                        {
                            if (src.StartsWith(_userFileRelativeUrl))
                            {
                                string path = Path.Combine(_userFilePath, fileName);
                                using (var fs = new FileStream(path, FileMode.Open))
                                {
                                    var bytes = new byte[fs.Length];
                                    fs.Read(bytes, 0, (int)fs.Length);
                                    attachment.Content = Convert.ToBase64String(bytes);
                                }
                            }
                            else
                            {
                                //another 
                                _logger.LogWarning("unrecognized local image url", src);
                            }
                        }
                        else if (src.StartsWith("http"))
                        {
                            using (var client = new WebClient())
                            {
                                var bytes = client.DownloadData(src);
                                attachment.Content = Convert.ToBase64String(bytes);
                            }
                        }
                        else
                        {
                            _logger.LogWarning("unknown image src format", src);
                            continue;
                        }

                        attachment.Disposition = "inline";
                        attachment.Filename = fileName;
                        attachment.ContentId = fileName;

                        node.SetAttributeValue("src", $"cid:{attachment.ContentId}");
                        message.AddAttachment(attachment);
                    }
                }
            }

            //set the modified html back o the message to update src's to cids
            message.HtmlContent = htmlDoc.DocumentNode.InnerHtml;
        }

        private async Task<Response> Send(SendGridMessage message,params User[] to)
        {
            SendGridClient client = new SendGridClient(new SendGridClientOptions()
            {
                ApiKey = _apiKey
            });
            message.From = new EmailAddress(_fromEmail, _fromName);

            //remove anybody that doesn't want notifications,dedup the to list
            to = to.Where(x=>x.AllowEmailNotifications).GroupBy(x => x.Email).Select(x => x.First()).ToArray();

            bool hasTo = false;
            if(!string.IsNullOrEmpty(_overrideTo))
            {
                if (to.Any(x => x.AllowEmailNotifications))
                {
                    if (_overrideTo != "nobody")
                    {
                        message.AddTo(new EmailAddress(_overrideTo, "Test User"));
                        hasTo = true;
                    }
                }
            }
            else
            {
                var filteredTo = new List<EmailAddress>();
                foreach(var email in to)
                {
                    if(email.Email.Contains("@"))
                    {
                        var domain = email.Email.Substring(email.Email.IndexOf("@") + 1);
                        if(!_urlRoot.Contains(domain))
                        {
                            filteredTo.Add(email.ToEmailAddress());
                        }
                    }
                }

                if (filteredTo.Count > 0)
                {
                    hasTo = true;
                    //remove any that have the same host as this app, since these are test users
                    if (filteredTo.Count > 1)
                    {
                        message.AddBccs(filteredTo.ToList());
                    }
                    else
                    {
                        message.AddTos(filteredTo.ToList());
                    }
                }
            }

            if (hasTo)
            {
                AttachEmbeddedImages(message);

                var response = await client.SendEmailAsync(message);

                if(response.StatusCode!=System.Net.HttpStatusCode.Accepted)
                {
                    throw new SendGridEmailException()
                    {
                        Body = await response.Body.ReadAsStringAsync(),
                        StatusCode = response.StatusCode
                    };
                }

                return response;
            }
            else
            {
                return null;
            }
        }

        private string GetToEmail(string email)
        {
            if(string.IsNullOrEmpty(_overrideTo))
            {
                return email;
            }
            else
            {
                return _overrideTo;
            }
        }

        private void AddOnBehalfOf(SendGridMessage message)
        {
            message.PlainTextContent += $"\n\nOn behalf of";
            message.HtmlContent += $"<br/><br/><em>On behalf of</em>";

            AddToUnsubscribe(message);
        }

        private void AddToUnsubscribe(SendGridMessage message)
        {
            message.PlainTextContent += $"\n\nTo disable email notifications visit {_urlRoot}{_profileRoute}";
            message.HtmlContent += $"<br/><br/>To disable email notifications visit <a href='{_urlRoot}{_profileRoute}'>{_urlRoot}{_profileRoute}<a>";
        }

    }
}
