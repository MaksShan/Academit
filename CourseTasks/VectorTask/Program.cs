using System;

namespace VectorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] vector1Array = { 3, 0.2, -1, 9 };
            Vector vector1 = new Vector(vector1Array);

            double[] vector2Array = { 1, -2, 4, 6, 9 };
            Vector vector2 = new Vector(vector2Array);

            Console.WriteLine($"Размерность вектора {vector1}: {vector1.GetDimension()}");
            Console.WriteLine($"Размерность вектора {vector2}: {vector2.GetDimension()}");

            vector1.Add(vector2);
            Console.WriteLine("Результат сложения векторов: " + vector1);

            vector1.Subtract(vector2);
            Console.WriteLine("Результат вычитания из результата второй вектор: " + vector1);

            vector1.MultiplyByScalar(5);
            Console.WriteLine($"Результат умножения полученного вектора на скаляр {5}: {vector1}");

            vector1.TurnAround();
            Console.WriteLine("Разворот вектора: " + vector1);

            Console.WriteLine("Длинна вектора: " + vector1.GetLength());

            Console.Write("Введите индекс массива для замены числа: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine($"Число под индексом {index}: {vector1[index]}");

            Console.Write("Ведите число для замены: ");
            double number = double.Parse(Console.ReadLine());

            vector1[index] = number;
            Console.WriteLine($"Вектор после замен компонента по индексу {index}: {vector1}");

            if (vector1.Equals(vector2))
            {
                Console.WriteLine("Векторы равны");
            }
            else
            {
                Console.WriteLine("Векторы не равны");
            }

            Vector vector1Test = new Vector(vector1Array);
            Vector vector2Test = new Vector(vector2Array);

            Console.Write($"Сложение векторов {vector1Test} и {vector2Test} с помощью статического метода: ");
            Console.WriteLine(Vector.GetSum(vector1Test, vector2Test));

            Console.Write($"Вычитание векторов {vector1Test} и {vector2Test} с помощью статического метода: ");
            Console.WriteLine(Vector.GetDifference(vector1Test, vector2Test));

            Console.Write($"Скалярное произведение векторов {vector1Test} и {vector2Test} = ");
            Console.WriteLine(Vector.GetScalarProduct(vector1Test, vector2Test));

            Console.ReadKey();
        }
    }
}
