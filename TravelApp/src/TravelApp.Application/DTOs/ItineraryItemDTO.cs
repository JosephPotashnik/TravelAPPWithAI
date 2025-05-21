using System;
using System.ComponentModel.DataAnnotations;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for ItineraryItem entity
    /// </summary>
    public class ItineraryItemDTO
    {
        /// <summary>
        /// Unique identifier for the itinerary item
        /// </summary>
        public string Id { get; set; } = string.Empty;
        
        /// <summary>
        /// Reference to the itinerary this item belongs to
        /// </summary>
        [Required]
        public string ItineraryId { get; set; } = string.Empty;
        
        /// <summary>
        /// Title or name of the item
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
        
        /// <summary>
        /// Description of the item
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Type of the itinerary item
        /// </summary>
        public ItineraryItemType Type { get; set; }
        
        /// <summary>
        /// Start date and time of the item
        /// </summary>
        [Required]
        public DateTime StartDateTime { get; set; }
        
        /// <summary>
        /// End date and time of the item
        /// </summary>
        [Required]
        public DateTime EndDateTime { get; set; }
        
        /// <summary>
        /// Day number in the itinerary (1 = first day)
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Day number must be positive")]
        public int DayNumber { get; set; }
        
        /// <summary>
        /// Order within the day
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Order in day cannot be negative")]
        public int OrderInDay { get; set; }
        
        /// <summary>
        /// Location name
        /// </summary>
        [StringLength(100)]
        public string LocationName { get; set; } = string.Empty;
        
        /// <summary>
        /// Reference to destination (if applicable)
        /// </summary>
        public string? DestinationId { get; set; }
        
        /// <summary>
        /// Populated destination data (optional, used for retrieving full data)
        /// </summary>
        public DestinationDTO? Destination { get; set; }
        
        /// <summary>
        /// Address of the location
        /// </summary>
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
        
        /// <summary>
        /// Latitude coordinate
        /// </summary>
        public double? Latitude { get; set; }
        
        /// <summary>
        /// Longitude coordinate
        /// </summary>
        public double? Longitude { get; set; }
        
        /// <summary>
        /// Cost estimate for this item
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Cost cannot be negative")]
        public decimal? Cost { get; set; }
        
        /// <summary>
        /// Booking reference (if applicable)
        /// </summary>
        [StringLength(50)]
        public string BookingReference { get; set; } = string.Empty;
        
        /// <summary>
        /// URL for booking or more information
        /// </summary>
        [StringLength(255)]
        [Url]
        public string Url { get; set; } = string.Empty;
        
        /// <summary>
        /// Notes or special requirements for this item
        /// </summary>
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;
        
        /// <summary>
        /// Flag indicating if this item is a must-see/must-do
        /// </summary>
        public bool IsMustDo { get; set; }
        
        /// <summary>
        /// Flag indicating if this item is confirmed (booked)
        /// </summary>
        public bool IsConfirmed { get; set; }
        
        /// <summary>
        /// Flag indicating if this item is flexible (can be moved)
        /// </summary>
        public bool IsFlexible { get; set; } = true;
        
        /// <summary>
        /// Weather forecast for this item (if available)
        /// </summary>
        public string? WeatherForecast { get; set; }
        
        /// <summary>
        /// Flag indicating if this item is transportation between locations
        /// </summary>
        public bool IsTransportation { get; set; }
        
        /// <summary>
        /// Transportation mode (if applicable)
        /// </summary>
        public TransportationMode? TransportationMode { get; set; }
        
        /// <summary>
        /// Source location for transportation (if applicable)
        /// </summary>
        [StringLength(100)]
        public string? TransportationSource { get; set; }
        
        /// <summary>
        /// Destination location for transportation (if applicable)
        /// </summary>
        [StringLength(100)]
        public string? TransportationDestination { get; set; }
        
        /// <summary>
        /// Duration in minutes for transportation
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Transportation duration cannot be negative")]
        public int? TransportationDurationMinutes { get; set; }
        
        /// <summary>
        /// Date and time when the entity was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Date and time when the entity was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        
        /// <summary>
        /// Gets the duration of the item in minutes
        /// </summary>
        /// <returns>Duration in minutes</returns>
        public int GetDurationMinutes()
        {
            return (int)(EndDateTime - StartDateTime).TotalMinutes;
        }
    }
}