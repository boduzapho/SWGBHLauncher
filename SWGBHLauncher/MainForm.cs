using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Text;
using System.Diagnostics;

namespace SWGBHLauncher
{
    public partial class MainForm : Form
    {
        #region vars

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        string InstallPath = "";
        string OriginalFiles = "";
        string RemotePath = "";
        string Localver = "";

        int mode = 0; //0 = new 1 = update
        int cnt = 0;
        int cnt2 = 0;
        int totalFiles = 0;
        private bool _mouseDown;
        private Point _startPoint;
        private MainForm moreForm;

        private int Angle;
        private Image Art; // you may need to resample larger images to a smaller image dynamically!
        private int AngleStep = 20;
        private System.Drawing.Drawing2D.GraphicsPath Vinyl = new System.Drawing.Drawing2D.GraphicsPath();

        double increment = 0;
        string[] qlines = null;
        string[][] quotes = null;

        Random r = new Random();

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public static PrivateFontCollection private_fonts = new PrivateFontCollection();

        #endregion
 
        public MainForm()
        {
            var bitmap = new Bitmap(SWGBHLauncher.Properties.Resources.LatestBG);
            Region = GetRegion(bitmap);

            InitializeComponent();

            //do check for new install or forced update
            mode = 0;
            if (ModeCheck()) mode = 1;
            MouseControl();

            LoadFont(SWGBHLauncher.Properties.Resources.Strjmono);
            Font Strjmono = new Font(private_fonts.Families[0], 20);

            timer2.Interval = 50;
            Art = Properties.Resources.spinner; // image as embedded resource (or from somewhere else)

            // larger circle with the center cut out: (like a vinyl record)
            Vinyl.AddEllipse(pictureBox2.ClientRectangle);
            Rectangle rc = new Rectangle(pictureBox1.Width / 2, pictureBox1.Height / 2, 1, 1);
            ///rc.Inflate(10, 10);
            Vinyl.AddEllipse(rc);

            pictureBox2.Paint += PictureBox2_Paint;

        }

        #region Utilities

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.SetClip(Vinyl);
            G.TranslateTransform(pictureBox2.Width / 2, pictureBox2.Height / 2); // move to the center
            G.RotateTransform(Angle); // rotate to the current angle
            G.DrawImage(Art, new Point(-(Art.Width / 2), -(Art.Height / 2))); // draw the image centered
        }

        private bool ModeCheck()
        {
            try
            {

                InstallPath = Read("InstallPath");
                OriginalFiles = Read("OriginalFiles");
                RemotePath = Read("RemotePath");
                Localver = Read("ver");

                if (InstallPath == "" || OriginalFiles == "" || RemotePath == "" || Localver == "") return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        
        private Region GetRegion(Bitmap _img)
        {
            var rgn = new Region();
            rgn.MakeEmpty();
            var rc = new Rectangle(0, 0, 0, 0);
            bool inimage = false;
            for (int y = 0; y < _img.Height; y++)
            {
                for (int x = 0; x < _img.Width; x++)
                {
                    if (!inimage)
                    {
                        // if pixel is not transparent
                        if (_img.GetPixel(x, y).A != 0)
                        {
                            inimage = true;
                            rc.X = x;
                            rc.Y = y;
                            rc.Height = 1;
                        }
                    }
                    else
                    {
                        // if pixel is transparent
                        if (_img.GetPixel(x, y).A == 0)
                        {
                            inimage = false;
                            rc.Width = x - rc.X;
                            rgn.Union(rc);
                        }
                    }
                }
                if (inimage)
                {
                    inimage = false;
                    rc.Width = _img.Width - rc.X;
                    rgn.Union(rc);
                }
            }
            return rgn;
        }

        private void MouseControl()
        {
            foreach (Control c in this.Controls)
            {
                if(c.GetType() != typeof(PictureButton) && c.GetType() != typeof(Label) && c.GetType() != typeof(PictureBox) && c.GetType() != typeof(Button))
                { 
                c.MouseDown += mdhandler;
                c.MouseUp += muhandler;
                c.MouseMove += mmhandler;
                }
            }
            this.MouseDown += mdhandler;
            this.MouseUp += muhandler;
            this.MouseMove += mmhandler;
        }

        private void mdhandler(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            _startPoint = new Point(e.X, e.Y);
        }

        private void muhandler(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void mmhandler(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                var p1 = new Point(e.X, e.Y);
                var p2 = PointToScreen(p1);
                var p3 = new Point(p2.X - _startPoint.X,p2.Y - _startPoint.Y);
                Location = p3;
            }
        }

        public static void LoadFont(Byte[] fontData)
        {
            //create an unsafe memory block for the data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontData.Length);
            //copy the bytes to the unsafe memory block
            Marshal.Copy(fontData, 0, data, fontData.Length);

            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);

            //pass the font to the font collection
            private_fonts.AddMemoryFont(data, fontData.Length);
            //free the unsafe memory
            Marshal.FreeCoTaskMem(data);

        }

        private string InstallDirectory()
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {                    
                    return folderBrowserDialog1.SelectedPath;                    
                }
                return null;
            }
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        public double CheckInternetSpeed()
        {
            // Create Object Of WebClient
            System.Net.WebClient wc = new System.Net.WebClient();

            //DateTime Variable To Store Download Start Time.
            DateTime dt1 = DateTime.Now;

            //Number Of Bytes Downloaded Are Stored In ‘data’
            byte[] data = wc.DownloadData("https://patentimages.storage.googleapis.com/pages/US4896960-4.png");

            //DateTime Variable To Store Download End Time.
            DateTime dt2 = DateTime.Now;

            //To Calculate Speed in Kb Divide Value Of data by 1024 And Then by End Time Subtract Start Time To Know Download Per Second.
            return Math.Round((data.Length / 1024) / (dt2 - dt1).TotalSeconds, 2);
        }

