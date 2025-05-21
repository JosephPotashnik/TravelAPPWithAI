using System;

namespace TravelApp.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when an entity is not found
    /// </summary>
    public class EntityNotFoundException : DomainException
    {
        /// <summary>
        /// Gets the name of the entity type that was not found
        /// </summary>
        public string EntityType { get; }

        /// <summary>
        /// Gets the identifier of the entity that was not found
        /// </summary>
        public string EntityId { get; }

        /// <summary>
        /// Initializes a new instance of the EntityNotFoundException class with specified entity type and ID
        /// </summary>
        /// <param name="entityType">The name of the entity type that was not found</param>
        /// <param name="entityId">The identifier of the entity that was not found</param>
        public EntityNotFoundException(string entityType, string entityId)
            : base(DomainErrorCodes.EntityNotFound, $"{entityType} with ID '{entityId}' was not found.")
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        /// <summary>
        /// Initializes a new instance of the EntityNotFoundException class with a custom message
        /// </summary>
        /// <param name="entityType">The name of the entity type that was not found</param>
        /// <param name="entityId">The identifier of the entity that was not found</param>
        /// <param name="message">The custom error message</param>
        public EntityNotFoundException(string entityType, string entityId, string message)
            : base(DomainErrorCodes.EntityNotFound, message)
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        /// <summary>
        /// Initializes a new instance of the EntityNotFoundException class with a custom message and inner exception
        /// </summary>
        /// <param name="entityType">The name of the entity type that was not found</param>
        /// <param name="entityId">The identifier of the entity that was not found</param>
        /// <param name="message">The custom error message</param>
        /// <param name="innerException">The inner exception</param>
        public EntityNotFoundException(string entityType, string entityId, string message, Exception innerException)
            : base(DomainErrorCodes.EntityNotFound, message, innerException)
        {
            EntityType = entityType;
            EntityId = entityId;
        }
    }
}