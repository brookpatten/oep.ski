using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Amphibian.Oep.Api.Repositories;
using Amphibian.Oep.Api.Models;
using Amphibian.Oep.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Amphibian.Oep.Api.Extensions;
using Amphibian.Oep.Api.Dtos;
using Amphibian.Oep.Api.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Amphibian.Oep.Configuration;

namespace Amphibian.Oep.Api.Controllers
{
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly ILogger<FileUploadController> _logger;
        private readonly IFileUploadRepository _imageUploadRepository;
        private readonly string _imageRelativeUrl;

        public FileUploadController(ILogger<FileUploadController> logger, IFileUploadRepository imageUploadRepository, AppConfiguration appConfiguration)
        {
            _logger = logger;
            _imageUploadRepository = imageUploadRepository;
            _imageRelativeUrl = appConfiguration.UserFileRelativeUrl;
        }

        public class FileUpload
        {
            public int? PatrolId { get; set; }
            public IFormFile FormFile { get; set; }
        }
        [HttpPost]
        [Route("file/upload")]
        [Authorize]
        public async Task<IActionResult> UploadFile([FromForm]FileUpload file)
        {
            //if (/*some condition*/)
            //{
            //    var record = await _imageUploadRepository.PersistUpload(file.FormFile, User.UserId(), file.PatrolId);

            //    var relativeUrl = _imageRelativeUrl + "/" + record.GetUniqueName();

            //    return Ok(new
            //    {
            //        Size = record.FileSize,
            //        RelativeUrl = relativeUrl,
            //        Id = record.Id,
            //        Name = record.Name
            //    });
            //}
            //else
            //{
            //    return Forbid();
            //}
            return Forbid();
        }
    }
}
