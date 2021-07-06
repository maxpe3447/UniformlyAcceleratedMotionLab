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
        private int counter = 1;
        Phisics ph;
        public MainWindow()
        {
            InitializeComponent();
            lIfoAboutGraph.Text = "Для початку роботи\nнатисніть на кнопку...";
            gb = new GraphDrawing(pictureBox1);
            //richTextBox1.AppendText("Для перегляду інструкції використання натисніть кнопку у верхньому правому куті...");
            richTextBox1.AppendText("№\tL\tH\tS\tКут\tЧас\n");
        }
        private double GetAnAngle(double h, double l) => (int)Math.Floor((Math.Atan(h/l)) * 180.0 / Math.PI) % 360; 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            gb.CreateNewTriangle(this);

            lIfoAboutGraph.Text = gb.GetInfoOfSize() + $"\nКут = {GetAnAngle(gb.H, gb.L)}";
            ph = new Phisics(GetAnAngle(gb.H, gb.L));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Clear();
            //richTextBox1.AppendText("№\tL\tH\tS\tКут\tЧас\n");

            gb.FirstCreate();
            gb.DrawTriangle();

            ph = new Phisics(GetAnAngle(gb.H, gb.L));
           
            lIfoAboutGraph.Text = gb.GetInfoOfSize();
            lIfoAboutGraph.Text = gb.GetInfoOfSize() + $"\nКут = {GetAnAngle(gb.H, gb.L)}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //richTextBox1.AppendText("№\tL\t\tH\t\tS\t\tКут\t\tЧас");
            if(gb.L == 0)
            {
                MessageBox.Show("Некоректне використання програми", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
            richTextBox1.AppendText($"{counter++}\t{gb.L}\t{gb.H}\t{gb.S.ToString("0.00")}\t{GetAnAngle(gb.H, gb.L)}\t{ph.GetTime(gb.S).ToString("0.000")}\n");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Instruction instructionForm = new Instruction();
            instructionForm.Show();
        }
    }
}
