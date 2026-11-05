using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("Artworks")]
    public class ArtworkDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the artwork.
        /// </summary>
        [Key]
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
        public string ImageURL { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the URL of the artwork's compressed image.
        /// </summary>
        public string CompressedURL { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the URL of the artwork's watermarked image.
        /// </summary>
        public string WatermarkedURL { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the ID of the user who created the artwork.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the number of times the item has been viewed.
        /// </summary>
        public int ViewCount { get; set; }
        /// <summary>
        /// Gets or sets the number of boost views remaining.
        /// </summary>
        public int BoostViewsRemaining { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the artwork was uploaded.
        /// </summary>
        public DateTime UploadDate { get; set; } 
        /// <summary>
        /// Gets or sets a value indicating whether the artwork is removed.
        /// </summary>
        public bool isRemoved { get; set; }
        /// <summary>
        /// Gets or sets the reason why the artwork was removed.
        /// </summary>
        public int? RemovedReason { get; set; }

    }
}
