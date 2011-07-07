namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// The response from a GET request for News headlines
    /// </summary>
    public class ListNewsHeadlinesResponseDTO
    {
        /// <summary>
        /// A list of News headlines
        /// </summary>

        public NewsDTO[] Headlines { get; set; }
    }
}