namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// Contains the result of a ListSpreadMarketsResponseDTO query
    /// </summary>
    public class ListSpreadMarketsResponseDTO
    {
        /// <summary>
        /// A list of Spread Betting markets
        /// </summary>

        public MarketDTO[] Markets { get; set; }
    }
}