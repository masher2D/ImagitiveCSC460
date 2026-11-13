using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("AdminRequests")]
    public class AdminRequestDBModel
    {
        /// <summary>
        /// Gets or sets the id for the request.
        /// </summary>
        [Key]
        public int RequestId { get; set; }
        /// <summary>
        /// Gets or sets the id of the requester.
        /// </summary>
        public int RequesterId { get; set; }
        /// <summary>
        /// Gets or sets the id of the requestee.
        /// </summary>
        public int RequesteeId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the date and time when the item was requested.
        /// </summary>
        public DateTime RequestedAt { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the item was resolved.
        /// </summary>
        public DateTime? ResolvedAt { get; set; }
        /// <summary>
        /// Gets or sets the id of the user who resolved the request.
        /// </summary>
        public int? ResolvedBy { get; set; }
        /// <summary>
        /// Gets or sets the action taken on the request.
        /// </summary>
        public string? ActionTaken { get; set; }
    }
}
