using System;
using System.IO;
using System.Collections.Generic;

namespace ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fileLines = GetLinesFromFile("..\\..\\..\\Data.txt");

            foreach (string line in fileLines)
            {
                Console.WriteLine(line);
            }

            List<int> numbers = new List<int> { -1, -2, -4, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine();
            Console.WriteLine($"Исходный список целых чисел: {string.Join(", ", numbers)}");

            RemoveEvenNumbers(numbers);
            Console.WriteLine($"Список целых чисел после удаления четных: {string.Join(", ", numbers)}");

            List<int> repeatableNumbers = new List<int> { 1, 5, 2, 1, 3, 5 };

            Console.WriteLine();
            Console.WriteLine($"Исходный список целых чисел: {string.Join(", ", repeatableNumbers)}");

            List<int> uniqueNumbers = GetListWithoutRepeats(repeatableNumbers);
            Console.WriteLine($"Список целых чисел без повторений: {string.Join(", ", uniqueNumbers)}");

            Console.ReadKey();
        }

        private static List<string> GetLinesFromFile(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                using StreamReader reader = new StreamReader(filePath);

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    lines.Add(currentLine);
                }

                return lines;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
            catch (IOException)
            {
                Console.WriteLine("Не удалось открыть файл!");
            }

            return lines;
        }

        private static void RemoveEvenNumbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);

                    i--;
                }
            }
        }

        private static List<int> GetListWithoutRepeats(List<int> numbers)
        {
            List<int> uniqueNumbers = new List<int>(numbers.Count);

            foreach (int number in numbers)
            {
                if (!uniqueNumbers.Contains(number))
                {
                    uniqueNumbers.Add(number);
                }
            }

            return uniqueNumbers;
        }
    }
}