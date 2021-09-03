using System;
using VectorTask;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] array1 = {{1, 2, 5},
                                {5, 2, 6},
                                {1, 6, 2}};

            Matrix matrix1 = new Matrix(array1);

            Console.WriteLine($"Размеры матрицы {matrix1}: {string.Join('x', matrix1.GetSize())}");

            Console.WriteLine($"Вектор-строка под индексом {0}: {matrix1.GetVector(0)}");

            double[] oneDimensionArray = { 1, 3, 5 };
            Vector testVector1 = new Vector(oneDimensionArray);

            matrix1.SetVector(0, testVector1);
            Console.WriteLine($"Массив после замены вектора-строки под индексом {0} на вектор строку {testVector1}: {matrix1}");

            Console.WriteLine($"Вектор-столбец под индексом {1}: {matrix1.GetColumnVector(1)}");

            Console.WriteLine($"Матрица после транспонирования: {matrix1.GetTransposition()}");

            matrix1.MultiplyByScalar(5);
            Console.WriteLine($"При умножении матрицы на скаляр ({5}), получим матрицу: {matrix1}");

            Console.WriteLine($"Определитель матрицы равен {Matrix.GetDeterminant(matrix1)}");

            double[] arrayTable = { 1, 3, 5 };

            Vector testVector2 = new Vector(arrayTable);

            Console.WriteLine($"При умножении матрицы на вектор {testVector2}, получим матрицу: {matrix1.MultiplyByVector(testVector2)}");

            double[,] array2 = {{1, 5, 3},
                                {1, 2, 2},
                                {4, 5, 2}};


            Matrix matrix2 = new Matrix(array2);

            Console.Write($"Прибавив к матрице {matrix1} матрицу {matrix2}, ");
            matrix1.GetAddition(matrix2);
            Console.WriteLine($"получим матрицу {matrix1}");

            Console.Write($"Вычтя из матрицы {matrix2} матрицу {matrix1}, ");
            matrix2.Substract(matrix1);
            Console.WriteLine($"получим матрицу {matrix2}");

            Console.WriteLine($"Сложение матрицы {matrix1} и матрицы {matrix2} при помощи статического метода: {Matrix.GetStaticAddition(matrix1, matrix2)}");

            Console.WriteLine($"Вычитание из матрицы {matrix1} матрицы {matrix2} при помощи статического метода: {Matrix.GetStaticSubstraction(matrix1, matrix2)}");

            Console.WriteLine($"Умножение матрицы {matrix1} на матрицу {matrix2} при помощи статического метода: {Matrix.GetStaticMultiplication(matrix1, matrix2)}");

            Console.ReadKey();
        }
    }
}
