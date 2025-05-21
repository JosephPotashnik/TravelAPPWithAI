using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelApp.Domain.Common;

namespace TravelApp.Domain.Repositories
{
    /// <summary>
    /// Generic repository interface for data access operations
    /// </summary>
    /// <typeparam name="T">Entity type that inherits from Entity</typeparam>
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Gets an entity by its identifier
        /// </summary>
        /// <param name="id">The entity identifier</param>
        /// <returns>The entity if found, otherwise null</returns>
        Task<T?> GetByIdAsync(string id);

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>A collection of all entities</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Finds entities that match the specified expression
        /// </summary>
        /// <param name="expression">The filter expression</param>
        /// <returns>A collection of entities that match the expression</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The added entity</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns>The updated entity</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Removes an entity
        /// </summary>
        /// <param name="id">The identifier of the entity to remove</param>
        /// <returns>True if the entity was removed, otherwise false</returns>
        Task<bool> RemoveAsync(string id);

        /// <summary>
        /// Checks if an entity with the specified expression exists
        /// </summary>
        /// <param name="expression">The expression to check</param>
        /// <returns>True if at least one entity exists, otherwise false</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Gets the count of entities that match the specified expression
        /// </summary>
        /// <param name="expression">The filter expression</param>
        /// <returns>The count of matching entities</returns>
        Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);
    }
}