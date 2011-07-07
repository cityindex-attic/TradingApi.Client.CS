using System;

namespace TradingApi.Client.Framework.DTOs
{
    public class ApiBasicStopLimitOrderDTO
    {
        /// <summary>
        /// The order's unique identifier.
        /// </summary>

        public Int32 OrderId { get; set; }
        /// <summary>
        /// The order's trigger price.
        /// </summary>

        public Decimal TriggerPrice { get; set; }
    }
}