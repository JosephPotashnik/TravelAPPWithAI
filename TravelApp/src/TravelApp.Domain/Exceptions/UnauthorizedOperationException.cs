using System;

namespace TravelApp.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when a user is not authorized to perform an operation
    /// </summary>
    public class UnauthorizedOperationException : DomainException
    {
        /// <summary>
        /// Gets the user ID that attempted the unauthorized operation
        /// </summary>
        public string? UserId { get; }

        /// <summary>
        /// Gets the operation that was attempted
        /// </summary>
        public string Operation { get; }

        /// <summary>
        /// Initializes a new instance of the UnauthorizedOperationException class
        /// </summary>
        /// <param name="operation">The operation that was attempted</param>
        public UnauthorizedOperationException(string operation)
            : base(DomainErrorCodes.UnauthorizedOperation, $"Unauthorized operation: {operation}")
        {
            Operation = operation;
        }

        /// <summary>
        /// Initializes a new instance of the UnauthorizedOperationException class with user ID
        /// </summary>
        /// <param name="userId">The user ID that attempted the unauthorized operation</param>
        /// <param name="operation">The operation that was attempted</param>
        public UnauthorizedOperationException(string userId, string operation)
            : base(DomainErrorCodes.UnauthorizedOperation, $"User '{userId}' is not authorized to perform operation: {operation}")
        {
            UserId = userId;
            Operation = operation;
        }
    }
}