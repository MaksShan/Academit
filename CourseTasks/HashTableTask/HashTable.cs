using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>, IEnumerable<T>
    {
        private readonly List<T>[] data;
        private int modCount;

        public HashTable()
        {
            data = new List<T>[50];
        }

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Размер массива не может быть меньше 0: {nameof(size)} = {size}");
            }

            data = new List<T>[size];
        }

        private int GetListIndex(object item)
        {
            return Math.Abs(item.GetHashCode() % data.Length);
        }

        public void Add(T item)
        {
            int index = GetListIndex(item);

            if (data[index] == null)
            {
                data[index] = new List<T>();
            }

            data[index].Add(item);

            ++modCount;
        }

        public bool Remove(T item)
        {
            int index = GetListIndex(item);

            if (data[index].Remove(item))
            {
                ++modCount;

                return true;
            }

            return false;
        }

        public void CopyTo(T[] arrayCopyTo, int index)
        {
            if (index > data.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Индекс не может быть меньше нуля, или больше {data.Length}: {nameof(index)} = {index}");
            }

            data[index].CopyTo(arrayCopyTo);
        }

        public void Clear()
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = null;
            }

            ++modCount;
        }

        public bool Contains(T item)
        {
            int index = GetListIndex(item);

            if (data[index].Contains(item))
            {
                return true;
            }

            return false;
        }

        public int Count
        {
            get { return data.Length; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int mods = modCount;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    if (mods != modCount)
                    {
                        throw new InvalidOperationException("Коллекция была изменена во вресмя обхода");
                    }

                    yield return data[i][j];
                }
            }
        }
    }
}