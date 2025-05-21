using System;

namespace TravelApp.Domain.Exceptions.User
{
    /// <summary>
    /// Exception thrown when a user is not found
    /// </summary>
    public class UserNotFoundException : EntityNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the UserNotFoundException class with a user ID
        /// </summary>
        /// <param name="userId">The ID of the user that was not found</param>
        public UserNotFoundException(string userId)
            : base("User", userId, $"User with ID '{userId}' was not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the UserNotFoundException class with an email
        /// </summary>
        /// <param name="email">The email of the user that was not found</param>
        /// <param name="searchByEmail">Flag to indicate searching by email</param>
        public UserNotFoundException(string email, bool searchByEmail)
            : base("User", email, $"User with email '{email}' was not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the UserNotFoundException class with a username
        /// </summary>
        /// <param name="username">The username of the user that was not found</param>
        /// <param name="searchByUsername">Flag to indicate searching by username</param>
        public UserNotFoundException(string username, bool searchByUsername)
            : base("User", username, $"User with username '{username}' was not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the UserNotFoundException class with a custom message
        /// </summary>
        /// <param name="message">The custom error message</param>
        public UserNotFoundException(string message)
            : base("User", "unknown", message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the UserNotFoundException class with a custom message and inner exception
        /// </summary>
        /// <param name="message">The custom error message</param>
        /// <param name="innerException">The inner exception</param>
        public UserNotFoundException(string message, Exception innerException)
            : base("User", "unknown", message, innerException)
        {
        }
    }
}