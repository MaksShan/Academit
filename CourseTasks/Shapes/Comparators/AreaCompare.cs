using System.Collections.Generic;
using Shapes.Shapes;

namespace Shapes.Comparators
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}
