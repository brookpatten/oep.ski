using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Models
{
    public class Token
    {
        public int Id { get; set; }
        public Guid TokenGuid { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastRequestAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public DateTime? SupersededAt { get; set; }
    }
}
