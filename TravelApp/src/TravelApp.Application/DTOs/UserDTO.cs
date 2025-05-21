
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelApp.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for User entity
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Unique identifier for the user
        /// </summary>
        public string Id { get; set; } = string.Empty;
        
        /// <summary>
        /// Email address of the user, serves as unique identifier
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// User's username or display name
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;
        
        /// <summary>
        /// User's first name
        /// </summary>
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        /// <summary>
        /// User's last name
        /// </summary>
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        /// <summary>
        /// Date when the user registered
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        
        /// <summary>
        /// Date of the user's last login
        /// </summary>
        public DateTime? LastLoginDate { get; set; }
        
        /// <summary>
        /// User's profile picture URL
        /// </summary>
        public string ProfilePictureUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Flag indicating if the user's email has been verified
        /// </summary>
        public bool IsEmailVerified { get; set; }
        
        /// <summary>
        /// Flag indicating if the user account is active
        /// </summary>
        public bool IsActive { get; set; } = true;
        
        /// <summary>
        /// User's preferred locale for internationalization
        /// </summary>
        public string Locale { get; set; } = "en-US";
        
        /// <summary>
        /// User's timezone
        /// </summary>
        public string TimeZone { get; set; } = "UTC";
        
        /// <summary>
        /// User's travel preferences ID
        /// </summary>
        public string PreferenceId { get; set; } = string.Empty;
        
        /// <summary>
        /// List of IDs for itineraries created by the user
        /// </summary>
        public List<string> ItineraryIds { get; set; } = new List<string>();
        
        /// <summary>
        /// Gets the full name of the user
        /// </summary>
        /// <returns>The full name (first name + last name)</returns>
        public string GetFullName()
        {
            return $"{FirstName} {LastName}".Trim();
        }
        
        /// <summary>
        /// Date and time when the entity was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Date and time when the entity was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}