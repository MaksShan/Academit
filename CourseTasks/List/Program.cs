using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            for (int i = 5; i > 0; i--)
            {
                list.AddFirst(i);
            }

            Console.WriteLine("Исходный лист: " + list);

            Console.WriteLine($"Размер листа: {list.Count} элементов");

            try
            {
                Console.WriteLine($"Значение, хранимое в первом элементе: {list.GetFirst()}");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Список пуст");
            }

            try
            {
                Console.WriteLine($"Значение, хранимое в элементе под индексом {3}: { list.GetData(3)}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Невозможно получить элемент. Индекс находится вне длины списка");
            }

            try
            {
                Console.WriteLine($"Элемент {list.SetData(3, 0)} был изменен на {0} под индексом {3}: " + list);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Невозможно изменить элемент. Индекс находится вне длины списка");
            }

            try
            {
                Console.WriteLine($"Элемент {list.RemoveByIndex(4)} под индексом {4} был удален: " + list);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Невозможно удалить элемент. Индекс находится вне длины списка");
            }

            try
            {
                list.Insert(2, 20);

                Console.WriteLine($"Узел со значением {20} был вставлен под индексом {2}: " + list);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Невозможно вставить элемент. Индекс находится вне длины списка");
            }

            try
            {
                if (list.RemoveData(20))
                {
                    Console.WriteLine($"Элемент удален {20}: " + list);
                }
                else
                {
                    Console.WriteLine("Элемент не был найден");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Список пуст");
            }

            list.Reverse();
            Console.WriteLine("Список после инвертирования: " + list);

            SinglyLinkedList<int> copiedList = list.Copy();

            Console.WriteLine("Скопированный список: " + copiedList);

            Console.ReadKey();
        }
    }
}