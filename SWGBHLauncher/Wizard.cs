using FormFader;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Drawing.Text;
using System.Text;
using System.Diagnostics;

namespace SWGBHLauncher
{
    public partial class Wizard : Form
    {
        // Override for form movement via mouse
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
        //    {
        //        m.Result = (IntPtr)2;   // HTCLIENT
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

        //private void Wizard_Shown(object sender, EventArgs e)
        //{
        //    Fader.FadeIn(this, Fader.FadeSpeed.Slower);
        //}

        public Wizard()
        {
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile(@"wiz.gif") as Bitmap;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            this.TransparencyKey = Color.FromArgb(227, 146, 254); //Contrast Color

            InitializeComponent();
        }


        #region Utilities

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    //TextBox1.Text = CheckInternetSpeed().ToString() + " Kb/Sec";
                   
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public double CheckInternetSpeed()
        {
            // Create Object Of WebClient
            System.Net.WebClient wc = new System.Net.WebClient();

            //DateTime Variable To Store Download Start Time.
            DateTime dt1 = DateTime.Now;

            //Number Of Bytes Downloaded Are Stored In ‘data’
            byte[] data = wc.DownloadData("http://google.com");

            //DateTime Variable To Store Download End Time.
            DateTime dt2 = DateTime.Now;

            //To Calculate Speed in Kb Divide Value Of data by 1024 And Then by End Time Subtract Start Time To Know Download Per Second.
            return Math.Round((data.Length / 1024) / (dt2 - dt1).TotalSeconds, 2);
        }
    }
    #endregion


    // Our Great Application!
    class TheWiz
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new Wizard());
        }
    }
}
