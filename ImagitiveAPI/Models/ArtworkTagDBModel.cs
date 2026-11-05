using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("ArtworkTags")]
    public class ArtworkTagDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the artwork.
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the tag.
        /// </summary>
        public int TagId { get; set; }
    }
}
