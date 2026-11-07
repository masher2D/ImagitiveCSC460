using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{

    public class PostArtworkRequest
    {
        /// <summary>
        /// The ID of the user creating the artwork.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// The title of the artwork.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// The description of the artwork.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// The tags associated with the artwork.
        /// </summary>
        public List<string> Tags { get; set; } = [];

    }
}
