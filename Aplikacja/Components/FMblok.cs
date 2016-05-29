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

        private Color ulozonyKolor = Color.Black;

        public Color UlozonyKolor {
            get {
                return ulozonyKolor;
            }

            set {
                ulozonyKolor = value;
            }
        }

        public FMblok() {
            InitializeComponent();
            AllowDrop = true;
        }

        protected override void OnPaint(PaintEventArgs pe) {
            if (UlozonyKolor == Color.Black) {
                pe.Graphics.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Silver, Color.Snow), ClientRectangle);
            }
            else {
                pe.Graphics.FillRectangle(new SolidBrush(UlozonyKolor), ClientRectangle);
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

            UlozonyKolor = Color.FromArgb(Convert.ToInt32(colorName));

            Invalidate();
        }
    }
}
