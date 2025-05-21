using MongoDB.Driver;

namespace TravelApp.Infrastructure.Database
{
    /// <summary>
    /// Interface for MongoDB database context
    /// </summary>
    public interface IMongoDbContext
    {
        /// <summary>
        /// Get a MongoDB collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <param name="collectionName">Name of the collection</param>
        /// <returns>MongoDB collection</returns>
        IMongoCollection<T> GetCollection<T>(string collectionName);

        /// <summary>
        /// Get the Users collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <returns>Users collection</returns>
        IMongoCollection<T> Users<T>();

        /// <summary>
        /// Get the Itineraries collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <returns>Itineraries collection</returns>
        IMongoCollection<T> Itineraries<T>();

        /// <summary>
        /// Get the Destinations collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <returns>Destinations collection</returns>
        IMongoCollection<T> Destinations<T>();

        /// <summary>
        /// Get the Feedback collection
        /// </summary>
        /// <typeparam name="T">Type of documents in the collection</typeparam>
        /// <returns>Feedback collection</returns>
        IMongoCollection<T> Feedback<T>();
    }
}