using System;
using System.Collections.Generic;
using TravelApp.Domain.Common;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Entities
{
    /// <summary>
    /// Preference entity representing a user's travel preferences
    /// </summary>
    public class Preference : Entity
    {
        /// <summary>
        /// Reference to the user who owns these preferences
        /// </summary>
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
        public decimal? CustomBudgetMin { get; set; }

        /// <summary>
        /// Custom budget range (maximum per day)
        /// </summary>
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
        /// Validates the preference entity
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when validation fails</exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(UserId))
                throw new ArgumentException("User ID cannot be empty", nameof(UserId));

            if (CustomBudgetMin.HasValue && CustomBudgetMax.HasValue)
            {
                if (CustomBudgetMin.Value < 0)
                    throw new ArgumentException("Minimum budget cannot be negative", nameof(CustomBudgetMin));

                if (CustomBudgetMax.Value < CustomBudgetMin.Value)
                    throw new ArgumentException("Maximum budget cannot be less than minimum budget", nameof(CustomBudgetMax));
            }
        }

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