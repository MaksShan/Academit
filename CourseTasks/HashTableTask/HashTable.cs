using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private readonly List<T>[] lists;

        private readonly int defaultListSize = 50;

        private int modCount;

        public int Count { get; private set; }


        public bool IsReadOnly => false;

        public HashTable()
        {
            lists = new List<T>[defaultListSize];
        }

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Размер массива не может быть меньше 0: {nameof(size)} = {size}");
            }

            lists = new List<T>[size];
        }

        public int GetListIndex(object item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % lists.Length);
        }

        public void Add(T item)
        {
            int index = GetListIndex(item);

            if (lists[index] == null)
            {
                lists[index] = new List<T>();
            }

            lists[index].Add(item);

            ++Count;
            ++modCount;
        }

        public bool Remove(T item)
        {
            int index = GetListIndex(item);

            if (lists[index].Remove(item))
            {
                ++modCount;
                --Count;

                return true;
            }

            return false;
        }

        public void CopyTo(T[] arrayCopyTo, int index)
        {
            if (arrayCopyTo == null)
            {
                throw new ArgumentNullException("Массив имеет значение null");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не может быть меньше 0: {index}");
            }

            if (Count > arrayCopyTo.Length - index)
            {
                throw new ArgumentException($"Число элементов в исходной коллекции больше доступного места от положения, заданного значением параметра {nameof(index)}:{index} до конца массива назначения {nameof(arrayCopyTo)}");
            }

            int arrayLastIndex = 0;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                {
                    continue;
                }

                for (int j = 0; j < lists[i].Count; j++)
                {
                    arrayCopyTo.SetValue(lists[i][j], arrayLastIndex);

                    arrayLastIndex++;
                }
            }
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = null;
            }

            Count = 0;
            ++modCount;
        }

        public bool Contains(T item)
        {
            int index = GetListIndex(item);

            if (lists[index].Contains(item))
            {
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int InitialModCount = modCount;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                {
                    continue;
                }

                for (int j = 0; j < lists[i].Count; j++)
                {
                    if (InitialModCount != modCount)
                    {
                        throw new InvalidOperationException("Коллекция была изменена во время обхода");
                    }

                    yield return lists[i][j];
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                {
                    continue;
                }

                stringBuilder.Append('[');

                for (int j = 0; j < lists[i].Count - 1; j++)
                {
                    if (lists[i][j] == null)
                    {
                        stringBuilder.Append("NULL, ");
                    }
                    else
                    {
                        stringBuilder.Append($"{lists[i][j]}, ");
                    }
                }

                if (lists[i][lists[i].Count - 1] == null)
                {
                    stringBuilder.Append("NULL");
                }
                else
                {
                    stringBuilder.Append($"{lists[i][lists[i].Count - 1]}");
                }

                stringBuilder.Append(']');

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}