using AutoMapper;
using TravelApp.Application.DTOs;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for User entity mapping
    /// </summary>
    public class UserMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMappingProfile"/> class
        /// </summary>
        public UserMappingProfile()
        {
            // Map from User to UserDTO
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.RegistrationDate))
                .ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => src.LastLoginDate))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePictureUrl))
                .ForMember(dest => dest.IsEmailVerified, opt => opt.MapFrom(src => src.IsEmailVerified))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Locale, opt => opt.MapFrom(src => src.Locale))
                .ForMember(dest => dest.TimeZone, opt => opt.MapFrom(src => src.TimeZone))
                .ForMember(dest => dest.PreferenceId, opt => opt.MapFrom(src => src.PreferenceId))
                .ForMember(dest => dest.ItineraryIds, opt => opt.MapFrom(src => src.ItineraryIds))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            // Map from UserDTO to User
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.RegistrationDate))
                .ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => src.LastLoginDate))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePictureUrl))
                .ForMember(dest => dest.IsEmailVerified, opt => opt.MapFrom(src => src.IsEmailVerified))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Locale, opt => opt.MapFrom(src => src.Locale))
                .ForMember(dest => dest.TimeZone, opt => opt.MapFrom(src => src.TimeZone))
                .ForMember(dest => dest.PreferenceId, opt => opt.MapFrom(src => src.PreferenceId))
                .ForMember(dest => dest.ItineraryIds, opt => opt.MapFrom(src => src.ItineraryIds))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                // Exclude PasswordHash from DTO mapping to domain entity
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}