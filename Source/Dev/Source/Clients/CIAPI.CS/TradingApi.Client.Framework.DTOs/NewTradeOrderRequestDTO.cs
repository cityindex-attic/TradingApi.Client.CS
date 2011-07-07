using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// A request for a trade order
    /// </summary>
    public class NewTradeOrderRequestDTO
    {
        /// <summary>
        /// A market's unique identifier
        /// demoValue : 71442
        /// minimum : 1000000
        /// maximum : 9999999
        /// </summary>

        public Int32 MarketId { get; set; }
        /// <summary>
        /// Direction identifier for order/trade, values supported are buy or sell
        /// demoValue : "buy"
        /// </summary>

        public String Direction { get; set; }
        /// <summary>
        /// Size of the order/trade
        /// demoValue : 1.0
        /// </summary>

        public Decimal Quantity { get; set; }
        /// <summary>
        /// Market prices are quoted as a pair (buy/sell or bid/offer), the BidPrice is the lower of the two
        /// demoValue : 100.0
        /// </summary>

        public Decimal BidPrice { get; set; }
        /// <summary>
        /// Market prices are quote as a pair (buy/sell or bid/offer), the OfferPrice is the higher of the market price pair
        /// demoValue : 110.0
        /// </summary>

        public Decimal OfferPrice { get; set; }
        /// <summary>
        /// Unique identifier for a price tick
        /// demoValue : "5998CBE8-3594-4232-A57E-09EC3A4E7AA8"
        /// </summary>

        public String AuditId { get; set; }
        /// <summary>
        /// TradingAccount associated with the trade/order request
        /// demoValue : 1
        /// </summary>

        public Int32 TradingAccountId { get; set; }
    }
}