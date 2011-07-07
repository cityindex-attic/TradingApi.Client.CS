using System;

namespace TradingApi.Client.Framework.DTOs
{
    public class ApiOrderResponseDTO
    {
        public Int32 OrderId { get; set; }

        public Int32 StatusReason { get; set; }

        public Int32 Status { get; set; }

        public Int32 Price { get; set; }

        public Decimal CommissionCharge { get; set; }

        public ApiIfDoneResponseDTO[] IfDone { get; set; }
    }
}