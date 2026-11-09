using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("Regions")]
    public class RegionDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the region.
        /// </summary>
        [Key]
        public int RegionId { get; set; }
        /// <summary>
        /// Gets or sets the name of the region.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets a value indicating whether the region is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
