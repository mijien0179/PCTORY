using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pctory.design;

namespace pctory.design
{
    public partial class pctoryForm: Form
    {
        #region Property

        private Color[] titlebar_Color =
        {
            Color.FromArgb(255, 35, 168, 242), 
            Color.FromArgb(255,45,178,252)
        };
        public Color[] TitleBarColor
        {
            get { return titlebar_Color;}
            set { if(value.Length == 2) titlebar_Color = value;}
        }
        private string titleFontFamily = "d2coding";
        public string TitleFontFamily
        {
            get { return titleFontFamily;}
            set { titleFontFamily = value;}
        }

        #endregion

        public pctoryForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            
        }

        private Rectangle CaptionRectangle
        {
            get
            {
                return new Rectangle(0, 0, Width, 30);
            }
        }

        private Rectangle TitleRectangle
        {
            get
            {
                return new Rectangle(5, 5, Width - 100, 25);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(CaptionRectangle.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTCAPTION, (IntPtr)0);
            }
            base.OnMouseDown(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if (DesignMode)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                    e.Graphics.DrawLine(pen, CaptionRectangle.Left, CaptionRectangle.Bottom, CaptionRectangle.Right, CaptionRectangle.Bottom);

            }


            Font TitleFont = new Font(TitleFontFamily, 15.0f);
            TextRenderer.DrawText(e.Graphics, Text, TitleFont,TitleRectangle, Color.Black, Color.Transparent, TextFormatFlags.Left);

            using(Pen pen = new Pen(Color.DarkGray, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, 0, Height);  // left
                e.Graphics.DrawLine(pen, 0, 0, Width, 0);   // top
                e.Graphics.DrawLine(pen, Width, 0, Width, Height);  // right
                e.Graphics.DrawLine(pen, 0, Height, Width, Height);  // bottom

            }

            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0,2), new Point(Width, 2), TitleBarColor[0], TitleBarColor[1]))
                e.Graphics.FillRectangle(brush, new Rectangle(0,0,Width, 5));
        }

    }
}
