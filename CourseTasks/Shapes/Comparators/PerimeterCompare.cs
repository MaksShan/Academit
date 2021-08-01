using System.Collections.Generic;
using Shapes.ShapesClasses;

namespace Shapes.Comparators
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            double perimeter1 = shape1.GetPerimeter();
            double perimeter2 = shape2.GetPerimeter();

            return perimeter1.CompareTo(perimeter2);
        }
    }
}
