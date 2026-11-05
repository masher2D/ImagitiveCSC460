using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Responses
{
    public class LogInResponse
    {
        /// <summary>
        /// Indicates whether the operation or process succeeded.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the message associated with the login operation.
        /// </summary>
        public string Message { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the ID of the logged-in user.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the username of the logged-in user.
        /// </summary>
        public string Username { get; set; } = string.Empty;
    }
}
