using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Destination entity operations
    /// </summary>
    public interface IDestinationRepository : IRepository<Destination>
    {
        /// <summary>
        /// Gets destinations by name (partial match)
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <returns>Collection of destinations with matching names</returns>
        Task<IEnumerable<Destination>> SearchByNameAsync(string name);

        /// <summary>
        /// Gets destinations by type
        /// </summary>
        /// <param name="type">The destination type</param>
        /// <returns>Collection of destinations of the specified type</returns>
        Task<IEnumerable<Destination>> GetByTypeAsync(DestinationType type);

        /// <summary>
        /// Gets destinations by category
        /// </summary>
        /// <param name="category">The destination category</param>
        /// <returns>Collection of destinations in the specified category</returns>
        Task<IEnumerable<Destination>> GetByCategoryAsync(DestinationCategory category);

        /// <summary>
        /// Gets destinations by country
        /// </summary>
        /// <param name="country">The country</param>
        /// <returns>Collection of destinations in the specified country</returns>
        Task<IEnumerable<Destination>> GetByCountryAsync(string country);

        /// <summary>
        /// Gets destinations by city
        /// </summary>
        /// <param name="city">The city</param>
        /// <returns>Collection of destinations in the specified city</returns>
        Task<IEnumerable<Destination>> GetByCityAsync(string city);

        /// <summary>
        /// Gets destinations by region
        /// </summary>
        /// <param name="region">The region</param>
        /// <returns>Collection of destinations in the specified region</returns>
        Task<IEnumerable<Destination>> GetByRegionAsync(string region);

        /// <summary>
        /// Gets destinations by tags
        /// </summary>
        /// <param name="tags">The tags to search for</param>
        /// <returns>Collection of destinations with the specified tags</returns>
        Task<IEnumerable<Destination>> GetByTagsAsync(IEnumerable<string> tags);

        /// <summary>
        /// Gets destinations recommended for a specific season
        /// </summary>
        /// <param name="season">The season</param>
        /// <returns>Collection of destinations recommended for the specified season</returns>
        Task<IEnumerable<Destination>> GetByRecommendedSeasonAsync(Season season);

        /// <summary>
        /// Gets destinations by cost level
        /// </summary>
        /// <param name="costLevel">The cost level</param>
        /// <returns>Collection of destinations with the specified cost level</returns>
        Task<IEnumerable<Destination>> GetByCostLevelAsync(CostLevel costLevel);

        /// <summary>
        /// Gets destinations by accessibility
        /// </summary>
        /// <param name="isAccessible">The accessibility flag</param>
        /// <returns>Collection of destinations with the specified accessibility flag</returns>
        Task<IEnumerable<Destination>> GetByAccessibilityAsync(bool isAccessible);

        /// <summary>
        /// Gets destinations suitable for children
        /// </summary>
        /// <param name="isChildFriendly">The child-friendly flag</param>
        /// <returns>Collection of destinations with the specified child-friendly flag</returns>
        Task<IEnumerable<Destination>> GetByChildFriendlyAsync(bool isChildFriendly);

        /// <summary>
        /// Gets destinations near a location
        /// </summary>
        /// <param name="latitude">The latitude</param>
        /// <param name="longitude">The longitude</param>
        /// <param name="radiusKm">The radius in kilometers</param>
        /// <returns>Collection of destinations within the specified radius</returns>
        Task<IEnumerable<Destination>> GetNearLocationAsync(double latitude, double longitude, double radiusKm);

        /// <summary>
        /// Gets destinations by climate type
        /// </summary>
        /// <param name="climate">The climate type</param>
        /// <returns>Collection of destinations with the specified climate</returns>
        Task<IEnumerable<Destination>> GetByClimateAsync(ClimateType climate);

        /// <summary>
        /// Gets top-rated destinations
        /// </summary>
        /// <param name="count">The number of destinations to return</param>
        /// <returns>Collection of top-rated destinations</returns>
        Task<IEnumerable<Destination>> GetTopRatedAsync(int count);

        /// <summary>
        /// Gets must-visit destinations
        /// </summary>
        /// <returns>Collection of must-visit destinations</returns>
        Task<IEnumerable<Destination>> GetMustVisitAsync();
    }
}