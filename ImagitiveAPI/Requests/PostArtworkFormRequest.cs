using Microsoft.AspNetCore.Http;
namespace ImagitiveAPI.Requests
{
    /// <summary>
    /// Represents a request to post artwork with form data.
    /// </summary>
    public class PostArtworkFormRequest
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Gets or sets the collection of tags.
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets the image file.
        /// </summary>
        public IFormFile ImageFile { get; set; } = null!;
    }
}