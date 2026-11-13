using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class PostAdminPromoteRequest
    {
        /// <summary>
        /// Gets or sets the id of the requestee.
        /// </summary>
        public int RequesteeId { get; set; }
        /// <summary>
        /// Gets or sets the description of why the request is being made.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
