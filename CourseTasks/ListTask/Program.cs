using System;

namespace ListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine($"Под индексом {3} находитится число: {list[3]}");

            list[3] = 0;
            Console.WriteLine($"Заменив число под индексом {3} на {0}, получим: {list[3]}");

            Console.WriteLine($"Приведенный список состоит из: {list.Count} чисел");

            list.Add(5);
            Console.WriteLine($"Добавив к списку число {5}, получим список: {string.Join(", ", list)}");

            list.RemoveAt(2);
            Console.WriteLine($"Убрав из списка число под индексом {2}, получаем список: {string.Join(", ", list)}");

            list.Remove(5);
            Console.WriteLine($"Удалив из списка первое вхождение числа {5}, получаем список: {string.Join(", ", list)}");

            list.Insert(0, 0);
            Console.WriteLine($"После вставки в список числа {0} по  индексу {0}, получим список: {string.Join(", ", list)}");

            if (list.Contains(8))
            {
                Console.WriteLine($"Список содержит число {8}");
            }
            else
            {
                Console.WriteLine($"Список не содержит число {8}");
            }

            int[] array = new int[10];

            list.CopyTo(array, 2);
            Console.WriteLine($"Массив с скопированными числами из листа, начиная с индекса {2}: {string.Join(", ", array)}");

            Console.WriteLine($"Индекс числа {2}: {list.IndexOf(2)}");

            Console.ReadKey();
        }
    }
}