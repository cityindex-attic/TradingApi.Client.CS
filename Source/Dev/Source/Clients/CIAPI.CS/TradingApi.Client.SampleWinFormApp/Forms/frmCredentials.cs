using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace TradingApi.Client.SampleWinFormApp
{
    public partial class frmCredentials : Form
    {
        public frmCredentials()
        {
            InitializeComponent();
        }

        private void frmCredentials_Load(object sender, EventArgs e)
        {

            cbUserNames.Text = ConfigurationManager.AppSettings.Get("USER_NAME");
            txtPassword.Text = ConfigurationManager.AppSettings.Get("PASSWORD");
            Globals.Instance.StreamingServer = ConfigurationManager.AppSettings.Get("LS_SERVER");
            Globals.Instance.RequestServer = ConfigurationManager.AppSettings.Get("REQUEST_SERVER"); 

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;  
            this.Close(); 
        }

        private void frmCredentials_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void cmdLogon_Click(object sender, EventArgs e)
        {
            Globals.Instance.UserName = cbUserNames.Text; 
            Globals.Instance.Password = txtPassword.Text;
            this.DialogResult = DialogResult.OK;  
            this.Close(); 
        }
    }
}
