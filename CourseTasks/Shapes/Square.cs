namespace Shapes
{
    class Square : IShape
    {
        private double SideLength { get; set; }

        public Square(double sideLenght)
        {
            SideLength = sideLenght;
        }

        public double GetWidth()
        {
            return SideLength;
        }
        public double GetHeight()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }

        public override string ToString()
        {
            return $"квадрат. Его площадь составляет: {GetArea()}, а периметр {GetPerimeter()}";
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

            Square square = (Square)obj;

            return SideLength == square.SideLength;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + SideLength.GetHashCode();

            return hash;
        }
    }
}
