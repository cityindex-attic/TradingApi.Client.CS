namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// The response from a request for Price Ticks
    /// </summary>
    public class GetPriceTickResponseDTO
    {
        /// <summary>
        /// An array of price ticks, sorted in ascending order by PriceTick.TickDate
        /// </summary>

        public PriceTickDTO[] PriceTicks { get; set; }
    }
}