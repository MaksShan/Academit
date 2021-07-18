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

            Console.WriteLine($"Длина первого диапазона чисел: {range1.GetRange()}");
            Console.WriteLine($"Длина второго диапазона чисел: {range2.GetRange()}");

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

            Range crossingRange = range1.GetCrossingInterval(range2);

            if (crossingRange == null)
            {
                Console.WriteLine("Интервалы не пересакаются!");
            }
            else
            {
                Console.WriteLine($"Интервал пересечения двух интервалов: [{crossingRange.From} : {crossingRange.To}]");
            }

            Range[] combinedInterval = range1.GetCombinedInterval(range2);

            Console.Write("Объединенный интервал двух интервалов: ");

            if (combinedInterval.Length == 1)
            {
                Console.WriteLine($"[{combinedInterval[0].From} : {combinedInterval[0].To}]");
            }
            else
            {
                Console.WriteLine($"[{combinedInterval[0].From} : {combinedInterval[0].To} , {combinedInterval[1].From} : {combinedInterval[1].To}]");
            }

            Range[] intervalDifference = range1.GetIntervalDifference(range2);

            Console.Write("Разность интервалов: ");

            if (intervalDifference == null)
            {
                Console.WriteLine("0");
            }
            else if (intervalDifference.Length == 1)
            {
                Console.WriteLine($"[{intervalDifference[0].From} : {intervalDifference[0].To}]");
            }
            else
            {
                Console.WriteLine($"[{intervalDifference[0].From} : {intervalDifference[0].To} , {intervalDifference[1].From} : {intervalDifference[1].To}]");
            }

            Console.ReadKey();
        }
    }
}
