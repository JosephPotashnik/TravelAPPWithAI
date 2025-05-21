using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.Models.Requests
{
    /// <summary>
    /// Request model for searching destinations
    /// </summary>
    public class SearchDestinationsRequest
    {
        /// <summary>
        /// Search query term
        /// </summary>
        public string? Query { get; set; }
        
        /// <summary>
        /// Destination types to include in results
        /// </summary>
        public List<DestinationType>? Types { get; set; }
        
        /// <summary>
        /// Destination categories to include in results
        /// </summary>
        public List<DestinationCategory>? Categories { get; set; }
        
        /// <summary>
        /// Country to filter by
        /// </summary>
        public string? Country { get; set; }
        
        /// <summary>
        /// Region to filter by
        /// </summary>
        public string? Region { get; set; }
        
        /// <summary>
        /// City to filter by
        /// </summary>
        public string? City { get; set; }
        
        /// <summary>
        /// Minimum rating to filter by
        /// </summary>
        [Range(0, 5)]
        public double? MinRating { get; set; }
        
        /// <summary>
        /// Cost levels to include
        /// </summary>
        public List<CostLevel>? CostLevels { get; set; }
        
        /// <summary>
        /// Tags to filter by (all tags must match)
        /// </summary>
        public List<string>? Tags { get; set; }
        
        /// <summary>
        /// Flag to only include accessible destinations
        /// </summary>
        public bool? OnlyAccessible { get; set; }
        
        /// <summary>
        /// Flag to only include child-friendly destinations
        /// </summary>
        public bool? OnlyChildFriendly { get; set; }
        
        /// <summary>
        /// Flag to only include must-visit destinations
        /// </summary>
        public bool? OnlyMustVisit { get; set; }
        
        /// <summary>
        /// Seasons to filter by (destinations recommended for these seasons)
        /// </summary>
        public List<Season>? Seasons { get; set; }
        
        /// <summary>
        /// Maximum distance in kilometers from a specified point
        /// </summary>
        public double? MaxDistanceKm { get; set; }
        
        /// <summary>
        /// Latitude for distance calculation
        /// </summary>
        public double? Latitude { get; set; }
        
        /// <summary>
        /// Longitude for distance calculation
        /// </summary>
        public double? Longitude { get; set; }
        
        /// <summary>
        /// Page number for pagination (1-based)
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        
        /// <summary>
        /// Number of items per page
        /// </summary>
        [Range(1, 100)]
        public int PageSize { get; set; } = 20;
        
        /// <summary>
        /// Field to sort by
        /// </summary>
        public string SortBy { get; set; } = "Name";
        
        /// <summary>
        /// Sort direction (asc or desc)
        /// </summary>
        public string SortDirection { get; set; } = "asc";
    }
}