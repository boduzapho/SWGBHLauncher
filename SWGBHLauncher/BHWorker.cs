using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace SWGBHLauncher
{
    public partial class BHWorker : UserControl
    {        

        #region vars

        bool _go = false;
        bool _done = false;
        string _lPath = "";
        string _tbURI = "";
        string _fName = "";
        private Object thisLock = new Object();

        [Browsable(true)]
        public string URI
        {
            get { return _tbURI; }
            set { _tbURI = value; }
        }

        [Browsable(true)]
        public string fName
        {
            get { return _fName; }
            set { _fName = value.Remove(0, 1);}
        }

        [Browsable(true)]
        public string lPath
        {
            get { return _lPath; }
            set { _lPath = value; }
        }

        [Browsable(true)]
        public bool Activated
        {
            set { _go = value; }
            get { return _go; }
        }

        public bool donedownload
        {
            set { _done = value; }
            get { return _done; }
        }

        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed

        public readonly string Url;
        public readonly string Filename;
        public readonly WebClient Client;

        #endregion

        public BHWorker()
        {
            InitializeComponent();
        }

        public void start()
        {
            if (_go)
            {
                if (_lPath != "" && _tbURI != "")
                {
                    this.Visible = false;
                    SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
                    lblNameofFile.Text = fName.ToString();
                    this.Width = lblNameofFile.Width;
                    DownloadFile(_tbURI, _lPath);
                }
            }
            return;
        }

        public void DownloadFile(string urlAddress, string location)
        {
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();
                this.Visible = true;
                try
                {
                    webClient.DownloadFileAsync(URL, location);
                }
                catch (Exception ex)
                {
                    lblDownloaded.Text = ex.Message;
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lock (thisLock)
            {
                pbProgress.Value = e.ProgressPercentage;
            }
        }

        // The event that will trigger when the WebClient is completed
        public void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
                lblDownloaded.Text = "Download has been canceled.";
            }
            else
            {
                lblDownloaded.Text = "Download completed!";
            }
            this.Dispose();
        }

        private void pbProgress_Click(object sender, EventArgs e)
        {

        }
    }
}