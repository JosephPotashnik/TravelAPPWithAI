using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Services
{
    /// <summary>
    /// Service interface for AI-powered itinerary generation
    /// </summary>
    public interface IItineraryGenerationService : IService
    {
        /// <summary>
        /// Generates an itinerary based on user preferences and constraints
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="destination">The primary destination</param>
        /// <param name="startDate">The start date of the trip</param>
        /// <param name="endDate">The end date of the trip</param>
        /// <param name="budget">The total budget for the trip</param>
        /// <param name="interests">Specific interests to consider (optional)</param>
        /// <param name="pace">The preferred pace of travel (optional)</param>
        /// <param name="accommodationType">The preferred accommodation type (optional)</param>
        /// <param name="useSurpriseMe">Whether to include surprising/unexpected elements (optional)</param>
        /// <returns>A generated itinerary</returns>
        Task<Itinerary> GenerateItineraryAsync(
            string userId, 
            string destination, 
            DateTime startDate, 
            DateTime endDate, 
            decimal budget,
            IEnumerable<TravelInterest>? interests = null,
            TravelPace pace = TravelPace.Moderate,
            AccommodationType? accommodationType = null,
            bool useSurpriseMe = false);

        /// <summary>
        /// Generates an itinerary for multiple destinations
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="destinations">The destinations to visit</param>
        /// <param name="startDate">The start date of the trip</param>
        /// <param name="endDate">The end date of the trip</param>
        /// <param name="budget">The total budget for the trip</param>
        /// <param name="interests">Specific interests to consider (optional)</param>
        /// <param name="pace">The preferred pace of travel (optional)</param>
        /// <param name="accommodationType">The preferred accommodation type (optional)</param>
        /// <returns>A generated multi-destination itinerary</returns>
        Task<Itinerary> GenerateMultiDestinationItineraryAsync(
            string userId,
            IEnumerable<string> destinations,
            DateTime startDate,
            DateTime endDate,
            decimal budget,
            IEnumerable<TravelInterest>? interests = null,
            TravelPace pace = TravelPace.Moderate,
            AccommodationType? accommodationType = null);

        /// <summary>
        /// Modifies an existing itinerary based on user feedback
        /// </summary>
        /// <param name="itineraryId">The itinerary ID to modify</param>
        /// <param name="feedback">User feedback for changes</param>
        /// <param name="preferences">Specific preferences for the modifications</param>
        /// <returns>The modified itinerary</returns>
        Task<Itinerary> ModifyItineraryAsync(
            string itineraryId,
            string feedback,
            Dictionary<string, object>? preferences = null);

        /// <summary>
        /// Regenerates a specific day in an itinerary
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <param name="dayNumber">The day number to regenerate (1-based)</param>
        /// <param name="feedback">User feedback for changes</param>
        /// <returns>The modified itinerary with the regenerated day</returns>
        Task<Itinerary> RegenerateDayAsync(
            string itineraryId,
            int dayNumber,
            string? feedback = null);

        /// <summary>
        /// Validates if an itinerary is feasible based on timing, distances, etc.
        /// </summary>
        /// <param name="itineraryId">The itinerary ID to validate</param>
        /// <returns>A list of validation issues, empty if no issues found</returns>
        Task<IEnumerable<string>> ValidateItineraryFeasibilityAsync(string itineraryId);

        /// <summary>
        /// Generates recommendations for activities based on user preferences and destination
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="destination">The destination</param>
        /// <param name="date">The date for the activities</param>
        /// <param name="count">The number of recommendations to generate</param>
        /// <returns>A list of recommended itinerary items</returns>
        Task<IEnumerable<ItineraryItem>> GetActivityRecommendationsAsync(
            string userId,
            string destination,
            DateTime date,
            int count = 5);

        /// <summary>
        /// Suggests accommodations that match user preferences in a destination
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="destination">The destination</param>
        /// <param name="checkIn">The check-in date</param>
        /// <param name="checkOut">The check-out date</param>
        /// <param name="maxPrice">Maximum price per night</param>
        /// <returns>A list of recommended accommodations</returns>
        Task<IEnumerable<Destination>> GetAccommodationRecommendationsAsync(
            string userId,
            string destination,
            DateTime checkIn,
            DateTime checkOut,
            decimal? maxPrice = null);

        /// <summary>
        /// Optimizes an itinerary for efficiency (e.g., reducing travel time between points)
        /// </summary>
        /// <param name="itineraryId">The itinerary ID to optimize</param>
        /// <returns>The optimized itinerary</returns>
        Task<Itinerary> OptimizeItineraryAsync(string itineraryId);
    }
}