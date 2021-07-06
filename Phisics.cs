using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformlyAcceleratedMotionLab
{
    class Phisics
    {
        const double g = 9.81;
        double a;
        public Phisics(double angle)
        {
            double radian = angle * Math.PI / 180;
            a = g * Math.Sin(radian);
        }

        public double GetTime(double S) {
            Random random = new Random(DateTime.Now.Millisecond);
            if(random.Next() % 2 == 0)
            {
                return Math.Sqrt(((2 * S) / a) + (double)(random.Next(0, 5) / 100.0));
            }
            else
            {
                return Math.Sqrt(((2 * S) / a) - (double)(random.Next(0, 5) / 100.0));
            }
        }
    }
}
