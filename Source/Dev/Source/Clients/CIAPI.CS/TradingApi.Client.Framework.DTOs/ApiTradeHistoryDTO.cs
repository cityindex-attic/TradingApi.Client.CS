using System;

namespace TradingApi.Client.Framework.DTOs
{
    public class ApiTradeHistoryDTO
    {
        public Int32 OrderId { get; set; }

        public Int32 MarketId { get; set; }

        public String MarketName { get; set; }

        public String Direction { get; set; }

        public Decimal OriginalQuantity { get; set; }

        public Decimal Price { get; set; }

        public Int32 TradingAccountId { get; set; }
        /// <summary>
        /// The trade currency
        /// </summary>

        public String Currency { get; set; }

        public String LastChangedDateTimeUtc { get; set; }
    }
}