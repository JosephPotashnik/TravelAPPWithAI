using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TravelApp.Infrastructure.Database
{
    /// <summary>
    /// MongoDB database context
    /// </summary>
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoDbSettings _settings;

        /// <summary>
        /// Initializes a new instance of the MongoDbContext class
        /// </summary>
        /// <param name="options">MongoDB settings options</param>
        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            _settings = options.Value;

            try
            {
                var client = new MongoClient(_settings.ConnectionString);
                _database = client.GetDatabase(_settings.DatabaseName);
            }
            catch (Exception ex)
            {
                // In a real-world scenario, we would use a proper logging mechanism here
                Console.WriteLine($"Error connecting to MongoDB: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get a MongoDB collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <param name="collectionName">Name of the collection</param>
        /// <returns>MongoDB collection</returns>
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        /// <summary>
        /// Get the Users collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <returns>Users collection</returns>
        public IMongoCollection<T> Users<T>() => GetCollection<T>(_settings.UsersCollection);

        /// <summary>
        /// Get the Itineraries collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <returns>Itineraries collection</returns>
        public IMongoCollection<T> Itineraries<T>() => GetCollection<T>(_settings.ItinerariesCollection);

        /// <summary>
        /// Get the Destinations collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <returns>Destinations collection</returns>
        public IMongoCollection<T> Destinations<T>() => GetCollection<T>(_settings.DestinationsCollection);

        /// <summary>
        /// Get the Feedback collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <returns>Feedback collection</returns>
        public IMongoCollection<T> Feedback<T>() => GetCollection<T>(_settings.FeedbackCollection);
    }
}