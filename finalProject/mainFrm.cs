using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalProject
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        
        string v = "123";
        private void Form1_Load(object sender, EventArgs e)
        {
            
            randomLbl.Text = "";
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
                randomLbl.Text += v[random.Next(3)];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text+= "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text += "2";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text += "3";
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            
            randomLbl.Text = "";
            Random random = new Random();
            for(int i=1;i<=5;i++)
              randomLbl.Text += v[random.Next(3)];
            
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (label3.Text == randomLbl.Text)
            {
                Hide();
                ChooseFrm choose = new ChooseFrm();
                choose.ShowDialog();

            }
            else
            {
                MessageBox.Show("Try Again");
                label3.Text = "";
                
                randomLbl.Text = "";
                Random random = new Random();

                for (int i = 1; i <= 5; i++)
                    randomLbl.Text += v[random.Next(3)];
            }
        }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}