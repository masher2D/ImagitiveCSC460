using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class SetUserStatusRequest
    {
        public required string Status { get; set; }
    }
}
