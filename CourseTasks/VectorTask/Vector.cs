using System;
using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] components;

        public double[] Components
        {
            get
            {
                return components;
            }
            set
            {
                components = value;
            }
        }

        public Vector(int dimension)
        {
            if (dimension < 1)
            {
                throw new ArgumentException($"Размерность вектора меньше 1: dimension = {dimension}");
            }

            components = new double[dimension];
        }

        public Vector(Vector vector)
        {
            components = new double[vector.components.Length];

            Array.Copy(vector.components, components, components.Length);
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Невозможно создать вектор, так как размер входного массива меньше 1: array.Length = {array.Length}");
            }

            components = new double[array.Length];

            Array.Copy(array, components, components.Length);
        }

        public Vector(int dimension, double[] array)
        {
            if (dimension < 1)
            {
                throw new ArgumentException($"Невозможно создать вектор, так как размер вектора должен быть > 0: dimension = {dimension}");
            }

            components = new double[dimension];

            Array.Copy(array, 0, components, 0, array.Length);
        }

        public int GetDimension()
        {
            return components.Length;
        }

        public void Add(Vector vector)
        {
            ChangeVectorDimension(components.Length, vector.components.Length);

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            ChangeVectorDimension(components.Length, vector.components.Length);

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= scalar;
            }
        }

        public void Unfold()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double squaresSum = 0;

            foreach (double e in components)
            {
                squaresSum += e * e;
            }

            return Math.Sqrt(squaresSum);
        }

        public double Get(int index)
        {
            return components[index];
        }

        public void Set(int index, double number)
        {
            components[index] = number;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(vector1); ;

            newVector.Add(vector2);

            return newVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(vector1);

            newVector.Subtract(vector2);

            return newVector;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            double scalarProduct = 0;

            if (vector1.components.Length < vector2.components.Length)
            {
                for (int i = 0; i < vector1.components.Length; i++)
                {
                    scalarProduct += vector1.components[i] * vector2.components[i];
                }
            }
            else
            {
                for (int i = 0; i < vector2.components.Length; i++)
                {
                    scalarProduct += vector1.components[i] * vector2.components[i];
                }
            }

            return scalarProduct;
        }

        public void ChangeVectorDimension(int vectorDimension, int targetDimension)
        {
            if (vectorDimension < targetDimension)
            {
                Array.Resize(ref components, targetDimension);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('{');
            stringBuilder.Append(string.Join(", ", components));
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

            if (components.Length != vector.components.Length)
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != vector.components[i])
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

            foreach (double e in components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }
    }
}
