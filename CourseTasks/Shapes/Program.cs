using System;
using Shapes.Shapes;
using Shapes.Comparators;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Circle(25),
                new Rectangle(54, 12),
                new Triangle(2.6, 2.9, 15.3, 20, 40, 24),
                new Square(15.3),
                new Circle(32),
                new Rectangle(17, 58),
                new Square(41.4)
            };

            Array.Sort(shapes, new AreaComparer());
            Console.WriteLine("Фигура с самой большой площадью: " + shapes[shapes.Length - 1]);

            Array.Sort(shapes, new PerimeterComparer());
            Console.WriteLine("Фигура со вторым по величине периметром: " + shapes[shapes.Length - 2]);

            Console.ReadKey();
        }
    }
}
