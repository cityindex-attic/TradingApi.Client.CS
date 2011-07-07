namespace TradingApi.Client.Framework.DTOs
{
    public class ApiIfDoneResponseDTO
    {
        public ApiStopLimitResponseDTO Stop { get; set; }

        public ApiStopLimitResponseDTO Limit { get; set; }
    }
}