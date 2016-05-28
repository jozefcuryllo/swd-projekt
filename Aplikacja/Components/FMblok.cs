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

namespace Aplikacja {
    public partial class FMblok : Control {

        public Color ulozonyKolor = Color.Black;


        public FMblok() {
            InitializeComponent();
            AllowDrop = true;
        }

        protected override void OnPaint(PaintEventArgs pe) {
            if (ulozonyKolor == Color.Black) {
                pe.Graphics.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Silver, Color.Snow), ClientRectangle);
            }
            else {
                pe.Graphics.FillRectangle(new SolidBrush(ulozonyKolor), ClientRectangle);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent) {
            
        }


        protected override void OnDragEnter(DragEventArgs drgevent) {
            drgevent.Effect = DragDropEffects.Move;
        }

        protected override void OnDragDrop(DragEventArgs drgevent) {
           
            String colorName = drgevent.Data.GetData(DataFormats.StringFormat) as string;

            if (colorName == null)
                return;

            ulozonyKolor = Color.FromArgb(Convert.ToInt32(colorName));

            Invalidate();
        }
    }
}
