using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UniformlyAcceleratedMotionLab
{
    class GraphDrawing
    {
        private Graphics graph;
        private Bitmap bmp;

        private int _h, _l;
        private double _s;

        private System.Windows.Forms.PictureBox pictureBox;

        private Point startPoint, secondPoint, arbitrarilyPoint, newArbitrarilyPoint;
        public double Angle
        {
            get { return CalcAnAngle(); }
        }

        /// <summary>
        /// $"H = {H} m" or use GetInfoOfSize()
        /// </summary>
        public int H
        {
            get { return _h; }
            private set { _h = value; }
        }

        /// <summary>
        /// $"L = {L} m" or use GetInfoOfSize()
        /// </summary>
        public int L
        {
            get { return _l; }
            private set { _l = value; }
        }

        /// <summary>
        /// $"S = {S} m" or use GetInfoOfSize()
        /// </summary>
        public double S
        {
            get { return _s; }
            private set { _s = value; }
        }
        public GraphDrawing(System.Windows.Forms.PictureBox pictureBox)
        {
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            graph = Graphics.FromImage(bmp);

            this.pictureBox = pictureBox;
        }
        public void DrawTriangle()
        {
            graph.DrawLine(new Pen(Color.Black, 3), startPoint, secondPoint);
            graph.DrawLine(new Pen(Color.Black, 3), arbitrarilyPoint, secondPoint);
            graph.DrawLine(new Pen(Color.Black, 3), arbitrarilyPoint, startPoint);

            int radius = 25;
            RectangleF phosiksBody = new RectangleF(arbitrarilyPoint.X - radius, arbitrarilyPoint.Y - radius, radius, radius);
            graph.DrawEllipse(new Pen(Color.Blue, 3), phosiksBody);
            pictureBox.Image = bmp;
        }

        public void CreateNewTriangle(System.Windows.Forms.Form form)
        {
            newArbitrarilyPoint = System.Windows.Forms.Cursor.Position;
            newArbitrarilyPoint.X -= form.Location.X;
            newArbitrarilyPoint.Y -= form.Location.Y;

            if (newArbitrarilyPoint != arbitrarilyPoint)
            {
                graph.Clear(Color.White);

                newArbitrarilyPoint.X -= 10;
                newArbitrarilyPoint.Y -= 62;
                arbitrarilyPoint = newArbitrarilyPoint;

                secondPoint.X = newArbitrarilyPoint.X;

                H = secondPoint.Y - arbitrarilyPoint.Y;
                L = secondPoint.X - startPoint.X;
                S = Math.Sqrt(Math.Pow(L, 2) + Math.Pow(H, 2));

                DrawTriangle();
            }
        }

        public void FirstCreate()
        { 
            graph.Clear(Color.White);

            Random rand = new Random();

            startPoint.X = rand.Next(pictureBox.Location.X + 30, pictureBox.Location.X + 30 + 50);
            startPoint.Y = rand.Next(pictureBox.Location.Y + pictureBox.Height - 60, pictureBox.Location.Y + pictureBox.Height - 40);

            int widthOfMainTriangle = rand.Next(pictureBox.Width / 2, (int)pictureBox.Width * 2 / 3);
            secondPoint.X = startPoint.X + widthOfMainTriangle;
            secondPoint.Y = startPoint.Y;

            int heightOfMainTriangle = rand.Next(pictureBox.Location.Y + 50, pictureBox.Location.Y + 70);
            arbitrarilyPoint.X = secondPoint.X;
            arbitrarilyPoint.Y = heightOfMainTriangle;

            H = secondPoint.Y - heightOfMainTriangle;
            L = widthOfMainTriangle;
            S = Math.Sqrt(Math.Pow(L, 2) + Math.Pow(H, 2));
        }
        private double CalcAnAngle() => /*(int)*/Math.Floor((Math.Atan(H / L)) * 180.0 / Math.PI) % 360;
        public string GetInfoOfSize() => $"L = {L} m\nH = {H} m\nS = {S.ToString("0.000")} m\n-------------\n";
        public string GetCursorPos() => $"Pos: {newArbitrarilyPoint.X} -> {newArbitrarilyPoint.Y}\n";

    }
}
