using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Responses
{
    public class PagedResponse<T>
    {
        /// <summary>
        /// Gets or sets the items in the collection.
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();
        /// <summary>
        /// Gets or sets the total number of items.
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Gets the total number of pages required to represent all items.
        /// </summary>
        public int TotalPages =>(int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
