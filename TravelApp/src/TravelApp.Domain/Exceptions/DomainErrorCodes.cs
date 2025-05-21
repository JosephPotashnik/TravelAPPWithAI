namespace TravelApp.Domain.Exceptions
{
    /// <summary>
    /// Defines error codes for domain exceptions
    /// </summary>
    public static class DomainErrorCodes
    {
        // General domain errors (1000-1099)
        public const string InvalidEntityState = "DOM1000";
        public const string EntityNotFound = "DOM1001";
        public const string ValidationFailed = "DOM1002";
        public const string UnauthorizedOperation = "DOM1003";
        public const string ConcurrencyConflict = "DOM1004";
        
        // User domain errors (1100-1199)
        public const string UserNotFound = "DOM1100";
        public const string InvalidCredentials = "DOM1101";
        public const string EmailAlreadyExists = "DOM1102";
        public const string UsernameAlreadyExists = "DOM1103";
        public const string UserAccountLocked = "DOM1104";
        public const string UserAccountDeactivated = "DOM1105";
        public const string EmailVerificationRequired = "DOM1106";
        public const string InvalidVerificationToken = "DOM1107";
        public const string InvalidResetToken = "DOM1108";
        public const string InvalidPassword = "DOM1109";
        
        // Preference domain errors (1200-1299)
        public const string PreferenceNotFound = "DOM1200";
        public const string InvalidPreference = "DOM1201";
        
        // Itinerary domain errors (1300-1399)
        public const string ItineraryNotFound = "DOM1300";
        public const string InvalidItinerary = "DOM1301";
        public const string ItineraryGenerationFailed = "DOM1302";
        public const string InvalidItineraryDates = "DOM1303";
        public const string InvalidItineraryBudget = "DOM1304";
        public const string ItineraryOptimizationFailed = "DOM1305";
        public const string ItineraryVersionConflict = "DOM1306";
        public const string ItineraryItemNotFound = "DOM1307";
        public const string InvalidItineraryItem = "DOM1308";
        
        // Destination domain errors (1400-1499)
        public const string DestinationNotFound = "DOM1400";
        public const string InvalidDestination = "DOM1401";
        public const string DestinationUnavailable = "DOM1402";
        public const string InvalidLocationCoordinates = "DOM1403";
        public const string WeatherDataUnavailable = "DOM1404";
        public const string TravelAdvisoryUnavailable = "DOM1405";
        
        // Feedback domain errors (1500-1599)
        public const string FeedbackNotFound = "DOM1500";
        public const string InvalidFeedback = "DOM1501";
        public const string DuplicateFeedback = "DOM1502";
        
        // External services errors (1600-1699)
        public const string ExternalServiceFailed = "DOM1600";
        public const string AIServiceFailed = "DOM1601";
        public const string MapsServiceFailed = "DOM1602";
        public const string WeatherServiceFailed = "DOM1603";
        public const string TravelAdvisoryServiceFailed = "DOM1604";
    }
}