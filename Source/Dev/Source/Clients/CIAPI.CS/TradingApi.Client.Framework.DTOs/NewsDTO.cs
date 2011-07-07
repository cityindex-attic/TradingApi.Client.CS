using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// A news headline
    /// </summary>
    public class NewsDTO
    {
        /// <summary>
        /// The unique identifier for a news story
        /// demoValue : 12654
        /// minimum : 1
        /// maximum : 2147483647
        /// </summary>

        public Int32 StoryId { get; set; }
        /// <summary>
        /// The News story headline
        /// demoValue : "Barron's(8/29) Speaking Of Dividends: The Big Cheese: Kraft Foods Slices Costs And Serves A Payout Hike"
        /// </summary>

        public String Headline { get; set; }
        /// <summary>
        /// The date on which the news story was published. Always in UTC
        /// demoValue : "\/Date(1289231327280)\/"
        /// </summary>

        public DateTime PublishDate { get; set; }
    }
}