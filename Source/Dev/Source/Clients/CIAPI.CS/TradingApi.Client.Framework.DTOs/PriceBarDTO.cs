using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// The details of a specific price bar, useful for plotting candlestick charts
    /// </summary>
    public class PriceBarDTO
    {
        /// <summary>
        /// The date of the start of the price bar interval
        /// demoValue : "\/Date(1287136540715)\/"
        /// format : "wcf-date"
        /// </summary>

        public DateTime BarDate { get; set; }
        /// <summary>
        /// The price at the open of the price bar interval
        /// demoValue : 1.5
        /// </summary>

        public Decimal Open { get; set; }
        /// <summary>
        /// The highest price occuring during the interval of the price bar
        /// demoValue : 2.343
        /// </summary>

        public Decimal High { get; set; }
        /// <summary>
        /// The lowest price occuring during the interval of the price bar
        /// demoValue : 1.3423
        /// </summary>

        public Decimal Low { get; set; }
        /// <summary>
        /// The price at the end of the price bar interval
        /// demoValue : 2.42
        /// </summary>

        public Decimal Close { get; set; }
    }
}