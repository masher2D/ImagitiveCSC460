using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("Tags")]
    public class TagDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the tag.
        /// </summary>
        [Key]
        public int TagId { get; set; }
        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets a value indicating whether the tag is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
