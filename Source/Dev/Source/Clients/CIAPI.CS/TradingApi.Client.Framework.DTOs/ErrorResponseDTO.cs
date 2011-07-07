using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// This is a description of ErrorResponseDTO
    /// </summary>
    public class ErrorResponseDTO
    {
        /// <summary>
        /// This is a description of the ErrorMessage property
        /// demoValue : "sample value"
        /// </summary>

        public String ErrorMessage { get; set; }
        /// <summary>
        /// The error code
        /// </summary>

        public ErrorCode ErrorCode { get; set; }
    }
}