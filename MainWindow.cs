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
       
        GraphDrawing gb;
        public MainWindow()
        {
            InitializeComponent();

            gb = new GraphDrawing(pictureBox1);
        }
        private double GetAnAngle(double h, double l) => (int)Math.Floor((Math.Atan(h/l)) * 180.0 / Math.PI) % 360; 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            gb.CreateNewTriangle(this);
            
            richTextBox1.AppendText(gb.GetInfoOfSize());
            debugLabel.Text = gb.GetCursorPos() + "\n" + GetAnAngle(gb.H, gb.L);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            gb.FirstCreate();
           
            richTextBox1.AppendText(gb.GetInfoOfSize());
            debugLabel.Text = gb.GetCursorPos() + "\n" + gb.Angle;
        }
    }
}
