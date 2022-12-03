using System;

namespace Amphibian.Oep.Api.Models
{
    public class Cause
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public SnowSport SnowSport { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AcceptedAt { get; set; }
    }
}
