using System;

namespace TravelApp.Domain.Exceptions
{
    /// <summary>
    /// Base exception for all domain-specific exceptions
    /// </summary>
    public abstract class DomainException : Exception
    {
        /// <summary>
        /// Gets the error code associated with this exception
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Initializes a new instance of the DomainException class with a specified error code
        /// </summary>
        /// <param name="errorCode">The error code associated with this exception</param>
        protected DomainException(string errorCode) : base()
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the DomainException class with a specified error message and error code
        /// </summary>
        /// <param name="errorCode">The error code associated with this exception</param>
        /// <param name="message">The message that describes the error</param>
        protected DomainException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the DomainException class with a specified error message, error code, and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="errorCode">The error code associated with this exception</param>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        protected DomainException(string errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}