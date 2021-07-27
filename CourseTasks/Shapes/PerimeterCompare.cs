using System.Collections.Generic;

namespace Shapes
{
    class PerimeterCompare : IComparer<IShape>
    {
        public int Compare(IShape a, IShape b)
        {
            double perimeter1 = a.GetPerimeter();
            double perimeter2 = b.GetPerimeter();

            if (perimeter1 > perimeter2)
            {
                return 1;
            }
            else if (perimeter1 < perimeter2)
            {
                return -1;
            }

            return 0;
        }
    }
}
