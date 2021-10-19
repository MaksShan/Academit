using System;

namespace ArrayListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine($"Исходный список: {list}");

            Console.WriteLine($"Под индексом {3} находится число: {list[3]}");

            list[3] = 0;
            Console.WriteLine($"Заменив число под индексом {3} на {0}, получим: {list}");

            Console.WriteLine($"Приведенный список состоит из: {list.Count} элементов");

            list.Add(5);
            Console.WriteLine($"Добавив к списку число {5}, получим список: {list}");

            list.RemoveAt(2);
            Console.WriteLine($"Убрав из списка число под индексом {2}, получаем список: {list}");

            list.Remove(5);
            Console.WriteLine($"Удалив из списка первое вхождение числа {5}, получаем список: {list}");

            list.Insert(0, 0);
            Console.WriteLine($"После вставки в список числа {0} по  индексу {0}, получим список: {list}");

            int numberToCheck = 8;

            if (list.Contains(numberToCheck))
            {
                Console.WriteLine($"Список содержит число {numberToCheck}");
            }
            else
            {
                Console.WriteLine($"Список не содержит число {numberToCheck}");
            }

            Console.WriteLine($"Индекс числа {2}: {list.IndexOf(2)}");

            Console.WriteLine($"Ёмкость листа и число элементов до обрезания емкости: {nameof(list.Capacity)} = {list.Capacity} {nameof(list.Count)} = {list.Count}");
            list.TrimExcess();
            Console.WriteLine($"Ёмкость листа и число элементов после обрезания емкости: {nameof(list.Capacity)} = {list.Capacity} {nameof(list.Count)} = {list.Count}");

            int[] array = new int[10];

            list.CopyTo(array, 2);
            Console.WriteLine($"Массив с скопированными числами из листа, начиная с индекса {2}: [{string.Join(", ", array)}]");

            Console.ReadKey();
        }
    }
}