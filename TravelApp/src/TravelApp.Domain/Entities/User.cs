using System;
using System.Collections.Generic;
using TravelApp.Domain.Common;

namespace TravelApp.Domain.Entities
{
    /// <summary>
    /// User entity representing a registered user in the system
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Email address of the user, serves as unique identifier
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User's username or display name
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Hashed password for authentication
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Date when the user registered
        /// </summary>
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

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
        /// User's travel preferences
        /// </summary>
        public string PreferenceId { get; set; } = string.Empty;

        /// <summary>
        /// List of previous itineraries created by the user
        /// </summary>
        public List<string> ItineraryIds { get; set; } = new List<string>();

        /// <summary>
        /// Validates the user entity
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when validation fails</exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentException("Email cannot be empty", nameof(Email));

            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("Username cannot be empty", nameof(Username));

            if (string.IsNullOrWhiteSpace(PasswordHash))
                throw new ArgumentException("Password hash cannot be empty", nameof(PasswordHash));
        }

        /// <summary>
        /// Gets the full name of the user
        /// </summary>
        /// <returns>The full name (first name + last name)</returns>
        public string GetFullName()
        {
            return $"{FirstName} {LastName}".Trim();
        }
    }
}