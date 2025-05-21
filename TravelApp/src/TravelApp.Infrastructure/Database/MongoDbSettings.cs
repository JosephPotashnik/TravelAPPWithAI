using System;

namespace TravelApp.Infrastructure.Database
{
    /// <summary>
    /// MongoDB connection settings
    /// </summary>
    public class MongoDbSettings
    {
        /// <summary>
        /// Connection string to MongoDB instance
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;
        
        /// <summary>
        /// Database name
        /// </summary>
        public string DatabaseName { get; set; } = string.Empty;

        /// <summary>
        /// Users collection name
        /// </summary>
        public string UsersCollection { get; set; } = "Users";
        
        /// <summary>
        /// Itineraries collection name
        /// </summary>
        public string ItinerariesCollection { get; set; } = "Itineraries";
        
        /// <summary>
        /// Destinations collection name
        /// </summary>
        public string DestinationsCollection { get; set; } = "Destinations";
        
        /// <summary>
        /// Feedback collection name
        /// </summary>
        public string FeedbackCollection { get; set; } = "Feedback";
    }
}