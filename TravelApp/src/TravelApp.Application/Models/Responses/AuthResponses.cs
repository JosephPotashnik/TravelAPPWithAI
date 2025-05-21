using System;

namespace TravelApp.Application.Models.Responses
{
    /// <summary>
    /// Response model for successful authentication
    /// </summary>
    public class AuthSuccessResponse
    {
        /// <summary>
        /// JWT token for API authentication
        /// </summary>
        public string Token { get; set; } = string.Empty;
        
        /// <summary>
        /// Token expiration time
        /// </summary>
        public DateTime Expiration { get; set; }
        
        /// <summary>
        /// User ID of the authenticated user
        /// </summary>
        public string UserId { get; set; } = string.Empty;
        
        /// <summary>
        /// Username of the authenticated user
        /// </summary>
        public string Username { get; set; } = string.Empty;
        
        /// <summary>
        /// Email of the authenticated user
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// Response model for authentication operations
    /// </summary>
    public class AuthResponse
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
        /// Authentication data (if operation was successful)
        /// </summary>
        public AuthSuccessResponse? Data { get; set; }
    }
}