using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("Reasons")]
    public class ReasonDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the reason.
        /// </summary>
        [Key]
        public int ReasonId { get; set; }
        /// <summary>
        /// Gets or sets the name of the reason.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets a value indicating whether the reason is active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; }
    }
}
