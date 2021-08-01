using System.Collections.Generic;
using Shapes.ShapesClasses;

namespace Shapes.Comparators
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            double area1 = shape1.GetArea();
            double area2 = shape2.GetArea();

            return area1.CompareTo(area2);
        }
    }
}
