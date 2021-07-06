using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniformlyAcceleratedMotionLab
{
    public partial class MainWindow : Form
    {
        Graphics graph;
        Bitmap bmp; 
        public MainWindow()
        {
            InitializeComponent();
            //graph = this.CreateGraphics();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            //DrawLines();

        }
        private double GetAnAngle(double h, double l) => (int)Math.Floor((Math.Atan(h/l)) * 180.0 / Math.PI) % 360; 
        //{

        //    return 
        //}
        private void DrawTriangle()
        {
            graph.DrawLine(new Pen(Color.Black, 3), startPoint, secondPoint);
            graph.DrawLine(new Pen(Color.Black, 3), arbitrarilyPoint, secondPoint);
            graph.DrawLine(new Pen(Color.Black, 3), arbitrarilyPoint, startPoint);

            int radius = 25;
            RectangleF phosiksBody = new RectangleF(arbitrarilyPoint.X - radius, arbitrarilyPoint.Y - radius, radius, radius);
            graph.DrawEllipse(new Pen(Color.Blue, 3), phosiksBody);
            pictureBox1.Image = bmp;
        }

        private Point startPoint, secondPoint, arbitrarilyPoint;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point newArbitrarilyPoint = Cursor.Position;
            newArbitrarilyPoint.X -= this.Location.X;
            newArbitrarilyPoint.Y -= this.Location.Y;

            if (newArbitrarilyPoint != arbitrarilyPoint)
            {
                graph.Clear(Color.White);
                //
                label1.Text = $"Pos: {newArbitrarilyPoint.X} -> {newArbitrarilyPoint.Y}";
                
                //
                newArbitrarilyPoint.X -= 10;
                newArbitrarilyPoint.Y -= 62;
                arbitrarilyPoint = newArbitrarilyPoint;
                
                secondPoint.X = newArbitrarilyPoint.X;

                int _H =  secondPoint.Y - arbitrarilyPoint.Y;
                int _L = secondPoint.X - startPoint.X;
                double _S = Math.Sqrt(Math.Pow(_L, 2) + Math.Pow(_H, 2));
               
                richTextBox1.AppendText($"L = {_L} m\nH = {_H} m\nS = {_S.ToString("0.000")} m\n-------------\n");
                richTextBox1.AppendText(arbitrarilyPoint.ToString());
                DrawTriangle();
                label2.Text = GetAnAngle(_H, _L).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            graph.Clear(Color.White);

            Random rand = new Random();

            startPoint.X = rand.Next(pictureBox1.Location.X + 30, pictureBox1.Location.X + 30 + 50);
            startPoint.Y = rand.Next(pictureBox1.Location.Y + pictureBox1.Height - 60, pictureBox1.Location.Y + pictureBox1.Height -40);
            
            int widthOfMainTriangle = rand.Next(pictureBox1.Width / 2, (int) pictureBox1.Width * 2 / 3);
            secondPoint.X = startPoint.X + widthOfMainTriangle;//widthOfMainTriangle;
            secondPoint.Y = startPoint.Y;

            int heightOfMainTriangle = rand.Next(pictureBox1.Location.Y+50, pictureBox1.Location.Y+70);
            arbitrarilyPoint.X = secondPoint.X;
            arbitrarilyPoint.Y = heightOfMainTriangle;

            int _H = secondPoint.Y - heightOfMainTriangle;
            int _L = widthOfMainTriangle;
            double _S = Math.Sqrt(Math.Pow(_L, 2) + Math.Pow(_H, 2));
           
            richTextBox1.AppendText($"L = {_L} m\nH = {_H} m\nS = {_S.ToString("0.000")} m\n-------------\n");
            richTextBox1.AppendText(arbitrarilyPoint.ToString());
            DrawTriangle();


            //Bitmap bitmap = new Bitmap(pictureBox1.Width + 1, pictureBox1.Height + 1, graph);
            //pictureBox1.Image = bitmap;
        }
    }
}
