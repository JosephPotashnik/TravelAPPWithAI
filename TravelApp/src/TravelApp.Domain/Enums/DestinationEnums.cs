namespace TravelApp.Domain.Enums
{
    /// <summary>
    /// Types of destinations
    /// </summary>
    public enum DestinationType
    {
        City,
        Region,
        Country,
        Attraction,
        NaturalLandmark,
        Hotel,
        Restaurant,
        Museum,
        Park,
        Beach,
        Mountain,
        Historical,
        Cultural,
        Entertainment,
        Shopping
    }

    /// <summary>
    /// Categories of destinations
    /// </summary>
    public enum DestinationCategory
    {
        Landmark,
        Accommodation,
        Dining,
        Nightlife,
        Shopping,
        Nature,
        Cultural,
        Historical,
        Entertainment,
        Sports,
        Wellness,
        Educational,
        Religious,
        Business,
        Transport
    }

    /// <summary>
    /// Cost levels for destinations
    /// </summary>
    public enum CostLevel
    {
        Free,
        Low,
        Medium,
        High,
        VeryHigh
    }

    /// <summary>
    /// Seasons of the year
    /// </summary>
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter,
        YearRound
    }
}