        private void picExpand_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 400)
            {
                panel1.Width = (pbPlay.Left + pbPlay.Width) - panel1.Left;
                //picExpand.Left = panel1.Left + (panel1.Width - 26);
                picExpand.BackgroundImage = SWGBHLauncher.Properties.Resources.btn_condense;
                panel2.Top = 40;
                //panel2.Left = 500;
                return;
            }
            else
            {
                panel1.Width = 400;
                //picExpand.Left = panel1.Left + (panel1.Width - 26);
                picExpand.BackgroundImage = SWGBHLauncher.Properties.Resources.btn_expand;
                panel2.Top = 420;
                //panel2.Left = 500;
                return;
            }
        }

        private void MeatSpin()
        {
            Angle = Angle + AngleStep;
            if (Angle >= 360)
            {
                Angle = Angle - 360;
            }
            pictureBox2.Refresh();
        }

        #endregion

        #region registry

        private void getRegisrty()
        {
            Write("InstallPath", @"G:\local\");
            Write("OriginalFiles", @"I:\Clean Install");
            Write("RemotePath", @"http://127.0.0.1/");  //@"http://ode-guild.com/swg/install/"
            Write("ver", "1.1");

            try
            {
                InstallPath = Read("InstallPath");
                OriginalFiles = Read("OriginalFiles");
                RemotePath = Read("RemotePath");
                Localver = Read("ver");
            }
            catch (Exception)
            {
            }
        }

        public string Read(string keyName)
        {
            string subKey = "SOFTWARE\\SWGEMULU\\" + Application.ProductName.ToUpper();

            RegistryKey currentKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subKey);
            if (currentKey == null)
                return null;
            else
                return currentKey.GetValue(keyName.ToUpper()).ToString();
        }
                
        public void Write(string keyName, string value)
        {
            string subKey = "SOFTWARE\\SWGEMULU\\" + Application.ProductName.ToUpper();

            RegistryKey writeKeyValue = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(subKey);
            writeKeyValue.SetValue(keyName.ToUpper(), value);
        }

        #endregion

        #region Downloads

        public byte[] GetFileViaHttp(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }

        private void downloadfiles()
        {
            Application.DoEvents();
            foreach (BHWorker c in pnlControls.Controls)
            {
                if(cnt2 < cnt + 1) { c.start(); }                
            }

            while(pnlControls.Controls.Count > 0)
            {
                Application.DoEvents();
            }
            pnlControls.Location = new Point(917, 509);
            pnlControls.Visible = false;
        }

        private void FileDownload_Click(object sender, EventArgs e)
        {
            if (IsConnectedToInternet())
            {
                PercentComplete.Visible = true;
                timer2.Enabled = !timer2.Enabled;
                progressBar1.Value = 0;
                progressBar1.SetState(2);
                progressBar1.Refresh();
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                ModifyProgressBarColor.SetState(progressBar1, 2);

                progressBar1.MarqueeAnimationSpeed = 50;
                Application.DoEvents();
                //Get registry
                getRegisrty();

                //get the headerfile
                //System.Collections.Generic.IEnumerable<String> lines = File.ReadLines(@"http://ode-guild.com/swg/install/filesCRC.txt");
                var result = GetFileViaHttp(@"http://127.0.0.1/filesCRC.txt"); //@"http://ode-guild.com/swg/install/filesCRC.txt
                string str = Encoding.UTF8.GetString(result);
                
                string[] lines = str.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                qlines = System.IO.File.ReadAllLines(@"quotes.txt");
                

                pnlControls.Location = new Point(472, 19);
                pnlControls.Visible = true;
                totalFiles = 0;
                progressBar1.Maximum = 100;
                increment = (100 / System.Convert.ToDouble(lines.Length));

                int rInt = r.Next(0, qlines.Length - 1);
                lblQuotes.Text = qlines[rInt].ToString();

                foreach (var item in lines)
                {
                    // split the line
                    int idx = 2;
                    string[] details = item.Split(',');
                    BHWorker bh = new BHWorker();
                    bh.URI = RemotePath + details[idx].Replace("\"", "").ToString();
                    bh.lPath = InstallPath + details[idx].Replace("\"", "").ToString();
                    bh.fName = details[idx].Replace("\"", "").ToString();
                    bh.Activated = true;
                    bh.donedownload = false;
                    bh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                    pnlControls.Controls.Add(bh);
                    cnt++;
                    totalFiles++;
                }
            }
            else
            {
                MessageBox.Show("You have NO connection to the internet..", "Critical Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true);

            }
            tmrQuote.Enabled = true;
            timer1.Enabled = true;
            downloadfiles();
            this.Refresh();
            Application.DoEvents();
        }

        #endregion

        #region timers

        private void timer1_Tick(object sender, EventArgs e)
        {   
            Random r = new Random();
            int rInt = r.Next(0, 100);

            progressBar1.ForeColor = Color.Red;
            progressBar1.Style = ProgressBarStyle.Continuous;

            timer1.Enabled = false;
            double val = (increment * (totalFiles - pnlControls.Controls.Count));
            if (val > 100) val = 100;
            double pbv = increment * (totalFiles - pnlControls.Controls.Count);
            progressBar1.Value = (int)pbv;
            
            MeatSpin();

            int mve = 860 / totalFiles;
            PercentComplete.Text = ((int)progressBar1.Value).ToString() + "%";
            //PercentComplete.Left = (mve * (totalFiles - pnlControls.Controls.Count)) - PercentComplete.Width; //(PercentComplete.Width) + (progressBar1.Left + (mve * (totalFiles - pnlControls.Controls.Count)));
            progressBar1.Refresh();
            Application.DoEvents();
            if (this.pnlControls.Controls.Count <= 0)
            {
                progressBar1.Value = 0;
                tmrQuote.Enabled = false;
                lblQuotes.Text = "";
                progressBar1.Value = 100;
                PercentComplete.Text = "100%";
                                
                progressBar1.Refresh();
                Application.DoEvents();
                return;
            }
            else
            {
                timer1.Enabled = true; 
                Application.DoEvents();
            }
        }

        private void tmrQuote_Tick(object sender, EventArgs e)
        {
            int rInt = r.Next(0, qlines.Length - 1);
            lblQuotes.Text = qlines[rInt].ToString();
        }

        #endregion
        
        #region links

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.swgsremu.com/forum/index.php");
        }

        private void pbWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.swgsremu.com/");
        }

        private void pbDiscord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://discord.gg/k8QK2MB");
        }

        private void pbMantis_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.sentinelsgalaxy.com/Mantis/login_page.php");
        }

        private void pbtnFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.facebook.com/SentinelsRepublicEmu/");
        }

        private void pbPatchNotes_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://tyler.berlin/p/skillplanner");
        }

        private void pbtnDiscord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://discord.gg/k8QK2MB");
        }

        private void LogoLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.swgsremu.com/");
        }

        private void pbGH_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://galaxyharvester.net/");
        }

        private void pbSkill_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://swgsremu.com/skillplanner");
        }

        private void pbMantisWeb_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://sentinelsgalaxy.com/mantis/login_page.php");
        }

        private void pbVoteforUs_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://topg.org/swg-private-servers/in-473411");
        }

        private void pbPPDonate_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.paypal.com/donate/?token=sRdTzF6qPC-HtRiKdTkz88XaEd37Mq_wgeoT0GOpXB139XkicJfn-HgeOwiHi7-GI5-b4G&country.x=GB&locale.x=GB");
        }

        private void pbskillPlanner_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://tyler.berlin/p/skillplanner");
        }

        private void ibtnOWB_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(webBrowser1.Url.ToString());
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            // Cycle through percentage complete, to test it (must be between 0 and 100)
            for (var I = 0; I <= 100; I++)
            {
                // Create a stopwatch and a do-loop to simulate some kind of work being don
                Stopwatch SW = new Stopwatch();
                SW.Start();
                do
                {
                    Application.DoEvents();
                }
                while (SW.ElapsedMilliseconds <= 100);
                SW.Stop();
                // Update the percent complete
                //customizableProgressBar1.Value = I;
                //customizableProgressBar1.Update();
            }
        }
    }
}

public static class ModifyProgressBarColor
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
    public static void SetState(this ProgressBar pBar, int state)
    {
        SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
    }
}

