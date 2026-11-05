using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class UpdatePasswordRequest
    {
        /// <summary>
        /// The ID of the user whose password is being updated.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// The current password of the user, used for verification before updating to a new password.
        /// </summary>
        public string CurrentPassword { get; set; } = string.Empty;
        /// <summary>
        /// The new password that the user wants to set. This should be different from the current password and meet any security requirements set by the application.
        /// </summary>
        public string NewPassword { get; set; } = string.Empty;
    }
}
