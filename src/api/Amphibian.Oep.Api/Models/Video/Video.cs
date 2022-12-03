using System;
using System.Collections.Generic;

namespace Amphibian.Oep.Api.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string VideoProvider { get; set; }
        public string VideoProviderKey { get; set; }
        public string Title { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public SnowSport SnowSport { get; set; }
    }
}
