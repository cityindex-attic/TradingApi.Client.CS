using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// A quote for a specific order request
    /// </summary>
    public class QuoteDTO
    {
        /// <summary>
        /// The uniqueId of the Quote
        /// demoValue : 1
        /// </summary>

        public Int32 QuoteId { get; set; }
        /// <summary>
        /// The Order the Quote is related to
        /// demoValue : 1
        /// </summary>

        public Int32 OrderId { get; set; }
        /// <summary>
        /// The Market the Quote is related to
        /// demoValue : 1
        /// </summary>

        public Int32 MarketId { get; set; }
        /// <summary>
        /// ????
        /// demoValue : 1.1
        /// </summary>

        public Decimal BidPrice { get; set; }
        /// <summary>
        /// ????
        /// demoValue : 1.1
        /// </summary>

        public Decimal BidAdjust { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 1.1
        /// </summary>

        public Decimal OfferPrice { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 1.1
        /// </summary>

        public Decimal OfferAdjust { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 1.1
        /// </summary>

        public Decimal Quantity { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 1
        /// </summary>

        public Int32 CurrencyId { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 1
        /// </summary>

        public Int32 StatusId { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 1
        /// </summary>

        public Int32 TypeId { get; set; }
        /// <summary>
        /// The timestamp the quote was requested. Always expressed in UTC
        /// demoValue : "\/Date(1289231327280)\/"
        /// </summary>

        public String RequestDateTime { get; set; }
    }
}