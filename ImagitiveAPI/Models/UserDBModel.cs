using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagitiveAPI.Models
{
    [Table("Users")]
    public class UserDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        [Key]
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the region of the user.
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// Gets or sets the account status of the user.
        /// </summary>
        public string AccountStatus { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the user was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the user's account is restricted until.
        /// </summary>
        public DateTime RestrictedUntil { get; set; }
        /// <summary>
        /// Gets or sets the biography of the user.
        /// </summary>
        public string? Bio { get; set; }
    }
}
