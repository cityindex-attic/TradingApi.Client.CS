using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TradingApi.Client.SampleWinFormApp
{
    internal class DoubleBufferedGridView : System.Windows.Forms.DataGridView
    {


        public DoubleBufferedGridView()
        {
            base.DoubleBuffered = true;

        }

    }

}