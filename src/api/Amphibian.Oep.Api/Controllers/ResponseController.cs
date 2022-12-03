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

namespace Amphibian.Oep.Api.Controllers
{
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private IResponseRepository _responseRepository;
        private IResponseService _responseService;
        ILogger<ResponseController> _logger;
        
        public ResponseController(ILogger<ResponseController> logger, IResponseRepository responseRepository, IResponseService responseService)
        {
            _logger = logger;
            _responseRepository = responseRepository;
            _responseService = responseService;
        }

        [HttpGet]
        [Route("response/search")]
        public async Task<IActionResult> Search(SnowSport snowSport,int? userId,string orderBy)
        {
            return Ok();
        }

        [HttpGet]
        [Route("response")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("response")]
        [Authorize]
        public async Task<IActionResult> Create(ResponseDto response)
        {
            return Ok();
        }

        [HttpPut]
        [Route("response")]
        [Authorize]
        public async Task<IActionResult> Update(ResponseDto response)
        {
            return Ok();
        }

        [HttpPost]
        [Route("response/feedback")]
        [Authorize]
        public async Task<IActionResult> LeaveFeedback(int responseId, bool thumbsUp)
        {
            return Ok();
        }
    }
}
