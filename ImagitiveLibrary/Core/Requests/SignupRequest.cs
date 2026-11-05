using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class SignupRequest
    {
        /// <summary>
        /// The username for the new user.
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// The password for the new user.
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// The email for the new user.
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// The list of roles for the new user.
        /// </summary>
        public List<int> RoleIds { get; set; } = [];
    }
}
