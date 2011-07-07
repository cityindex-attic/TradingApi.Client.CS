using System;

namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// Contains details of a specific news story
    /// </summary>
    public class NewsDetailDTO : NewsDTO
    {
        /// <summary>
        /// The detail of the story. This can contain HTML characters.
        /// demoValue : "<pre>    (Expect lots of HTML here)     By Shirley A. Lazo </pre><p>    (END) Dow Jones Newswires</p><p>   August 27, 2005 00:01 ET (04:01 GMT)</p>"
        /// minLength : 0
        /// maxLength : 2147483647
        /// </summary>

        public String Story { get; set; }
    }
}