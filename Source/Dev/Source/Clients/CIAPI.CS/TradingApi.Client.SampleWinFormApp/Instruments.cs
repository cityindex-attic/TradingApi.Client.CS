

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TradingApi.Client.SampleWinFormApp
{


    class Instruments : BindingList<Instrument>
    {

        public System.Drawing.Image UpImage;

        public System.Drawing.Image DownImage;
        

        public Instrument this[int key]
        {
            get { return Instrument(key); }

        }

        public void RemoveItem(int key)
        {

            Instrument item;
            for (int i = 0; i < Count; i++)
            {
                item = this[i];
                if (item.Id == key)
                {
                    this.RemoveAt(i);
                    return;
                }
            }
            return;
        }

        public Instrument Instrument(int key)
        {            
            Instrument item;
            for (int i = 0; i < Count; i++)
            {
                item = this.Items[i];
                if (item.Id == key)
                {
                    return item;
                }
            }
            return default(Instrument); // Not found
        }
    }
}

