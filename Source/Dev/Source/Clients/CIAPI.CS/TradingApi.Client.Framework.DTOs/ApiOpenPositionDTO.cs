using System;

namespace TradingApi.Client.Framework.DTOs
{
    public class ApiOpenPositionDTO
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
        /// The quantity of the order.
        /// </summary>

        public Decimal Quantity { get; set; }
        /// <summary>
        /// The price / rate that the trade was opened at.
        /// </summary>

        public Decimal Price { get; set; }
        /// <summary>
        /// The trading account that the order is on.
        /// </summary>

        public Int32 TradingAccountId { get; set; }
        /// <summary>
        /// The trade currency.
        /// </summary>

        public String Currency { get; set; }
        /// <summary>
        /// The order status.
        /// </summary>

        public String Status { get; set; }
        /// <summary>
        /// The stop order attached to this order.
        /// </summary>

        public ApiBasicStopLimitOrderDTO StopOrder { get; set; }
        /// <summary>
        /// The limit order attached to this order.
        /// </summary>

        public ApiBasicStopLimitOrderDTO LimitOrder { get; set; }
        /// <summary>
        /// The date time the order was last changed.
        /// </summary>

        public String LastChangedDateTimeUTC { get; set; }
    }
}