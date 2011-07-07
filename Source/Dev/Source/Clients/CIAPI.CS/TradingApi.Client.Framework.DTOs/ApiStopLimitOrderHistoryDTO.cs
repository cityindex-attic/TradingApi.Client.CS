using System;

namespace TradingApi.Client.Framework.DTOs
{
    public class ApiStopLimitOrderHistoryDTO
    {
        /// <summary>
        /// The order's unique identifier.
        /// </summary>

        public Int32 OrderId { get; set; }
        /// <summary>
        /// The markets unique identifier.
        /// </summary>

        public Int32 MarketId { get; set; }
        /// <summary>
        /// The market's name.
        /// </summary>

        public String MarketName { get; set; }
        /// <summary>
        /// The direction, buy or sell.
        /// </summary>

        public String Direction { get; set; }
        /// <summary>
        /// The quantity of the order when it became a trade / was cancelled etc.
        /// </summary>

        public Decimal OriginalQuantity { get; set; }
        /// <summary>
        /// The price / rate that the order was filled at.
        /// </summary>

        public String Price { get; set; }
        /// <summary>
        /// The price / rate that the the order was set to trigger at.
        /// </summary>

        public Decimal TriggerPrice { get; set; }
        /// <summary>
        /// The trading account that the order is on.
        /// </summary>

        public Int32 TradingAccountId { get; set; }
        /// <summary>
        /// The type of the order stop, limit or trade
        /// </summary>

        public Int32 TypeId { get; set; }
        /// <summary>
        /// When the order applies until. ie good till cancelled (GTC) good for day (GFD) or good till time (GTT).
        /// </summary>

        public Int32 OrderApplicabilityId { get; set; }
        /// <summary>
        /// The trade currency
        /// </summary>

        public String Currency { get; set; }
        /// <summary>
        /// the order status.
        /// </summary>

        public Int32 StatusId { get; set; }
        /// <summary>
        /// The date time the order was last changed.
        /// </summary>

        public String LastChangedDateTimeUtc { get; set; }
    }
}