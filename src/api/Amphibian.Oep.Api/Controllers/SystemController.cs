using Amphibian.Oep.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Controllers
{
    [ApiController]
    public class SystemController : ControllerBase
    {
        private OepApiConfiguration _configuration;

        public SystemController(OepApiConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("timezones")]
        public async Task<IActionResult> GetTimezones()
        {
            var timezones = TimeZoneInfo.GetSystemTimeZones().OrderBy(x=>x.StandardName).Select(x => new { value = x.Id, label = x.StandardName, offset = x.BaseUtcOffset.ToString() });
            return Ok(timezones);
        }

        [HttpGet]
        [Route("version")]
        public async Task<IActionResult> GetVersion()
        {
            return Ok(_configuration.Version);
        }
    }
}
