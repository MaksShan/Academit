using System;
using VectorTask;
using System.Text;

namespace Matrix
{
    class Matrix
    {
        private Vector[] vectors;

        public Matrix(int height, int lenght)
        {
            vectors = new Vector[height];

            for (int i = 0; i < height; i++)
            {
                vectors[i] = new Vector(lenght);
            }
        }

        public Matrix(Matrix matrix)
        {
            vectors = new Vector[matrix.vectors.Length];

            Array.Copy(matrix.vectors, vectors, matrix.vectors.Length);
        }

        public Matrix(double[,] array)
        {
            double[] tempArray = new double[array.GetLength(1)];

            vectors = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    tempArray[j] = array[i, j];
                }

                vectors[i] = new Vector(tempArray);
            }
        }

        public Matrix(Vector[] array)
        {
            vectors = new Vector[array.Length];

            Array.Copy(array, vectors, array.Length);
        }

        public int[] GetSize()
        {
            int[] sizes = new int[2];

            sizes[0] = vectors.Length;
            sizes[1] = vectors[0].GetDimension();

            return sizes;
        }

        public Vector GetVector(int index)
        {
            return vectors[index];
        }

        public void SetVector(int index, Vector vector)
        {
            if (vector.Components.Length != vectors[index].Components.Length)
            {
                throw new ArgumentException($"Длины массивов должны совпадать. Длина входного массива: vector.Components.Length = {vector.Components.Length}, длина исходного массива: vectors[index].Components.Length = {vectors[index].Components.Length}");
            }

            if (index > vectors.Length - 1 || index < 0)
            {
                throw new ArgumentException($"Индекс (index) = {index}. Индекс не может быть больше {vectors.Length - 1} или меньше 0");
            }

            Array.Copy(vector.Components, vectors[index].Components, vector.Components.Length);
        }

        public Vector GetColumnVector(int index)
        {
            if (index > vectors[0].Components.Length - 1 || index < 0)
            {
                throw new ArgumentException($"Индекс (index) = {index}. Индекс не может быть больше {vectors[0].Components.Length - 1} или меньше 0");
            }

            Vector columnVector = new Vector(vectors.GetLength(0));

            for (int i = 0; i < vectors.GetLength(0); i++)
            {
                columnVector.Components[i] = vectors[i].Components[index];
            }

            return columnVector;
        }

        public Matrix GetTransposition()
        {
            Vector[] transposeVectors = new Vector[vectors[0].Components.Length];

            for (int i = 0; i < transposeVectors.Length; i++)
            {
                transposeVectors[i] = GetColumnVector(i);
            }

            return new Matrix(transposeVectors);
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                for (int j = 0; j < vectors[0].Components.Length; j++)
                {
                    vectors[i].Components[j] *= scalar;
                }
            }
        }

        public static double GetDeterminant(Matrix matrix)
        {
            double determinant = 0;

            int rowsNumber = matrix.vectors.Length;
            int columnsNumber = matrix.vectors[0].Components.Length;

            if (rowsNumber != columnsNumber)
            {
                throw new ArgumentException($"Невозможно вычислить опеределитель матрицы так как матрица не квадратная: {matrix.vectors.Length}x{matrix.vectors[0].Components.Length}, matrix.vectors.Length != matrix.vectors[0].Components.Length");
            }

            if (rowsNumber == 1 && columnsNumber == 1)
            {
                return matrix.vectors[0].Components[0];
            }

            for (int i = 0; i < rowsNumber; i++)
            {
                determinant += Math.Pow(-1, i) * matrix.vectors[0].Components[i] * GetDeterminant(GetMinor(matrix, i));
            }

            return determinant;
        }

        private static Matrix GetMinor(Matrix inputMatrix, int index)
        {
            Matrix minor = new Matrix(inputMatrix.vectors.Length - 1, inputMatrix.vectors[0].Components.Length - 1);

            for (int i = 0; i < minor.vectors.Length; i++)
            {
                minor.vectors[i] = new Vector(minor.vectors.Length);
            }

            for (int i = 1; i < inputMatrix.vectors.Length; i++)
            {
                for (int j = 0; j < index; j++)
                {
                    minor.vectors[i - 1].Components[j] = inputMatrix.vectors[i].Components[j];
                }
                for (int j = index + 1; j < inputMatrix.vectors.Length; j++)
                {
                    minor.vectors[i - 1].Components[j - 1] = inputMatrix.vectors[i].Components[j];
                }
            }

            return minor;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('{');

            for (int i = 0; i < vectors.Length; i++)
            {
                stringBuilder.Append('{');
                stringBuilder.Append(string.Join(", ", vectors[i].Components));
                stringBuilder.Append("}");

                if (i != vectors.Length - 1)
                {
                    stringBuilder.Append(',');
                }
            }

            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (vectors.Length != vector.Components.Length)
            {
                throw new ArgumentException($"Число строк в матрице (vectors.Length = {vectors.Length}) должно совпадать с числом столбцов в векторе (vector.Components.Length = {vector.Components.Length})");
            }

            Vector outputVector = new Vector(vector.Components.Length);

            for (int i = 0; i < vector.Components.Length; i++)
            {
                for (int j = 0; j < vectors.Length; j++)
                {
                    outputVector.Components[i] += vectors[j].Components[i] * vector.Components[j];
                }
            }

            return outputVector;
        }

        public void GetAddition(Matrix matrix)
        {
            if (vectors.Length != matrix.vectors.Length || vectors[0].Components.Length != matrix.vectors[0].Components.Length)
            {
                throw new ArgumentException($"Размеры матриц не равны! {vectors.Length}x{vectors[0].Components.Length}, {matrix.vectors.Length}x{matrix.vectors[0].Components.Length}");
            }

            for (int i = 0; i < vectors.Length; i++)
            {
                for (int j = 0; j < vectors[0].Components.Length; j++)
                {
                    vectors[i].Components[j] += matrix.vectors[i].Components[j];
                }
            }
        }

        public void Substract(Matrix matrix)
        {
            if (vectors.Length != matrix.vectors.Length || vectors[0].Components.Length != matrix.vectors[0].Components.Length)
            {
                throw new ArgumentException($"Размеры матриц не равны! {vectors.Length}x{vectors[0].Components.Length}, {matrix.vectors.Length}x{matrix.vectors[0].Components.Length}");
            }

            for (int i = 0; i < vectors.Length; i++)
            {
                for (int j = 0; j < vectors[0].Components.Length; j++)
                {
                    vectors[i].Components[j] -= matrix.vectors[i].Components[j];
                }
            }
        }

        public static Matrix GetStaticAddition(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.vectors.Length != matrix2.vectors.Length || matrix1.vectors[0].Components.Length != matrix2.vectors[0].Components.Length)
            {
                throw new ArgumentException($"Размеры матриц не равны! {matrix1.vectors.Length}x{matrix1.vectors[0].Components.Length}, {matrix2.vectors.Length}x{matrix2.vectors[0].Components.Length}");
            }

            Matrix outputMatrix = new Matrix(matrix1.vectors.Length, matrix1.vectors[0].Components.Length);

            for (int i = 0; i < matrix1.vectors.Length; i++)
            {
                for (int j = 0; j < matrix1.vectors[0].Components.Length; j++)
                {
                    outputMatrix.vectors[i].Components[j] = matrix1.vectors[i].Components[j] + matrix2.vectors[i].Components[j];
                }
            }

            return outputMatrix;
        }

        public static Matrix GetStaticSubstraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.vectors.Length != matrix2.vectors.Length || matrix1.vectors[0].Components.Length != matrix2.vectors[0].Components.Length)
            {
                throw new ArgumentException($"Размеры матриц не равны! {matrix1.vectors.Length}x{matrix1.vectors[0].Components.Length}, {matrix2.vectors.Length}x{matrix2.vectors[0].Components.Length}");
            }

            Matrix outputMatrix = new Matrix(matrix1.vectors.Length, matrix1.vectors[0].Components.Length);

            for (int i = 0; i < matrix1.vectors.Length; i++)
            {
                for (int j = 0; j < matrix1.vectors[0].Components.Length; j++)
                {
                    outputMatrix.vectors[i].Components[j] = matrix1.vectors[i].Components[j] - matrix2.vectors[i].Components[j];
                }
            }

            return outputMatrix;
        }

        public static Matrix GetStaticMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.vectors[0].Components.Length != matrix2.vectors.Length)
            {
                throw new ArgumentException($"Количество столбцов первой матрицы (matrix1.vectors[0].Components.Length = {matrix1.vectors[0].Components.Length}) должно совпадать количеству строк (matrix2.vectors.Length = {matrix2.vectors.Length}) второй матрицы!");
            }

            Matrix outputMatrix = new Matrix(matrix1.vectors.Length, matrix2.vectors[0].Components.Length);

            for (int i = 0; i < matrix1.vectors.Length; i++)
            {
                for (int j = 0; j < matrix2.vectors[i].Components.Length; j++)
                {
                    for (int k = 0; k < matrix1.vectors[i].Components.Length; k++)
                    {
                        outputMatrix.vectors[i].Components[j] += matrix1.vectors[i].Components[k] * matrix2.vectors[k].Components[j];
                    }

                }
            }

            return outputMatrix;
        }
    }
}