using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TravelApp.Application.Mapping
{
    /// <summary>
    /// Configuration class for setting up AutoMapper
    /// </summary>
    public static class MappingConfig
    {
        /// <summary>
        /// Adds AutoMapper configuration to the service collection
        /// </summary>
        /// <param name="services">The service collection to add AutoMapper to</param>
        /// <returns>The service collection with AutoMapper configured</returns>
        public static IServiceCollection AddMappingConfiguration(this IServiceCollection services)
        {
            // Add AutoMapper with all profiles from this assembly
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;
        }

        /// <summary>
        /// Creates and configures a new instance of the AutoMapper configuration
        /// </summary>
        /// <returns>Configured AutoMapper configuration</returns>
        public static MapperConfiguration GetMapperConfiguration()
        {
            // Create and configure the mapping configuration
            var config = new MapperConfiguration(cfg =>
            {
                // Add all mapping profiles
                cfg.AddProfile<UserMappingProfile>();
                cfg.AddProfile<PreferenceMappingProfile>();
                cfg.AddProfile<ItineraryMappingProfile>();
                cfg.AddProfile<DestinationMappingProfile>();
                cfg.AddProfile<FeedbackMappingProfile>();
            });

            // Validate the configuration
            config.AssertConfigurationIsValid();

            return config;
        }

        /// <summary>
        /// Creates a new instance of the AutoMapper
        /// </summary>
        /// <returns>Configured mapper instance</returns>
        public static IMapper CreateMapper()
        {
            return GetMapperConfiguration().CreateMapper();
        }
    }
}