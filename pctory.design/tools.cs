using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace pctory.design
{
    internal static class tools
    {

        public static TextFormatFlags Align2TextFormat(ContentAlignment flags)
        {
            TextFormatFlags result = new TextFormatFlags();

            switch (flags)
            {
                case ContentAlignment.TopLeft:
                    result = TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    result = TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
                case ContentAlignment.TopCenter:
                    result = TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    result = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleCenter:
                    result = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleRight:
                    result = TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    result = TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomCenter:
                    result = TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomRight:
                    result = TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
            }

            return result;
        }
        
    }
}
