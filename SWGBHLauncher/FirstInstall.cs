using FolderSelect;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SWGBHLauncher
{
    public partial class FirstInstall : Form
    {
        #region Global Vars

        string InstallPath = "";
        string OriginalFiles = "";
        string RemotePath = "";
        string Localver = "";
        bool askExit;
        int CurrentStep = 1;
        int totalSteps = 4;
        
        int wizStep = 1;

        #endregion

        public FirstInstall()
        {
            InitializeComponent();
            this.TopMost = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile(@"wiz.gif") as Bitmap;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            this.TransparencyKey = Color.FromArgb(227, 146, 254); //Contrast Color

            setStep(CurrentStep, totalSteps);

            askExit = true;

            if (CheckForInternetConnection())
            {
                atxtSpeed.Text = CheckInternetSpeed().ToString() + " Kb/Sec";
            }
            else
            {
                //no internet we out!
                MessageBox.Show("Great Scott! You have no Internet. Now THAT'S an error!.", "Critical Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true);
                askExit = false;
                Application.Exit();
            }

            //Begin process
            //1. Check registry

            //set local vars
            InstallPath = ""; OriginalFiles = ""; RemotePath = ""; Localver = "";

            if (!getRegisrty())
            {
                //Unable to read the registry files.. Assume no install

            }

            bool GoodFiles = true;
            int Badcount = 0;
            var ValidateFiles = ReadLogLines(@"Validate.txt");
            foreach (var s in ValidateFiles)
            {
                String[] det = s.Split(',');
                listBox1.Items.Add(det[0].ToString());
                if(!File.Exists(@OriginalFiles + det[0].ToString().Replace("\"", "")))
                {
                    GoodFiles = false;
                    Badcount++;
                }
            }

            if(!GoodFiles)
            {

            }
        }

        private IEnumerable<string> ReadLogLines(string logPath)
        {
            using (StreamReader reader = File.OpenText(logPath))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        #region registry

        private bool getRegisrty()
        {
            //Write("InstallPath", @"G:\local\");
            //Write("OriginalFiles", @"I:\Clean Install");
            //Write("RemotePath", @"http://ode-guild.com/swg/install/";
            //Write("ver", "1.1");

            try
            {
                InstallPath = Read("InstallPath");
                OriginalFiles = Read("OriginalFiles");
                RemotePath = Read("RemotePath");
                Localver = Read("ver");
                return true;
            }
            catch (Exception)
            {
                return false;
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

        #region Utilities

        public void setStep(int c, int t)
        {
            lblCstep.Text = c.ToString();
            lblTsteps.Text = t.ToString();

            if (c == 1)
            {
                lblTerms.Visible = true;
                btnNext.Visible = true;
                chkServerRules.Visible = true;
                btnCancel.Visible = true;

                pbInstall.Visible = false;
                btnFinish.Visible = false;
                btnBrowse.Visible = false;
                btnPrevious.Visible = false;
                btnNext.Visible = false;
                pbImages.Visible = false;

                if (chkServerRules.Checked) btnNext.Visible = true;
            }
            else if (c == 2)
            {
                btnNext.Visible = true;                
                btnCancel.Visible = true;
                pbImages.Visible = true;
                btnPrevious.Visible = true;
                btnBrowse.Visible = true;

                chkServerRules.Visible = false;
                lblTerms.Visible = false;
                btnFinish.Visible = false;
                pbInstall.Visible = false;
            }
            else if (c == 3)
            {                
                btnNext.Visible = true;
                btnCancel.Visible = true;                
                btnPrevious.Visible = true;
                btnBrowse.Visible = true;
                pbInstall.Visible = true;

                pbImages.Visible = false;
                chkServerRules.Visible = false;
                lblTerms.Visible = false;
                btnFinish.Visible = false;
                ;
            }            
            else if (c == 4)
            {
                btnFinish.Visible = true;
                btnNext.Visible = true;

                lblTerms.Visible = false;
                chkServerRules.Visible = false;                
                btnNext.Visible = false;
                btnPrevious.Visible = true;
                btnCancel.Visible = false;                
                btnBrowse.Visible = false;
                pbInstall.Visible = false;
            }

            string NL = Environment.NewLine + Environment.NewLine;

            switch (c)
            {
                case 1:
                    lblTitle.Text = "Server Rules and Useage Terms.";
                    lblDescription.Text = "Welcome! " + NL + "This is the first step to playing on SREmu." + NL + "To setup SWGEmu, you will need the ORIGINAL Star Wars Galaxies (SWG) client, and only the ORIGINAL Star Wars Galaxies (SWG) client." + NL + "You can not use 14 day trial client or any other trial client, you can not use client obtained through torrent or third party download sites. If you don't own an original client, SOE's digital copy or original CD's, you can buy original CD's cheap on E-Bay or (Recommended) Amazon.com." + NL + "Most versions of SWG will work. If you're having issues, please ask for help in our Forums.";                   
                    break;
                case 2:
                    lblTitle.Text = "Validate Original Install";
                    lblDescription.Text = "This step requires you to validate your original disks." + NL + "Please use the browse button to locate your install directory for the original game client." + NL + "It's default install directory" + Environment.NewLine + "usually is: " + Environment.NewLine + @"C:\Program Files\StarWarsGalaxies";
                    break;
                case 3:
                    lblTitle.Text = "Select Installiation Location";
                    lblDescription.Text = "Congradulations!" + NL + "Now lets decide where SREmu should be installed on your computer." + NL + "I suggest an SSD or similar type of fast storage better drive for this." + NL + "Did you know you can install the game on a USB and take it with you?";
                    break;
                case 4:
                    lblTitle.Text = "Finish Up";
                    lblDescription.Text = "Excellent!" + NL + "After this the updater will run and install the game files, this should be fairly painless." + NL + "Meesa thinks your gonna have fun!";
                    break;                
            }
            Application.DoEvents();
            this.Refresh();
        }

        public bool CheckInstallPath()
        {
            //check for local install of original disks
            if (InstallPath == "" || InstallPath == null)
            {
                //No Install found, execute find originals
                return false;
            }
            else
            {
                //original files found
                return true;
            }
        }

        public bool LoadOriginalFiles()
        {
            try
            {
                //load list of original files with SH1 and file size to ensure legal is meet.
                var originalFiles = Properties.Resources.filesCRC.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                return true;
            }
            catch (Exception)
            {
                //file not found, redownload needed.
                return false;
            }

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
            {
                m.Result = (IntPtr)2;   // HTCLIENT
                return;
            }
            base.WndProc(ref m);
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
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
            Cursor.Current = Cursors.WaitCursor;
            // Create Object Of WebClient
            System.Net.WebClient wc = new System.Net.WebClient();

            //DateTime Variable To Store Download Start Time.
            DateTime dt1 = DateTime.Now;

            //Number Of Bytes Downloaded Are Stored In ‘data’
            byte[] data = wc.DownloadData("http://www.swgsremu.com/forum/");

            //DateTime Variable To Store Download End Time.
            DateTime dt2 = DateTime.Now;

            //To Calculate Speed in Kb Divide Value Of data by 1024 And Then by End Time Subtract Start Time To Know Download Per Second.

            Cursor.Current = Cursors.Default;
            return Math.Round((data.Length / 1024) / (dt2 - dt1).TotalSeconds, 2);
        }

        public static bool CloseCancel()
        {
            const string message = "Are you sure that you would like to cancel the installer?";
            const string caption = "Cancel Installer";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        #endregion

        #region events

        private void picrefreshspeed_Click(object sender, EventArgs e)
        {
            atxtSpeed.Text = CheckInternetSpeed().ToString() + " Kb/Sec Speed Test";
        }

        #endregion

        #region buttons

        private void pbHome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.swgsremu.com/");
        }

        private void pbDiscord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://discord.gg/k8QK2MB");
        }

        private void pbFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.facebook.com/SentinelsRepublicEmu/");
        }

        private void pbWebSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.swgsremu.com/");
        }

        private void pbForums_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"www.swgsremu.com/forum");
        }

        private void pbCreateAccount_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.swgsremu.com/forum/app.php/new-alderaan-account-creation");
        }

        private void pbRules_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.swgsremu.com/forum/viewforum.php?f=5");
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            askExit = false;
            MainForm mf = new MainForm();
            mf.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var fsd = new FolderSelectDialog();
            OriginalFiles = "";
            switch (CurrentStep)
            {
                case 2:
                    fsd = new FolderSelectDialog();
                    fsd.Title = "Find your original client install folder.";
                    fsd.InitialDirectory = @"C:\Program Files";
                    if (fsd.ShowDialog(IntPtr.Zero)) OriginalFiles = fsd.FileName;
                    break;
                case 3:
                    fsd = new FolderSelectDialog();
                    fsd.Title = "Selectr where to install the SREmu files";
                    fsd.InitialDirectory = @"C:\Program Files";
                    if (fsd.ShowDialog(IntPtr.Zero)) OriginalFiles = fsd.FileName;
                    break;                    
            }            
            Application.DoEvents();
            this.Refresh();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            CurrentStep--;
            if (CurrentStep < 1) CurrentStep = 1;
            setStep(CurrentStep, totalSteps);
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            CurrentStep++;
            if (CurrentStep == totalSteps) CurrentStep = totalSteps;
            setStep(CurrentStep, totalSteps);
        }

        #endregion

        #region FormEvents

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (askExit)
            {
                if (CloseCancel() == false)
                {
                    e.Cancel = true;
                }
            }
        }

        private void chkServerRules_CheckedChanged(object sender, EventArgs e)
        {
            if(chkServerRules.Checked)
            {
                btnNext.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
            }
        }

        #endregion
    }

    class TheFirstInstall
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new FirstInstall());
        }
    }
}
