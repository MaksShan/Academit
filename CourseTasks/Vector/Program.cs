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

            Vector.Check(vector1, vector2);

            Console.WriteLine($"Размерность вектора {vector1}: {vector1.GetSize()}");
            Console.WriteLine($"Размерность вектора {vector2}: {vector2.GetSize()}");

            Console.WriteLine("Результат сложения векторов: " + vector1.Multiplication(vector2));

            Console.WriteLine("Результат вычитания из результата второй вектор: " + vector1.Subtraction(vector2));

            Console.WriteLine($"Результат умножения полученного вектора на скаляр {5}: {vector1.ScalarMultiplication(5)}");

            Console.WriteLine($"Разворот вектора: " + vector1.Reversal());

            Console.WriteLine("Длинна вектора: " + vector1.GetLength());

            vector1.GetSet(3);
            Console.WriteLine($"Вектор после замен компонента по индексу {3}: {vector1}");

            if (vector1.Equals(vector2))
            {
                Console.WriteLine("Векторы равны");
            }
            else
            {
                Console.WriteLine("Векторы не равны");
            }

            Console.WriteLine($"Сложение векторов {vector1} и {vector2} с помошью статического метода = {Vector.StaticMultiplication(vector1, vector2)}");

            Console.WriteLine($"Вычитание векторов {vector1} и {vector2} с помошью статического метода = {Vector.StaticSubtraction(vector1, vector2)}");

            Console.WriteLine($"Скалярное произведение векторов {vector1} и {vector2} = {Vector.ScalarProduct(vector1, vector2)}");

            Console.ReadKey();
        }
    }
}
