using AutoMapper;
using TravelApp.Application.DTOs;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for Itinerary entity mapping
    /// </summary>
    public class ItineraryMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItineraryMappingProfile"/> class
        /// </summary>
        public ItineraryMappingProfile()
        {
            // Map from Itinerary to ItineraryDTO
            CreateMap<Itinerary, ItineraryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.PrimaryDestination, opt => opt.MapFrom(src => src.PrimaryDestination))
                .ForMember(dest => dest.TotalBudget, opt => opt.MapFrom(src => src.TotalBudget))
                .ForMember(dest => dest.ItineraryItemIds, opt => opt.MapFrom(src => src.ItineraryItemIds))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.IsDraft, opt => opt.MapFrom(src => src.IsDraft))
                .ForMember(dest => dest.IsAIGenerated, opt => opt.MapFrom(src => src.IsAIGenerated))
                .ForMember(dest => dest.IsTemplate, opt => opt.MapFrom(src => src.IsTemplate))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.OriginalItineraryId, opt => opt.MapFrom(src => src.OriginalItineraryId))
                .ForMember(dest => dest.VersionNotes, opt => opt.MapFrom(src => src.VersionNotes))
                .ForMember(dest => dest.FeedbackIds, opt => opt.MapFrom(src => src.FeedbackIds))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                // The ItineraryItems will be mapped separately when needed
                .ForMember(dest => dest.ItineraryItems, opt => opt.Ignore());

            // Map from ItineraryDTO to Itinerary
            CreateMap<ItineraryDTO, Itinerary>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.PrimaryDestination, opt => opt.MapFrom(src => src.PrimaryDestination))
                .ForMember(dest => dest.TotalBudget, opt => opt.MapFrom(src => src.TotalBudget))
                .ForMember(dest => dest.ItineraryItemIds, opt => opt.MapFrom(src => src.ItineraryItemIds))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.IsDraft, opt => opt.MapFrom(src => src.IsDraft))
                .ForMember(dest => dest.IsAIGenerated, opt => opt.MapFrom(src => src.IsAIGenerated))
                .ForMember(dest => dest.IsTemplate, opt => opt.MapFrom(src => src.IsTemplate))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.OriginalItineraryId, opt => opt.MapFrom(src => src.OriginalItineraryId))
                .ForMember(dest => dest.VersionNotes, opt => opt.MapFrom(src => src.VersionNotes))
                .ForMember(dest => dest.FeedbackIds, opt => opt.MapFrom(src => src.FeedbackIds))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            // Map from ItineraryItem to ItineraryItemDTO
            CreateMap<ItineraryItem, ItineraryItemDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ItineraryId, opt => opt.MapFrom(src => src.ItineraryId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.StartDateTime))
                .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.EndDateTime))
                .ForMember(dest => dest.DayNumber, opt => opt.MapFrom(src => src.DayNumber))
                .ForMember(dest => dest.OrderInDay, opt => opt.MapFrom(src => src.OrderInDay))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.LocationName))
                .ForMember(dest => dest.DestinationId, opt => opt.MapFrom(src => src.DestinationId))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost))
                .ForMember(dest => dest.BookingReference, opt => opt.MapFrom(src => src.BookingReference))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.IsMustDo, opt => opt.MapFrom(src => src.IsMustDo))
                .ForMember(dest => dest.IsConfirmed, opt => opt.MapFrom(src => src.IsConfirmed))
                .ForMember(dest => dest.IsFlexible, opt => opt.MapFrom(src => src.IsFlexible))
                .ForMember(dest => dest.WeatherForecast, opt => opt.MapFrom(src => src.WeatherForecast))
                .ForMember(dest => dest.IsTransportation, opt => opt.MapFrom(src => src.IsTransportation))
                .ForMember(dest => dest.TransportationMode, opt => opt.MapFrom(src => src.TransportationMode))
                .ForMember(dest => dest.TransportationSource, opt => opt.MapFrom(src => src.TransportationSource))
                .ForMember(dest => dest.TransportationDestination, opt => opt.MapFrom(src => src.TransportationDestination))
                .ForMember(dest => dest.TransportationDurationMinutes, opt => opt.MapFrom(src => src.TransportationDurationMinutes))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                // The Destination will be mapped separately when needed
                .ForMember(dest => dest.Destination, opt => opt.Ignore());

            // Map from ItineraryItemDTO to ItineraryItem
            CreateMap<ItineraryItemDTO, ItineraryItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ItineraryId, opt => opt.MapFrom(src => src.ItineraryId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.StartDateTime))
                .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.EndDateTime))
                .ForMember(dest => dest.DayNumber, opt => opt.MapFrom(src => src.DayNumber))
                .ForMember(dest => dest.OrderInDay, opt => opt.MapFrom(src => src.OrderInDay))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.LocationName))
                .ForMember(dest => dest.DestinationId, opt => opt.MapFrom(src => src.DestinationId))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost))
                .ForMember(dest => dest.BookingReference, opt => opt.MapFrom(src => src.BookingReference))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.IsMustDo, opt => opt.MapFrom(src => src.IsMustDo))
                .ForMember(dest => dest.IsConfirmed, opt => opt.MapFrom(src => src.IsConfirmed))
                .ForMember(dest => dest.IsFlexible, opt => opt.MapFrom(src => src.IsFlexible))
                .ForMember(dest => dest.WeatherForecast, opt => opt.MapFrom(src => src.WeatherForecast))
                .ForMember(dest => dest.IsTransportation, opt => opt.MapFrom(src => src.IsTransportation))
                .ForMember(dest => dest.TransportationMode, opt => opt.MapFrom(src => src.TransportationMode))
                .ForMember(dest => dest.TransportationSource, opt => opt.MapFrom(src => src.TransportationSource))
                .ForMember(dest => dest.TransportationDestination, opt => opt.MapFrom(src => src.TransportationDestination))
                .ForMember(dest => dest.TransportationDurationMinutes, opt => opt.MapFrom(src => src.TransportationDurationMinutes))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}