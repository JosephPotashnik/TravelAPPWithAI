using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Preference entity
    /// </summary>
    public class PreferenceDTO
    {
        /// <summary>
        /// Unique identifier for the preference
        /// </summary>
        public string Id { get; set; } = string.Empty;
        
        /// <summary>
        /// Reference to the user who owns these preferences
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        /// <summary>
        /// Preferred travel interests
        /// </summary>
        public List<TravelInterest> Interests { get; set; } = new List<TravelInterest>();
        
        /// <summary>
        /// Budget preference for daily spending
        /// </summary>
        public BudgetLevel BudgetLevel { get; set; } = BudgetLevel.Medium;
        
        /// <summary>
        /// Custom budget range (minimum per day)
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Minimum budget cannot be negative")]
        public decimal? CustomBudgetMin { get; set; }
        
        /// <summary>
        /// Custom budget range (maximum per day)
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Maximum budget cannot be negative")]
        public decimal? CustomBudgetMax { get; set; }
        
        /// <summary>
        /// Preferred pace of travel
        /// </summary>
        public TravelPace Pace { get; set; } = TravelPace.Moderate;
        
        /// <summary>
        /// Preferred accommodation type
        /// </summary>
        public AccommodationType PreferredAccommodation { get; set; } = AccommodationType.Hotel;
        
        /// <summary>
        /// Accessibility requirements
        /// </summary>
        public List<AccessibilityRequirement> AccessibilityRequirements { get; set; } = new List<AccessibilityRequirement>();
        
        /// <summary>
        /// Preferred transportation modes
        /// </summary>
        public List<TransportationMode> PreferredTransportation { get; set; } = new List<TransportationMode>();
        
        /// <summary>
        /// Flag indicating if the user prefers avoiding crowds
        /// </summary>
        public bool AvoidCrowds { get; set; }
        
        /// <summary>
        /// Flag indicating if the user prefers child-friendly destinations
        /// </summary>
        public bool ChildFriendly { get; set; }
        
        /// <summary>
        /// Dietary restrictions or preferences
        /// </summary>
        public List<DietaryPreference> DietaryPreferences { get; set; } = new List<DietaryPreference>();
        
        /// <summary>
        /// Preferred climate types
        /// </summary>
        public List<ClimateType> PreferredClimates { get; set; } = new List<ClimateType>();
        
        /// <summary>
        /// Preferred trip durations in days
        /// </summary>
        public TripDuration PreferredTripDuration { get; set; } = TripDuration.Medium;
        
        /// <summary>
        /// Destinations the user has already visited
        /// </summary>
        public List<string> VisitedDestinations { get; set; } = new List<string>();
        
        /// <summary>
        /// Destinations the user wishes to visit
        /// </summary>
        public List<string> WishlistDestinations { get; set; } = new List<string>();
        
        /// <summary>
        /// Flag indicating if the user is open to surprise destinations
        /// </summary>
        public bool OpenToSurprises { get; set; } = true;
        
        /// <summary>
        /// Date and time when the entity was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Date and time when the entity was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        
        /// <summary>
        /// Gets the estimated daily budget range based on budget level or custom values
        /// </summary>
        /// <returns>A tuple with minimum and maximum daily budget</returns>
        public (decimal Min, decimal Max) GetDailyBudgetRange()
        {
            // If custom budget is set, use that
            if (CustomBudgetMin.HasValue && CustomBudgetMax.HasValue)
                return (CustomBudgetMin.Value, CustomBudgetMax.Value);
            
            // Otherwise, use predefined ranges based on budget level
            return BudgetLevel switch
            {
                BudgetLevel.Budget => (25m, 75m),
                BudgetLevel.Medium => (75m, 150m),
                BudgetLevel.Luxury => (150m, 500m),
                BudgetLevel.UltraLuxury => (500m, 2000m),
                _ => (50m, 150m) // Default range
            };
        }
    }
}