namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// The response from a GET price bar history request. Contains both an array of finalized price bars, and a partial (not finalized) bar for the current period
    /// </summary>
    public class GetPriceBarResponseDTO
    {
        /// <summary>
        /// An array of finalized price bars, sorted in ascending order based on PriceBar.BarDate
        /// </summary>

        public PriceBarDTO[] PriceBars { get; set; }
    }
}