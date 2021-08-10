using System;
using System.Text;

namespace Vector
{
    class Vector
    {
        private double[] array;

        public Vector(int dimension)
        {
            array = new double[dimension];

            EmptyArrayCheck(array);
        }

        public Vector(Vector vector)
        {
            array = new double[vector.array.Length];

            EmptyArrayCheck(array);

            Array.Copy(vector.array, array, array.Length);
        }

        public Vector(double[] array)
        {
            this.array = new double[array.Length];

            EmptyArrayCheck(this.array);

            Array.Copy(array, this.array, this.array.Length);
        }

        public Vector(int dimension, double[] array)
        {
            this.array = new double[dimension];

            EmptyArrayCheck(this.array);

            Array.Copy(array, 0, this.array, 0, array.Length);
        }

        public int GetSize()
        {
            return array.Length;
        }

        public void Multiply(Vector vector)
        {
            Check(this, vector);

            for (int i = 0; i < vector.array.Length; i++)
            {
                array[i] += vector.array[i];
            }
        }

        public void Subtract(Vector vector)
        {
            Check(this, vector);

            for (int i = 0; i < vector.array.Length; i++)
            {
                array[i] -= vector.array[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= scalar;
            }
        }

        public void TurnBack()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double squaresSum = 0;

            foreach (int a in array)
            {
                squaresSum += a * a;
            }

            return Math.Sqrt(squaresSum);
        }

        public double Get(int index)
        {
            return array[index];
        }

        public void Set(int index, double number)
        {
            array[index] = number;
        }

        public static Vector Multiply(Vector vector1, Vector vector2)
        {
            Check(vector1, vector2);

            Vector newVector = new Vector(vector1);

            newVector.Multiply(vector2);

            return newVector;
        }

        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            Check(vector1, vector2);

            Vector newVector = new Vector(vector1);

            newVector.Subtract(vector2);

            return newVector;
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            Check(vector1, vector2);

            double scalarProduct = 0;

            for (int i = 0; i < vector1.array.Length; i++)
            {
                scalarProduct += vector1.array[i] * vector2.array[i];
            }

            return scalarProduct;
        }

        public static void Check(Vector vector1, Vector vector2)
        {
            if (vector1.array.Length != vector2.array.Length)
            {
                if (vector1.array.Length > vector2.array.Length)
                {
                    Array.Resize(ref vector2.array, vector1.array.Length);
                }
                else
                {
                    Array.Resize(ref vector1.array, vector2.array.Length);
                }
            }
        }

        private static void EmptyArrayCheck(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Размерность одного из векторов = 0");
            }
        }

        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder("{}");

            outputString.Insert(outputString.Length / 2, string.Join(", ", array));

            return outputString.ToString();
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

            if (array.Length != vector.array.Length)
            {
                return false;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != vector.array[i])
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

            foreach (double a in array)
            {
                hash = prime * hash + a.GetHashCode();
            }

            return hash;
        }
    }
}
