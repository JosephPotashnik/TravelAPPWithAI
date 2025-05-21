using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Exceptions;
using TravelApp.Domain.Exceptions.User;
using TravelApp.Domain.Repositories;
using TravelApp.Domain.Services;

namespace TravelApp.Application.Services
{
    /// <summary>
    /// Implementation of the itinerary management service
    /// </summary>
    public class ItineraryService
    {
        private readonly IItineraryRepository _itineraryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDestinationRepository _destinationRepository;
        private readonly IItineraryGenerationService _itineraryGenerationService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItineraryService"/> class
        /// </summary>
        /// <param name="itineraryRepository">The itinerary repository</param>
        /// <param name="userRepository">The user repository</param>
        /// <param name="destinationRepository">The destination repository</param>
        /// <param name="itineraryGenerationService">The itinerary generation service</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ItineraryService(
            IItineraryRepository itineraryRepository,
            IUserRepository userRepository,
            IDestinationRepository destinationRepository,
            IItineraryGenerationService itineraryGenerationService,
            IMapper mapper)
        {
            _itineraryRepository = itineraryRepository ?? throw new ArgumentNullException(nameof(itineraryRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _destinationRepository = destinationRepository ?? throw new ArgumentNullException(nameof(destinationRepository));
            _itineraryGenerationService = itineraryGenerationService ?? throw new ArgumentNullException(nameof(itineraryGenerationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Creates a new itinerary
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="name">The itinerary name</param>
        /// <param name="description">The itinerary description</param>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="primaryDestination">The primary destination</param>
        /// <param name="totalBudget">The total budget</param>
        /// <param name="tags">Optional tags for the itinerary</param>
        /// <returns>The created itinerary</returns>
        public async Task<Itinerary> CreateItineraryAsync(
            string userId,
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            string primaryDestination,
            decimal totalBudget,
            IEnumerable<string>? tags = null)
        {
            // Validate user exists
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Validate inputs
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Itinerary name cannot be empty", nameof(name));

            if (endDate < startDate)
                throw new ArgumentException("End date cannot be before start date", nameof(endDate));

            if (string.IsNullOrWhiteSpace(primaryDestination))
                throw new ArgumentException("Primary destination cannot be empty", nameof(primaryDestination));

            if (totalBudget < 0)
                throw new ArgumentException("Total budget cannot be negative", nameof(totalBudget));

            // Create the itinerary
            var itinerary = new Itinerary
            {
                UserId = userId,
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                PrimaryDestination = primaryDestination,
                TotalBudget = totalBudget,
                Tags = tags?.ToList() ?? new List<string>(),
                IsDraft = true,
                IsAIGenerated = false,
                IsTemplate = false,
                Version = 1
            };

            // Save the itinerary
            var savedItinerary = await _itineraryRepository.AddAsync(itinerary);

            // Update user's itinerary list
            user.ItineraryIds.Add(savedItinerary.Id);
            await _userRepository.UpdateAsync(user);

            return savedItinerary;
        }

        /// <summary>
        /// Gets an itinerary by ID
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <param name="loadItems">Whether to load itinerary items</param>
        /// <returns>The itinerary if found</returns>
        public async Task<Itinerary> GetItineraryAsync(string itineraryId, bool loadItems = false)
        {
            Itinerary? itinerary;

            if (loadItems)
            {
                itinerary = await _itineraryRepository.GetWithItemsAsync(itineraryId);
            }
            else
            {
                itinerary = await _itineraryRepository.GetByIdAsync(itineraryId);
            }

            if (itinerary == null)
                throw new EntityNotFoundException("Itinerary", itineraryId);

            return itinerary;
        }

        /// <summary>
        /// Gets all itineraries for a user
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>Collection of the user's itineraries</returns>
        public async Task<IEnumerable<Itinerary>> GetUserItinerariesAsync(string userId)
        {
            // Validate user exists
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return await _itineraryRepository.GetByUserIdAsync(userId);
        }

        /// <summary>
        /// Updates an existing itinerary
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <param name="userId">The user ID (for authorization)</param>
        /// <param name="name">The updated name (optional)</param>
        /// <param name="description">The updated description (optional)</param>
        /// <param name="startDate">The updated start date (optional)</param>
        /// <param name="endDate">The updated end date (optional)</param>
        /// <param name="primaryDestination">The updated primary destination (optional)</param>
        /// <param name="totalBudget">The updated total budget (optional)</param>
        /// <param name="tags">The updated tags (optional)</param>
        /// <param name="isDraft">The updated draft status (optional)</param>
        /// <returns>The updated itinerary</returns>
        public async Task<Itinerary> UpdateItineraryAsync(
            string itineraryId,
            string userId,
            string? name = null,
            string? description = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            string? primaryDestination = null,
            decimal? totalBudget = null,
            IEnumerable<string>? tags = null,
            bool? isDraft = null)
        {
            // Get the itinerary
            var itinerary = await _itineraryRepository.GetByIdAsync(itineraryId);
            if (itinerary == null)
                throw new EntityNotFoundException("Itinerary", itineraryId);

            // Verify ownership
            if (itinerary.UserId != userId)
                throw new UnauthorizedOperationException("UpdateItinerary", $"User {userId} does not own this itinerary");

            // Update only the provided values
            if (name != null)
                itinerary.Name = name;

            if (description != null)
                itinerary.Description = description;

            if (startDate != null)
                itinerary.StartDate = startDate.Value;

            if (endDate != null)
            {
                // Validate end date
                if (endDate < itinerary.StartDate)
                    throw new ArgumentException("End date cannot be before start date", nameof(endDate));

                itinerary.EndDate = endDate.Value;
            }

            if (primaryDestination != null)
                itinerary.PrimaryDestination = primaryDestination;

            if (totalBudget != null)
            {
                // Validate budget
                if (totalBudget < 0)
                    throw new ArgumentException("Total budget cannot be negative", nameof(totalBudget));

                itinerary.TotalBudget = totalBudget.Value;
            }

            if (tags != null)
                itinerary.Tags = tags.ToList();

            if (isDraft != null)
                itinerary.IsDraft = isDraft.Value;

            itinerary.UpdatedAt = DateTime.UtcNow;

            // Save the updated itinerary
            return await _itineraryRepository.UpdateAsync(itinerary);
        }

        /// <summary>
        /// Deletes an itinerary
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <param name="userId">The user ID (for authorization)</param>
        /// <returns>True if the deletion was successful</returns>
        public async Task<bool> DeleteItineraryAsync(string itineraryId, string userId)
        {
            // Get the itinerary
            var itinerary = await _itineraryRepository.GetByIdAsync(itineraryId);
            if (itinerary == null)
                throw new EntityNotFoundException("Itinerary", itineraryId);

            // Verify ownership
            if (itinerary.UserId != userId)
                throw new UnauthorizedOperationException("DeleteItinerary", $"User {userId} does not own this itinerary");

            // Remove the itinerary from the user's list
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                user.ItineraryIds.Remove(itineraryId);
                await _userRepository.UpdateAsync(user);
            }

            // Delete the itinerary
            return await _itineraryRepository.RemoveAsync(itineraryId);
        }

        /// <summary>
        /// Creates a new version of an itinerary
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <param name="userId">The user ID (for authorization)</param>
        /// <param name="versionNotes">Notes about the new version</param>
        /// <returns>The new itinerary version</returns>
        public async Task<Itinerary> CreateNewVersionAsync(string itineraryId, string userId, string versionNotes)
        {
            // Get the original itinerary
            var itinerary = await _itineraryRepository.GetWithItemsAsync(itineraryId);
            if (itinerary == null)
                throw new EntityNotFoundException("Itinerary", itineraryId);

            // Verify ownership
            if (itinerary.UserId != userId)
                throw new UnauthorizedOperationException("CreateNewVersion", $"User {userId} does not own this itinerary");

            // Create new version
            var newVersion = itinerary.CreateNewVersion(versionNotes);

            // Save the new version
            var savedVersion = await _itineraryRepository.AddAsync(newVersion);

            // Update user's itinerary list
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                user.ItineraryIds.Add(savedVersion.Id);
                await _userRepository.UpdateAsync(user);
            }

            return savedVersion;
        }

        /// <summary>
        /// Creates a template from an existing itinerary
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <param name="userId">The user ID (for authorization)</param>
        /// <returns>The new template itinerary</returns>
        public async Task<Itinerary> CreateTemplateAsync(string itineraryId, string userId)
        {
            // Get the original itinerary
            var itinerary = await _itineraryRepository.GetWithItemsAsync(itineraryId);
            if (itinerary == null)
                throw new EntityNotFoundException("Itinerary", itineraryId);

            // Verify ownership
            if (itinerary.UserId != userId)
                throw new UnauthorizedOperationException("CreateTemplate", $"User {userId} does not own this itinerary");

            // Create template
            var template = itinerary.CreateTemplateFromThis();

            // Save the template
            var savedTemplate = await _itineraryRepository.AddAsync(template);

            // Update user's itinerary list
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                user.ItineraryIds.Add(savedTemplate.Id);
                await _userRepository.UpdateAsync(user);
            }

            return savedTemplate;
        }

        /// <summary>
        /// Gets all template itineraries
        /// </summary>
        /// <returns>Collection of template itineraries</returns>
        public async Task<IEnumerable<Itinerary>> GetTemplatesAsync()
        {
            return await _itineraryRepository.GetTemplatesAsync();
        }

        /// <summary>
        /// Gets all versions of an itinerary
        /// </summary>
        /// <param name="originalItineraryId">The original itinerary ID</param>
        /// <param name="userId">The user ID (for authorization)</param>
        /// <returns>Collection of all versions of the itinerary</returns>
        public async Task<IEnumerable<Itinerary>> GetAllVersionsAsync(string originalItineraryId, string userId)
        {
            // Get the original itinerary
            var itinerary = await _itineraryRepository.GetByIdAsync(originalItineraryId);
            if (itinerary == null)
                throw new EntityNotFoundException("Itinerary", originalItineraryId);

            // Verify ownership
            if (itinerary.UserId != userId)
                throw new UnauthorizedOperationException("GetAllVersions", $"User {userId} does not own this itinerary");

            // Get all versions
            return await _itineraryRepository.GetAllVersionsAsync(originalItineraryId);
        }

        /// <summary>
        /// Generates an itinerary using AI
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="name">The itinerary name</param>
        /// <param name="destination">The primary destination</param>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="budget">The total budget</param>
        /// <param name="interests">Specific interests (optional)</param>
        /// <param name="pace">The preferred travel pace (optional)</param>
        /// <param name="accommodationType">The preferred accommodation type (optional)</param>
        /// <param name="useSurpriseMe">Whether to include surprising elements (optional)</param>
        /// <returns>The generated itinerary</returns>
        public async Task<Itinerary> GenerateItineraryAsync(
            string userId,
            string name,
            string destination,
            DateTime startDate,
            DateTime endDate,
            decimal budget,
            IEnumerable<Domain.Enums.TravelInterest>? interests = null,
            Domain.Enums.TravelPace pace = Domain.Enums.TravelPace.Moderate,
            Domain.Enums.AccommodationType? accommodationType = null,
            bool useSurpriseMe = false)
        {
            // Validate user exists
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Generate itinerary using the AI service
            var generatedItinerary = await _itineraryGenerationService.GenerateItineraryAsync(
                userId,
                destination,
                startDate,
                endDate,
                budget,
                interests,
                pace,
                accommodationType,
                useSurpriseMe);

            // Set provided name and mark as AI-generated
            generatedItinerary.Name = name;
            generatedItinerary.IsAIGenerated = true;

            // Save the generated itinerary
            var savedItinerary = await _itineraryRepository.AddAsync(generatedItinerary);

            // Update user's itinerary list
            user.ItineraryIds.Add(savedItinerary.Id);
            await _userRepository.UpdateAsync(user);

            return savedItinerary;
        }

        /// <summary>
        /// Adds an item to an itinerary
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <param name="userId">The user ID (for authorization)</param>
        /// <param name="title">The item title</param>
        /// <param name="description">The item description</param>
        /// <param name="type">The item type</param>
        /// <param name="startDateTime">The start date and time</param>
        /// <param name="endDateTime">The end date and time</param>
        /// <param name="dayNumber">The day number</param>
        /// <param name="locationName">The location name</param>
        /// <param name="address">The address (optional)</param>
        /// <param name="cost">The estimated cost (optional)</param>
        /// <param name="notes">Additional notes (optional)</param>
        /// <returns>The added itinerary item</returns>
        public async Task<ItineraryItem> AddItineraryItemAsync(
            string itineraryId,
            string userId,
            string title,
            string description,
            Domain.Enums.ItineraryItemType type,
            DateTime startDateTime,
            DateTime endDateTime,
            int dayNumber,
            string locationName,
            string? address = null,
            decimal? cost = null,
            string? notes = null)
        {
            // Get the itinerary
            var itinerary = await _itineraryRepository.GetByIdAsync(itineraryId);
            if (itinerary == null)
                throw new EntityNotFoundException("Itinerary", itineraryId);

            // Verify ownership
            if (itinerary.UserId != userId)
                throw new UnauthorizedOperationException("AddItineraryItem", $"User {userId} does not own this itinerary");

            // Validate inputs
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Item title cannot be empty", nameof(title));

            if (endDateTime < startDateTime)
                throw new ArgumentException("End time cannot be before start time", nameof(endDateTime));

            if (dayNumber <= 0)
                throw new ArgumentException("Day number must be positive", nameof(dayNumber));

            if (string.IsNullOrWhiteSpace(locationName))
                throw new ArgumentException("Location name cannot be empty", nameof(locationName));

            // Get the current order in day
            int orderInDay = 0;
            // TODO: Implement logic to determine the order within the day based on existing items

            // Create the itinerary item
            var item = new ItineraryItem
            {
                ItineraryId = itineraryId,
                Title = title,
                Description = description,
                Type = type,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,
                DayNumber = dayNumber,
                OrderInDay = orderInDay,
                LocationName = locationName,
                Address = address ?? string.Empty,
                Cost = cost,
                Notes = notes ?? string.Empty
            };

            // TODO: Save the item to the database
            // For now, we'll just return the item as if it was saved

            // Update the itinerary with the new item ID
            itinerary.ItineraryItemIds.Add(item.Id);
            itinerary.UpdatedAt = DateTime.UtcNow;
            await _itineraryRepository.UpdateAsync(itinerary);

            return item;
        }

        /// <summary>
        /// Searches for itineraries based on criteria
        /// </summary>
        /// <param name="searchTerm">The search term (optional)</param>
        /// <param name="userId">The user ID to filter by (optional)</param>
        /// <param name="destination">The destination to filter by (optional)</param>
        /// <param name="startDate">The earliest start date (optional)</param>
        /// <param name="endDate">The latest end date (optional)</param>
        /// <param name="tags">The tags to filter by (optional)</param>
        /// <param name="isTemplate">Whether to include only templates (optional)</param>
        /// <param name="isAIGenerated">Whether to include only AI-generated itineraries (optional)</param>
        /// <returns>Collection of matching itineraries</returns>
        public async Task<IEnumerable<Itinerary>> SearchItinerariesAsync(
            string? searchTerm = null,
            string? userId = null,
            string? destination = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            IEnumerable<string>? tags = null,
            bool? isTemplate = null,
            bool? isAIGenerated = null)
        {
            // TODO: Implement a more sophisticated search using a combination of repository methods
            // For now, we'll use a simple approach

            IEnumerable<Itinerary> results;

            // Get base set of itineraries
            if (userId != null)
            {
                results = await _itineraryRepository.GetByUserIdAsync(userId);
            }
            else if (destination != null)
            {
                results = await _itineraryRepository.GetByDestinationAsync(destination);
            }
            else if (isTemplate == true)
            {
                results = await _itineraryRepository.GetTemplatesAsync();
            }
            else
            {
                results = await _itineraryRepository.GetAllAsync();
            }

            // Apply filters
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                results = results.Where(i =>
                    i.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    i.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    i.PrimaryDestination.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            if (startDate != null)
            {
                results = results.Where(i => i.StartDate >= startDate);
            }

            if (endDate != null)
            {
                results = results.Where(i => i.EndDate <= endDate);
            }

            if (tags != null && tags.Any())
            {
                var tagList = tags.ToList();
                results = results.Where(i => i.Tags.Intersect(tagList).Any());
            }

            if (isAIGenerated != null)
            {
                results = results.Where(i => i.IsAIGenerated == isAIGenerated);
            }

            return results;
        }

        /// <summary>
        /// Optimizes an itinerary to minimize travel time
        /// </summary>
        /// <param name="itineraryId">The itinerary ID</param>
        /// <param name="userId">The user ID (for authorization)</param>
        /// <returns>The optimized itinerary</returns>
        public async Task<Itinerary> OptimizeItineraryAsync(string itineraryId, string userId)
        {
            // Get the itinerary
            var itinerary = await _itineraryRepository.GetByIdAsync(itineraryId);
            if (itinerary == null)
                throw new EntityNotFoundException("Itinerary", itineraryId);

            // Verify ownership
            if (itinerary.UserId != userId)
                throw new UnauthorizedOperationException("OptimizeItinerary", $"User {userId} does not own this itinerary");

            // Use the generation service to optimize
            return await _itineraryGenerationService.OptimizeItineraryAsync(itineraryId);
        }
    }
}