using System;
using System.Collections.Generic;
using TravelApp.Domain.Common;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Entities
{
    /// <summary>
    /// Feedback entity representing user feedback and ratings
    /// </summary>
    public class Feedback : Entity
    {
        /// <summary>
        /// Reference to the user who provided the feedback
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Type of feedback
        /// </summary>
        public FeedbackType Type { get; set; }

        /// <summary>
        /// Reference to the itinerary (if applicable)
        /// </summary>
        public string? ItineraryId { get; set; }

        /// <summary>
        /// Reference to the itinerary item (if applicable)
        /// </summary>
        public string? ItineraryItemId { get; set; }

        /// <summary>
        /// Reference to the destination (if applicable)
        /// </summary>
        public string? DestinationId { get; set; }

        /// <summary>
        /// Rating from 1-5
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Comment or detailed feedback
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// List of specific aspects that were rated
        /// </summary>
        public Dictionary<FeedbackAspect, int> AspectRatings { get; set; } = new Dictionary<FeedbackAspect, int>();

        /// <summary>
        /// Flag indicating if this feedback is for AI-generated content
        /// </summary>
        public bool IsAIFeedback { get; set; }

        /// <summary>
        /// Flag indicating if this feedback is public
        /// </summary>
        public bool IsPublic { get; set; } = false;

        /// <summary>
        /// Date when the feedback was submitted
        /// </summary>
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Suggestions for improvement
        /// </summary>
        public string Suggestions { get; set; } = string.Empty;

        /// <summary>
        /// Would recommend (yes/no)
        /// </summary>
        public bool WouldRecommend { get; set; }

        /// <summary>
        /// Images attached to the feedback
        /// </summary>
        public List<string> ImageUrls { get; set; } = new List<string>();

        /// <summary>
        /// Validates the feedback entity
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when validation fails</exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(UserId))
                throw new ArgumentException("User ID cannot be empty", nameof(UserId));

            // At least one reference ID must be provided
            if (string.IsNullOrWhiteSpace(ItineraryId) && 
                string.IsNullOrWhiteSpace(ItineraryItemId) && 
                string.IsNullOrWhiteSpace(DestinationId))
                throw new ArgumentException("At least one reference ID (Itinerary, ItineraryItem, or Destination) must be provided");

            if (Rating < 1 || Rating > 5)
                throw new ArgumentException("Rating must be between 1 and 5", nameof(Rating));

            // Validate aspect ratings
            foreach (var rating in AspectRatings.Values)
            {
                if (rating < 1 || rating > 5)
                    throw new ArgumentException("Aspect ratings must be between 1 and 5", nameof(AspectRatings));
            }
        }

        /// <summary>
        /// Gets the average rating across all aspects
        /// </summary>
        /// <returns>Average aspect rating, or 0 if no aspects rated</returns>
        public double GetAverageAspectRating()
        {
            if (AspectRatings.Count == 0)
                return 0;

            double sum = 0;
            foreach (var rating in AspectRatings.Values)
            {
                sum += rating;
            }

            return sum / AspectRatings.Count;
        }
    }
}