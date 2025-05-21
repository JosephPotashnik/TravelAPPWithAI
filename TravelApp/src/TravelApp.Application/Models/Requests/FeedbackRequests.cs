using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.Models.Requests
{
    /// <summary>
    /// Request model for submitting feedback
    /// </summary>
    public class SubmitFeedbackRequest
    {
        /// <summary>
        /// Type of feedback
        /// </summary>
        [Required]
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
        public Dictionary<FeedbackAspect, int>? AspectRatings { get; set; }
        
        /// <summary>
        /// Flag indicating if this feedback is for AI-generated content
        /// </summary>
        public bool IsAIFeedback { get; set; }
        
        /// <summary>
        /// Flag indicating if this feedback is public
        /// </summary>
        public bool IsPublic { get; set; } = false;
        
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
        public List<string>? ImageUrls { get; set; }
    }
}