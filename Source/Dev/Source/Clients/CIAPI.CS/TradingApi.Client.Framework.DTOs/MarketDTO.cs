using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// Information about a Market
    /// </summary>
    public class MarketDTO
    {
        /// <summary>
        /// A market's unique identifier
        /// demoValue : 254527845
        /// minimum : 1000000
        /// maximum : 9999999
        /// </summary>

        public Int32 MarketId { get; set; }
        /// <summary>
        /// The market name
        /// demoValue : "Vodaphone CFD"
        /// minLength : 1
        /// maxLength : 120
        /// </summary>

        public String Name { get; set; }
    }
}