using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;



namespace TradingApi.Client.SampleWinFormApp
{
    public class InstrumentHelpers
    {
        public static System.Drawing.Image AppIcon(string path)
        {
            return System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(path));
        }

        public static string GetSymbol(int iid)
        {
            switch (iid)
            {
                case 400481111: return "AUD/CAD";
                case 400481112: return "AUD/CHF";
                case 400481115: return "AUD/JPY";
                case 400481116: return "AUD/NZD";
                case 400481117: return "AUD/USD";
                case 400481118: return "CAD/CHF";
                case 400481119: return "CAD/JPY";
                case 400481120: return "CHF/JPY";
                case 400481121: return "EUR/AUD";
                case 400481122: return "EUR/CAD";
                case 400481123: return "EUR/CHF";
                case 400481124: return "EUR/CZK";
                case 400481125: return "EUR/DDK";
                case 400481126: return "EUR/GBP";
                case 400481127: return "EUR/HUF";
                case 400481128: return "EUR/JPY";
                case 400481129: return "EUR/NOK";

                case 400481130: return "EUR/NZD";
                case 400481131: return "EUR/PLN";
                case 400481132: return "EUR/SEK";
                case 400481133: return "EUR/TRY";
                case 400481134: return "EUR/USD";
                case 400481135: return "EUR/ZAR";
                case 400481136: return "GBP/AUD";
                case 400481137: return "GBP/CAD";
                case 400481138: return "GBP/CHF";
                case 400481139: return "GBP/JPY";
                case 400481140: return "GBP/NZD";
                case 400481141: return "GBP/SGD";
                case 400481142: return "GBP/USD";
                case 400481143: return "NZD/CAD";
                case 400481144: return "NZD/CHF";
                case 400481145: return "NZD/JPY";
                case 400481146: return "NZD/USD";
                case 400481147: return "USD/CAD";
                case 400481148: return "USD/CHF";
                case 400481149: return "USD/CZK";
                case 400481150: return "USD/DKK";
                case 400481151: return "USD/HKD";
                case 400481152: return "USD/HUF";
                case 400481153: return "USD/JPY";
                case 400481154: return "USD/MXN";
                case 400481155: return "USD/NOK";
                case 400481156: return "USD/PLN";
                case 400481157: return "USD/SEK";
                case 400481158: return "USD/SGD";
                case 400481159: return "USD/TRY";
                case 400481160: return "USD/ZAR";
                case 400485556: return "XAU/USD";
                case 400485557: return "XAG/USD";
                case 400485558: return "XPD/USD";
                case 400485559: return "XPT/USD";
                case 400490174: return "CHF/USD";
                case 400490175: return "JPY/USD";
                case 400490176: return "CAD/USD";
                case 400510102: return "SGD/USD";
                case 400472215: return "Brent Oil";
                case 400471960: return "WIT Oil";
                case 400535929: return "Raw Sugar";
                case 400535933: return "USDX";
                case 400535937: return "Cooper";
                case 400535930: return "Corn";
                case 400535931: return "Soy Beans"; 

                default: return "";
            
            }
        }
        
    }

}
