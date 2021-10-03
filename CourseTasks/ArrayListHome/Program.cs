using System;
using System.IO;
using System.Collections.Generic;

namespace ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> fileLines = ReadLinesFromFile("..\\..\\..\\Data.txt");

                foreach (string l in fileLines)
                {
                    Console.WriteLine(l);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Не удалось открыть файл");
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

        private static List<string> ReadLinesFromFile(string filePath)
        {
            try
            {
                using StreamReader reader = new StreamReader(filePath);

                List<string> lines = new List<string>();

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    lines.Add(currentLine);
                }

                return lines;
            }
            catch
            {
                throw new IOException();
            }
        }

        private static void RemoveEvenNumbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if ((numbers[i]) % 2 == 0)
                {
                    numbers.RemoveAt(i);

                    i--;
                }
            }
        }

        private static List<int> GetListWithoutRepeats(List<int> numbersList)
        {
            List<int> uniqueNumbers = new List<int>(10);

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (uniqueNumbers.Contains(numbersList[i]))
                {
                    continue;
                }

                uniqueNumbers.Add(numbersList[i]);
            }

            return uniqueNumbers;
        }
    }
}
