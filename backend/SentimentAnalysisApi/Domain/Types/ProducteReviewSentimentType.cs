namespace Domain.Types
{
    /// <summary>
    /// Represents the sentiment type of a product review as analyzed by AWS Comprehend
    /// </summary>
    public enum ProductReviewSentimentType
    {
        /// <summary>
        /// Sentiment has not been identified or analysis is pending
        /// </summary>
        NotIdentified = 0,
        
        /// <summary>
        /// Review expresses neutral sentiment
        /// </summary>
        Neutral,
        
        /// <summary>
        /// Review expresses negative sentiment
        /// </summary>
        Negative,
        
        /// <summary>
        /// Review expresses positive sentiment
        /// </summary>
        Positive,
        
        /// <summary>
        /// Review expresses mixed sentiments
        /// </summary>
        Mixed,
    }
}
