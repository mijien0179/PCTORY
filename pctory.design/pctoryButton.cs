using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pctory.design
{
    internal partial class pctoryButton : Button
    {
        public pctoryButton()
        {
            InitializeComponent();
            Padding = new Padding(2);
            Size = new Size(116, 32);
            TextAlign = ContentAlignment.BottomLeft;
        }

        #region property

        [DefaultValue(true)]
        private bool border = true;
        [Category("pctory"), Description("Border의 표시 유무입니다.")]
        public bool Border
        {
            get { return border; }
            set { border = value; Invalidate(); }
        }

        [DefaultValue(false)]
        private bool enterSizing = false;
        [Category("pctory"), Description("컨트롤이 포커스 되었을 때 크기를 줄일지 결정합니다.")]
        public bool EnterSizing
        {
            get { return enterSizing; }
            set { enterSizing = value; Invalidate(); }
        }

        #endregion


        private bool isEnter;
        protected override void OnMouseEnter(EventArgs e)
        {
            isEnter = true;
            Cursor = base.Cursor;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            isEnter = false;
            Invalidate();
        }

        private Color GetStyleColor()
        {
            float weight = 0.95f;
            Color result = BackColor;

            weight = !Enabled ? 0.8f : weight;

            if (isEnter || !Enabled)
            {
                result = Color.FromArgb(result.A, (int)(result.R * weight) % 255, (int)(result.G * weight )% 255, (int)(result.B * weight )% 255);
            }

            return result;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.Clear(Parent.BackColor);
            Rectangle rect;
            if (isEnter && EnterSizing) rect = new Rectangle(Padding.Left, Padding.Top, Width - 1 - Padding.Right * 2, Height - 1 - Padding.Bottom * 2);
            else rect = new Rectangle(0, 0, Width - 1, Height - 1);

            Color ForeColor = base.ForeColor;
            if (Enabled)
            {
                using(SolidBrush brush = new SolidBrush(GetStyleColor())) pe.Graphics.FillRectangle(brush, rect);
            }
            else
            {
                using(SolidBrush brush = new SolidBrush(GetStyleColor())) pe.Graphics.FillRectangle(brush, rect);
            }


            if(Border)
                using (Pen pen = new Pen(ForeColor, 1)) pe.Graphics.DrawRectangle(pen, rect);

            rect = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);

            TextRenderer.DrawText(pe.Graphics, Text, Font, rect, ForeColor, Color.Transparent, tools.Align2TextFormat(TextAlign));

        }
    }
}
