using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    class MyList<T> : IList<T>
    {
        private T[] items;

        private int modCount;

        public int Count { get; private set; }

        private readonly int defaultCapacity = 10;

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            private set
            {
                Array.Resize(ref items, value);
            }
        }

        public MyList()
        {
            items = new T[defaultCapacity];
        }

        public MyList(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException($"Невозможно создать список ёмкостью меньше 1: {capacity}", nameof(capacity));
            }

            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return items[index];
            }
            set
            {
                CheckIndex(index);

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        private void IncreaseCapacity()
        {
            if (items.Length == 0)
            {
                Array.Resize(ref items, defaultCapacity);
            }

            Array.Resize(ref items, (items.Length) * 2);
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            items[Count - 1] = default;

            --Count;
            ++modCount;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException($"Индекс должен быть не отрецательным и не превышать {Count}: {index}", nameof(index));
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;

            ++Count;
            ++modCount;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default;
            }

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) == -1;
        }

        public void CopyTo(T[] array, int index)
        {
            if (Count > array.Length - index)
            {
                throw new ArgumentException($"Размер массива должен быть больше {Count + index} : {array.Length}", nameof(array.Length));
            }

            Array.Copy(items, 0, array, index, Count);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Индекс должен быть не отрецательным и меньше {Count}: {index}", nameof(index));
            }
        }

        public void TrimExcess()
        {
            Capacity = Count;
        }

        public bool IsReadOnly => false;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCounter = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (initialModCounter != modCount)
                {
                    throw new InvalidOperationException("Коллекция была изменена во время обхода");
                }

                yield return items[i];
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('[');

            for (int i = 0; i < Count - 1; i++)
            {
                stringBuilder.Append(items[i]);

                stringBuilder.Append(", ");
            }

            stringBuilder.Append(items[Count - 1]);

            stringBuilder.Append(']');

            return stringBuilder.ToString();
        }
    }
}