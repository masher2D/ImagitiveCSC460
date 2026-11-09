namespace ImagitiveAPI.Session
{
    public static class UserSession
    {
        /// <summary>
        /// The JWT Token associated with the current user session.
        /// </summary>
        public static string JwtToken { get; set; } = string.Empty;
        /// <summary>
        /// The ID of the current user.
        /// </summary>
        public static int UserId { get; set; }
        /// <summary>
        /// The username of the current user.
        /// </summary>
        public static string Username { get; set; } = string.Empty;
        /// <summary>
        /// The roles of the current user.
        /// </summary>
        public static List<string> Roles { get; set; } = [];
        /// <summary>
        /// The currently active role of the user in the session. This can be used to determine the user's permissions and access level within the application.
        /// </summary>
        public static string ActiveRole { get; set; } = string.Empty;
    }
}
