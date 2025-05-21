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
        /// <param name="isEmail">Flag to indicate searching by email</param>
        public UserNotFoundException(string email, bool isEmail)
            : base("User", email, $"User with email '{email}' was not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the UserNotFoundException class with a custom message
        /// </summary>
        /// <param name="message">The custom error message</param>
        /// <param name="identifier">The identifier used to search for the user</param>
        public UserNotFoundException(string message, string identifier)
            : base("User", identifier, message)
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