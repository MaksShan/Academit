using System;
using System.Text;

namespace List
{
    class SinglyLinkedList<T>
    {
        private Node<T> head;

        public int Count { get; private set; } //автосвойство размера списка

        public T GetFirst() //получение значения первого элемента
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }

            return head.Data;
        }

        private void CheckIndex(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс ({index}) находится вне длины списка {Count}");
            }
        }

        private Node<T> GetNode(int index) // поиск необходимого узла
        {
            CheckIndex(index);

            Node<T> current = head;

            for (int i = 0; current != null; i++)
            {
                if (i == index)
                {
                    break;
                }

                current = current.Next;
            }

            return current;
        }

        private Node<T> GetNode(int index, Node<T> startNode) // Для Insert, RemoveByIndex
        {
            CheckIndex(index);

            Node<T> current = startNode;

            for (int i = 1; current.Next != null; i++)
            {
                if (i == index)
                {
                    break;
                }

                current = current.Next;
            }

            return current;
        }

        public T GetData(int index) // получение элемента по индексу
        {
            Node<T> node = GetNode(index);

            return node.Data;
        }

        public T SetData(int index, T data) // изменение элемента по индексу
        {
            T oldData;

            Node<T> node = GetNode(index);

            oldData = node.Data;

            node.Data = data;

            return oldData;
        }

        public void AddFirst(T data) // вставка элемента в начало
        {
            head = new Node<T>(data, head);

            Count++;
        }

        public T RemoveByIndex(int index) // удаление элемента по индексу
        {
            CheckIndex(index);

            T deletedData;

            if (index == 0) // если индекс 0 то сдвигаем head
            {
                deletedData = RemoveFirst();

                return deletedData;
            }

            Node<T> current = head;

            current = GetNode(index, current); // 1 так как при 0 уже проверили

            deletedData = current.Next.Data;

            current.Next = current.Next.Next;

            Count--;

            return deletedData;
        }

        public void Insert(int index, T data) // вставка элемента по индексу
        {
            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            Node<T> current = GetNode(index, head);

            Node<T> insertedNode = new Node<T>(data);

            insertedNode.Next = current.Next;

            current.Next = insertedNode;

            Count++;

            return;
        }

        public bool RemoveData(T data) // удаление узла по значению
        {
            if (head != null && head.Data.Equals(data))
            {
                RemoveFirst();

                return true;
            }

            Node<T> current = head;

            while (current != null)
            {
                if (current.Next.Data != null && current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;

                    Count--;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T RemoveFirst() // удаление первого элемента
        {
            T removedData = head.Data;

            head = head.Next;

            return removedData;
        }

        public void Reverse() // разворот списка за линейное время
        {
            Node<T> previous = null;
            Node<T> current = head;

            while (current != null)
            {
                Node<T> next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }

        public SinglyLinkedList<T> Copy() // копирование списка
        {
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

            Node<T> currentOld = head;
            Node<T> currentNew = new Node<T>();

            while (currentOld != null)
            {
                if (newList.head == null)
                {
                    newList.head = new Node<T>(currentOld.Data);

                    currentNew = newList.head;
                }
                else
                {
                    currentNew.Next = new Node<T>();
                    currentNew = currentNew.Next;
                    currentNew.Data = currentOld.Data;
                }

                currentOld = currentOld.Next;

                newList.Count++;
            }

            return newList;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            Node<T> current = head;

            while (current != null)
            {
                stringBuilder.Append(current.Data);

                if (current.Next != null)
                {
                    stringBuilder.Append(", ");
                }

                current = current.Next;
            }

            return stringBuilder.ToString();
        }
    }
}