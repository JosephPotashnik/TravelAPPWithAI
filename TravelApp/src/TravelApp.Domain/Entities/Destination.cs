using System;
using System.Collections.Generic;
using TravelApp.Domain.Common;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Entities
{
    /// <summary>
    /// Destination entity representing a location, attraction, or point of interest
    /// </summary>
    public class Destination : Entity
    {
        /// <summary>
        /// Name of the destination
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description of the destination
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Type of the destination
        /// </summary>
        public DestinationType Type { get; set; }

        /// <summary>
        /// Destination category
        /// </summary>
        public DestinationCategory Category { get; set; }

        /// <summary>
        /// Country where the destination is located
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Region or state where the destination is located
        /// </summary>
        public string Region { get; set; } = string.Empty;

        /// <summary>
        /// City where the destination is located
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Full address of the destination
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Latitude coordinate
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude coordinate
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// List of image URLs for the destination
        /// </summary>
        public List<string> ImageUrls { get; set; } = new List<string>();

        /// <summary>
        /// Main image URL for the destination
        /// </summary>
        public string MainImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Website URL for the destination
        /// </summary>
        public string WebsiteUrl { get; set; } = string.Empty;

        /// <summary>
        /// Average rating from 1-5
        /// </summary>
        public double AverageRating { get; set; }

        /// <summary>
        /// Number of ratings received
        /// </summary>
        public int RatingsCount { get; set; }

        /// <summary>
        /// Tags for easy searching and categorization
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// Recommended season(s) to visit
        /// </summary>
        public List<Season> RecommendedSeasons { get; set; } = new List<Season>();

        /// <summary>
        /// Estimated cost level
        /// </summary>
        public CostLevel CostLevel { get; set; } = CostLevel.Medium;

        /// <summary>
        /// Typical amount of time needed to visit
        /// </summary>
        public TimeSpan TypicalVisitDuration { get; set; } = TimeSpan.FromHours(2);

        /// <summary>
        /// Opening hours information
        /// </summary>
        public string OpeningHours { get; set; } = string.Empty;

        /// <summary>
        /// Flag indicating if this destination is accessible for people with disabilities
        /// </summary>
        public bool IsAccessible { get; set; }

        /// <summary>
        /// Accessibility features
        /// </summary>
        public List<AccessibilityRequirement> AccessibilityFeatures { get; set; } = new List<AccessibilityRequirement>();

        /// <summary>
        /// Flag indicating if this destination is child-friendly
        /// </summary>
        public bool IsChildFriendly { get; set; }

        /// <summary>
        /// Flag indicating if this destination is a must-see/must-do
        /// </summary>
        public bool IsMustVisit { get; set; }

        /// <summary>
        /// Local travel advisories
        /// </summary>
        public string TravelAdvisories { get; set; } = string.Empty;

        /// <summary>
        /// Practical information for visitors
        /// </summary>
        public string PracticalInfo { get; set; } = string.Empty;

        /// <summary>
        /// Climate type of the destination
        /// </summary>
        public ClimateType Climate { get; set; }

        /// <summary>
        /// Best activities to do at this destination
        /// </summary>
        public List<string> BestActivities { get; set; } = new List<string>();

        /// <summary>
        /// Local transportation options
        /// </summary>
        public List<TransportationMode> LocalTransportation { get; set; } = new List<TransportationMode>();

        /// <summary>
        /// Nearby destinations that are commonly visited together
        /// </summary>
        public List<string> NearbyDestinationIds { get; set; } = new List<string>();

        /// <summary>
        /// Validates the destination entity
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when validation fails</exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Name cannot be empty", nameof(Name));

            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentException("Description cannot be empty", nameof(Description));

            if (string.IsNullOrWhiteSpace(Country))
                throw new ArgumentException("Country cannot be empty", nameof(Country));

            if (AverageRating < 0 || AverageRating > 5)
                throw new ArgumentException("Average rating must be between 0 and 5", nameof(AverageRating));

            if (RatingsCount < 0)
                throw new ArgumentException("Ratings count cannot be negative", nameof(RatingsCount));

            if (TypicalVisitDuration < TimeSpan.Zero)
                throw new ArgumentException("Typical visit duration cannot be negative", nameof(TypicalVisitDuration));
        }
    }
}