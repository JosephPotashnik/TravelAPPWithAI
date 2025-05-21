using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Feedback entity operations
    /// </summary>
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        /// <summary>
        /// Gets feedback by user ID
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>Collection of feedback submitted by the user</returns>
        Task<IEnumerable<Feedback>> GetByUserIdAsync(string userId);

        /// <summary>
        /// Gets feedback for an itinerary
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <returns>Collection of feedback for the specified itinerary</returns>
        Task<IEnumerable<Feedback>> GetByItineraryIdAsync(string itineraryId);

        /// <summary>
        /// Gets feedback for an itinerary item
        /// </summary>
        /// <param name="itineraryItemId">The itinerary item ID</param>
        /// <returns>Collection of feedback for the specified itinerary item</returns>
        Task<IEnumerable<Feedback>> GetByItineraryItemIdAsync(string itineraryItemId);

        /// <summary>
        /// Gets feedback for a destination
        /// </summary>
        /// <param name="destinationId">The destination ID</param>
        /// <returns>Collection of feedback for the specified destination</returns>
        Task<IEnumerable<Feedback>> GetByDestinationIdAsync(string destinationId);

        /// <summary>
        /// Gets feedback by type
        /// </summary>
        /// <param name="type">The feedback type</param>
        /// <returns>Collection of feedback of the specified type</returns>
        Task<IEnumerable<Feedback>> GetByTypeAsync(FeedbackType type);

        /// <summary>
        /// Gets feedback by rating
        /// </summary>
        /// <param name="rating">The rating value (1-5)</param>
        /// <returns>Collection of feedback with the specified rating</returns>
        Task<IEnumerable<Feedback>> GetByRatingAsync(int rating);

        /// <summary>
        /// Gets AI-related feedback
        /// </summary>
        /// <param name="isAIFeedback">The AI feedback flag</param>
        /// <returns>Collection of feedback with the specified AI feedback flag</returns>
        Task<IEnumerable<Feedback>> GetByAIFeedbackAsync(bool isAIFeedback);

        /// <summary>
        /// Gets public feedback
        /// </summary>
        /// <param name="isPublic">The public flag</param>
        /// <returns>Collection of feedback with the specified public flag</returns>
        Task<IEnumerable<Feedback>> GetByPublicStatusAsync(bool isPublic);

        /// <summary>
        /// Gets feedback by recommendation status
        /// </summary>
        /// <param name="wouldRecommend">The recommendation flag</param>
        /// <returns>Collection of feedback with the specified recommendation flag</returns>
        Task<IEnumerable<Feedback>> GetByRecommendationAsync(bool wouldRecommend);

        /// <summary>
        /// Gets the average rating for an itinerary
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <returns>The average rating or 0 if no ratings exist</returns>
        Task<double> GetAverageRatingForItineraryAsync(string itineraryId);

        /// <summary>
        /// Gets the average rating for a destination
        /// </summary>
        /// <param name="destinationId">The destination ID</param>
        /// <returns>The average rating or 0 if no ratings exist</returns>
        Task<double> GetAverageRatingForDestinationAsync(string destinationId);

        /// <summary>
        /// Gets the average rating for a specific aspect across all feedback
        /// </summary>
        /// <param name="aspect">The feedback aspect</param>
        /// <returns>The average rating for the aspect or 0 if no ratings exist</returns>
        Task<double> GetAverageRatingForAspectAsync(FeedbackAspect aspect);
    }
}