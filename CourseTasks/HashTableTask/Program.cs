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
                Console.WriteLine("Не удалось удалить элемент");
            }

            string[] countries = new string[300];

            table.CopyTo(countries, 0);

            Console.WriteLine("Содержимое таблицы: ");
            Console.WriteLine(table);

            table.Clear();

            Console.ReadKey();
        }
    }
}