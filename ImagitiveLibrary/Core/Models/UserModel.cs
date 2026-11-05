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
        public int UserId { get; set; } 
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the region of the user.
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// Gets or sets the roles of the user.
        /// </summary>
        public List<string> Roles { get; set; } = new List<string>();
    }
}
