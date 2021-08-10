using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] vector1Array = { 1, -2, 4, 6, 9 };
            Vector vector1 = new Vector(vector1Array);

            double[] vector2Array = { 3, 0.2, -1, 9 };
            Vector vector2 = new Vector(vector2Array);

            Console.WriteLine($"Размерность вектора {vector1}: {vector1.GetSize()}");
            Console.WriteLine($"Размерность вектора {vector2}: {vector2.GetSize()}");

            vector1.Multiply(vector2);
            Console.WriteLine("Результат сложения векторов: " + vector1);

            vector1.Subtract(vector2);
            Console.WriteLine("Результат вычитания из результата второй вектор: " + vector1);

            vector1.MultiplyByScalar(5);
            Console.WriteLine($"Результат умножения полученного вектора на скаляр {5}: {vector1}");

            vector1.TurnBack();
            Console.WriteLine($"Разворот вектора: " + vector1);

            Console.WriteLine("Длинна вектора: " + vector1.GetLength());

            Console.Write("Введите индекс массива для замены числа: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine($"Число под индексом {index}: {vector1.Get(index)}");

            Console.Write("Ведите число для замены: ");
            double number = double.Parse(Console.ReadLine());

            vector1.Set(index, number);
            Console.WriteLine($"Вектор после замен компонента по индексу {index}: {vector1}");

            if (vector1.Equals(vector2))
            {
                Console.WriteLine("Векторы равны");
            }
            else
            {
                Console.WriteLine("Векторы не равны");
            }

            Console.WriteLine($"Сложение векторов {vector1} и {vector2} с помошью статического метода: {Vector.Multiply(vector1, vector2)}");

            Console.WriteLine($"Вычитание векторов {vector1} и {vector2} с помошью статического метода: {Vector.Subtract(vector1, vector2)}");

            Console.WriteLine($"Скалярное произведение векторов {vector1} и {vector2} = {Vector.ScalarProduct(vector1, vector2)}");

            Console.ReadKey();
        }
    }
}
