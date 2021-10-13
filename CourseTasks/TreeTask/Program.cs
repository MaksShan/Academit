using System;

namespace TreeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Insert(8);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(10);
            tree.Insert(6);
            tree.Insert(7);

            if (tree.FindNode(6))
            {
                Console.WriteLine($"Узел с значением {6} найден");
            }
            else
            {
                Console.WriteLine($"Узел с значением {6} не найден!");
            }

            if (tree.Remove(6))
            {
                Console.WriteLine($"Узел с значением {6} удален");
            }
            else
            {
                Console.WriteLine($"Не удалось удалить узел с значением {6}");
            }

            Console.Write("Обход дерева в ширину: ");
            tree.BypassInWide();

            Console.WriteLine();

            Console.Write("Обход дерева в глубь без рекурсии: ");
            tree.BypassInDepthNonRecursion();

            Console.WriteLine();

            Console.Write("Обход дерева в глубь c рекурсией: ");
            tree.BypassInDepth();

            Console.ReadKey();
        }
    }
}
