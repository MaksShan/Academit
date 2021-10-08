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

            Console.WriteLine($"Размер листа: {list.GetLength()} элементов");

            try
            {
                Console.WriteLine($"Значение, хранимое в первом элементе: {list.GetFirstElement()}");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Список пуст");
            }

            try
            {
                Console.WriteLine($"Значение, хранимое в элементе под индексом {3}: { list.GetElement(3)}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Невозможно получить элемент. Индекс находится вне длины списка");
            }

            try
            {
                Console.WriteLine($"Элемент {list.ChangeElement(3, 0)} был изменен на {0} под индексом {3}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Невозможно изменить элемент. Индекс находится вне длины списка");
            }

            try
            {
                Console.WriteLine($"Элемент {list.Remove(4)} под индексом {4} был удален");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Невозможно удалить элемент. Индекс находится вне длины списка");
            }

            Node<int> nodeToInsert = new Node<int>(20);

            try
            {
                list.Insert(nodeToInsert, 2);

                Console.WriteLine($"Узел со значением {20} был вставлен под индексом {2}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Невозможно вставить элемент. Индекс находится вне длины списка");
            }

            try
            {
                if (list.RemoveItem(20))
                {
                    Console.WriteLine($"Элемент удален {20}");
                }
                else
                {
                    Console.WriteLine("Элеменнт не был найден");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Список пуст");
            }

            list.Reverse();

            SinglyLinkedList<int> copyList = list.Copy();

            Console.ReadKey();
        }
    }
}