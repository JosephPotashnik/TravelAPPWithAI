using System.Collections.Generic;

namespace TravelApp.Application.Models.Responses
{
    /// <summary>
    /// Generic API response model for consistent response format
    /// </summary>
    /// <typeparam name="T">Type of data returned</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Flag indicating if the operation was successful
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Message providing additional information about the operation
        /// </summary>
        public string Message { get; set; } = string.Empty;
        
        /// <summary>
        /// Response data (if operation was successful)
        /// </summary>
        public T? Data { get; set; }
        
        /// <summary>
        /// List of errors (if operation failed)
        /// </summary>
        public List<string>? Errors { get; set; }
        
        /// <summary>
        /// Create a successful response with data
        /// </summary>
        /// <param name="data">Response data</param>
        /// <param name="message">Optional success message</param>
        /// <returns>API response object</returns>
        public static ApiResponse<T> CreateSuccess(T data, string message = "Operation completed successfully")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }
        
        /// <summary>
        /// Create a failure response with optional error messages
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="errors">List of detailed errors</param>
        /// <returns>API response object</returns>
        public static ApiResponse<T> CreateFailure(string message, List<string>? errors = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}