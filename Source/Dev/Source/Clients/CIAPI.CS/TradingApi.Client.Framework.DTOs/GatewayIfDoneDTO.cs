namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// An IfDone order represents an order which is placed when the corresponding order is filled, e.g attaching a stop/limit to a trade or order
    /// </summary>
    public class GatewayIfDoneDTO
    {
        /// <summary>
        /// The price at which the stop order will be filled
        /// </summary>

        public GatewayStopLimitOrderDTO Stop { get; set; }
        /// <summary>
        /// The price at which the limit order will be filled
        /// </summary>

        public GatewayStopLimitOrderDTO Limit { get; set; }
    }
}