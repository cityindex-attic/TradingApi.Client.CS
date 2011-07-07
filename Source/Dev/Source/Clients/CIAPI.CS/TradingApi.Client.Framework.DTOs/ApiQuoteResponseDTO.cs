using System;

namespace TradingApi.Client.Framework.DTOs
{
    public class ApiQuoteResponseDTO
    {
        public Int32 QuoteId { get; set; }

        public Int32 Status { get; set; }

        public Int32 StatusReason { get; set; }
    }
}