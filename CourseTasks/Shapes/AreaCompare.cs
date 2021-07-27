using System.Collections.Generic;

namespace Shapes
{
    class AreaCompare : IComparer<IShape>
    {
        public int Compare(IShape a, IShape b)
        {
            double area1 = a.GetArea();
            double area2 = b.GetArea();

            if (area1 > area2)
            {
                return 1;
            }
            else if (area1 < area2)
            {
                return -1;
            }

            return 0;
        }
    }
}
