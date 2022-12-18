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
    public class VideoController : ControllerBase
    {
        private IVideoRepository _videoRepository;
        private IVideoService _videoService;
        ILogger<VideoController> _logger;
        
        public VideoController(ILogger<VideoController> logger, IVideoRepository videoRepository, IVideoService videoService)
        {
            _logger = logger;
            _videoRepository = videoRepository;
            _videoService = videoService;
        }

        [HttpGet]
        [Route("video/search")]
        public async Task<IActionResult> Search(int? snowSportId,int? userId,string orderBy)
        {
            return Ok();
        }

        [HttpGet]
        [Route("video/recent")]
        public async Task<IActionResult> Recent(int snowSportId, int count = 6)
        {
            return Ok(await _videoRepository.GetRecentVideos(snowSportId, count));
        }

        [HttpGet]
        [Route("video/popular")]
        public async Task<IActionResult> Popular(int snowSportId, int count = 6)
        {
            return Ok(await _videoRepository.GetPopularVideos(snowSportId, count));
        }

        [HttpPost]
        [Route("video")]
        [Authorize]
        public async Task<IActionResult> Create(VideoDto video)
        {
            return Ok();
        }

        [HttpPut]
        [Route("video")]
        [Authorize]
        public async Task<IActionResult> Update(VideoDto video)
        {
            return Ok();
        }

        [HttpPut]
        [Route("video/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }
    }
}
