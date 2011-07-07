using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// Represents a stop/limit order
    /// </summary>
    public class GatewayStopLimitOrderDTO : GatewayOrderDTO
    {
        /// <summary>
        /// The associated expiry DateTime for a pair of GoodTillDate IfDone orders
        /// demoValue : "\\/Date(1290164280000)\\/"
        /// </summary>

        public String ExpiryDateTimeUTC { get; set; }
        /// <summary>
        /// Identifier which relates to the expiry of the order/trade, i.e. GoodTillDate (GTD), GoodTillCancelled (GTC) or GoodForDay (GFD)
        /// demoValue : "GTC"
        /// </summary>

        public String Applicability { get; set; }
    }
}