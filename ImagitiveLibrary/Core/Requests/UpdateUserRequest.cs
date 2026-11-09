using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class UpdateUserRequest
    {
        

        /// <summary>
        /// The updated username for the user.
        /// </summary>
        public string? Username { get; set; } = string.Empty;

        /// <summary>
        /// The updated email for the user.
        /// </summary>
        public string? Email { get; set; } = string.Empty;

        /// <summary>
        /// The updated region ID for the user.
        /// </summary>
        public int? RegionId { get; set; }

        /// <summary>
        /// The current password of the user, required for authentication when updating sensitive information.
        /// </summary>
        public string CurrentPassword { get; set; } = string.Empty;
    }
}

