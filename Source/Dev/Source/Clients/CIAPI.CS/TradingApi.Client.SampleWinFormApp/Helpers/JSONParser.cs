using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradingApi.Client.SampleWinFormApp
{
    public class JSONParser
    {
        public static DateTime ParseJSONDateToUtc(string jsonDate)
        {
            var ms = Int64.Parse(jsonDate.Replace(@"\/Date(", "").Replace(@")\/", ""));
            var ticks = ms * TimeSpan.TicksPerMillisecond + new DateTime(1970, 1, 1).Ticks;
            return new DateTime(ticks, DateTimeKind.Utc);
        }
    }
}



