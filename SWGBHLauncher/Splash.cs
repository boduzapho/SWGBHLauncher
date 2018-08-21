using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SWGBHLauncher
{
    public partial class Splash : Form
    {
        public static PrivateFontCollection private_fonts = new PrivateFontCollection();
        private bool _mouseDown;
        private Point _startPoint;
        private Form1 moreForm;

        MyPerPixelAlphaForm Splash1 = new MyPerPixelAlphaForm();

        public Splash()
        {
            //var bitmap = new Bitmap(SWGBHLauncher.Properties.Resources.SM1duallogo);
            //Region = GetRegion(bitmap);
            

            Font = new Font("tahoma", 8);
            Text = "perpixelalpha# - Sample application";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;
            ClientSize = new Size(350, 160);
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            
            Splash1.Show();

            LoadFont(SWGBHLauncher.Properties.Resources.Strjmono);
            Font Strjmono = new Font(private_fonts.Families[0], 20);

            SetPerPixelBitmapFilename();


            label1.Font = Strjmono;
            MouseControl();
            timer1.Enabled = false;
            timer1.Tick -= timer1_Tick;
            timer1.Tick += FadeOut;
            timer1.Interval = 2000; /* whatever your original interval was */
            timer1.Enabled = true;
            MyPerPixelAlphaForm Splash1 = new MyPerPixelAlphaForm();
        }

        private void MouseControl()
        {
            foreach (Control c in this.Controls)
            {                
                    c.MouseDown += mdhandler;
                    c.MouseUp += muhandler;
                    c.MouseMove += mmhandler;        
            }

            this.MouseDown += mdhandler;
            this.MouseUp += muhandler;
            this.MouseMove += mmhandler;
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

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        private void dropShadow(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Color[] shadow = new Color[3];
            shadow[0] = Color.FromArgb(181, 181, 181);
            shadow[1] = Color.FromArgb(195, 195, 195);
            shadow[2] = Color.FromArgb(211, 211, 211);
            Pen pen = new Pen(shadow[0]);
            using (pen)
            {
                foreach (Panel p in panel.Controls.OfType<Panel>())
                {
                    Point pt = p.Location;
                    pt.Y += p.Height;
                    for (var sp = 0; sp < 3; sp++)
                    {
                        pen.Color = shadow[sp];
                        e.Graphics.DrawLine(pen, pt.X, pt.Y, pt.X + p.Width - 1, pt.Y);
                        pt.Y++;
                    }
                }
            }
        }

        private void FadeOut(object sender, EventArgs e)
        {
            timer1.Interval = 15;
            this.Opacity -= 0.01;

            if (this.Opacity <= 0)
            {
                timer1.Enabled = false;
                Form1 fMain = new Form1();
                fMain.Show();
                this.Hide();
            }
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
                var p3 = new Point(p2.X - _startPoint.X, p2.Y - _startPoint.Y);
                Location = p3;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FadeOut(sender, e);
        }

        private void SetPerPixelBitmapFilename()
        {
            Bitmap newBitmap;

            try
            {
                newBitmap = Image.FromHbitmap(SWGBHLauncher.Properties.Resources.bhbg.GetHbitmap()) as Bitmap;
                Splash1.SetBitmap(newBitmap, (byte)90);

            }
            catch (ApplicationException e)
            {
                
                return;
            }
            catch (Exception e)
            {
                
                return;
            }

        }
    }

    class TheSplash
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new SplashShreen());
        }
    }
}