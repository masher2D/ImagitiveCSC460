using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Models
{
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the region of the user.
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public string Role { get; set; } = string.Empty;
    }
}
