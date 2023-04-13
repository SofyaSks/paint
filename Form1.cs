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

namespace paint
{
    public partial class Form1 : Form
    {
        SolidBrush sb;
        Graphics g;
        bool isDrawing = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sb = new SolidBrush(panel2.BackColor);
            g = panel1.CreateGraphics();
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel2.BackColor = colorDialog1.Color; 
                sb.Color = panel2.BackColor;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing == true)
            {
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.FillEllipse(sb, e.X, e.Y, trackBar1.Value, trackBar1.Value);
            }
        }
    }
}
