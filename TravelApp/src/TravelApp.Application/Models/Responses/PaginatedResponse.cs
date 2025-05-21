using System.Collections.Generic;

namespace TravelApp.Application.Models.Responses
{
    /// <summary>
    /// Generic paginated response model for list operations
    /// </summary>
    /// <typeparam name="T">Type of items in the collection</typeparam>
    public class PaginatedResponse<T>
    {
        /// <summary>
        /// Current page number
        /// </summary>
        public int PageNumber { get; set; }
        
        /// <summary>
        /// Number of items per page
        /// </summary>
        public int PageSize { get; set; }
        
        /// <summary>
        /// Total number of items across all pages
        /// </summary>
        public int TotalCount { get; set; }
        
        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages { get; set; }
        
        /// <summary>
        /// Collection of items for the current page
        /// </summary>
        public IEnumerable<T> Items { get; set; } = new List<T>();
        
        /// <summary>
        /// Flag indicating if there is a previous page
        /// </summary>
        public bool HasPrevious => PageNumber > 1;
        
        /// <summary>
        /// Flag indicating if there is a next page
        /// </summary>
        public bool HasNext => PageNumber < TotalPages;
    }
    
    /// <summary>
    /// API response wrapper for paginated data
    /// </summary>
    /// <typeparam name="T">Type of items in the collection</typeparam>
    public class PaginatedApiResponse<T> : ApiResponse<PaginatedResponse<T>>
    {
        /// <summary>
        /// Create a successful paginated response
        /// </summary>
        /// <param name="data">Paginated data</param>
        /// <param name="message">Optional success message</param>
        /// <returns>API response with paginated data</returns>
        public new static PaginatedApiResponse<T> CreateSuccess(PaginatedResponse<T> data, string message = "Data retrieved successfully")
        {
            return new PaginatedApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }
    }
}