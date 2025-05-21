using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Preference entity operations
    /// </summary>
    public interface IPreferenceRepository : IRepository<Preference>
    {
        /// <summary>
        /// Gets preferences by user ID
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>The user's preferences if found, otherwise null</returns>
        Task<Preference?> GetByUserIdAsync(string userId);
    }
}