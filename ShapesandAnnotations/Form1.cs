using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace ShapesandAnnotations
{
    public partial class Form1 : Form
    {
        int x, y;
        static int count = 0;
        Shapes.AnnotationList annotations = new Shapes.AnnotationList();
        public Form1()
        {


            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = new Bitmap(@"E:\2019\ShapesandAnnotations\ShapesandAnnotations\Images\pexels-photo-247487.jpeg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.MouseClick += new MouseEventHandler(PictureBox1_MouseClick);
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            x = p.X;
            y = p.Y;
            int width = 100, height = 100;
            count = count + 1;


            if (comboBox1.SelectedIndex == 0)
            {
                annotations.Add(new Shapes.CircleShape()
                {
                    Rectangle = new Rectangle(x - width / 2, y - height / 2, width, height),
                    count = count,
                    x = x,
                    y = y

                }

                );
                annotations.Draw(pictureBox1.CreateGraphics());
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                annotations.Add(new Shapes.RectangleShape()
                {
                    Rectangle = new Rectangle(x, y, width, height / 2),
                    count = count,
                    x = x + 25,
                    y = y + 12

                });

                annotations.Draw(pictureBox1.CreateGraphics());
            }




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            //if(comboBox1.SelectedIndex==0)
            //{
            //    MessageBox.Show("circle");
            //}
            //else if (comboBox1.SelectedIndex == 1)
            //{
            //    MessageBox.Show("rectangle");
            //}
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            annotations.Save(@"E:\shapes.bin");
            annotations.Clear();
            this.pictureBox1.Invalidate();
            MessageBox.Show("Shapes saved successfully.");

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            annotations.Load(@"E:\shapes.bin");
            this.pictureBox1.Invalidate();


            annotations.Draw(pictureBox1.CreateGraphics());
            MessageBox.Show("Shapes loaded successfully.");
        }



        //public void DrawAnnotation(int x, int y, int width, int height)
        //{
        //    count = count + 1;
        //    Graphics g = pictureBox1.CreateGraphics();
        //    Pen p = new Pen(Color.Black);

        //    if (comboBox1.SelectedIndex == 0)
        //    {
        //        SolidBrush sb = new SolidBrush(Color.Red);


        //        g.DrawEllipse(p, x - width / 2, y - height / 2, width, height);
        //        g.FillEllipse(sb, x - width / 2, y - height / 2, width, height);

        //        g.DrawString(count.ToString(), new Font("Arial", 12, FontStyle.Bold),
        //            Brushes.White, x, y);

        //    }
        //    if (comboBox1.SelectedIndex == 1)
        //    {
        //        SolidBrush sb = new SolidBrush(Color.Blue);
        //        g.DrawRectangle(p, x, y, width, height / 2);
        //        g.FillRectangle(sb, x, y, width, height / 2);
        //        g.DrawString(count.ToString(), new Font("Arial", 12, FontStyle.Bold),
        //           Brushes.White, x + 25, y + 12);
        //    }
        //}


    }
}
