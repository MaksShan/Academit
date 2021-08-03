using System;

namespace Vector
{
    class Vector
    {
        private double[] vector;

        public Vector(int n)
        {
            vector = new double[n];

            for (int i = 0; i < n; i++)
            {
                vector[i] = 0;
            }
        }

        public Vector(Vector inputVector)
        {
            vector = new double[inputVector.vector.Length];
            vector = inputVector.vector;
        }

        public Vector(double[] inputArray)
        {
            vector = new double[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                vector[i] = inputArray[i];
            }
        }

        public Vector(int n, double[] inputArray)
        {
            vector = new double[n];

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (i < n)
                {
                    vector[i] = inputArray[i];
                }
                else
                {
                    vector[i] = 0;
                }
            }
        }

        public int GetSize()
        {
            return vector.Length;
        }

        public Vector Multiplication(Vector inputVector)
        {
            for (int i = 0; i < inputVector.vector.Length; i++)
            {
                vector[i] += inputVector.vector[i];
            }

            return new Vector(vector);
        }

        public Vector Subtraction(Vector inputVector)
        {
            for (int i = 0; i < inputVector.vector.Length; i++)
            {
                vector[i] -= inputVector.vector[i];
            }

            return new Vector(vector);
        }

        public Vector ScalarMultiplication(int scalar)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] *= scalar;
            }

            return new Vector(vector);
        }

        public Vector Reversal()
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] *= -1;
            }

            return new Vector(vector);
        }

        public double GetLength()
        {
            double squareSum = 0;

            for (int i = 0; i < vector.Length; i++)
            {
                squareSum += vector[i] * vector[i];
            }

            return Math.Sqrt(squareSum);
        }

        public Vector GetSet(int index)
        {
            Console.WriteLine($"Компонент по индексу {index} = {vector[index]}");

            Console.Write("Введите другой компонент для замены: ");
            vector[index] = double.Parse(Console.ReadLine());

            return new Vector(vector);
        }

        public static Vector StaticMultiplication(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(vector1.vector.Length);

            for (int i = 0; i < vector1.vector.Length; i++)
            {
                newVector.vector[i] = vector1.vector[i] + vector2.vector[i];
            }

            return newVector;
        }

        public static Vector StaticSubtraction(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(vector1.vector.Length);

            for (int i = 0; i < vector1.vector.Length; i++)
            {
                newVector.vector[i] = vector1.vector[i] - vector2.vector[i];
            }

            return newVector;
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            double scalarProduct = 0;

            for (int i = 0; i < vector1.vector.Length; i++)
            {
                scalarProduct += vector1.vector[i] * vector2.vector[i];
            }

            return scalarProduct;
        }

        public void Modification(int length)
        {
            Vector newVector = new Vector(length);

            for (int i = 0; i < vector.Length; i++)
            {
                newVector.vector[i] = vector[i];
            }

            for (int i = vector.Length; i < length; i++)
            {
                newVector.vector[i] = 0;
            }

            vector = newVector.vector;
        }

        public static void Check(Vector vector1, Vector vector2)
        {
            if (vector1.vector.Length == 0 || vector2.vector.Length == 0)
            {
                throw new ArgumentException("Размерность одного из векторов = 0");
            }

            if (vector1.vector.Length != vector2.vector.Length)
            {
                if (vector1.vector.Length > vector2.vector.Length)
                {
                    vector2.Modification(vector1.vector.Length);
                }
                else
                {
                    vector1.Modification(vector2.vector.Length);
                }
            }
        }

        public override string ToString()
        {
            return '{' + string.Join(", ", vector) + '}';
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

            Vector inputVector = (Vector)obj;

            if (vector.Length != inputVector.vector.Length)
            {
                return false;
            }

            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] != inputVector.vector[i])
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

            for (int i = 0; i < vector.Length; i++)
            {
                hash += prime * hash + vector[i].GetHashCode();
            }

            return hash;
        }
    }
}
