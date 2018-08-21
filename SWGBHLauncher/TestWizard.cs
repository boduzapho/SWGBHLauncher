using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SWGBHLauncher
{
    /// <para>Our test form for this sample application.  The bitmap will be displayed in this window.</para>
    class TestWizard : PerPixelAlphaForm
    {
        public TestWizard()
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

    class MyWizard : MyPerPixelAlphaForm
    {
        
        private Bitmap bitmap;

        public MyWizard()
        {
            SetPerPixelBitmapFilename();
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
                newBitmap = Image.FromFile(@"WizardBack.png") as Bitmap;
                newBitmap = ChangePixelFormat(newBitmap, PixelFormat.Format32bppArgb);
                this.SetBitmap(newBitmap, (byte)255);
                this.StartPosition = FormStartPosition.Manual;
                this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            }
            catch (ApplicationException e)
            {
                return;
            }
            catch (Exception e)
            {
                return;
            }

            if (bitmap != null) bitmap.Dispose();
            bitmap = newBitmap;
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

    
}