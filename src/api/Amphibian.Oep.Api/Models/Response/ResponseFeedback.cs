using System;

namespace Amphibian.Oep.Api.Models
{
    public class ResponseFeedback
    {
        public int Id { get; set; }
        public int ResponseId { get; set; }
        public bool ThumbsUp { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
