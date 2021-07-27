using System;

namespace Shapes
{
    class Triangle : IShape
    {
        private double X1 { get; set; }
        private double Y1 { get; set; }
        private double X2 { get; set; }
        private double Y2 { get; set; }
        private double X3 { get; set; }
        private double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }
        public double GetWidth()
        {
            double meanMax = Math.Max(X1, X2);
            double meanMin = Math.Min(X1, X2);

            return Math.Max(meanMax, X3) - Math.Min(meanMin, X3);
        }
        public double GetHeight()
        {
            double meanMax = Math.Max(Y1, Y2);
            double meanMin = Math.Min(Y1, Y2);

            return Math.Max(meanMax, Y3) - Math.Min(meanMin, Y3);
        }

        public double GetArea()
        {
            double AB = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
            double BC = Math.Sqrt(Math.Pow(X2 - X3, 2) + Math.Pow(Y2 - Y3, 2));
            double AC = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));

            double halfPerimetr = (AB + BC + AC) / 2;

            double area = Math.Sqrt((halfPerimetr - AB) * (halfPerimetr - AC) * (halfPerimetr - BC) * halfPerimetr);

            return area;
        }

        public double GetPerimeter()
        {
            double AB = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
            double BC = Math.Sqrt(Math.Pow(X2 - X3, 2) + Math.Pow(Y2 - Y3, 2));
            double AC = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));

            return AB + BC + AC;
        }

        public override string ToString()
        {
            return $"треугольник. Его площадь составляет: {GetArea()}, а периметр {GetPerimeter()}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return X1 == triangle.X1 && Y1 == triangle.Y1 && X2 == triangle.X2 && Y2 == triangle.Y2 && X3 == triangle.X3 && Y3 == triangle.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}
