using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("Ratings")]
    public class RatingDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the user who rated the artwork.
        /// </summary>
        [Key]
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the artwork being rated.
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the rating given by the user.
        /// </summary>
        public byte RateValue { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the artwork was rated.
        /// </summary>
        public DateTime RatedAt { get; set; }
    }
}
