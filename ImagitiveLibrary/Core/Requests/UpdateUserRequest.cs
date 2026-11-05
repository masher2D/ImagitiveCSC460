using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class UpdateUserRequest
    {
        /// <summary>
        /// The Id of the user to be updated.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The updated username for the user.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// The updated email for the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The updated region ID for the user.
        /// </summary>
        public int? RegionId { get; set; }
    }
}
