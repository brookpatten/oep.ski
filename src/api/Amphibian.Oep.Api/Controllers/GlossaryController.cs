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
    public class GlossaryController : ControllerBase
    {
        private IGlossaryRepository _glossaryRepository;
        ILogger<GlossaryController> _logger;
        
        public GlossaryController(ILogger<GlossaryController> logger, IGlossaryRepository glossaryRepository)
        {
            _logger = logger;
            _glossaryRepository = glossaryRepository;
        }

        [HttpGet]
        [Route("glossary/snowsports")]
        public async Task<IActionResult> SnowSports()
        {
            return Ok(await _glossaryRepository.GetSnowSports());
        }
    }
}
