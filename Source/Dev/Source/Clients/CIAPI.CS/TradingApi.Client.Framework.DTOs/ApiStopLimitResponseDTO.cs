using System;

namespace TradingApi.Client.Framework.DTOs
{
    public class ApiStopLimitResponseDTO : ApiOrderResponseDTO
    {
        public Decimal GuaranteedPremium { get; set; }

        public ApiStopLimitResponseDTO OCO { get; set; }
    }
}