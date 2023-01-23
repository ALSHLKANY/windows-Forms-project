using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalProject
{
    public partial class Draw : Form
    {
        public Draw() 
        {
            InitializeComponent();
        }
        Color mainColor = Color.Red;
        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void panel4_Click(object sender, EventArgs e)
        {
            
            //colorDialog
            colorDialog1.AllowFullOpen = true;
            colorDialog1.AnyColor = true;
            colorDialog1.SolidColorOnly = false;
            colorDialog1.Color = mainColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                mainColor = colorDialog1.Color;
            }
            panel4.BackColor = mainColor;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            ChooseFrm chooseFrm = new ChooseFrm();
            chooseFrm.ShowDialog();

        }

        Point a;
        bool Drawing = false;

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Drawing = false;
        }
       

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;
        }

       
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drawing)
            {

                int qoutientX = e.X/10;
                int qoutientY = e.Y/10;
                a.X = qoutientX*10 ;
                a.Y = qoutientY*10;
              
                Graphics g = panel2.CreateGraphics();
                Pen p = new Pen(mainColor);
                Rectangle rec = new Rectangle(a.X, a.Y, 10, 10);
                g.DrawRectangle(p, rec);
                g.FillRectangle(new SolidBrush(mainColor), rec);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
