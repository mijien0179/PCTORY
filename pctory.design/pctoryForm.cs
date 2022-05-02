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
    public partial class pctoryForm : Form
    {
        public pctoryForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            TitleFontFamily = base.Font;
        }

        #region Property

        private Color[] titlebar_Color =
        {
            Color.FromArgb(255, 35, 168, 242),
            Color.FromArgb(255,45,178,252)
        };

        [Category("pctory"), Description("제목 상단의 색상을 설정합니다.\n최대 두 가지 색상으로 지정할 수 있습니다.")]
        public Color[] TitleBarColor
        {
            get { return titlebar_Color; }
            set
            {
                if (value.Length == 2)
                {
                    titlebar_Color = value;
                    Invalidate();
                }
            }
        }
        private Font titleFontFamily;

        [Category("pctory"), Description("제목의 폰트를 설정합니다. FontFamily 외의 정보는 무시됩니다.")]
        public Font TitleFontFamily
        {
            get { return titleFontFamily; }
            set { titleFontFamily = value; Invalidate(); }
        }

        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; Invalidate(); }
        }

        #endregion

        #region method
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

        private enum TitleButtonType
        {
            Cancel = 1,
            Maximize = 2,
            Minimize = 3
        }

        private Rectangle TitleButtonRectangle(TitleButtonType type)
        {
            return new Rectangle(Width - 30 * (int)type - (int)type, 0, Width - 30 * ((int)type - 1), 30);
        }

        #endregion


        #region override

        bool isCaptionHover;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (TitleButtonRectangle(TitleButtonType.Cancel).Contains(e.Location))
            {
                Close();
                return;
            }
            else if (TitleButtonRectangle(TitleButtonType.Maximize).Contains(e.Location))
            {
                if(WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
                else WindowState = FormWindowState.Maximized;
                Invalidate();
            }
            else if (TitleButtonRectangle(TitleButtonType.Minimize).Contains(e.Location))
            {
                WindowState = FormWindowState.Minimized;
            }
                
            if (CaptionRectangle.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTCAPTION, (IntPtr)0);
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (CaptionRectangle.Contains(e.Location))
            {
                // TODO: TitleButton 위치에 따라 색 달리 작성하는 방식으로
                if(isCaptionHover == false)
                {
                    isCaptionHover = true;
                }
                Invalidate();
            }
            else if(!CaptionRectangle.Contains(e.Location) && isCaptionHover == true)
            {
                isCaptionHover = false;
                Invalidate();
            }


        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isCaptionHover = false;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 2), new Point(Width, 2), TitleBarColor[0], TitleBarColor[1]))
                e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 5));

            if (DesignMode)
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                    e.Graphics.DrawLine(pen, CaptionRectangle.Left, CaptionRectangle.Bottom, CaptionRectangle.Right, CaptionRectangle.Bottom);
            }

            using (Pen pen = new Pen(Color.DarkGray, 1))
            using (SolidBrush brush = new SolidBrush(Color.LightGray))
            {

                e.Graphics.FillRectangle(brush, TitleButtonRectangle(TitleButtonType.Cancel));
                e.Graphics.FillRectangle(brush, TitleButtonRectangle(TitleButtonType.Maximize));
                e.Graphics.FillRectangle(brush, TitleButtonRectangle(TitleButtonType.Minimize));

                //e.Graphics.DrawRectangle(pen, TitleButtonRectangle(TitleButtonType.Cancel));
                //e.Graphics.DrawRectangle(pen, TitleButtonRectangle(TitleButtonType.Maximize));
                //e.Graphics.DrawRectangle(pen, TitleButtonRectangle(TitleButtonType.Minimize));

            }

            Font TitleFont = new Font(TitleFontFamily.FontFamily.Name, 13.0f);
            TextRenderer.DrawText(e.Graphics, base.Text, TitleFont, TitleRectangle, Color.Black, Color.Transparent, TextFormatFlags.Left);

            using (Pen pen = new Pen(Color.Gray, 1))
            {
                //e.Graphics.DrawLine(pen, 0, 0, Width, 0);   // top
                e.Graphics.DrawLine(pen, 0, 5, 0, Height);  // left
                e.Graphics.DrawLine(pen, Width, 5, Width, Height);  // right
                e.Graphics.DrawLine(pen, 0, Height, Width, Height);  // bottom

            }

        }

        #endregion

    }
}
