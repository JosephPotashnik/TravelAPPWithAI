using System;
using TravelApp.Domain.Common;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Entities
{
    /// <summary>
    /// ItineraryItem entity representing an activity, accommodation, or transportation in an itinerary
    /// </summary>
    public class ItineraryItem : Entity
    {
        /// <summary>
        /// Reference to the itinerary this item belongs to
        /// </summary>
        public string ItineraryId { get; set; } = string.Empty;

        /// <summary>
        /// Title or name of the item
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description of the item
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Type of the itinerary item
        /// </summary>
        public ItineraryItemType Type { get; set; }

        /// <summary>
        /// Start date and time of the item
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// End date and time of the item
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Day number in the itinerary (1 = first day)
        /// </summary>
        public int DayNumber { get; set; }

        /// <summary>
        /// Order within the day
        /// </summary>
        public int OrderInDay { get; set; }

        /// <summary>
        /// Location name
        /// </summary>
        public string LocationName { get; set; } = string.Empty;

        /// <summary>
        /// Reference to destination (if applicable)
        /// </summary>
        public string? DestinationId { get; set; }

        /// <summary>
        /// Address of the location
        /// </summary>
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
        public decimal? Cost { get; set; }

        /// <summary>
        /// Booking reference (if applicable)
        /// </summary>
        public string BookingReference { get; set; } = string.Empty;

        /// <summary>
        /// URL for booking or more information
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Notes or special requirements for this item
        /// </summary>
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
        public string? TransportationSource { get; set; }

        /// <summary>
        /// Destination location for transportation (if applicable)
        /// </summary>
        public string? TransportationDestination { get; set; }

        /// <summary>
        /// Duration in minutes for transportation
        /// </summary>
        public int? TransportationDurationMinutes { get; set; }

        /// <summary>
        /// Validates the itinerary item entity
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when validation fails</exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(ItineraryId))
                throw new ArgumentException("Itinerary ID cannot be empty", nameof(ItineraryId));

            if (string.IsNullOrWhiteSpace(Title))
                throw new ArgumentException("Title cannot be empty", nameof(Title));

            if (EndDateTime < StartDateTime)
                throw new ArgumentException("End time cannot be before start time", nameof(EndDateTime));

            if (DayNumber <= 0)
                throw new ArgumentException("Day number must be positive", nameof(DayNumber));

            if (OrderInDay < 0)
                throw new ArgumentException("Order in day cannot be negative", nameof(OrderInDay));

            if (Cost.HasValue && Cost.Value < 0)
                throw new ArgumentException("Cost cannot be negative", nameof(Cost));

            if (IsTransportation)
            {
                if (!TransportationMode.HasValue)
                    throw new ArgumentException("Transportation mode is required for transportation items", nameof(TransportationMode));

                if (string.IsNullOrWhiteSpace(TransportationSource))
                    throw new ArgumentException("Transportation source is required for transportation items", nameof(TransportationSource));

                if (string.IsNullOrWhiteSpace(TransportationDestination))
                    throw new ArgumentException("Transportation destination is required for transportation items", nameof(TransportationDestination));
            }
        }

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