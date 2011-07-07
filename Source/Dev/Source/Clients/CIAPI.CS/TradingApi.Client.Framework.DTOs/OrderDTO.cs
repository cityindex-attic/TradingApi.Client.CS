using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// An order for a specific Trading Account
    /// </summary>
    public class OrderDTO
    {
        /// <summary>
        /// ???
        /// demoValue : 100
        /// </summary>

        public Int32 OrderId { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100
        /// </summary>

        public Int32 MarketId { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100
        /// </summary>

        public Int32 ClientAccountId { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100
        /// </summary>

        public Int32 TradingAccountId { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 100
        /// minimum : 0
        /// maximum : 999999999
        /// </summary>

        public Int32 CurrencyId { get; set; }
        /// <summary>
        /// ???
        /// demoValue : "GBP"
        /// </summary>

        public String CurrencyISO { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 1
        /// </summary>

        public Int32 Direction { get; set; }
        /// <summary>
        /// ???
        /// demoValue : true
        /// </summary>

        public Boolean AutoRollover { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal ExecutionPrice { get; set; }
        /// <summary>
        /// The date of the Order. Always expressed in UTC
        /// demoValue : "\/Date(1289231327280)\/"
        /// </summary>

        public String LastChangedTime { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal OpenPrice { get; set; }
        /// <summary>
        /// The date of the Order. Always expressed in UTC
        /// demoValue : "\/Date(1289231327280)\/"
        /// </summary>

        public String OriginalLastChangedDateTime { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal OriginalQuantity { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 96.1575
        /// minimum : 0.0
        /// maximum : 999999999.0
        /// </summary>

        public Decimal Quantity { get; set; }
        /// <summary>
        /// ???
        /// demoValue : "TODO"
        /// </summary>

        public String Type { get; set; }
        /// <summary>
        /// ???
        /// demoValue : "96.1575"
        /// </summary>

        public String Status { get; set; }
        /// <summary>
        /// ???
        /// demoValue : 1
        /// </summary>

        public Int32 ReasonId { get; set; }
    }
}