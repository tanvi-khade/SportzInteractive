using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportzInteractive
{
    public sealed class Circle
    {
        public Circle(double radius)
        {
            this.radius = radius;
        }
        private double radius;
        public double Calculate(Func<double, double> op)
        {
            return op(radius);
        }
    }
}
