using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleWinFormApp
{
    public sealed class Globals
    {
        static readonly Globals _instance = new Globals();
        public static Globals Instance
        {
            get { return _instance; }
        }

        private Globals()
        {
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string RequestServer { get; set; }
        public string StreamingServer { get; set; }


        
    }
}
