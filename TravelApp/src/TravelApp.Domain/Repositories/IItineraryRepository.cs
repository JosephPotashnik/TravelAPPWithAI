using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Itinerary entity operations
    /// </summary>
    public interface IItineraryRepository : IRepository<Itinerary>
    {
        /// <summary>
        /// Gets all itineraries for a specific user
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>Collection of itineraries belonging to the user</returns>
        Task<IEnumerable<Itinerary>> GetByUserIdAsync(string userId);

        /// <summary>
        /// Gets all itineraries for a specific destination
        /// </summary>
        /// <param name="destinationName">The primary destination name</param>
        /// <returns>Collection of itineraries for the specified destination</returns>
        Task<IEnumerable<Itinerary>> GetByDestinationAsync(string destinationName);

        /// <summary>
        /// Gets itineraries within a date range
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns>Collection of itineraries that fall within the date range</returns>
        Task<IEnumerable<Itinerary>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets itineraries by tags
        /// </summary>
        /// <param name="tags">The tags to search for</param>
        /// <returns>Collection of itineraries containing the specified tags</returns>
        Task<IEnumerable<Itinerary>> GetByTagsAsync(IEnumerable<string> tags);

        /// <summary>
        /// Gets template itineraries
        /// </summary>
        /// <returns>Collection of template itineraries</returns>
        Task<IEnumerable<Itinerary>> GetTemplatesAsync();

        /// <summary>
        /// Gets all versions of an itinerary
        /// </summary>
        /// <param name="originalItineraryId">The original itinerary ID</param>
        /// <returns>Collection of all versions of the specified itinerary</returns>
        Task<IEnumerable<Itinerary>> GetAllVersionsAsync(string originalItineraryId);

        /// <summary>
        /// Gets AI-generated itineraries for a user
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>Collection of AI-generated itineraries for the user</returns>
        Task<IEnumerable<Itinerary>> GetAIGeneratedByUserIdAsync(string userId);

        /// <summary>
        /// Gets an itinerary with all its related items loaded
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <returns>The itinerary with items if found, otherwise null</returns>
        Task<Itinerary?> GetWithItemsAsync(string itineraryId);

        /// <summary>
        /// Gets itineraries by draft status
        /// </summary>
        /// <param name="isDraft">The draft status to filter by</param>
        /// <param name="userId">Optional user ID to filter by</param>
        /// <returns>Collection of itineraries with the specified draft status</returns>
        Task<IEnumerable<Itinerary>> GetByDraftStatusAsync(bool isDraft, string? userId = null);
    }
}