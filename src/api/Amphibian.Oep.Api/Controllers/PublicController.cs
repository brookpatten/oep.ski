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
    public class PublicController : ControllerBase
    {
        private readonly ILogger<PublicController> _logger;
        private ISystemClock _clock;
        
        public PublicController(ILogger<PublicController> logger, ISystemClock systemClock)
        {
            _logger = logger;
            _clock = systemClock;
        }
    }
}
