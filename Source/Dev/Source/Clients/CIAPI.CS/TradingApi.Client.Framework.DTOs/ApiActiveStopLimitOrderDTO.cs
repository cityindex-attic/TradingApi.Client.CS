using System;

namespace TradingApi.Client.Framework.DTOs
{
    public class ApiActiveStopLimitOrderDTO
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

        public Decimal Quantity { get; set; }

        public Decimal TriggerPrice { get; set; }

        public Decimal TradingAccountId { get; set; }

        public String Type { get; set; }

        public String Applicability { get; set; }

        public String Currency { get; set; }

        public String Status { get; set; }

        public ApiBasicStopLimitOrderDTO StopOrder { get; set; }
 
        public ApiBasicStopLimitOrderDTO LimitOrder { get; set; }

        public ApiBasicStopLimitOrderDTO OcoOrder { get; set; }

        public String LastChangedDateTimeUTC { get; set; }
    }
}