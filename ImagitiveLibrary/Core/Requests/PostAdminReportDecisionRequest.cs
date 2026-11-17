using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class PostAdminReportDecisionRequest
    {
        public int RequestId { get; set; }
        public string Decision { get; set; } = string.Empty;
        public DateTime? RestrictedUntil { get; set; }
    }
}
