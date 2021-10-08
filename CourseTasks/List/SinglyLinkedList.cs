using System;

namespace List
{
    class SinglyLinkedList<T>
    {
        private int count;
        private Node<T> head;

        public SinglyLinkedList()
        {
            head = null;
            count = 0;
        }

        public int GetLength() // получить размер списка
        {
            return count;
        }

        public T GetFirstElement() //получение значения первого элемента
        {
            return head.Data;
        }

        public T GetElement(int index) // получение элемента по индексу
        {
            Node<T> current = head;

            int elementCounter = 0;

            while (current != null)
            {
                if (elementCounter == index)
                {
                    return current.Data;
                }

                elementCounter++;
                current = current.Next;
            }

            throw new ArgumentOutOfRangeException("Индекс находится вне длины списка");
        }

        public T ChangeElement(int index, T data) // изменение элемента по индексу
        {
            T previousData;

            Node<T> current = head;

            int elementCounter = 0;

            while (current != null)
            {
                if (elementCounter == index)
                {
                    previousData = current.Data;

                    current.Data = data;

                    return previousData;
                }

                elementCounter++;
                current = current.Next;
            }

            throw new ArgumentOutOfRangeException("Индекс находится вне длины списка");
        }

        public void AddFirst(T data) // вставка элемента в начало
        {
            Node<T> node = new Node<T>(data);

            node.Next = head;
            head = node;

            count++;
        }

        public T Remove(int index) // удаление элемента по индексу
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }

            Node<T> current = head;

            T oldData;

            if (index == 0) // если индекс 0 то сдвигаем head
            {
                oldData = current.Data;

                head = current.Next;

                return oldData;
            }

            int elementCounter = 1; // так как при 0 уже проверили

            while (current.Next != null)
            {
                if (elementCounter == index)
                {
                    oldData = current.Next.Data;

                    current.Next = current.Next.Next;

                    count--;

                    return oldData;
                }

                current = current.Next;

                elementCounter++;
            }

            throw new ArgumentOutOfRangeException("Индекс находится вне длины списка");
        }

        public void Insert(Node<T> data, int index) // вставка элемента по индексу
        {
            if (index == 0)
            {
                AddFirst(data.Data);

                return;
            }

            Node<T> current = head;

            int elementCounter = 1;

            while (current.Next != null)
            {
                if (elementCounter == index)
                {
                    data.Next = current.Next;
                    current.Next = data;

                    count++;

                    return;
                }

                current = current.Next;

                elementCounter++;
            }

            throw new ArgumentOutOfRangeException("Индекс находится вне длины списка");
        }

        public bool RemoveItem(T item) // удаление узла по значению
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }

            if (head.Data.Equals(item))
            {
                RemoveFirst();

                return true;
            }

            Node<T> current = head;

            while (current != null)
            {
                if (current.Next.Data.Equals(item))
                {
                    current.Next = current.Next.Next;

                    count--;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T RemoveFirst() // удаление первого хлемента
        {
            T deletedData = GetFirstElement();

            Remove(0);

            return deletedData;
        }

        public void Reverse() // разворот списка за линейнное время
        {
            Node<T> previous = null;
            Node<T> current = head;
            Node<T> next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }

        public SinglyLinkedList<T> Copy() // копирование списка
        {
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

            Node<T> current = head;

            while (current != null)
            {
                newList.Add(current.Data);

                current = current.Next;
            }

            return newList;
        }

        private void Add(T data)
        {
            Node<T> current = head;

            if (current == null)
            {
                current = new Node<T>(data);

                head = current;

                count++;

                return;
            }

            while (current.Next != null)
            {
                current = current.Next;
            }

            Node<T> nodeToAdd = new Node<T>(data);
            current.Next = nodeToAdd;

            count++;
        }
    }
}