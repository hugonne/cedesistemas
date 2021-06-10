using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedesistemas.Solid.OCP
{
    public class AreaCalculator
    {
        public double TotalArea(Rectangle[] rectangles)
        {
            double area = 0;
            foreach (var rectangle in rectangles)
            {
                area += rectangle.Height * rectangle.Width;
            }
            return area;
        }
    }
}
