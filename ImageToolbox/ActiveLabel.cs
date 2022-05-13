using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToolbox
{
    internal class ActiveLabel : Label
    {
        private bool hover;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (hover && Enabled)
            {
                int borderFudge = 0;
                if (BorderStyle == BorderStyle.FixedSingle)
                {
                    borderFudge = 2;
                }
                e.Graphics.DrawRectangle(SystemPens.Highlight, new Rectangle(0, 0, Width - borderFudge - 1, Height - borderFudge - 1));
            }
        }
    }
}
