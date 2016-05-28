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
    public partial class FMdrag : Control {

        Color color;

        public void makeFMDrag(int r, int g, int b) {
            color = Color.FromArgb(r, g, b);
        }

        public FMdrag() {
            InitializeComponent();

            
        }

        protected override void OnPaint(PaintEventArgs pe) {
            pe.Graphics.FillRectangle(new SolidBrush(color), ClientRectangle);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent) {

        }

        protected override void OnMouseDown(MouseEventArgs e) {
                 DoDragDrop(this, DragDropEffects.Move);
         
        }
    }
}
