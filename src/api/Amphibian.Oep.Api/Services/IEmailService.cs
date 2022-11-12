using Amphibian.Oep.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Services
{
    public interface IEmailService
    {
        //registration/authentication
        Task SendRegistrationEmail(User user);
        Task SendResetEmail(User user, string resetRoute);
        Task SendNewUserWelcomeEmail(User user, string welcomeRoute);
        Task SendExistingUserWelcomeEmail(User user, string welcomeRoute);
    }
}
