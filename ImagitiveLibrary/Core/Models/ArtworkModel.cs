using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Models
{
    public class ArtworkModel
    {
        /// <summary>
        /// Gets or sets the ID of the artwork.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the title of the artwork.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description of the artwork.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the URL of the artwork's image.
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Gets or sets the ID of the user who created the artwork.
        /// </summary>
        public int UserId { get; set; }

    }
}
