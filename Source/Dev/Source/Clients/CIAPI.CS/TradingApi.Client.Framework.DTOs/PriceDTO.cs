using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// A Price for a specific Market
    /// </summary>
    public class PriceDTO
    {
        /// <summary>
        /// The Market that the Price is related to
        /// demoValue : 1000
        /// minimum : 1
        /// maximum : 9999999
        /// </summary>

        public Int32 MarketId { get; set; }
        /// <summary>
        /// The date of the Price. Always expressed in UTC
        /// demoValue : "\/Date(1289231327280)\/"
        /// </summary>

        public String TickDate { get; set; }
        /// <summary>
        /// The current Bid price (price at which the customer can sell)
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal Bid { get; set; }
        /// <summary>
        /// The current Offer price (price at which the customer can buy)
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal Offer { get; set; }
        /// <summary>
        /// The current mid price
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal Price { get; set; }
        /// <summary>
        /// The highest price reached for the day
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal High { get; set; }
        /// <summary>
        /// The lowest price reached for the day
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal Low { get; set; }
        /// <summary>
        /// The change since the last price (always positive. See Direction for direction)
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal Change { get; set; }
        /// <summary>
        /// The direction of movement since the last price. 1 == up, 0 == down
        /// demoValue : 1
        /// minimum : 0
        /// maximum : 1
        /// </summary>

        public Int32 Direction { get; set; }
        /// <summary>
        /// A unique id for this price. Treat as a unique, but random string
        /// demoValue : "o892nkl8hopin"
        /// </summary>

        public String AuditId { get; set; }
    }
}