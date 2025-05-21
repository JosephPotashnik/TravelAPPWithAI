using System;

namespace TravelApp.Domain.Exceptions.User
{
    /// <summary>
    /// Exception thrown when user credentials are invalid
    /// </summary>
    public class InvalidCredentialsException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the InvalidCredentialsException class
        /// </summary>
        public InvalidCredentialsException()
            : base(DomainErrorCodes.InvalidCredentials, "Invalid email or password.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the InvalidCredentialsException class with a custom message
        /// </summary>
        /// <param name="message">The custom error message</param>
        public InvalidCredentialsException(string message)
            : base(DomainErrorCodes.InvalidCredentials, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InvalidCredentialsException class with a custom message and inner exception
        /// </summary>
        /// <param name="message">The custom error message</param>
        /// <param name="innerException">The inner exception</param>
        public InvalidCredentialsException(string message, Exception innerException)
            : base(DomainErrorCodes.InvalidCredentials, message, innerException)
        {
        }
    }
}