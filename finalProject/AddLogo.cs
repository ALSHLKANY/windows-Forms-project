using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalProject
{
    public partial class AddLogo : Form
    {
        public AddLogo()
        {
            InitializeComponent();
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //return to the choose form
            this.Hide();
            ChooseFrm chooseFrm = new ChooseFrm();
            chooseFrm.Location = this.Location;
            chooseFrm.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG files(*.png)|*.png|jpg files(*.jpg)|*.jpg |  jpeg files(*.jpeg)|*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                    Pic1.ImageLocation = ofd.FileName;
            }
            catch (Exception V) { MessageBox.Show(V.Message); }
        }

        public Bitmap picAfter;
        private void button2_Click(object sender, EventArgs e)
        {
            Pic2.Image = Pic1.Image;
           if(CenterBtn.Checked)
            {
                Bitmap res = new Bitmap(Pic2.Image.Width, Pic2.Image.Height);
                Graphics g = Graphics.FromImage(res);
                g.DrawImage(Pic1.Image, new Point(0, 0));

                g.DrawImage(pictureBox1.Image, (Pic1.Image.Width - 100)/2, (Pic1.Image.Height - 100)/2, 100,100);
                Pic2.Image = res;
            }
            else if (LeftTopBtn.Checked)
            {
                Bitmap res = new Bitmap(Pic1.Image.Width, Pic1.Image.Height);
                Graphics g = Graphics.FromImage(res);
                g.DrawImage(Pic1.Image, new Point(0, 0));

                g.DrawImage(pictureBox1.Image, 0, 0, 100, 100);
                Pic2.Image = res;
            }
            else if (RightTopBtn.Checked)
            {
                Bitmap res = new Bitmap(Pic2.Image.Width, Pic2.Image.Height);
                Graphics g = Graphics.FromImage(res);
                g.DrawImage(Pic2.Image, new Point(0, 0));

                g.DrawImage(pictureBox1.Image, Pic2.Image.Width-100, 0, 100, 100);
                Pic2.Image = res;

            }
            else if (RightDownBtn.Checked)
            {
                Bitmap res = new Bitmap(Pic2.Image.Width, Pic2.Image.Height);
                Graphics g = Graphics.FromImage(res);
                g.DrawImage(Pic2.Image, new Point(0, 0));

                g.DrawImage(pictureBox1.Image, Pic2.Image.Width - 100, Pic2.Image.Height - 100, 100, 100);
                Pic2.Image = res;
            }
            else if (LeftDownBtn.Checked)
            {
                Bitmap res = new Bitmap(Pic2.Image.Width, Pic2.Image.Height);
                Graphics g = Graphics.FromImage(res);
                g.DrawImage(Pic2.Image, new Point(0, 0));

                g.DrawImage(pictureBox1.Image, 0, Pic2.Image.Height -100, 100, 100);
                Pic2.Image = res;
            }
            else
            {
                MessageBox.Show("choose where are you need to add your logo");
            }
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = "";

                SaveFileDialog saveDialog = new SaveFileDialog();

                // Set the file type filter to image files
                saveDialog.Filter = "Image files (*.png)|*.png|Image files (*.jpg)|*.jpg";
                saveDialog.FileName = Pic1.ImageLocation + $"{new Random().Next(1000000)}_After_.png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {

                    // Get the file name specified by the user
                    FileName = saveDialog.FileName;


                }
                Bitmap bitmap = new Bitmap(Pic2.Image);
                bitmap.Save(FileName);
                Process.Start(FileName);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG files(*.png)|*.png|jpg files(*.jpg)|*.jpg |  jpeg files(*.jpeg)|*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                    pictureBox1.ImageLocation = ofd.FileName;
            }
            catch (Exception V) { MessageBox.Show(V.Message); }
        }

        private void CenterBtn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
