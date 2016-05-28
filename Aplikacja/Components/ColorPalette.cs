using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja.Components {
    public partial class ColorPalette : Control {

        List<Color> colors = new List<Color>();
        private int colorSize = 40;

        public void Add(Color color) {
            colors.Add(color);

            Invalidate();
        }

        public Rectangle GetColorRectangle(Color clr) {
            int index = colors.IndexOf(clr);
            if (index == -1)
                return new Rectangle(0, 0, 0, 0);
            int numberColorX = ClientRectangle.Width / colorSize;
            int colorX = index % numberColorX;
            int colorY = index / numberColorX;

            Rectangle rc = new Rectangle(colorX * colorSize, colorY * colorSize, colorSize, colorSize);
            rc.Inflate(-colorSize / 10, -colorSize / 10);
            return rc;
        }

        public ColorPalette() {
            InitializeComponent();

            
        }

        protected override void OnPaint(PaintEventArgs pe) {
            foreach (Color clr in colors) {
                Rectangle rc = GetColorRectangle(clr);

                pe.Graphics.FillRectangle(new SolidBrush(clr), rc);
            }

        }

        protected override void OnPaintBackground(PaintEventArgs pevent) {

        }

        protected override void OnMouseDown(MouseEventArgs e) {
           foreach (Color clr in colors) {
                Rectangle rc = GetColorRectangle(clr);

                if (rc.Contains(e.Location)) {
                    DoDragDrop(clr.ToArgb().ToString(), DragDropEffects.Move);

                    return;
                }
            }
        }
    }
}
