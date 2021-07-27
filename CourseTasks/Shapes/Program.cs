using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] array = new IShape[] { new Circle(25), new Rectangle(54, 12), new Triangle(2.6, 2.9, 15.3, 20, 40, 24), new Square(15.3), new Circle(32), new Rectangle(17, 58), new Square(41.4) };

            Array.Sort(array, new AreaCompare());
            Console.WriteLine("Фигура с самой большой площадью: " + array[array.Length - 1]);

            Array.Sort(array, new PerimeterCompare());
            Console.WriteLine("Фигура со вторым по величине периметром: " + array[array.Length - 2]);

            Console.ReadKey();
        }
    }
}
