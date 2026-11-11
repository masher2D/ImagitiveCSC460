using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Responses
{
    public class APIResponse<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation completed successfully.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T? Data { get; set; }
    }

}
