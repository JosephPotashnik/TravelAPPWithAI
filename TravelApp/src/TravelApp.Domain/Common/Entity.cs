using System;

namespace TravelApp.Domain.Common
{
    /// <summary>
    /// Base class for all domain entities
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Unique identifier for the entity
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Date and time when the entity was created
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Date and time when the entity was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Checks if the entity is new (not yet persisted)
        /// </summary>
        public bool IsNew() => string.IsNullOrEmpty(Id);

        /// <summary>
        /// Equality comparison based on entity Id
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
                return false;

            var other = (Entity)obj;

            if (IsNew() || other.IsNew())
                return ReferenceEquals(this, other);

            return Id == other.Id;
        }

        /// <summary>
        /// GetHashCode implementation based on entity Id
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Equality operator for entities
        /// </summary>
        public static bool operator ==(Entity? left, Entity? right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator for entities
        /// </summary>
        public static bool operator !=(Entity? left, Entity? right)
        {
            return !(left == right);
        }
    }
}