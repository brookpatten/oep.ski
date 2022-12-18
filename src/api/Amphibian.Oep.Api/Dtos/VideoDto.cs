using Amphibian.Oep.Api.Models;
using System.Collections.Generic;

namespace Amphibian.Oep.Api.Dtos
{
    public class VideoDto:Video
    {
        public List<TimeCode> TimeCodes { get; set; }
    }
}
