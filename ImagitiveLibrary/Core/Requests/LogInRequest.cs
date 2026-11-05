using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class LogInRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
