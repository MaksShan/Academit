using System;
using System.IO;

namespace HashTableTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable table = new HashTable(100);

            using (StreamReader reader = new StreamReader("..\\..\\..\\Countries.txt"))
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    table.SetItem(currentLine);
                }
            }

            string searchItem = "Benin";

            if (table.GetItemIndex(searchItem) == -1)
            {
                Console.WriteLine($"Элемента \"{searchItem}\" не существует");
            }
            else
            {
                Console.WriteLine($"Хэш-код элемента \"{searchItem}\" = {table.GetListIndex(searchItem)}, его индекс в листе: {table.GetItemIndex(searchItem)}");

                Console.WriteLine(table.RemoveItem(searchItem));
            }

            Console.ReadKey();
        }
    }
}
