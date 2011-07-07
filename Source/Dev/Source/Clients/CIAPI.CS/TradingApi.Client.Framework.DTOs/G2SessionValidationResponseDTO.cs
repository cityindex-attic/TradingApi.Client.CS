using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class G2SessionValidationResponseDTO
    {
        /// <summary>
        /// ClientAccountIds that this session is authorized to work with
        /// demoValue : [  1,  2,  3,  4]
        /// </summary>

        public Int32[] ClientAccountIds { get; set; }
        /// <summary>
        /// TradingAccountIds that this session is authorized to work with
        /// demoValue : [  1,  2,  3,  4]
        /// </summary>

        public Int32[] TradingAccountIds { get; set; }
        /// <summary>
        /// Whether this session token is still valid
        /// demoValue : true
        /// </summary>

        public Boolean IsValid { get; set; }
    }
}