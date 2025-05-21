using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.Models.Requests
{
    /// <summary>
    /// Request model for updating user preferences
    /// </summary>
    public class UpdatePreferenceRequest
    {
        /// <summary>
        /// Preferred travel interests
        /// </summary>
        public List<TravelInterest>? Interests { get; set; }
        
        /// <summary>
        /// Budget preference for daily spending
        /// </summary>
        public BudgetLevel? BudgetLevel { get; set; }
        
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
        public TravelPace? Pace { get; set; }
        
        /// <summary>
        /// Preferred accommodation type
        /// </summary>
        public AccommodationType? PreferredAccommodation { get; set; }
        
        /// <summary>
        /// Accessibility requirements
        /// </summary>
        public List<AccessibilityRequirement>? AccessibilityRequirements { get; set; }
        
        /// <summary>
        /// Preferred transportation modes
        /// </summary>
        public List<TransportationMode>? PreferredTransportation { get; set; }
        
        /// <summary>
        /// Flag indicating if the user prefers avoiding crowds
        /// </summary>
        public bool? AvoidCrowds { get; set; }
        
        /// <summary>
        /// Flag indicating if the user prefers child-friendly destinations
        /// </summary>
        public bool? ChildFriendly { get; set; }
        
        /// <summary>
        /// Dietary restrictions or preferences
        /// </summary>
        public List<DietaryPreference>? DietaryPreferences { get; set; }
        
        /// <summary>
        /// Preferred climate types
        /// </summary>
        public List<ClimateType>? PreferredClimates { get; set; }
        
        /// <summary>
        /// Preferred trip durations in days
        /// </summary>
        public TripDuration? PreferredTripDuration { get; set; }
        
        /// <summary>
        /// Destinations the user has already visited (to add)
        /// </summary>
        public List<string>? VisitedDestinationsToAdd { get; set; }
        
        /// <summary>
        /// Destinations the user has already visited (to remove)
        /// </summary>
        public List<string>? VisitedDestinationsToRemove { get; set; }
        
        /// <summary>
        /// Destinations the user wishes to visit (to add)
        /// </summary>
        public List<string>? WishlistDestinationsToAdd { get; set; }
        
        /// <summary>
        /// Destinations the user wishes to visit (to remove)
        /// </summary>
        public List<string>? WishlistDestinationsToRemove { get; set; }
        
        /// <summary>
        /// Flag indicating if the user is open to surprise destinations
        /// </summary>
        public bool? OpenToSurprises { get; set; }
    }
}