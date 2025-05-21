using AutoMapper;
using TravelApp.Application.DTOs;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for Feedback entity mapping
    /// </summary>
    public class FeedbackMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackMappingProfile"/> class
        /// </summary>
        public FeedbackMappingProfile()
        {
            // Map from Feedback to FeedbackDTO
            CreateMap<Feedback, FeedbackDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ItineraryId, opt => opt.MapFrom(src => src.ItineraryId))
                .ForMember(dest => dest.ItineraryItemId, opt => opt.MapFrom(src => src.ItineraryItemId))
                .ForMember(dest => dest.DestinationId, opt => opt.MapFrom(src => src.DestinationId))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.AspectRatings, opt => opt.MapFrom(src => src.AspectRatings))
                .ForMember(dest => dest.IsAIFeedback, opt => opt.MapFrom(src => src.IsAIFeedback))
                .ForMember(dest => dest.IsPublic, opt => opt.MapFrom(src => src.IsPublic))
                .ForMember(dest => dest.SubmissionDate, opt => opt.MapFrom(src => src.SubmissionDate))
                .ForMember(dest => dest.Suggestions, opt => opt.MapFrom(src => src.Suggestions))
                .ForMember(dest => dest.WouldRecommend, opt => opt.MapFrom(src => src.WouldRecommend))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ImageUrls))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            // Map from FeedbackDTO to Feedback
            CreateMap<FeedbackDTO, Feedback>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ItineraryId, opt => opt.MapFrom(src => src.ItineraryId))
                .ForMember(dest => dest.ItineraryItemId, opt => opt.MapFrom(src => src.ItineraryItemId))
                .ForMember(dest => dest.DestinationId, opt => opt.MapFrom(src => src.DestinationId))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.AspectRatings, opt => opt.MapFrom(src => src.AspectRatings))
                .ForMember(dest => dest.IsAIFeedback, opt => opt.MapFrom(src => src.IsAIFeedback))
                .ForMember(dest => dest.IsPublic, opt => opt.MapFrom(src => src.IsPublic))
                .ForMember(dest => dest.SubmissionDate, opt => opt.MapFrom(src => src.SubmissionDate))
                .ForMember(dest => dest.Suggestions, opt => opt.MapFrom(src => src.Suggestions))
                .ForMember(dest => dest.WouldRecommend, opt => opt.MapFrom(src => src.WouldRecommend))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ImageUrls))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}