using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Services
{
    /// <summary>
    /// Service interface for destination data operations
    /// </summary>
    public interface IDestinationService : IService
    {
        /// <summary>
        /// Searches for destinations based on search criteria
        /// </summary>
        /// <param name="searchQuery">The search query</param>
        /// <param name="type">The destination type (optional)</param>
        /// <param name="category">The destination category (optional)</param>
        /// <param name="country">The country filter (optional)</param>
        /// <param name="city">The city filter (optional)</param>
        /// <param name="region">The region filter (optional)</param>
        /// <param name="tags">The tags to filter by (optional)</param>
        /// <param name="minRating">The minimum rating (optional)</param>
        /// <param name="costLevel">The cost level (optional)</param>
        /// <param name="accessibilityRequired">Whether accessible destinations are required (optional)</param>
        /// <param name="childFriendlyRequired">Whether child-friendly destinations are required (optional)</param>
        /// <param name="season">The season to visit (optional)</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="pageNumber">The page number</param>
        /// <returns>A collection of matching destinations</returns>
        Task<(IEnumerable<Destination> Destinations, int TotalCount)> SearchDestinationsAsync(
            string? searchQuery = null,
            DestinationType? type = null,
            DestinationCategory? category = null,
            string? country = null,
            string? city = null,
            string? region = null,
            IEnumerable<string>? tags = null,
            double? minRating = null,
            CostLevel? costLevel = null,
            bool? accessibilityRequired = null,
            bool? childFriendlyRequired = null,
            Season? season = null,
            int pageSize = 10,
            int pageNumber = 1);

        /// <summary>
        /// Gets destinations near a specific location
        /// </summary>
        /// <param name="latitude">The latitude</param>
        /// <param name="longitude">The longitude</param>
        /// <param name="radiusKm">The radius in kilometers</param>
        /// <param name="type">The destination type (optional)</param>
        /// <param name="category">The destination category (optional)</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="pageNumber">The page number</param>
        /// <returns>A collection of nearby destinations</returns>
        Task<(IEnumerable<Destination> Destinations, int TotalCount)> GetNearbyDestinationsAsync(
            double latitude,
            double longitude,
            double radiusKm,
            DestinationType? type = null,
            DestinationCategory? category = null,
            int pageSize = 10,
            int pageNumber = 1);

        /// <summary>
        /// Gets detailed destination information
        /// </summary>
        /// <param name="destinationId">The destination ID</param>
        /// <returns>Detailed destination information</returns>
        Task<Destination> GetDestinationDetailsAsync(string destinationId);

        /// <summary>
        /// Gets popular destinations based on user ratings and visits
        /// </summary>
        /// <param name="count">The number of destinations to return</param>
        /// <param name="category">The destination category (optional)</param>
        /// <param name="type">The destination type (optional)</param>
        /// <returns>A collection of popular destinations</returns>
        Task<IEnumerable<Destination>> GetPopularDestinationsAsync(
            int count = 10,
            DestinationCategory? category = null,
            DestinationType? type = null);

        /// <summary>
        /// Gets destinations recommended for a specific season
        /// </summary>
        /// <param name="season">The season</param>
        /// <param name="count">The number of destinations to return</param>
        /// <returns>A collection of season-recommended destinations</returns>
        Task<IEnumerable<Destination>> GetSeasonalDestinationsAsync(Season season, int count = 10);

        /// <summary>
        /// Gets travel advisories for a destination
        /// </summary>
        /// <param name="destinationId">The destination ID</param>
        /// <returns>Travel advisory information</returns>
        Task<string> GetTravelAdvisoriesAsync(string destinationId);

        /// <summary>
        /// Gets weather forecast for a destination
        /// </summary>
        /// <param name="destinationId">The destination ID</param>
        /// <param name="date">The date for the forecast</param>
        /// <returns>Weather forecast information</returns>
        Task<string> GetWeatherForecastAsync(string destinationId, DateTime date);

        /// <summary>
        /// Gets destinations that match user preferences
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="count">The number of destinations to return</param>
        /// <returns>A collection of personalized destination recommendations</returns>
        Task<IEnumerable<Destination>> GetRecommendedDestinationsForUserAsync(string userId, int count = 10);

        /// <summary>
        /// Gets destinations similar to a specified destination
        /// </summary>
        /// <param name="destinationId">The destination ID</param>
        /// <param name="count">The number of similar destinations to return</param>
        /// <returns>A collection of similar destinations</returns>
        Task<IEnumerable<Destination>> GetSimilarDestinationsAsync(string destinationId, int count = 5);

        /// <summary>
        /// Gets off-the-beaten-path destinations for more adventurous travelers
        /// </summary>
        /// <param name="region">The region filter (optional)</param>
        /// <param name="count">The number of destinations to return</param>
        /// <returns>A collection of lesser-known destinations</returns>
        Task<IEnumerable<Destination>> GetOffTheBeatenPathDestinationsAsync(string? region = null, int count = 5);

        /// <summary>
        /// Gets transportation options between two destinations
        /// </summary>
        /// <param name="fromDestinationId">The source destination ID</param>
        /// <param name="toDestinationId">The target destination ID</param>
        /// <param name="date">The date of travel</param>
        /// <returns>A collection of transportation options</returns>
        Task<IEnumerable<string>> GetTransportationOptionsAsync(
            string fromDestinationId,
            string toDestinationId,
            DateTime date);
    }
}