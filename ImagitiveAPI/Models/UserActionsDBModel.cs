using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("UserActions")]
    public class UserActionsDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the action.
        /// </summary>
        [Key]
        public int ActionId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the admin.
        /// </summary>
        public int AdminId { get; set; }
        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        public string ActionType { get; set; }
        /// <summary>
        /// Gets or sets the ID of the reason.
        /// </summary>
        public int ReasonId { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the action was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
