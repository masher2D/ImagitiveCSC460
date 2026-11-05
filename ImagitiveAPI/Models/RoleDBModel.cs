namespace ImagitiveAPI.Models
{
    public class RoleDBModel
    {
        /// <summary>
        /// The ID of the role.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// The name of the role.
        /// </summary>
        public string RoleName { get; set; } = string.Empty;
    }
}
