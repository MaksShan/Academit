using System;
using System.IO;

namespace HashTableTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> table = new HashTable<string>(100);

            using (StreamReader reader = new StreamReader("..\\..\\..\\Countries.txt"))
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    table.Add(currentLine);
                }
            }

            string searchItem = "Benin";

            if (table.Contains(searchItem))
            {
                Console.WriteLine($"Элемента \"{searchItem}\" хранится в списке");
            }
            else
            {
                Console.WriteLine($"Элемент \"{searchItem}\" в списке отсутствует");
            }

            if (table.Remove(searchItem))
            {
                Console.WriteLine("Элемент был успешно удален");
            }
            else
            {
                Console.WriteLine("Не удалось удалить жэлемент");
            }

            string[] countries = new string[20];

            table.CopyTo(countries, 10);

            Console.Write($"В таблице под индексом {10} хранятся следующие элементы: ");

            for (int i = 0; i < countries.Length && countries[i] != null; i++)
            {
                Console.Write(countries[i]);

                if (countries[i + 1] == null)
                {
                    break;
                }

                Console.Write(", ");
            }

            table.Clear();

            Console.ReadKey();
        }
    }
}