using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWGBHLauncher
{
    /// <para>Our test form for this sample application.  The bitmap will be displayed in this window.</para>
    class MyPerPixelAlphaForm : PerPixelAlphaForm
    {
        public MyPerPixelAlphaForm()
        {
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Let Windows drag this form for us
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
            {
                m.Result = (IntPtr)2;   // HTCLIENT
                return;
            }
            base.WndProc(ref m);
        }
    }

    class MainEntryPoint : MyPerPixelAlphaForm
    {
        private System.Windows.Forms.Timer timer1;
        private int counter = 5;
        private Bitmap bitmap;    

        public MainEntryPoint()
        {            
            SetPerPixelBitmapFilename();
            
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second                
            timer1.Start();
        }
           
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && bitmap != null)
                {
                    bitmap.Dispose();
                    bitmap = null;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void SetPerPixelBitmapFilename()
        {
            Bitmap newBitmap;

            try
            {
                newBitmap = Image.FromFile(@"sr-splash-screen-final.png") as Bitmap;
                newBitmap = ChangePixelFormat(newBitmap,PixelFormat.Format32bppArgb);
                this.SetBitmap(newBitmap, (byte)255);
                this.StartPosition = FormStartPosition.Manual;
                this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            }
            catch (ApplicationException e)
            {
                //MessageBox.Show(this, e.Message, "Error with bitmap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                //MessageBox.Show(this, e.Message, "Could not open image file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bitmap != null) bitmap.Dispose();
            bitmap = newBitmap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                Form f1 = new MainForm();
                f1.Show();
                this.Hide();
            }
        }

        private Bitmap ChangePixelFormat(Bitmap inputImage, PixelFormat newFormat)
        {
            Bitmap bmp = new Bitmap(inputImage.Width, inputImage.Height, newFormat);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(inputImage, 0, 0);
            }
            return bmp;
        }

    }

    // Our Great Application!
    class TheApp
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new MainEntryPoint());
        }
    }
}