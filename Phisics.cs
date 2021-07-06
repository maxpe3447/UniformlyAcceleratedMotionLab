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
            Random random = new Random();
            if(random.Next() % 2 == 0)
            {
                return Math.Sqrt(((2 * S) / a) + (random.Next(0, 500) / 100000));
            }
            else
            {
                return Math.Sqrt(((2 * S) / a) - (random.Next(0, 500) / 100000));
            }
        }
    }
}
