using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;
using TravelApp.Domain.Exceptions;
using TravelApp.Domain.Exceptions.User;
using TravelApp.Domain.Repositories;
using TravelApp.Domain.Services;

namespace TravelApp.Application.Services
{
    /// <summary>
    /// Implementation of the destination service
    /// </summary>
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPreferenceRepository _preferenceRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationService"/> class
        /// </summary>
        /// <param name="destinationRepository">The destination repository</param>
        /// <param name="userRepository">The user repository</param>
        /// <param name="preferenceRepository">The preference repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public DestinationService(
            IDestinationRepository destinationRepository,
            IUserRepository userRepository,
            IPreferenceRepository preferenceRepository,
            IMapper mapper)
        {
            _destinationRepository = destinationRepository ?? throw new ArgumentNullException(nameof(destinationRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _preferenceRepository = preferenceRepository ?? throw new ArgumentNullException(nameof(preferenceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<Destination> Destinations, int TotalCount)> SearchDestinationsAsync(
            string? searchQuery = null,
            DestinationType? type = null,
            DestinationCategory? category = null,
            string? country = null,
            string? city = null,
            string? region = null,
            IEnumerable<string>? tags = null,
            double? minRating = null,
            CostLevel? costLevel = null,
            bool? accessibilityRequired = null,
            bool? childFriendlyRequired = null,
            Season? season = null,
            int pageSize = 10,
            int pageNumber = 1)
        {
            // Validate pagination parameters
            if (pageSize <= 0)
                throw new ArgumentException("Page size must be positive", nameof(pageSize));
            
            if (pageNumber <= 0)
                throw new ArgumentException("Page number must be positive", nameof(pageNumber));

            // Start with all destinations
            IEnumerable<Destination> results = await _destinationRepository.GetAllAsync();
            
            // Apply filters based on provided parameters
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                results = results.Where(d => 
                    d.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    d.Description.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    d.Tags.Any(t => t.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)));
            }
            
            if (type.HasValue)
            {
                results = results.Where(d => d.Type == type.Value);
            }
            
            if (category.HasValue)
            {
                results = results.Where(d => d.Category == category.Value);
            }
            
            if (!string.IsNullOrWhiteSpace(country))
            {
                results = results.Where(d => d.Country.Equals(country, StringComparison.OrdinalIgnoreCase));
            }
            
            if (!string.IsNullOrWhiteSpace(city))
            {
                results = results.Where(d => d.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            }
            
            if (!string.IsNullOrWhiteSpace(region))
            {
                results = results.Where(d => d.Region.Equals(region, StringComparison.OrdinalIgnoreCase));
            }
            
            if (tags != null && tags.Any())
            {
                var tagList = tags.ToList();
                results = results.Where(d => d.Tags.Intersect(tagList, StringComparer.OrdinalIgnoreCase).Any());
            }
            
            if (minRating.HasValue)
            {
                results = results.Where(d => d.AverageRating >= minRating.Value);
            }
            
            if (costLevel.HasValue)
            {
                results = results.Where(d => d.CostLevel == costLevel.Value);
            }
            
            if (accessibilityRequired.HasValue && accessibilityRequired.Value)
            {
                results = results.Where(d => d.IsAccessible);
            }
            
            if (childFriendlyRequired.HasValue && childFriendlyRequired.Value)
            {
                results = results.Where(d => d.IsChildFriendly);
            }
            
            if (season.HasValue)
            {
                results = results.Where(d => d.RecommendedSeasons.Contains(season.Value));
            }
            
            // Calculate total count before pagination
            int totalCount = results.Count();
            
            // Apply pagination
            results = results
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return (results, totalCount);
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<Destination> Destinations, int TotalCount)> GetNearbyDestinationsAsync(
            double latitude,
            double longitude,
            double radiusKm,
            DestinationType? type = null,
            DestinationCategory? category = null,
            int pageSize = 10,
            int pageNumber = 1)
        {
            // Validate parameters
            if (latitude < -90 || latitude > 90)
                throw new ArgumentException("Latitude must be between -90 and 90", nameof(latitude));
            
            if (longitude < -180 || longitude > 180)
                throw new ArgumentException("Longitude must be between -180 and 180", nameof(longitude));
            
            if (radiusKm <= 0)
                throw new ArgumentException("Radius must be positive", nameof(radiusKm));
            
            if (pageSize <= 0)
                throw new ArgumentException("Page size must be positive", nameof(pageSize));
            
            if (pageNumber <= 0)
                throw new ArgumentException("Page number must be positive", nameof(pageNumber));

            // Get nearby destinations from repository
            var nearbyDestinations = await _destinationRepository.GetNearLocationAsync(latitude, longitude, radiusKm);
            
            // Apply additional filters
            if (type.HasValue)
            {
                nearbyDestinations = nearbyDestinations.Where(d => d.Type == type.Value);
            }
            
            if (category.HasValue)
            {
                nearbyDestinations = nearbyDestinations.Where(d => d.Category == category.Value);
            }
            
            // Calculate total count before pagination
            int totalCount = nearbyDestinations.Count();
            
            // Apply pagination
            nearbyDestinations = nearbyDestinations
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return (nearbyDestinations, totalCount);
        }

        /// <inheritdoc/>
        public async Task<Destination> GetDestinationDetailsAsync(string destinationId)
        {
            if (string.IsNullOrWhiteSpace(destinationId))
                throw new ArgumentException("Destination ID cannot be empty", nameof(destinationId));
            
            var destination = await _destinationRepository.GetByIdAsync(destinationId);
            
            if (destination == null)
                throw new EntityNotFoundException("Destination", destinationId);
            
            return destination;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Destination>> GetPopularDestinationsAsync(
            int count = 10,
            DestinationCategory? category = null,
            DestinationType? type = null)
        {
            if (count <= 0)
                throw new ArgumentException("Count must be positive", nameof(count));
            
            // Get top rated destinations from repository
            var popularDestinations = await _destinationRepository.GetTopRatedAsync(count * 2); // Get more to apply additional filters
            
            // Apply additional filters
            if (category.HasValue)
            {
                popularDestinations = popularDestinations.Where(d => d.Category == category.Value);
            }
            
            if (type.HasValue)
            {
                popularDestinations = popularDestinations.Where(d => d.Type == type.Value);
            }
            
            // Take the requested number of destinations
            return popularDestinations.Take(count).ToList();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Destination>> GetSeasonalDestinationsAsync(Season season, int count = 10)
        {
            if (count <= 0)
                throw new ArgumentException("Count must be positive", nameof(count));
            
            // Get destinations recommended for the specified season
            var seasonalDestinations = await _destinationRepository.GetByRecommendedSeasonAsync(season);
            
            // Take the requested number of destinations
            return seasonalDestinations.Take(count).ToList();
        }

        /// <inheritdoc/>
        public async Task<string> GetTravelAdvisoriesAsync(string destinationId)
        {
            if (string.IsNullOrWhiteSpace(destinationId))
                throw new ArgumentException("Destination ID cannot be empty", nameof(destinationId));
            
            var destination = await _destinationRepository.GetByIdAsync(destinationId);
            
            if (destination == null)
                throw new EntityNotFoundException("Destination", destinationId);
            
            // Return travel advisories from destination
            // In a real implementation, this might involve calling an external API for up-to-date information
            return destination.TravelAdvisories;
        }

        /// <inheritdoc/>
        public async Task<string> GetWeatherForecastAsync(string destinationId, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(destinationId))
                throw new ArgumentException("Destination ID cannot be empty", nameof(destinationId));
            
            var destination = await _destinationRepository.GetByIdAsync(destinationId);
            
            if (destination == null)
                throw new EntityNotFoundException("Destination", destinationId);
            
            // In a real implementation, this would call a weather API
            // For now, return a placeholder
            return $"Weather forecast for {destination.Name} on {date.ToShortDateString()}: " +
                   $"This is a placeholder. In a real implementation, this would call a weather API.";
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Destination>> GetRecommendedDestinationsForUserAsync(string userId, int count = 10)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID cannot be empty", nameof(userId));
            
            if (count <= 0)
                throw new ArgumentException("Count must be positive", nameof(count));
            
            // Get user and preferences
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);
            
            var preferences = await _preferenceRepository.GetByUserIdAsync(userId);
            if (preferences == null)
                throw new EntityNotFoundException("Preference", userId);
            
            // Get all destinations
            var allDestinations = await _destinationRepository.GetAllAsync();
            
            // Score destinations based on user preferences
            var scoredDestinations = allDestinations.Select(d => new
            {
                Destination = d,
                Score = CalculateDestinationScore(d, preferences)
            })
            .OrderByDescending(sd => sd.Score)
            .Take(count)
            .Select(sd => sd.Destination)
            .ToList();
            
            return scoredDestinations;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Destination>> GetSimilarDestinationsAsync(string destinationId, int count = 5)
        {
            if (string.IsNullOrWhiteSpace(destinationId))
                throw new ArgumentException("Destination ID cannot be empty", nameof(destinationId));
            
            if (count <= 0)
                throw new ArgumentException("Count must be positive", nameof(count));
            
            // Get the reference destination
            var referenceDestination = await _destinationRepository.GetByIdAsync(destinationId);
            if (referenceDestination == null)
                throw new EntityNotFoundException("Destination", destinationId);
            
            // Get all destinations
            var allDestinations = await _destinationRepository.GetAllAsync();
            
            // Filter out the reference destination
            allDestinations = allDestinations.Where(d => d.Id != destinationId);
            
            // Score destinations based on similarity to reference destination
            var similarDestinations = allDestinations.Select(d => new
            {
                Destination = d,
                SimilarityScore = CalculateSimilarityScore(referenceDestination, d)
            })
            .OrderByDescending(sd => sd.SimilarityScore)
            .Take(count)
            .Select(sd => sd.Destination)
            .ToList();
            
            return similarDestinations;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Destination>> GetOffTheBeatenPathDestinationsAsync(string? region = null, int count = 5)
        {
            if (count <= 0)
                throw new ArgumentException("Count must be positive", nameof(count));
            
            // Get all destinations
            var allDestinations = await _destinationRepository.GetAllAsync();
            
            // Apply region filter if provided
            if (!string.IsNullOrWhiteSpace(region))
            {
                allDestinations = allDestinations.Where(d => d.Region.Equals(region, StringComparison.OrdinalIgnoreCase));
            }
            
            // Consider destinations with lower ratings count but reasonable ratings as off-the-beaten-path
            var offTheBeatenPathDestinations = allDestinations
                .Where(d => d.RatingsCount < 100 && d.AverageRating >= 3.5)
                .OrderBy(d => d.RatingsCount)
                .Take(count)
                .ToList();
            
            return offTheBeatenPathDestinations;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> GetTransportationOptionsAsync(
            string fromDestinationId,
            string toDestinationId,
            DateTime date)
        {
            if (string.IsNullOrWhiteSpace(fromDestinationId))
                throw new ArgumentException("Source destination ID cannot be empty", nameof(fromDestinationId));
            
            if (string.IsNullOrWhiteSpace(toDestinationId))
                throw new ArgumentException("Target destination ID cannot be empty", nameof(toDestinationId));
            
            // Get source and target destinations
            var sourceDestination = await _destinationRepository.GetByIdAsync(fromDestinationId);
            if (sourceDestination == null)
                throw new EntityNotFoundException("Destination", fromDestinationId);
            
            var targetDestination = await _destinationRepository.GetByIdAsync(toDestinationId);
            if (targetDestination == null)
                throw new EntityNotFoundException("Destination", toDestinationId);
            
            // In a real implementation, this would call a transportation API
            // For now, return a placeholder with common transportation options
            var options = new List<string>
            {
                $"Taxi from {sourceDestination.Name} to {targetDestination.Name}",
                $"Bus from {sourceDestination.Name} to {targetDestination.Name}",
                $"Train from {sourceDestination.Name} to {targetDestination.Name}",
                $"Rental car from {sourceDestination.Name} to {targetDestination.Name}"
            };
            
            // Add flight option if destinations are far apart
            double distance = CalculateDistance(
                sourceDestination.Latitude, sourceDestination.Longitude,
                targetDestination.Latitude, targetDestination.Longitude);
            
            if (distance > 100) // More than 100km
            {
                options.Add($"Flight from {sourceDestination.Name} to {targetDestination.Name}");
            }
            
            return options;
        }

        #region Helper Methods

        /// <summary>
        /// Calculates a score for a destination based on user preferences
        /// </summary>
        /// <param name="destination">The destination to score</param>
        /// <param name="preferences">The user's preferences</param>
        /// <returns>The preference match score</returns>
        private double CalculateDestinationScore(Destination destination, Preference preferences)
        {
            double score = 0;
            
            // Avoid destinations already visited
            if (preferences.VisitedDestinations.Contains(destination.Id))
            {
                return -100; // Strong negative score for already visited destinations
            }
            
            // Boost score for wishlist destinations
            if (preferences.WishlistDestinations.Contains(destination.Id))
            {
                score += 50;
            }
            
            // Match interests
            foreach (var interest in preferences.Interests)
            {
                if (MatchesInterest(destination, interest))
                {
                    score += 10;
                }
            }
            
            // Match budget level
            if (destination.CostLevel == CostLevel.Free || BudgetMatchesPreference(destination.CostLevel, preferences.BudgetLevel))
            {
                score += 10;
            }
            
            // Match accessibility requirements
            if (preferences.AccessibilityRequirements.Any() && destination.IsAccessible)
            {
                score += 10;
            }
            
            // Match child-friendly preference
            if (preferences.ChildFriendly && destination.IsChildFriendly)
            {
                score += 10;
            }
            
            // Match climate preference
            if (preferences.PreferredClimates.Contains(destination.Climate))
            {
                score += 5;
            }
            
            // Consider rating
            score += destination.AverageRating * 2;
            
            return score;
        }

        /// <summary>
        /// Determines if a destination matches a specific interest
        /// </summary>
        /// <param name="destination">The destination</param>
        /// <param name="interest">The interest to check</param>
        /// <returns>True if the destination matches the interest</returns>
        private bool MatchesInterest(Destination destination, TravelInterest interest)
        {
            // Simple keyword matching for interests
            // In a real implementation, this would be more sophisticated
            switch (interest)
            {
                case TravelInterest.Beaches:
                    return destination.Type == DestinationType.Beach || 
                           destination.Tags.Any(t => t.Contains("beach", StringComparison.OrdinalIgnoreCase));
                
                case TravelInterest.Mountains:
                    return destination.Type == DestinationType.Mountain || 
                           destination.Tags.Any(t => t.Contains("mountain", StringComparison.OrdinalIgnoreCase));
                
                case TravelInterest.Cities:
                    return destination.Type == DestinationType.City;
                
                case TravelInterest.Museums:
                    return destination.Type == DestinationType.Museum || 
                           destination.Tags.Any(t => t.Contains("museum", StringComparison.OrdinalIgnoreCase));
                
                case TravelInterest.HistoricalSites:
                    return destination.Type == DestinationType.Historical || 
                           destination.Tags.Any(t => t.Contains("historical", StringComparison.OrdinalIgnoreCase) || 
                                               t.Contains("history", StringComparison.OrdinalIgnoreCase));
                
                case TravelInterest.Food:
                    return destination.Type == DestinationType.Restaurant || 
                           destination.Tags.Any(t => t.Contains("food", StringComparison.OrdinalIgnoreCase) || 
                                               t.Contains("culinary", StringComparison.OrdinalIgnoreCase));
                
                case TravelInterest.Shopping:
                    return destination.Type == DestinationType.Shopping || 
                           destination.Tags.Any(t => t.Contains("shopping", StringComparison.OrdinalIgnoreCase));
                
                case TravelInterest.Nightlife:
                    return destination.Category == DestinationCategory.Nightlife || 
                           destination.Tags.Any(t => t.Contains("nightlife", StringComparison.OrdinalIgnoreCase));
                
                case TravelInterest.Nature:
                    return destination.Category == DestinationCategory.Nature || 
                           destination.Type == DestinationType.NaturalLandmark || 
                           destination.Tags.Any(t => t.Contains("nature", StringComparison.OrdinalIgnoreCase));
                
                case TravelInterest.Culture:
                    return destination.Category == DestinationCategory.Cultural || 
                           destination.Type == DestinationType.Cultural || 
                           destination.Tags.Any(t => t.Contains("culture", StringComparison.OrdinalIgnoreCase));
                
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines if a destination's cost level matches user's budget preferences
        /// </summary>
        /// <param name="destinationCostLevel">The destination's cost level</param>
        /// <param name="preferenceBudgetLevel">The user's budget level preference</param>
        /// <returns>True if the cost level matches the budget preference</returns>
        private bool BudgetMatchesPreference(CostLevel destinationCostLevel, BudgetLevel preferenceBudgetLevel)
        {
            switch (preferenceBudgetLevel)
            {
                case BudgetLevel.Budget:
                    return destinationCostLevel <= CostLevel.Low;
                
                case BudgetLevel.Medium:
                    return destinationCostLevel <= CostLevel.Medium;
                
                case BudgetLevel.Luxury:
                    return destinationCostLevel <= CostLevel.High;
                
                case BudgetLevel.UltraLuxury:
                    return true; // Ultra luxury budget can afford any cost level
                
                default:
                    return destinationCostLevel <= CostLevel.Medium;
            }
        }

        /// <summary>
        /// Calculates the similarity score between two destinations
        /// </summary>
        /// <param name="reference">The reference destination</param>
        /// <param name="other">The destination to compare with</param>
        /// <returns>The similarity score</returns>
        private double CalculateSimilarityScore(Destination reference, Destination other)
        {
            double score = 0;
            
            // Same type and category are strong indicators of similarity
            if (reference.Type == other.Type)
                score += 20;
            
            if (reference.Category == other.Category)
                score += 20;
            
            // Same region or country indicates geographical similarity
            if (reference.Country.Equals(other.Country, StringComparison.OrdinalIgnoreCase))
                score += 10;
            
            if (reference.Region.Equals(other.Region, StringComparison.OrdinalIgnoreCase))
                score += 15;
            
            // Overlapping tags indicate similar characteristics
            int commonTags = reference.Tags.Intersect(other.Tags, StringComparer.OrdinalIgnoreCase).Count();
            score += commonTags * 5;
            
            // Similar cost level
            int costLevelDifference = Math.Abs((int)reference.CostLevel - (int)other.CostLevel);
            score += (5 - costLevelDifference) * 2; // 0 difference = +10, 5 difference = 0
            
            // Similar climate
            if (reference.Climate == other.Climate)
                score += 10;
            
            // Similar accessibility and child-friendliness
            if (reference.IsAccessible == other.IsAccessible)
                score += 5;
            
            if (reference.IsChildFriendly == other.IsChildFriendly)
                score += 5;
            
            // Common recommended seasons
            int commonSeasons = reference.RecommendedSeasons.Intersect(other.RecommendedSeasons).Count();
            score += commonSeasons * 2;
            
            return score;
        }

        /// <summary>
        /// Calculates the distance between two geographical points using the Haversine formula
        /// </summary>
        /// <param name="lat1">Latitude of first point in degrees</param>
        /// <param name="lon1">Longitude of first point in degrees</param>
        /// <param name="lat2">Latitude of second point in degrees</param>
        /// <param name="lon2">Longitude of second point in degrees</param>
        /// <returns>Distance in kilometers</returns>
        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadiusKm = 6371;
            
            // Convert degrees to radians
            double lat1Rad = DegreesToRadians(lat1);
            double lon1Rad = DegreesToRadians(lon1);
            double lat2Rad = DegreesToRadians(lat2);
            double lon2Rad = DegreesToRadians(lon2);
            
            // Haversine formula
            double dLat = lat2Rad - lat1Rad;
            double dLon = lon2Rad - lon1Rad;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = EarthRadiusKm * c;
            
            return distance;
        }

        /// <summary>
        /// Converts degrees to radians
        /// </summary>
        /// <param name="degrees">Angle in degrees</param>
        /// <returns>Angle in radians</returns>
        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        
        #endregion
    }
}