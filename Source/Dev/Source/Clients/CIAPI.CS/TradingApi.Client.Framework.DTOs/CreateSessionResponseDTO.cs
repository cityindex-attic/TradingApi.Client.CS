using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// Response to a CreateSessionRequest
    /// </summary>
    public class CreateSessionResponseDTO
    {
        /// <summary>
        /// Your session token (treat as a random string) <BR /> Session tokens are valid for a set period from the time of their creation. <BR /> The period is subject to change, and may vary depending on who you logon as.
        /// demoValue : "D2FF3E4D-01EA-4741-86F0-437C919B5559"
        /// minLength : 36
        /// maxLength : 100
        /// </summary>

        public String Session { get; set; }
    }
}