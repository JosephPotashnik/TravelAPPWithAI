namespace TravelApp.Domain.Enums
{
    /// <summary>
    /// Types of feedback
    /// </summary>
    public enum FeedbackType
    {
        ItineraryRating,
        DestinationReview,
        ItineraryItemReview,
        AIEngineRating,
        AppFeedback,
        FeatureRequest
    }

    /// <summary>
    /// Aspects that can be rated in feedback
    /// </summary>
    public enum FeedbackAspect
    {
        Value,
        Accuracy,
        Usefulness,
        Relevance,
        Completeness,
        Variety,
        Quality,
        Creativity,
        Organization,
        Pace,
        Transportation,
        Accommodation,
        Activities,
        Food,
        CostEstimation,
        TimeEstimation,
        UserInterface,
        Recommendations
    }
}