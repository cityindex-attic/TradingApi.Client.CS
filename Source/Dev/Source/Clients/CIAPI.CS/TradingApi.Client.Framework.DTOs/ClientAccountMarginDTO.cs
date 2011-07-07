using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// The current margin for a specific client account
    /// </summary>
    public class ClientAccountMarginDTO
    {
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal Cash { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal Margin { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal MarginIndicator { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal NetEquity { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal OpenTradeEquity { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal TradeableFunds { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal PendingFunds { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal TradingResource { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100.0
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal TotalMarginRequirement { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100
        /// </summary>

        public Int32 CurrencyId { get; set; }
        /// <summary>
        /// ???
        /// demoValue : "GBP"
        /// </summary>

        public String CurrencyISO { get; set; }
    }
}