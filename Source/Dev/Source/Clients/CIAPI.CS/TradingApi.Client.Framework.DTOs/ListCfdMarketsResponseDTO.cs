namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// Contains the result of a ListCfdMarkets query
    /// </summary>
    public class ListCfdMarketsResponseDTO
    {
        /// <summary>
        /// A list of CFD markets
        /// </summary>

        public MarketDTO[] Markets { get; set; }
    }
}