using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing; 
using System.ComponentModel;
 
namespace TradingApi.Client.SampleWinFormApp
{
    class Instrument : INotifyPropertyChanged
    {
         
        public event PropertyChangedEventHandler PropertyChanged;

        private Image _UpDown;
        private decimal _Bid;
        private decimal _Ask;
        private string _Symbol;
        private int _Id;
        private DateTime _LastUpdate;
        private decimal _High;
        private decimal _Low;
        private int _Direction;
        private decimal _Change;
        private string _AuditId;
        private decimal _LastBid=0;
        private decimal _LastAsk=0;

        public Instrument(int Id, string Symbol)
        {
            this.Id = Id;
            this.Symbol = Symbol; 

        }
        public string AuditId
        {
            get { return _AuditId; }
            set
            {
                _AuditId = value;
                this.NotifyPropertyChanged("AuditId");
            }
        }

        public int Direction
        {
            get { return _Direction; }
            set
            {
                _Direction = value;
            }
        }


        public DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set
            {
                _LastUpdate = value;
                this.NotifyPropertyChanged("LastUpdate");
            }
        }

        public decimal Change
        {
            get { return _Change; }
            set
            {
                _Change = value;
                this.NotifyPropertyChanged("Change");
            }
        }



        public Image UpDown
        {
            get { return _UpDown; }
            set
            {
                _UpDown = value;
                this.NotifyPropertyChanged("UpDown");
            }
        }


        public decimal Low
        {
            get { return _Low; }
            set
            {
                _Low = value;
                this.NotifyPropertyChanged("Low");
            }
        }



        public decimal High
        {
            get { return _High; }
            set
            {
                _High = value;
                this.NotifyPropertyChanged("High");
            }
        }

        
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                this.NotifyPropertyChanged("Id");
            }
        }


        public string Symbol
        {
            get { return _Symbol; }
            set
            {
                _Symbol = value;
                this.NotifyPropertyChanged("Symbol");
            }
        }


        public decimal Bid
        {
            get { return _Bid; }
            set
            {
                _Bid = value;
                this.NotifyPropertyChanged("Bid");    
            }
        }

        public decimal Ask
        {
            get { return _Ask; }
            set
            {
                _Ask = value;
                this.NotifyPropertyChanged("Ask");    
            }
        }
        
        private void NotifyPropertyChanged(string name)
        {
            if(PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    

    }
}
