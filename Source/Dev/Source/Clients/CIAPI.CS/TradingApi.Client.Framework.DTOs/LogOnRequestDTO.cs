using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class LogOnRequestDTO
    {
        /// <summary>
        /// Username is case sensitive
        /// demoValue : "CC735158"
        /// minLength : 6
        /// maxLength : 20
        /// </summary>

        public String UserName { get; set; }
        /// <summary>
        /// Password is case sensitive
        /// demoValue : "password"
        /// minLength : 6
        /// maxLength : 20
        /// </summary>

        public String Password { get; set; }
    }
}