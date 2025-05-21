using System.ComponentModel.DataAnnotations;

namespace TravelApp.Application.Models.Requests
{
    /// <summary>
    /// Request model for user registration
    /// </summary>
    public class RegisterUserRequest
    {
        /// <summary>
        /// Email address for the new user
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Username for the new user
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;
        
        /// <summary>
        /// Password for the new user
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", 
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string Password { get; set; } = string.Empty;
        
        /// <summary>
        /// First name of the user (optional)
        /// </summary>
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        /// <summary>
        /// Last name of the user (optional)
        /// </summary>
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// Request model for user login
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Email address for authentication
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// User password for authentication
        /// </summary>
        [Required]
        public string Password { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// Request model for updating user profile information
    /// </summary>
    public class UpdateUserProfileRequest
    {
        /// <summary>
        /// Username to update
        /// </summary>
        [StringLength(50, MinimumLength = 3)]
        public string? Username { get; set; }
        
        /// <summary>
        /// First name to update
        /// </summary>
        [StringLength(50)]
        public string? FirstName { get; set; }
        
        /// <summary>
        /// Last name to update
        /// </summary>
        [StringLength(50)]
        public string? LastName { get; set; }
        
        /// <summary>
        /// User's profile picture URL
        /// </summary>
        [Url]
        public string? ProfilePictureUrl { get; set; }
        
        /// <summary>
        /// User's preferred locale for internationalization
        /// </summary>
        [RegularExpression(@"^[a-z]{2}-[A-Z]{2}$", ErrorMessage = "Locale must be in format 'xx-XX'")]
        public string? Locale { get; set; }
        
        /// <summary>
        /// User's timezone
        /// </summary>
        public string? TimeZone { get; set; }
    }
    
    /// <summary>
    /// Request model for changing user password
    /// </summary>
    public class ChangePasswordRequest
    {
        /// <summary>
        /// Current password for verification
        /// </summary>
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;
        
        /// <summary>
        /// New password to set
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", 
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string NewPassword { get; set; } = string.Empty;
        
        /// <summary>
        /// Confirmation of new password
        /// </summary>
        [Required]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}