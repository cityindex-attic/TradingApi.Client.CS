using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// The mid price at a particular point in time.
    /// </summary>
    public class PriceTickDTO
    {
        /// <summary>
        /// The datetime at which a price tick occured. Accurate to the millisecond
        /// demoValue : "\/Date(1287136540715)\/"
        /// format : "wcf-date"
        /// </summary>

        public DateTime TickDate { get; set; }
        /// <summary>
        /// The mid price
        /// demoValue : 1.5457
        /// minimum : 0.0
        /// </summary>

        public Decimal Price { get; set; }
    }
}