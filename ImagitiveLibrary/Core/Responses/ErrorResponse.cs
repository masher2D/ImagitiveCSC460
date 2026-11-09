using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Responses
{
    public class ErrorResponse
    {
        /// <summary>
        /// The error message associated with the response.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
