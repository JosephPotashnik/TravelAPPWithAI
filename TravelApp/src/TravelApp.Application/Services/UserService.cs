using System;
using System.Collections.Generic;
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
    /// Implementation of the user management service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPreferenceRepository _preferenceRepository;
        private readonly IItineraryRepository _itineraryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="preferenceRepository">The preference repository</param>
        /// <param name="itineraryRepository">The itinerary repository</param>
        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IPreferenceRepository preferenceRepository,
            IItineraryRepository itineraryRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _preferenceRepository = preferenceRepository ?? throw new ArgumentNullException(nameof(preferenceRepository));
            _itineraryRepository = itineraryRepository ?? throw new ArgumentNullException(nameof(itineraryRepository));
        }

        /// <inheritdoc/>
        public async Task<User> RegisterUserAsync(
            string email,
            string username,
            string password,
            string firstName,
            string lastName)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty", nameof(email));
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty", nameof(username));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty", nameof(password));

            // Check if email or username already exists
            if (await _userRepository.EmailExistsAsync(email))
                throw new ValidationException("Email", "Email already in use");

            if (await _userRepository.UsernameExistsAsync(username))
                throw new ValidationException("Username", "Username already taken");

            // Hash the password (in a real application, use a proper password hasher)
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            // Create new user
            var user = new User
            {
                Email = email,
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                PasswordHash = passwordHash,
                RegistrationDate = DateTime.UtcNow,
                IsActive = true,
                IsEmailVerified = false // Email verification required
            };

            // Create default preferences for the user
            var preferences = new Preference
            {
                UserId = user.Id
            };

            // Save the user and preferences
            var savedUser = await _userRepository.AddAsync(user);
            preferences.UserId = savedUser.Id; // Ensure the correct ID is used

            // Save preferences and update user with preference ID
            var savedPreferences = await _preferenceRepository.AddAsync(preferences);
            savedUser.PreferenceId = savedPreferences.Id;
            await _userRepository.UpdateAsync(savedUser);

            return savedUser;
        }

        /// <inheritdoc/>
        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty", nameof(email));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty", nameof(password));

            // Get user by email
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return null;

            // Check if account is active
            if (!user.IsActive)
                throw new UnauthorizedOperationException("Authentication", "Account is deactivated");

            // Verify password (in a real application, use a proper password verifier)
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isPasswordValid)
                return null;

            // Update last login date
            await _userRepository.UpdateLastLoginAsync(user.Id);

            return user;
        }

        /// <inheritdoc/>
        public async Task<User> UpdateProfileAsync(
            string userId,
            string? firstName = null,
            string? lastName = null,
            string? profilePictureUrl = null)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Update only the provided values
            if (firstName != null)
                user.FirstName = firstName;

            if (lastName != null)
                user.LastName = lastName;

            if (profilePictureUrl != null)
                user.ProfilePictureUrl = profilePictureUrl;

            user.UpdatedAt = DateTime.UtcNow;

            return await _userRepository.UpdateAsync(user);
        }

        /// <inheritdoc/>
        public async Task<bool> ChangePasswordAsync(
            string userId,
            string currentPassword,
            string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Verify current password
            bool isCurrentPasswordValid = BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash);
            if (!isCurrentPasswordValid)
                return false;

            // Hash the new password
            string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            user.PasswordHash = newPasswordHash;
            user.UpdatedAt = DateTime.UtcNow;

            // Update user
            await _userRepository.UpdateAsync(user);
            return true;
        }

        /// <inheritdoc/>
        public async Task<Preference> UpdatePreferencesAsync(string userId, Preference preferences)
        {
            // Validate user exists
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Ensure the preferences belong to the user
            preferences.UserId = userId;

            // Get existing preferences
            var existingPreferences = await _preferenceRepository.GetByIdAsync(user.PreferenceId);
            if (existingPreferences == null)
            {
                // Create new preferences if none exist
                preferences.Id = string.Empty; // Ensure a new ID will be generated
                return await _preferenceRepository.AddAsync(preferences);
            }

            // Update existing preferences with new values
            existingPreferences.Interests = preferences.Interests;
            existingPreferences.BudgetLevel = preferences.BudgetLevel;
            existingPreferences.CustomBudgetMin = preferences.CustomBudgetMin;
            existingPreferences.CustomBudgetMax = preferences.CustomBudgetMax;
            existingPreferences.Pace = preferences.Pace;
            existingPreferences.PreferredAccommodation = preferences.PreferredAccommodation;
            existingPreferences.AccessibilityRequirements = preferences.AccessibilityRequirements;
            existingPreferences.PreferredTransportation = preferences.PreferredTransportation;
            existingPreferences.AvoidCrowds = preferences.AvoidCrowds;
            existingPreferences.ChildFriendly = preferences.ChildFriendly;
            existingPreferences.DietaryPreferences = preferences.DietaryPreferences;
            existingPreferences.PreferredClimates = preferences.PreferredClimates;
            existingPreferences.PreferredTripDuration = preferences.PreferredTripDuration;
            existingPreferences.VisitedDestinations = preferences.VisitedDestinations;
            existingPreferences.WishlistDestinations = preferences.WishlistDestinations;
            existingPreferences.OpenToSurprises = preferences.OpenToSurprises;
            existingPreferences.UpdatedAt = DateTime.UtcNow;

            return await _preferenceRepository.UpdateAsync(existingPreferences);
        }

        /// <inheritdoc/>
        public async Task<Preference> GetPreferencesAsync(string userId)
        {
            // Validate user exists
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Get preferences
            var preferences = await _preferenceRepository.GetByIdAsync(user.PreferenceId);
            if (preferences == null)
            {
                // Create default preferences if none exist
                preferences = new Preference
                {
                    UserId = userId
                };
                preferences = await _preferenceRepository.AddAsync(preferences);

                // Update user with preference ID
                user.PreferenceId = preferences.Id;
                await _userRepository.UpdateAsync(user);
            }

            return preferences;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Itinerary>> GetTravelHistoryAsync(string userId)
        {
            // Validate user exists
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Get all itineraries for the user
            return await _itineraryRepository.GetByUserIdAsync(userId);
        }

        /// <inheritdoc/>
        public async Task<User> GetUserProfileAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return user;
        }

        /// <inheritdoc/>
        public async Task<bool> InitiateEmailVerificationAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            if (user.IsEmailVerified)
                return true; // Already verified

            // TODO: Implement email verification token generation and sending
            // This would typically:
            // 1. Generate a unique token
            // 2. Store the token with an expiration time
            // 3. Send an email with a verification link

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> VerifyEmailAsync(string userId, string token)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            if (user.IsEmailVerified)
                return true; // Already verified

            // TODO: Implement token verification
            // This would typically:
            // 1. Retrieve the stored token for the user
            // 2. Verify the token is valid and not expired
            // 3. Mark the email as verified if valid

            // For this placeholder implementation, we'll simply mark it as verified
            user.IsEmailVerified = true;
            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> InitiatePasswordResetAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return false; // Don't reveal that the email doesn't exist for security

            // TODO: Implement password reset token generation and sending
            // This would typically:
            // 1. Generate a unique token
            // 2. Store the token with an expiration time
            // 3. Send an email with a reset link

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return false;

            // TODO: Implement token verification
            // This would typically:
            // 1. Retrieve the stored token for the user
            // 2. Verify the token is valid and not expired
            // 3. Allow password reset if valid

            // For this placeholder implementation, we'll update the password
            string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            user.PasswordHash = newPasswordHash;
            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeactivateAccountAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> ReactivateAccountAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            user.IsActive = true;
            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}