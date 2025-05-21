using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.Models.Requests
{
    /// <summary>
    /// Request model for generating a new itinerary
    /// </summary>
    public class GenerateItineraryRequest
    {
        /// <summary>
        /// Name of the itinerary
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Description of the itinerary
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Start date of the itinerary
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// End date of the itinerary
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }
        
        /// <summary>
        /// Primary destination (city/region/country)
        /// </summary>
        [Required]
        [StringLength(100)]
        public string PrimaryDestination { get; set; } = string.Empty;
        
        /// <summary>
        /// Additional destinations to include
        /// </summary>
        public List<string> AdditionalDestinations { get; set; } = new List<string>();
        
        /// <summary>
        /// Budget for the entire trip
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Total budget cannot be negative")]
        public decimal TotalBudget { get; set; }
        
        /// <summary>
        /// Preferred travel interests
        /// </summary>
        public List<TravelInterest> Interests { get; set; } = new List<TravelInterest>();
        
        /// <summary>
        /// Budget level for daily spending
        /// </summary>
        public BudgetLevel BudgetLevel { get; set; } = BudgetLevel.Medium;
        
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
        /// Flag indicating if the user prefers avoiding crowds
        /// </summary>
        public bool AvoidCrowds { get; set; }
        
        /// <summary>
        /// Flag indicating if the user prefers child-friendly destinations
        /// </summary>
        public bool ChildFriendly { get; set; }
        
        /// <summary>
        /// Flag indicating if the user is open to surprise destinations
        /// </summary>
        public bool OpenToSurprises { get; set; } = false;
        
        /// <summary>
        /// Use user's stored preferences
        /// </summary>
        public bool UseUserPreferences { get; set; } = true;
        
        /// <summary>
        /// Dietary restrictions or preferences
        /// </summary>
        public List<DietaryPreference> DietaryPreferences { get; set; } = new List<DietaryPreference>();
        
        /// <summary>
        /// Special notes or requirements
        /// </summary>
        [StringLength(1000)]
        public string Notes { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// Request model for updating an existing itinerary
    /// </summary>
    public class UpdateItineraryRequest
    {
        /// <summary>
        /// Name of the itinerary
        /// </summary>
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
        
        /// <summary>
        /// Description of the itinerary
        /// </summary>
        [StringLength(500)]
        public string? Description { get; set; }
        
        /// <summary>
        /// Start date of the itinerary
        /// </summary>
        public DateTime? StartDate { get; set; }
        
        /// <summary>
        /// End date of the itinerary
        /// </summary>
        public DateTime? EndDate { get; set; }
        
        /// <summary>
        /// Primary destination (city/region/country)
        /// </summary>
        [StringLength(100)]
        public string? PrimaryDestination { get; set; }
        
        /// <summary>
        /// Budget for the entire trip
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Total budget cannot be negative")]
        public decimal? TotalBudget { get; set; }
        
        /// <summary>
        /// Tags for easy searching and categorization
        /// </summary>
        public List<string>? Tags { get; set; }
        
        /// <summary>
        /// Flag indicating if this is a draft itinerary
        /// </summary>
        public bool? IsDraft { get; set; }
        
        /// <summary>
        /// Flag indicating if this is a template itinerary (for reuse)
        /// </summary>
        public bool? IsTemplate { get; set; }
        
        /// <summary>
        /// Notes or special requirements for the itinerary
        /// </summary>
        [StringLength(1000)]
        public string? Notes { get; set; }
    }
    
    /// <summary>
    /// Request model for cloning an existing itinerary
    /// </summary>
    public class CloneItineraryRequest
    {
        /// <summary>
        /// ID of the itinerary to clone
        /// </summary>
        [Required]
        public string ItineraryId { get; set; } = string.Empty;
        
        /// <summary>
        /// New name for the cloned itinerary
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string NewName { get; set; } = string.Empty;
        
        /// <summary>
        /// New start date for the cloned itinerary (if adjusting dates)
        /// </summary>
        public DateTime? NewStartDate { get; set; }
        
        /// <summary>
        /// Create as a template
        /// </summary>
        public bool CreateAsTemplate { get; set; } = false;
    }
}