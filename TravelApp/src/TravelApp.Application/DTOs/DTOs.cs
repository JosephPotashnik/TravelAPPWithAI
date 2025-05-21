namespace TravelApp.Application.DTOs
{
    /// <summary>
    /// Data Transfer Objects (DTOs) used for data exchange between layers
    /// This file serves as a reference for all DTOs in the application
    /// </summary>
    public static class DTOReferences
    {
        // User-related DTOs
        public static readonly System.Type UserDTO = typeof(UserDTO);
        
        // Preference-related DTOs
        public static readonly System.Type PreferenceDTO = typeof(PreferenceDTO);
        
        // Itinerary-related DTOs
        public static readonly System.Type ItineraryDTO = typeof(ItineraryDTO);
        public static readonly System.Type ItineraryItemDTO = typeof(ItineraryItemDTO);
        
        // Destination-related DTOs
        public static readonly System.Type DestinationDTO = typeof(DestinationDTO);
        
        // Feedback-related DTOs
        public static readonly System.Type FeedbackDTO = typeof(FeedbackDTO);
    }
}