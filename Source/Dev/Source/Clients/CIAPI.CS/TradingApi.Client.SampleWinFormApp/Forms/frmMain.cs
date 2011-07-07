#region "References"
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Common.Logging;
using TradingApi.Client.Framework.DTOs;
using TradingApi.Client.Framework.ApiFacade;
using TradingApi.Client.Core.Exceptions;
    
#endregion

namespace TradingApi.Client.SampleWinFormApp
{
    
    public partial class frmMain : Form
    {
        [DllImport("kernel32.dll")]
        static extern bool SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);
        private  Globals _g = Globals.Instance;
        private Instruments _Instruments = new  Instruments();

        private ILog Log = LogManager.GetLogger(typeof(frmMain));

        private delegate void PriceUpdateHandlerDelegate(PriceDTO p);

        private void cmdLogOn_Click(object sender, EventArgs e)
        {
            StartConnection("");
        }
         
        #region "Form Load"
           
            private void frmMain_Load(object sender, EventArgs e)
            {
                _Instruments.UpImage = InstrumentHelpers.AppIcon("TradingApi.Client.SampleWinFormApp.Images.arrow_up_green.ico");
                _Instruments.DownImage = InstrumentHelpers.AppIcon("TradingApi.Client.SampleWinFormApp.Images.arrow_down_blue.ico");
                StartConnection("");
            }
        
            private void StartConnection(String adapter)
            {
                                
                try
                {
                    frmCredentials f = new frmCredentials();
                    if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }

                    //Databind the Grid to the Instruments 
                    dgvMarketData.AutoGenerateColumns = false;
                    dgvMarketData.DataSource = _Instruments;

                    CiApi.Instance.Login(_g.UserName,
                                     _g.Password,
                                     _g.RequestServer);
                    
                    CiApi.Instance.StreamingManager.StreamingUrl = _g.StreamingServer;

                    var accountInformation = CiApi.Instance.ServiceManager.AccountInfoService.GetClientAndTradingAccount();

                    var cfdMarkets = CiApi.Instance.ServiceManager.CfdMarketService.ListCfdMarkets("", true, true, accountInformation.ClientAccountId, 100);
                    
                    List<int> marketIdList = new List<int>();
                    foreach (var cfdMarket in cfdMarkets.Markets) { marketIdList.Add(cfdMarket.MarketId); }

                    CiApi.Instance.StreamingManager.Streams.PriceStream.SubscribeToMarketPriceList(marketIdList);

                    CiApi.Instance.StreamingManager.Streams.PriceStream.PriceChanged += (o, s) => HandlePriceUpdate(s.Data);

                    Log.Info("Streaming..");

                    this.Show();
                }
                catch (ApiCallException apiCallException)
                {
                    Log.Error(apiCallException.Message);   
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    CiApi.Instance.Logout();  
                }

            }
 
            public frmMain()
            {
                InitializeComponent();
            }

        #endregion

        #region "Streaming Updates"

            private void HandlePriceUpdate(PriceDTO priceUpdate)
            {

                if (this.InvokeRequired)
                {
                    this.Invoke(new PriceUpdateHandlerDelegate(PriceUpdateHandler), priceUpdate);
                }

            }


//todo: could hook this up to prices
            private void PriceUpdateHandler(PriceDTO priceUpdate)
            {

                // This needs some optimization
                try
                {

                    int mid = priceUpdate.MarketId;

                    if (_Instruments[mid] == null)
                    {
                        _Instruments.Add(new Instrument(mid, InstrumentHelpers.GetSymbol(mid)));
                    }

                    _Instruments[mid].Bid = priceUpdate.Bid;
                    _Instruments[mid].Ask = priceUpdate.Offer;
                    _Instruments[mid].High = priceUpdate.High;
                    _Instruments[mid].Low = priceUpdate.High;
                    _Instruments[mid].LastUpdate = JSONParser.ParseJSONDateToUtc(priceUpdate.TickDate);
                    _Instruments[mid].Change = priceUpdate.Change;
                    _Instruments[mid].Direction = priceUpdate.Direction;
                    if (priceUpdate.Direction == 1)
                        _Instruments[mid].UpDown = _Instruments.UpImage;
                    else
                        _Instruments[mid].UpDown = _Instruments.DownImage;

                    _Instruments[mid].AuditId = priceUpdate.AuditId;

                }
                catch (Exception ex)
                {

                }

            }

            private void WriteStatusOutput(string status)
            {
                WriteOutput("STATUS: " + status);
            }

            private void WriteOutput(string message)
            {
            }


        #endregion

        #region "Cell Formatting"
                private void dgvMarketData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
                {
                    if (e.ColumnIndex == 2 || e.ColumnIndex == 4)
                    {
                        if (((Instrument)dgvMarketData.Rows[e.RowIndex].DataBoundItem).Direction == 1)
                            dgvMarketData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = System.Drawing.Color.LawnGreen;
                        else
                            dgvMarketData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = System.Drawing.Color.LightBlue;

                    }
                }
            #endregion

        #region "Cell Painting"

            private void dgvAccountInformation_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex == -1)
                    e.Handled = Drawing.GradientHeaders(StringAlignment.Center, e);

            }

            private void dgvMarketData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex == -1)
                    e.Handled = Drawing.GradientHeaders(StringAlignment.Center, e);
            }

            private void dgvTradeHistory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex == -1)
                    e.Handled = Drawing.GradientHeaders(StringAlignment.Center, e);
            }

            private void doubleBufferedGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex == -1)
                    e.Handled = Drawing.GradientHeaders(StringAlignment.Center, e);
            }

            private void dgvOpenPositions_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex == -1)
                    e.Handled = Drawing.GradientHeaders(StringAlignment.Center, e);
            }

        
            #endregion

            public static void adjustExternalMemoryWorkingSet()
            {

                MessageBox.Show("Cool");  
                try
                {
                    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                }
                catch (Exception ex)
                {
                   
                }
            }

            private void dgvMarketData_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                adjustExternalMemoryWorkingSet();
            }
    }

}


