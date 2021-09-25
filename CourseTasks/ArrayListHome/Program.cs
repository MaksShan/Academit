using System;
using System.IO;
using System.Collections.Generic;

namespace ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Текст из файла файла: ");

            List<string> dataFromFile = ReadFileData("..\\..\\..\\Data.txt");

            Console.WriteLine(string.Join('\n', dataFromFile));

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine($"\nИсходный список целых чисел: {string.Join(", ", numbers)}");

            RemoveEvenNunbers(numbers);

            Console.WriteLine($"Список целых чисел после удаления четных: {string.Join(", ", numbers)}");

            List<int> repeatableNumbers = new List<int> { 1, 5, 2, 1, 3, 5 };

            Console.WriteLine($"\nИсходный список целых чисел: {string.Join(", ", repeatableNumbers)}");

            List<int> uniqueNumbers = GetListWithoutRepeats(repeatableNumbers);

            Console.WriteLine($"Список целых чисел без повторений: {string.Join(", ", uniqueNumbers)}");

            Console.ReadKey();
        }

        private static List<string> ReadFileData(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<string> lines = new List<string>();

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    lines.Add(currentLine);
                }

                return lines;
            }
        }

        private static void RemoveEvenNunbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);
                }
            }
        }

        private static List<int> GetListWithoutRepeats(List<int> numbersList)
        {
            List<int> uniqueNumbers = new List<int>();

            if (numbersList.Count > 1)
            {
                for (int i = numbersList.Count - 1; i > 0; --i)
                {
                    bool isRepeats = false;

                    for (int j = i - 1; j >= 0; --j)
                    {
                        if (numbersList[i] == numbersList[j])
                        {
                            isRepeats = true;

                            break;
                        }
                    }

                    if (isRepeats == false)
                    {
                        uniqueNumbers.Add(numbersList[i]);
                    }
                }

                uniqueNumbers.Add(numbersList[0]);

                uniqueNumbers.Reverse();
            }
            else
            {
                uniqueNumbers.AddRange(numbersList);
            }

            return uniqueNumbers;
        }
    }
}
