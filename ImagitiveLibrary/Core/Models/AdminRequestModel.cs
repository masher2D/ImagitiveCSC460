using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Models
{
    public class AdminRequestModel
    {
        public int RequestId { get; set; }
        public int RequesterId { get; set; }
        public int RequesteeId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime RequestedAt { get; set; }

        public DateTime? ResolvedAt { get; set; }
    }
}
