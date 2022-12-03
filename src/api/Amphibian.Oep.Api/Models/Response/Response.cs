using System;

namespace Amphibian.Oep.Api.Models
{
    public class Response
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int VideoId { get; set; }
        public string Comments { get; set; }
    }
}
