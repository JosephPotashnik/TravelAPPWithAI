using System;

namespace TravelApp.Domain.Enums
{
    /// <summary>
    /// Travel interest categories
    /// </summary>
    [Flags]
    public enum TravelInterest
    {
        None = 0,
        Beaches = 1 << 0,
        Mountains = 1 << 1,
        Cities = 1 << 2,
        Museums = 1 << 3,
        HistoricalSites = 1 << 4,
        Food = 1 << 5,
        Shopping = 1 << 6,
        Nightlife = 1 << 7, 
        Nature = 1 << 8,
        Adventure = 1 << 9,
        Relaxation = 1 << 10,
        Culture = 1 << 11,
        Sports = 1 << 12,
        FamilyActivities = 1 << 13,
        LocalExperiences = 1 << 14,
        Wildlife = 1 << 15,
        PhotographySpots = 1 << 16,
        Architecture = 1 << 17
    }

    /// <summary>
    /// Budget range levels
    /// </summary>
    public enum BudgetLevel
    {
        Budget,
        Medium,
        Luxury,
        UltraLuxury
    }

    /// <summary>
    /// Pace of travel preference
    /// </summary>
    public enum TravelPace
    {
        Relaxed,
        Moderate,
        Intensive
    }

    /// <summary>
    /// Preferred accommodation types
    /// </summary>
    public enum AccommodationType
    {
        Hotel,
        Hostel,
        Resort,
        Apartment,
        Villa,
        BedAndBreakfast,
        Camping,
        GuestHouse,
        Boutique,
        LuxuryHotel
    }

    /// <summary>
    /// Accessibility requirements
    /// </summary>
    [Flags]
    public enum AccessibilityRequirement
    {
        None = 0,
        WheelchairAccessible = 1 << 0,
        LimitedMobility = 1 << 1,
        VisualImpairment = 1 << 2,
        HearingImpairment = 1 << 3,
        NoStairs = 1 << 4,
        ElevatorAccess = 1 << 5,
        AccessibleBathroom = 1 << 6,
        AccessibleTransportation = 1 << 7
    }

    /// <summary>
    /// Transportation modes
    /// </summary>
    [Flags]
    public enum TransportationMode
    {
        None = 0,
        Walking = 1 << 0,
        PublicTransport = 1 << 1,
        RentalCar = 1 << 2,
        Taxi = 1 << 3,
        Bicycle = 1 << 4,
        Ferry = 1 << 5,
        Train = 1 << 6,
        Bus = 1 << 7,
        RideSharing = 1 << 8,
        Scooter = 1 << 9
    }

    /// <summary>
    /// Dietary preferences and restrictions
    /// </summary>
    [Flags]
    public enum DietaryPreference
    {
        None = 0,
        Vegetarian = 1 << 0,
        Vegan = 1 << 1,
        GlutenFree = 1 << 2,
        DairyFree = 1 << 3,
        NutAllergy = 1 << 4,
        Halal = 1 << 5,
        Kosher = 1 << 6,
        Pescatarian = 1 << 7,
        LowCarb = 1 << 8,
        LowSugar = 1 << 9,
        LocalCuisine = 1 << 10
    }

    /// <summary>
    /// Climate type preferences
    /// </summary>
    [Flags]
    public enum ClimateType
    {
        None = 0,
        Tropical = 1 << 0,
        Desert = 1 << 1,
        Mediterranean = 1 << 2,
        Continental = 1 << 3,
        Polar = 1 << 4,
        Temperate = 1 << 5,
        Alpine = 1 << 6,
        Coastal = 1 << 7
    }

    /// <summary>
    /// Preferred trip duration
    /// </summary>
    public enum TripDuration
    {
        Weekend,     // 1-3 days
        Short,       // 4-7 days
        Medium,      // 8-14 days
        Long,        // 15-30 days
        Extended     // 30+ days
    }
}