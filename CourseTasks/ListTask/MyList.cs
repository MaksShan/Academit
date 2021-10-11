using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListTask
{
    class MyList<T> : IList<T>
    {
        private T[] items;
        private int modCount;
        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                Array.Resize(ref items, value);
            }
        }

        public MyList()
        {
            items = new T[10];
        }

        public MyList(int capacity)
        {
            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count - 1)
                {
                    throw new ArgumentOutOfRangeException($"Индекс должен быть больше 0 и меньше {Count - 1}, {nameof(index)} = {index}");
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException($"Индекс должен быть больше 0 и меньше {Count - 1}, {nameof(index)} = {index}");
                }

                items[index] = value;
            }
        }

        public void Add(T element)
        {
            Insert(Count, element);
        }

        private void IncreaseCapacity()
        {
            Array.Resize(ref items, (items.Length + 1) * 2);
        }

        public void RemoveAt(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException($"Индекс ({index}) должен быть больше 0 и меньше {Count - 1}, {nameof(index)} = {index}");
            }

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            items[Count - 1] = default(T);

            --Count;
            ++modCount;
        }

        public void Insert(int index, T element)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException($"Индекс ({index}) должен быть больше 0 и меньше {Count - 1}, {nameof(index)} = {index}");
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = element;

            ++Count;
            ++modCount;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default(T);
            }

            Count = 0;

            modCount++;
        }

        public bool Contains(T element)
        {
            if (IndexOf(element) == -1)
            {
                return false;
            }

            return true;
        }

        public void CopyTo(T[] array, int index)
        {
            if (Count > array.Length - index)
            {
                throw new IndexOutOfRangeException($"Размер массива {nameof(array.Length)} = {array.Length} должен быть больше {Count + index}");
            }

            Array.Copy(items, 0, array, index, Count);
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == null && element == null)
                {
                    return i;
                }
                else if (items[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(T element)
        {
            int oldCount = Count;

            RemoveAt(IndexOf(element));

            if (oldCount == Count)
            {
                return false;
            }

            return true;
        }

        public void TrimExpress()
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
            int mods = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (mods != modCount)
                {
                    throw new InvalidOperationException("Коллекция была изменена во вресмя обхода");
                }

                yield return items[i];
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append(items[i]);

                if (i+1!=Count)
                {
                    stringBuilder.Append(", ");
                }
            }

            return stringBuilder.ToString();
        }
    }
}