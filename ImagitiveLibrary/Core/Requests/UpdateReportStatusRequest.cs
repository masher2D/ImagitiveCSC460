using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class UpdateReportStatusRequest
    {
        public required string NewStatus { get; set; }
    }
}
