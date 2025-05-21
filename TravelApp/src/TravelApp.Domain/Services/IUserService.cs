using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Domain.Services
{
    /// <summary>
    /// Service interface for user management operations
    /// </summary>
    public interface IUserService : IService
    {
        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="username">User's username</param>
        /// <param name="password">User's password (plain text)</param>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <returns>The newly created user</returns>
        Task<User> RegisterUserAsync(
            string email,
            string username,
            string password,
            string firstName,
            string lastName);

        /// <summary>
        /// Authenticates a user by email and password
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password (plain text)</param>
        /// <returns>Authenticated user if successful, null if authentication fails</returns>
        Task<User?> AuthenticateAsync(string email, string password);

        /// <summary>
        /// Updates a user's profile information
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="firstName">New first name (optional)</param>
        /// <param name="lastName">New last name (optional)</param>
        /// <param name="profilePictureUrl">New profile picture URL (optional)</param>
        /// <returns>The updated user</returns>
        Task<User> UpdateProfileAsync(
            string userId,
            string? firstName = null,
            string? lastName = null,
            string? profilePictureUrl = null);

        /// <summary>
        /// Changes a user's password
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="currentPassword">Current password (plain text)</param>
        /// <param name="newPassword">New password (plain text)</param>
        /// <returns>True if the password was changed successfully, otherwise false</returns>
        Task<bool> ChangePasswordAsync(
            string userId,
            string currentPassword,
            string newPassword);

        /// <summary>
        /// Updates a user's travel preferences
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="preferences">The preferences to update</param>
        /// <returns>The updated preferences</returns>
        Task<Preference> UpdatePreferencesAsync(string userId, Preference preferences);

        /// <summary>
        /// Gets a user's preferences
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>The user's preferences</returns>
        Task<Preference> GetPreferencesAsync(string userId);

        /// <summary>
        /// Gets a user's travel history (past itineraries)
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>Collection of the user's past itineraries</returns>
        Task<IEnumerable<Itinerary>> GetTravelHistoryAsync(string userId);

        /// <summary>
        /// Gets a user's profile by ID
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>The user's profile information</returns>
        Task<User> GetUserProfileAsync(string userId);

        /// <summary>
        /// Initiates the email verification process for a user
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>True if the verification process was initiated successfully</returns>
        Task<bool> InitiateEmailVerificationAsync(string userId);

        /// <summary>
        /// Verifies a user's email with a verification token
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <param name="token">The verification token</param>
        /// <returns>True if the email was verified successfully, otherwise false</returns>
        Task<bool> VerifyEmailAsync(string userId, string token);

        /// <summary>
        /// Initiates the password reset process for a user
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <returns>True if the password reset process was initiated successfully</returns>
        Task<bool> InitiatePasswordResetAsync(string email);

        /// <summary>
        /// Resets a user's password using a reset token
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="token">The reset token</param>
        /// <param name="newPassword">The new password (plain text)</param>
        /// <returns>True if the password was reset successfully, otherwise false</returns>
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);

        /// <summary>
        /// Deactivates a user account
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>True if the account was deactivated successfully</returns>
        Task<bool> DeactivateAccountAsync(string userId);

        /// <summary>
        /// Reactivates a previously deactivated user account
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>True if the account was reactivated successfully</returns>
        Task<bool> ReactivateAccountAsync(string userId);
    }
}