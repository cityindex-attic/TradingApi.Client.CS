using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// The response returned from the underlying trading system
    /// </summary>
    public class ApiTradeOrderResponseDTO
    {
        /// <summary>
        /// The status of the order (Pending, Accepted, Open, etc)
        /// demoValue : 1
        /// </summary>

        public Int32 Status { get; set; }
        /// <summary>
        /// The id corresponding to a more descriptive reason for the order status
        /// demoValue : 1
        /// </summary>

        public Int32 StatusReason { get; set; }
        /// <summary>
        /// The unique identifier associated to the order returned from the underlying trading system
        /// demoValue : 1
        /// </summary>

        public Int32 OrderId { get; set; }
    }
}