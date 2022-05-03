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
        List<pctoryButton> controlButton = new List<pctoryButton>();
        pctoryButton cancelButton = null;
        pctoryButton maximizeButton = null;
        public pctoryForm()
        {

            InitializeComponent();
            bCursor = Cursor;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            TitleFontFamily = new Font("나눔고딕", 12);
            Padding = new Padding(Padding.Left, 40, Padding.Right, Padding.Bottom);

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

        [DefaultValue(true)]
        private bool sizable = true;

        [Category("pctory"), Description("크기 변경이 가능한 창인지 설정합니다.")]
        public bool Sizable
        {
            get { return sizable; }
            set { sizable = value; }
        }

        [Flags]
        public enum ControlTypes: uint
        {
            Cancel = 1,
            Maximize = 2,
            Minimize = 3
        }


        #endregion

        #region method
        bool isCaptionHover;
        private Rectangle CaptionRectangle
        {
            get
            {
                return new Rectangle(4, 4, Width, 30);
            }
        }

        private Rectangle TitleRectangle
        {
            get
            {
                return new Rectangle(5, 5, Width - 100, 25);
            }
        }

        private Rectangle BorderTop() => new Rectangle(4, 0, Width, 4);
        private Rectangle BorderLeft() => new Rectangle(0, 4, 4, Height - 4);
        private Rectangle BorderRight() => new Rectangle(Width - 4, 31, Width, Height - 4);
        private Rectangle BorderBottom() => new Rectangle(4, Height - 4, Width - 4, Height - 4);

        private Rectangle BorderTopLeft() => new Rectangle(0, 0, 4, 4);
        private Rectangle BorderTopRight() => new Rectangle(Width - 4, 0, Width, 4);
        private Rectangle BorderBottomLeft() => new Rectangle(0, Height - 4, 4, Height);
        private Rectangle BorderBottomRight() => new Rectangle(Width - 4, Height - 4, Width, Height);

        private Rectangle TitleButtonRectangle(ControlTypes type)
        {
            return new Rectangle(Width - 30 * ((int)type), 0, 30, 34);
        }


        private string ControlButtonText(ControlTypes type)
        {
            if (type == ControlTypes.Cancel) return "r";
            else if (type == ControlTypes.Maximize)
                if (WindowState == FormWindowState.Maximized) return "2";
                else return "1";

            // TitleButtonType.Minimize
            return "0";
        }

        private pctoryButton AddControlButton(ControlTypes type)
        {
            pctoryButton button = new pctoryButton
            {
                Text = ControlButtonText(type),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("webdings", 9.25f),
                Border = false,
                EnterSizing = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size = new Size(30, 30),
            };
            button.Tag = type;
            button.Click += new EventHandler(ControlButtonEvent);
            return button;
        }

        private void ControlButtonEvent(object s, EventArgs e)
        {
            ControlTypes tag = (ControlTypes)(s as pctoryButton).Tag;
            if (tag == ControlTypes.Cancel) Close();
            else if (tag == ControlTypes.Maximize)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                }
                else
                {
                    WindowState = FormWindowState.Maximized;
                }
                (s as pctoryButton).Text = ControlButtonText(tag);
                Invalidate();
            }
            else if (tag == ControlTypes.Minimize)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void ControlPositioning()
        {
            for(int i = 0; i < controlButton.Count; ++i)
            {
                controlButton[i].Location = new Point(Width - 30 * (i + 1) - 1, 1);
            }
        }

        #endregion


        #region override

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)Win32.Message.WM_SYSCOMMAND)
            {
                if (m.WParam == (IntPtr)0xF030)
                {

                }
            }

            base.WndProc(ref m);
        }

        protected override void OnResize(EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                int width, height;
                width = Size.Width;
                height = Size.Height;
                bool isMinimum = false;
                if (Size.Width < 150 && (isMinimum = true)) width = 150;
                if (Size.Height < 50 && (isMinimum = true)) height = 50;

                if (isMinimum) Size = new Size(width, height);
            }

            if (maximizeButton != null) maximizeButton.Text = ControlButtonText(ControlTypes.Maximize);
            Invalidate();
            base.OnResize(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cancelButton = AddControlButton(ControlTypes.Cancel);
            controlButton.Add(cancelButton);

            if (MaximizeBox)
            {
                maximizeButton = AddControlButton(ControlTypes.Maximize);
                controlButton.Add(maximizeButton);
            }
            if (MinimizeBox)
            {
                controlButton.Add(AddControlButton(ControlTypes.Minimize));
            }

            ControlPositioning();

            Controls.AddRange(controlButton.ToArray());

            Invalidate();
        }



        private bool isLButtonPress;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLButtonPress = true;
                if (e.Clicks > 1)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDBLCLK, (IntPtr)Win32.HitTest.HTCAPTION, (IntPtr)0);
                }
                else if (CaptionRectangle.Contains(e.Location))
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTCAPTION, (IntPtr)0);
                }
            }

            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isLButtonPress)
            {
                isLButtonPress = false;
            }
            base.OnMouseUp(e);
        }
        private Cursor bCursor;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            isLButtonPress = e.Button == MouseButtons.Left;
            bool temp;
            if (Sizable)
            {
                if ((temp = BorderTopLeft().Contains(e.Location)) || BorderBottomRight().Contains(e.Location))
                {
                    Cursor = Cursors.SizeNWSE;
                    if (isLButtonPress)
                    {
                        Win32.ReleaseCapture();
                        if (temp) // TopLEFT
                            Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTTOPLEFT, (IntPtr)0);
                        else
                            Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTBOTTOMRIGHT, (IntPtr)0);
                    }
                }
                else if ((temp = BorderBottomLeft().Contains(e.Location)) || BorderTopRight().Contains(e.Location))
                {
                    Cursor = Cursors.SizeNESW;
                    if (isLButtonPress)
                    {
                        Win32.ReleaseCapture();
                        if (temp) // bottomleft
                            Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTBOTTOMLEFT, (IntPtr)0);
                        else
                            Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTTOPRIGHT, (IntPtr)0);
                    }
                }
                else if ((temp = BorderLeft().Contains(e.Location)) || BorderRight().Contains(e.Location))
                {
                    Cursor = Cursors.SizeWE;
                    if (isLButtonPress)
                    {
                        Win32.ReleaseCapture();
                        if (temp) // Left
                            Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTLEFT, (IntPtr)0);
                        else
                            Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTRIGHT, (IntPtr)0);
                    }
                }
                else if ((temp = BorderTop().Contains(e.Location)) || BorderBottom().Contains(e.Location))
                {
                    Cursor = Cursors.SizeNS;
                    if (isLButtonPress)
                    {
                        Win32.ReleaseCapture();
                        if (temp) // Top
                            Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTTOP, (IntPtr)0);
                        else
                            Win32.SendMessage(Handle, (int)Win32.Message.WM_NCLBUTTONDOWN, (IntPtr)Win32.HitTest.HTBOTTOM, (IntPtr)0);
                    }

                }
                else
                {
                    Cursor = bCursor;
                }
            }

            if (CaptionRectangle.Contains(e.Location))
            {
                // TODO: TitleButton 위치에 따라 색 달리 작성하는 방식으로
                if (isCaptionHover == false)
                {
                    isCaptionHover = true;
                    Invalidate();
                }
            }
            else if (!CaptionRectangle.Contains(e.Location) && isCaptionHover == true)
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
            e.Graphics.Clear(BackColor);
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 2), new Point(Width, 2), TitleBarColor[0], TitleBarColor[1]))
                e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 5));

            if (DesignMode)
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                using (SolidBrush brush = new SolidBrush(cancelButton.BackColor))
                {
                    e.Graphics.DrawLine(pen, CaptionRectangle.Left, CaptionRectangle.Bottom, CaptionRectangle.Right, CaptionRectangle.Bottom);

                    e.Graphics.FillRectangle(brush, TitleButtonRectangle(ControlTypes.Cancel));
                    e.Graphics.FillRectangle(brush, TitleButtonRectangle(ControlTypes.Maximize));
                    e.Graphics.FillRectangle(brush, TitleButtonRectangle(ControlTypes.Minimize));

                    Font font = new Font("webdings", 9.75f);
                    TextRenderer.DrawText(e.Graphics, "r", font, TitleButtonRectangle(ControlTypes.Cancel), ForeColor);
                    TextRenderer.DrawText(e.Graphics, "1", font, TitleButtonRectangle(ControlTypes.Maximize), ForeColor);
                    TextRenderer.DrawText(e.Graphics, "0", font, TitleButtonRectangle(ControlTypes.Minimize), ForeColor);

                }
            }


            Font TitleFont = new Font(TitleFontFamily.FontFamily.Name, 13.0f);
            TextRenderer.DrawText(e.Graphics, base.Text, TitleFont, TitleRectangle, Color.Black, Color.Transparent, TextFormatFlags.Left);

            using (Pen pen = new Pen(TitleBarColor[0], 1))
                e.Graphics.DrawLine(pen, 0, 5, 0, Height - 1);  // left

            //e.Graphics.DrawLine(pen, 0, 0, Width, 0);   // top

            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 2), new Point(Width, 2), TitleBarColor[0], TitleBarColor[1]))
                e.Graphics.FillRectangle(brush, 0, Height - 1, Width - 1, Height - 1);  // bottom

            using (Pen pen = new Pen(TitleBarColor[1], 1))
                e.Graphics.DrawLine(pen, Width - 1, 0, Width - 1, Height - 1);  // right




        }

        #endregion

    }
}
