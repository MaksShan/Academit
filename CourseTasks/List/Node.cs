namespace List
{
    class Node<T>
    {
        internal Node<T> Next { get; set; }
        internal T Data { get; set; }

        public Node() // компилятор запрашивает пустой конструктор для метода Copy()
        {

        }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }
    }
}