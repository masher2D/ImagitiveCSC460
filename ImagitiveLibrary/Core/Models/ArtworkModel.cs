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
        public int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the title of the artwork.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the description of the artwork.
        /// </summary>
        public string? Description { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the URL of the artwork's image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the compressed URL.
        /// </summary>
        public string CompressedUrl { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the watermarked URL.
        /// </summary>
        public string WatermarkedUrl { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the ID of the user who created the artwork.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the artwork was uploaded.
        /// </summary>
        public DateTime UploadDate { get; set; }
        /// <summary>
        /// Gets or sets the number of times the item has been viewed.
        /// </summary>
        public int ViewCount { get; set; }
        /// <summary>
        /// Gets or sets the average rating of the artwork.
        /// </summary>
        public double AverageRateValue { get; set; }
        /// <summary>
        /// Gets or sets the list of tags associated with the artwork.
        /// </summary>
        public List<string> Tags { get; set; } = [];

    }
}
