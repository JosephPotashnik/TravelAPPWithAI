using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Domain.Repositories
{
    /// <summary>
    /// Repository interface for User entity operations
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets a user by email
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <returns>The user if found, otherwise null</returns>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <returns>The user if found, otherwise null</returns>
        Task<User?> GetByUsernameAsync(string username);

        /// <summary>
        /// Checks if an email is already registered
        /// </summary>
        /// <param name="email">The email to check</param>
        /// <returns>True if the email is already in use, otherwise false</returns>
        Task<bool> EmailExistsAsync(string email);

        /// <summary>
        /// Checks if a username is already taken
        /// </summary>
        /// <param name="username">The username to check</param>
        /// <returns>True if the username is already in use, otherwise false</returns>
        Task<bool> UsernameExistsAsync(string username);

        /// <summary>
        /// Gets a user with their preference data loaded
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>The user with preference data if found, otherwise null</returns>
        Task<User?> GetWithPreferenceAsync(string userId);

        /// <summary>
        /// Gets users with a specific activity status
        /// </summary>
        /// <param name="isActive">The active status to filter by</param>
        /// <returns>Collection of users with the specified active status</returns>
        Task<System.Collections.Generic.IEnumerable<User>> GetByActiveStatusAsync(bool isActive);

        /// <summary>
        /// Updates the user's last login date
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>True if the update was successful, otherwise false</returns>
        Task<bool> UpdateLastLoginAsync(string userId);
    }
}