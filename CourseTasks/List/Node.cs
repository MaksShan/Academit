namespace List
{
    class Node<T>
    {
        internal Node<T> Next { get; set; }
        internal T Data { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}