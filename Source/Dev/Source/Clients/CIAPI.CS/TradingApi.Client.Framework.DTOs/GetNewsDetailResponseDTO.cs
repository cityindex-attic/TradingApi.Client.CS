namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// JSON returned from News Detail GET request
    /// </summary>
    public class GetNewsDetailResponseDTO
    {
        /// <summary>
        /// The details of the news item
        /// </summary>

        public NewsDetailDTO NewsDetail { get; set; }
    }
}