namespace Shapes
{
    class Rectangle : IShape
    {
        private double SideALength { get; set; }
        private double SideBLength { get; set; }

        public Rectangle(double sideALenght, double sideBLength)
        {
            SideALength = sideALenght;
            SideBLength = sideBLength;
        }

        public double GetWidth()
        {
            return SideALength;
        }

        public double GetHeight()
        {
            return SideBLength;
        }

        public double GetArea()
        {
            return SideALength * SideBLength;
        }

        public double GetPerimeter()
        {
            return 2 * (SideALength + SideBLength);
        }

        public override string ToString()
        {
            return $"прямоугольник. Его площадь составляет: {GetArea()}, а периметр {GetPerimeter()}";
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

            Rectangle rectangle = (Rectangle)obj;

            return SideALength == rectangle.SideALength && SideBLength == rectangle.SideBLength;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + SideALength.GetHashCode();
            hash = prime * hash + SideBLength.GetHashCode();

            return hash;
        }
    }
}
