using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начало диапазона первого интервала: ");
            double from1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите конец диапазона первого интервала: ");
            double to1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите начало диапазона второго интервала: ");
            double from2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите конец диапазона второго интервала: ");
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
                Console.WriteLine($"Число {number} принадлежит к введённому диапазону первого интервала");
            }
            else
            {
                Console.WriteLine($"Число {number} НЕ принадлежит к введённому диапазону первого интервала");
            }

            if (isNumberInsideRange2)
            {
                Console.WriteLine($"Число {number} принадлежит к введённому диапазону второго интервала");
            }
            else
            {
                Console.WriteLine($"Число {number} НЕ принадлежит к введённому диапазону второго интервала");
            }

            Range crossingRange = range1.GetIntersection(range2);

            bool isCrossing = false;

            if (crossingRange == null)
            {
                Console.WriteLine("Интервалы не пересакаются!");
            }
            else
            {
                isCrossing = true;

                Console.WriteLine($"Интервал пересечения двух интервалов: ({crossingRange.From}; {crossingRange.To})");
            }

            Range[] union = range1.GetUnion(range2);

            Console.Write("Объединенный интервал двух интервалов: ");
            Print(union);

            Range[] difference = range1.GetDifference(range2, isCrossing);

            Console.Write("Разность интервалов: ");
            Print(difference);

            Console.ReadKey();
        }

        public static void Print(Range[] rangeArray)
        {
            if (rangeArray.Length == 0)
            {
                Console.WriteLine("[]");
            }
            else if (rangeArray.Length == 1)
            {
                Console.WriteLine($"[{rangeArray[0]}]");
            }
            else
            {
                Console.WriteLine($"[{rangeArray[0]}, {rangeArray[1]}]");
            }
        }
    }
}
