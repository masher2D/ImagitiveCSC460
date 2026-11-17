using System.ComponentModel.DataAnnotations;

namespace ImagitiveAPI.Models
{
    public class UserRoleDBModel
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        [Key]
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the role.
        /// </summary>
        [Key]
        public int RoleId { get; set; }
    }
}
