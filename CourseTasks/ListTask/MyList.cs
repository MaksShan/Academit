using System;
using System.Collections;
using System.Collections.Generic;

namespace ListTask
{
    public class MyList<T> : IList<T>, IEnumerable<T>
    {
        private T[] items = new T[10];
        private int length;

        public int Count
        {
            get { return length; }
        }

        public T this[int index]
        {
            get
            {
                if (index > length - 1 || index < 0)
                {
                    throw new ArgumentOutOfRangeException($"Индекс должен быть больше 0 и меньше {length - 1}, {nameof(index)}");
                }

                return items[index];
            }
            set
            {
                if (index > length - 1 || index < 0)
                {
                    throw new ArgumentOutOfRangeException($"Индекс должен быть больше 0 и меньше {length - 1}, {nameof(index)}");
                }

                items[index] = value;
            }
        }

        public void Add(T obj)
        {
            if (length >= items.Length)
            {
                IncreaseCapacity();
            }

            items[length] = obj;

            ++length;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;

            items = new T[old.Length * 2];

            Array.Copy(old, 0, items, 0, old.Length);
        }

        public void RemoveAt(int index)
        {
            if (index > length || index < 0)
            {
                throw new IndexOutOfRangeException($"Индекс ({index}) должен быть больше 0 и меньше {length - 1}, {nameof(index)}");
            }
            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            --length;
        }

        public void Insert(int index, T obj)
        {
            if (index > length || index < 0)
            {
                throw new IndexOutOfRangeException($"Индекс ({index}) должен быть больше 0 и меньше {length - 1}, {nameof(index)}");
            }

            if (index < length - 1)
            {
                if (length >= items.Length)
                {
                    IncreaseCapacity();
                }

                Array.Copy(items, index, items, index + 1, length - index);

                items[index] = obj;
            }

            ++length;
        }

        public void Clear()
        {
            length = 0;
        }

        public bool Contains(T obj)
        {
            for (int i = 0; i < length; i++)
            {
                if (items[i].Equals(obj))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            for (int i = 0; i < length; i++)
            {
                array.SetValue(items[i], index++);
            }
        }

        public int IndexOf(T obj)
        {
            for (int i = 0; i < length; i++)
            {
                if (items[i].Equals(obj))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(T obj)
        {
            try
            {
                RemoveAt(IndexOf(obj));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < length; i++)
            {
                yield return items[i];
            }
        }
    }
}