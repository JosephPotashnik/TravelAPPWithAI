using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Feedback entity
    /// </summary>
    public class FeedbackDTO
    {
        /// <summary>
        /// Unique identifier for the feedback
        /// </summary>
        public string Id { get; set; } = string.Empty;
        
        /// <summary>
        /// Reference to the user who provided the feedback
        /// </summary>
        [Required]
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
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        
        /// <summary>
        /// Comment or detailed feedback
        /// </summary>
        [StringLength(1000)]
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
        [StringLength(500)]
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
        /// Date and time when the entity was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Date and time when the entity was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        
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