using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TravelApp.Infrastructure.Database
{
    /// <summary>
    /// Extension methods for setting up MongoDB services
    /// </summary>
    public static class MongoDbExtensions
    {
        /// <summary>
        /// Adds MongoDB services to the service collection
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind MongoDB settings from configuration
            var mongoDbSettings = new MongoDbSettings();
            configuration.GetSection("MongoDB").Bind(mongoDbSettings);

            // Validate connection string
            if (string.IsNullOrEmpty(mongoDbSettings.ConnectionString))
            {
                throw new ArgumentException("MongoDB connection string is not configured.");
            }

            // Validate database name
            if (string.IsNullOrEmpty(mongoDbSettings.DatabaseName))
            {
                throw new ArgumentException("MongoDB database name is not configured.");
            }

            // Configure MongoDB settings as options
            services.Configure<MongoDbSettings>(options => 
                configuration.GetSection("MongoDB").Bind(options));

            // Register MongoDB context
            services.AddSingleton<IMongoDbContext, MongoDbContext>();

            return services;
        }
    }
}