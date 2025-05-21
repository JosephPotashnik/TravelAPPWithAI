using System;

namespace TravelApp.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when an operation is not allowed
    /// </summary>
    public class OperationNotAllowedException : DomainException
    {
        /// <summary>
        /// Gets the user ID that attempted the operation
        /// </summary>
        public string? UserId { get; }

        /// <summary>
        /// Gets the operation that was attempted
        /// </summary>
        public string Operation { get; }

        /// <summary>
        /// Initializes a new instance of the OperationNotAllowedException class
        /// </summary>
        /// <param name="operation">The operation that was attempted</param>
        public OperationNotAllowedException(string operation)
            : base(DomainErrorCodes.UnauthorizedOperation, $"Operation not allowed: {operation}")
        {
            Operation = operation;
        }

        /// <summary>
        /// Initializes a new instance of the OperationNotAllowedException class with user ID
        /// </summary>
        /// <param name="userId">The user ID that attempted the operation</param>
        /// <param name="operation">The operation that was attempted</param>
        public OperationNotAllowedException(string userId, string operation)
            : base(DomainErrorCodes.UnauthorizedOperation, $"User '{userId}' is not allowed to perform operation: {operation}")
        {
            UserId = userId;
            Operation = operation;
        }
    }
}