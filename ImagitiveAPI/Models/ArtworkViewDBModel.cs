using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("ArtworkViews")]
    public class ArtworkViewDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the view.
        /// </summary>
        [Key]
        public int ViewId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the artwork.
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the viewer.
        /// </summary>
        public int ViewerId { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the artwork was viewed.
        /// </summary>
        public DateTime ViewedAt { get; set; }
    }
}
