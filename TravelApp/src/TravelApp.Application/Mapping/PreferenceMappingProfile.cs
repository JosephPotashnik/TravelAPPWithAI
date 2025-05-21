using AutoMapper;
using TravelApp.Application.DTOs;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for Preference entity mapping
    /// </summary>
    public class PreferenceMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreferenceMappingProfile"/> class
        /// </summary>
        public PreferenceMappingProfile()
        {
            // Map from Preference to PreferenceDTO
            CreateMap<Preference, PreferenceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.Interests))
                .ForMember(dest => dest.BudgetLevel, opt => opt.MapFrom(src => src.BudgetLevel))
                .ForMember(dest => dest.CustomBudgetMin, opt => opt.MapFrom(src => src.CustomBudgetMin))
                .ForMember(dest => dest.CustomBudgetMax, opt => opt.MapFrom(src => src.CustomBudgetMax))
                .ForMember(dest => dest.Pace, opt => opt.MapFrom(src => src.Pace))
                .ForMember(dest => dest.PreferredAccommodation, opt => opt.MapFrom(src => src.PreferredAccommodation))
                .ForMember(dest => dest.AccessibilityRequirements, opt => opt.MapFrom(src => src.AccessibilityRequirements))
                .ForMember(dest => dest.PreferredTransportation, opt => opt.MapFrom(src => src.PreferredTransportation))
                .ForMember(dest => dest.AvoidCrowds, opt => opt.MapFrom(src => src.AvoidCrowds))
                .ForMember(dest => dest.ChildFriendly, opt => opt.MapFrom(src => src.ChildFriendly))
                .ForMember(dest => dest.DietaryPreferences, opt => opt.MapFrom(src => src.DietaryPreferences))
                .ForMember(dest => dest.PreferredClimates, opt => opt.MapFrom(src => src.PreferredClimates))
                .ForMember(dest => dest.PreferredTripDuration, opt => opt.MapFrom(src => src.PreferredTripDuration))
                .ForMember(dest => dest.VisitedDestinations, opt => opt.MapFrom(src => src.VisitedDestinations))
                .ForMember(dest => dest.WishlistDestinations, opt => opt.MapFrom(src => src.WishlistDestinations))
                .ForMember(dest => dest.OpenToSurprises, opt => opt.MapFrom(src => src.OpenToSurprises))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            // Map from PreferenceDTO to Preference
            CreateMap<PreferenceDTO, Preference>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.Interests))
                .ForMember(dest => dest.BudgetLevel, opt => opt.MapFrom(src => src.BudgetLevel))
                .ForMember(dest => dest.CustomBudgetMin, opt => opt.MapFrom(src => src.CustomBudgetMin))
                .ForMember(dest => dest.CustomBudgetMax, opt => opt.MapFrom(src => src.CustomBudgetMax))
                .ForMember(dest => dest.Pace, opt => opt.MapFrom(src => src.Pace))
                .ForMember(dest => dest.PreferredAccommodation, opt => opt.MapFrom(src => src.PreferredAccommodation))
                .ForMember(dest => dest.AccessibilityRequirements, opt => opt.MapFrom(src => src.AccessibilityRequirements))
                .ForMember(dest => dest.PreferredTransportation, opt => opt.MapFrom(src => src.PreferredTransportation))
                .ForMember(dest => dest.AvoidCrowds, opt => opt.MapFrom(src => src.AvoidCrowds))
                .ForMember(dest => dest.ChildFriendly, opt => opt.MapFrom(src => src.ChildFriendly))
                .ForMember(dest => dest.DietaryPreferences, opt => opt.MapFrom(src => src.DietaryPreferences))
                .ForMember(dest => dest.PreferredClimates, opt => opt.MapFrom(src => src.PreferredClimates))
                .ForMember(dest => dest.PreferredTripDuration, opt => opt.MapFrom(src => src.PreferredTripDuration))
                .ForMember(dest => dest.VisitedDestinations, opt => opt.MapFrom(src => src.VisitedDestinations))
                .ForMember(dest => dest.WishlistDestinations, opt => opt.MapFrom(src => src.WishlistDestinations))
                .ForMember(dest => dest.OpenToSurprises, opt => opt.MapFrom(src => src.OpenToSurprises))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}