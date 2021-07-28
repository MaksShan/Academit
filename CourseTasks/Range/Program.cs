using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начало первого диапазона: ");
            double from1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите конец первого диапазона: ");
            double to1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите начало второго диапазона: ");
            double from2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите конец второго диапазона: ");
            double to2 = double.Parse(Console.ReadLine());

            Range range1 = new Range(from1, to1);
            Range range2 = new Range(from2, to2);

            Console.WriteLine($"Длина первого диапазона чисел: {range1.GetLength()}");
            Console.WriteLine($"Длина второго диапазона чисел: {range2.GetLength()}");

            Console.Write("Введите число для проверки на пренадлежность к диапазонам: ");
            double number = double.Parse(Console.ReadLine());

            bool isNumberInsideRange1 = range1.IsInside(number);
            bool isNumberInsideRange2 = range2.IsInside(number);

            if (isNumberInsideRange1)
            {
                Console.WriteLine($"Число {number} принадлежит к первому диапазону");
            }
            else
            {
                Console.WriteLine($"Число {number} НЕ принадлежит к первому диапазону");
            }

            if (isNumberInsideRange2)
            {
                Console.WriteLine($"Число {number} принадлежит ко второму диапазону");
            }
            else
            {
                Console.WriteLine($"Число {number} НЕ принадлежит ко второму диапазону");
            }

            Range intersection = range1.GetIntersection(range2);

            if (intersection == null)
            {
                Console.WriteLine("Интервалы не пересакаются!");
            }
            else
            {
                Console.WriteLine($"Интервал пересечения двух интервалов: ({intersection.From}; {intersection.To})");
            }

            Range[] union = range1.GetUnion(range2);

            Console.Write("Объединенный интервал двух интервалов: ");
            Print(union);

            Range[] difference = range1.GetDifference(range2);

            Console.Write("Разность интервалов: ");
            Print(difference);

            Console.ReadKey();
        }

        public static void Print(Range[] ranges)
        {
            Console.Write('[');

            for (int i = 0; i < ranges.Length; i++)
            {
                Console.Write(ranges[i]);

                if (i != ranges.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine(']');
        }
    }
}
