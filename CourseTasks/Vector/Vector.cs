using System;
using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] vector;

        public Vector(int dimension)
        {
            if (dimension < 1)
            {
                throw new ArgumentException($"Размерность вектора меньше 1: {dimension}");
            }

            vector = new double[dimension];
        }

        public Vector(Vector vector)
        {
            if (vector.vector.Length < 1)
            {
                throw new ArgumentException($"Размерность вектора меньше 1: {vector.vector.Length}");
            }

            this.vector = new double[vector.vector.Length];

            Array.Copy(vector.vector, this.vector, this.vector.Length);
        }

        public Vector(double[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException($"Невозможно создать вектор, так как размер входного массива меньше 1: {array.Length}");
            }

            vector = new double[array.Length];

            Array.Copy(array, vector, vector.Length);
        }

        public Vector(int dimension, double[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException($"Невозможно создать вектор, так как размер массива < 0: {array.Length}");
            }

            if (dimension < 1)
            {
                throw new ArgumentException($"Невозможно создать вектор, так как размер вектора должен быть > 0: {dimension}");
            }

            vector = new double[dimension];

            Array.Copy(array, 0, vector, 0, array.Length);
        }

        public int GetSize()
        {
            return vector.Length;
        }

        public void GetAddition(Vector vector)
        {
            Check1Vector(this.vector, vector.vector.Length);

            for (int i = 0; i < vector.vector.Length; i++)
            {
                this.vector[i] += vector.vector[i];
            }
        }

        public void Subtract(Vector vector)
        {
            Check1Vector(this.vector, vector.vector.Length);

            for (int i = 0; i < vector.vector.Length; i++)
            {
                this.vector[i] -= vector.vector[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] *= scalar;
            }
        }

        public void TurnBack()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double squaresSum = 0;

            foreach (double e in vector)
            {
                squaresSum += e * e;
            }

            return Math.Sqrt(squaresSum);
        }

        public double Get(int index)
        {
            return vector[index];
        }

        public void Set(int index, double number)
        {
            vector[index] = number;
        }

        public static Vector GetAddition(Vector vector1, Vector vector2)
        {
            Vector newVector;

            if (vector1.vector.Length > vector2.vector.Length)
            {
                newVector = new Vector(vector1);

                newVector.GetAddition(vector2);

                return newVector;
            }

            newVector = new Vector(vector2);

            newVector.GetAddition(vector1);

            return newVector;
        }

        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            Vector newVector;

            if (vector1.vector.Length > vector2.vector.Length)
            {
                newVector = new Vector(vector1);

                newVector.Subtract(vector2);

                return newVector;
            }

            newVector = new Vector(vector2);

            newVector.Subtract(vector1);

            return newVector;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            Vector newVector;

            double scalarProduct = 0;

            if (vector1.vector.Length > vector2.vector.Length)
            {
                newVector = new Vector(vector1.vector.Length, vector2.vector);

                for (int i = 0; i < newVector.vector.Length; i++)
                {
                    scalarProduct += vector1.vector[i] * newVector.vector[i];
                }
            }
            else
            {
                newVector = new Vector(vector2.vector.Length, vector1.vector);

                for (int i = 0; i < newVector.vector.Length; i++)
                {
                    scalarProduct += newVector.vector[i] * vector2.vector[i];
                }
            }

            return scalarProduct;
        }

        public static void Check1Vector(double[] vector, int dimension)
        {
            if (vector.Length < dimension)
            {
                Array.Resize(ref vector, dimension);
            }
        }

        public static void Check2Vectors(Vector vector1, Vector vector2)
        {
            if (vector1.vector.Length != vector2.vector.Length)
            {
                if (vector1.vector.Length > vector2.vector.Length)
                {
                    Array.Resize(ref vector2.vector, vector1.vector.Length);
                }
                else
                {
                    Array.Resize(ref vector1.vector, vector2.vector.Length);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('{');
            stringBuilder.Append(string.Join(", ", vector));
            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (this.vector.Length != vector.vector.Length)
            {
                return false;
            }

            for (int i = 0; i < this.vector.Length; i++)
            {
                if (this.vector[i] != vector.vector[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            foreach (double e in vector)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }
    }
}
