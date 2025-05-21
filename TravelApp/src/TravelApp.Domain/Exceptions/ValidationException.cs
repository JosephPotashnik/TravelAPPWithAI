using System;
using System.Collections.Generic;

namespace TravelApp.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when domain validation fails
    /// </summary>
    public class ValidationException : DomainException
    {
        /// <summary>
        /// Gets the collection of validation errors
        /// </summary>
        public IDictionary<string, string[]> Errors { get; }

        /// <summary>
        /// Initializes a new instance of the ValidationException class with a validation error
        /// </summary>
        /// <param name="propertyName">The name of the property that failed validation</param>
        /// <param name="errorMessage">The validation error message</param>
        public ValidationException(string propertyName, string errorMessage)
            : base(DomainErrorCodes.ValidationFailed, "One or more validation errors occurred.")
        {
            Errors = new Dictionary<string, string[]>
            {
                { propertyName, new[] { errorMessage } }
            };
        }

        /// <summary>
        /// Initializes a new instance of the ValidationException class with multiple validation errors
        /// </summary>
        /// <param name="errors">The dictionary of validation errors</param>
        public ValidationException(IDictionary<string, string[]> errors)
            : base(DomainErrorCodes.ValidationFailed, "One or more validation errors occurred.")
        {
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the ValidationException class with a custom message
        /// </summary>
        /// <param name="message">The custom error message</param>
        /// <param name="errors">The dictionary of validation errors</param>
        public ValidationException(string message, IDictionary<string, string[]> errors)
            : base(DomainErrorCodes.ValidationFailed, message)
        {
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the ValidationException class with a custom message and inner exception
        /// </summary>
        /// <param name="message">The custom error message</param>
        /// <param name="errors">The dictionary of validation errors</param>
        /// <param name="innerException">The inner exception</param>
        public ValidationException(string message, IDictionary<string, string[]> errors, Exception innerException)
            : base(DomainErrorCodes.ValidationFailed, message, innerException)
        {
            Errors = errors;
        }
    }
}