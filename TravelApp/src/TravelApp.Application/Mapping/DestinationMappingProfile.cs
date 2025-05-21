using AutoMapper;
using TravelApp.Application.DTOs;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for Destination entity mapping
    /// </summary>
    public class DestinationMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationMappingProfile"/> class
        /// </summary>
        public DestinationMappingProfile()
        {
            // Map from Destination to DestinationDTO
            CreateMap<Destination, DestinationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ImageUrls))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.MainImageUrl))
                .ForMember(dest => dest.WebsiteUrl, opt => opt.MapFrom(src => src.WebsiteUrl))
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
                .ForMember(dest => dest.RatingsCount, opt => opt.MapFrom(src => src.RatingsCount))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.RecommendedSeasons, opt => opt.MapFrom(src => src.RecommendedSeasons))
                .ForMember(dest => dest.CostLevel, opt => opt.MapFrom(src => src.CostLevel))
                // Map TimeSpan to int for TypicalVisitDuration
                .ForMember(dest => dest.TypicalVisitDurationMinutes, opt => opt.MapFrom(src => (int)src.TypicalVisitDuration.TotalMinutes))
                .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src => src.OpeningHours))
                .ForMember(dest => dest.IsAccessible, opt => opt.MapFrom(src => src.IsAccessible))
                .ForMember(dest => dest.AccessibilityFeatures, opt => opt.MapFrom(src => src.AccessibilityFeatures))
                .ForMember(dest => dest.IsChildFriendly, opt => opt.MapFrom(src => src.IsChildFriendly))
                .ForMember(dest => dest.IsMustVisit, opt => opt.MapFrom(src => src.IsMustVisit))
                .ForMember(dest => dest.TravelAdvisories, opt => opt.MapFrom(src => src.TravelAdvisories))
                .ForMember(dest => dest.PracticalInfo, opt => opt.MapFrom(src => src.PracticalInfo))
                .ForMember(dest => dest.Climate, opt => opt.MapFrom(src => src.Climate))
                .ForMember(dest => dest.BestActivities, opt => opt.MapFrom(src => src.BestActivities))
                .ForMember(dest => dest.LocalTransportation, opt => opt.MapFrom(src => src.LocalTransportation))
                .ForMember(dest => dest.NearbyDestinationIds, opt => opt.MapFrom(src => src.NearbyDestinationIds))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            // Map from DestinationDTO to Destination
            CreateMap<DestinationDTO, Destination>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ImageUrls))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.MainImageUrl))
                .ForMember(dest => dest.WebsiteUrl, opt => opt.MapFrom(src => src.WebsiteUrl))
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
                .ForMember(dest => dest.RatingsCount, opt => opt.MapFrom(src => src.RatingsCount))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.RecommendedSeasons, opt => opt.MapFrom(src => src.RecommendedSeasons))
                .ForMember(dest => dest.CostLevel, opt => opt.MapFrom(src => src.CostLevel))
                // Map int to TimeSpan for TypicalVisitDuration
                .ForMember(dest => dest.TypicalVisitDuration, opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.TypicalVisitDurationMinutes)))
                .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src => src.OpeningHours))
                .ForMember(dest => dest.IsAccessible, opt => opt.MapFrom(src => src.IsAccessible))
                .ForMember(dest => dest.AccessibilityFeatures, opt => opt.MapFrom(src => src.AccessibilityFeatures))
                .ForMember(dest => dest.IsChildFriendly, opt => opt.MapFrom(src => src.IsChildFriendly))
                .ForMember(dest => dest.IsMustVisit, opt => opt.MapFrom(src => src.IsMustVisit))
                .ForMember(dest => dest.TravelAdvisories, opt => opt.MapFrom(src => src.TravelAdvisories))
                .ForMember(dest => dest.PracticalInfo, opt => opt.MapFrom(src => src.PracticalInfo))
                .ForMember(dest => dest.Climate, opt => opt.MapFrom(src => src.Climate))
                .ForMember(dest => dest.BestActivities, opt => opt.MapFrom(src => src.BestActivities))
                .ForMember(dest => dest.LocalTransportation, opt => opt.MapFrom(src => src.LocalTransportation))
                .ForMember(dest => dest.NearbyDestinationIds, opt => opt.MapFrom(src => src.NearbyDestinationIds))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}