using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Destination entity
    /// </summary>
    public class DestinationDTO
    {
        /// <summary>
        /// Unique identifier for the destination
        /// </summary>
        public string Id { get; set; } = string.Empty;
        
        /// <summary>
        /// Name of the destination
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Description of the destination
        /// </summary>
        [Required]
        [StringLength(1000)]
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
        [Required]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;
        
        /// <summary>
        /// Region or state where the destination is located
        /// </summary>
        [StringLength(100)]
        public string Region { get; set; } = string.Empty;
        
        /// <summary>
        /// City where the destination is located
        /// </summary>
        [StringLength(100)]
        public string City { get; set; } = string.Empty;
        
        /// <summary>
        /// Full address of the destination
        /// </summary>
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
        
        /// <summary>
        /// Latitude coordinate
        /// </summary>
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public double Latitude { get; set; }
        
        /// <summary>
        /// Longitude coordinate
        /// </summary>
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public double Longitude { get; set; }
        
        /// <summary>
        /// List of image URLs for the destination
        /// </summary>
        public List<string> ImageUrls { get; set; } = new List<string>();
        
        /// <summary>
        /// Main image URL for the destination
        /// </summary>
        [Url]
        public string MainImageUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Website URL for the destination
        /// </summary>
        [Url]
        public string WebsiteUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Average rating from 1-5
        /// </summary>
        [Range(0, 5, ErrorMessage = "Average rating must be between 0 and 5")]
        public double AverageRating { get; set; }
        
        /// <summary>
        /// Number of ratings received
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Ratings count cannot be negative")]
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
        /// Typical amount of time needed to visit (in minutes)
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Visit duration cannot be negative")]
        public int TypicalVisitDurationMinutes { get; set; } = 120;
        
        /// <summary>
        /// Opening hours information
        /// </summary>
        [StringLength(200)]
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
        [StringLength(500)]
        public string TravelAdvisories { get; set; } = string.Empty;
        
        /// <summary>
        /// Practical information for visitors
        /// </summary>
        [StringLength(500)]
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
        /// Date and time when the entity was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Date and time when the entity was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}