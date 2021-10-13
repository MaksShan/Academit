using System;
using System.Collections.Generic;

namespace TreeTask
{
    class BinaryTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;
        public int Count { get; private set; }

        public int GetElementsNumber() // получение числа элементов
        {
            return Count;
        }

        public void Insert(T item) // вставка
        {
            if (root == null)
            {
                root = new TreeNode<T>(item);
            }
            else
            {
                AddItem(root, item);
            }

            Count++;
        }

        private void AddItem(TreeNode<T> current, T item)
        {
            if (item.CompareTo(current.Data) < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new TreeNode<T>(item);
                }
                else
                {
                    AddItem(current.Left, item);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode<T>(item);
                }
                else
                {
                    AddItem(current.Right, item);
                }
            }
        }

        public bool Remove(T item) // удаление
        {
            TreeNode<T> current;
            TreeNode<T> parent;

            current = FindChildAndParent(item, out parent);

            if (current == null) // элемент не найден вохвращаем false
            {
                return false;
            }

            if (current.Right == null) // если нет правого ребенка
            {
                if (parent == null) // если нет ролителя
                {
                    root = current.Left; // то левый ребенок текущего становится корнем
                }
                else
                {
                    int comparison = parent.CompareTo(current.Data);

                    if (comparison > 0) // если родитель больше текущего
                    {
                        parent.Left = current.Left; // левый ребёнок текущеко становится левым ребенком родителя
                    }
                    else if (comparison < 0) // если родитель меньше текущего
                    {
                        parent.Right = current.Left; // левый рбенок текущего становится правым ребенком родителя
                    }
                }
            }
            else if (current.Right.Left == null) // если у правого ребёнка текущего нет детей слева, то он занимает место удаляемого
            {
                current.Right.Left = current.Left;

                if (parent == null) // если нет ролителя
                {
                    root = current.Right; // то правый ребенок текущего становится родителем
                }
                else
                {
                    int comparison = parent.CompareTo(current.Data);

                    if (comparison > 0) // если родитель больше текущего
                    {
                        parent.Left = current.Right; // то правый ребенок становится левым ребенком родителя
                    }
                    else if (comparison < 0) // если родитель меньше текущего
                    {
                        parent.Right = current.Right; // то правый ребенок текущего становится правым ребенком родителя
                    }
                }
            }
            else
            {
                TreeNode<T> farLeft = current.Right.Left;
                TreeNode<T> farLeftParent = current.Right;

                while (farLeft.Left != null) // находим крайний левый узел
                {
                    farLeftParent = farLeft;
                    farLeft = farLeft.Left;
                }

                farLeftParent.Left = farLeft.Right; // левое поддерево родителя становится правым поддеревом крайнего левого узла

                farLeft.Left = current.Left; // левый ребенок текущего узла становится левым ребенком крайнего левого
                farLeft.Right = current.Right; // правый реюенок текущего узла станоовится правым ребенком крайнего левого

                if (parent == null)
                {
                    root = farLeft;
                }
                else
                {
                    int comparison = parent.CompareTo(current.Data);

                    if (comparison > 0) // если родитель больше текущего
                    {
                        parent.Left = farLeft; // крайний левый узел становится левым ребенком родителя
                    }
                    else if (comparison < 0) // если родитель меньше текущего
                    {
                        parent.Right = farLeft; // крайний левый узел становится правым ребенком родителя
                    }
                }
            }

            Count--;

            return true;
        }

        public bool FindNode(T item)
        {
            TreeNode<T> parent;
            TreeNode<T> node = FindChildAndParent(item, out parent);

            if (node == null)
            {
                return false;
            }

            return true;
        }

        public TreeNode<T> FindChildAndParent(T item, out TreeNode<T> parent) // поиск узла
        {
            TreeNode<T> current = root;
            parent = null;

            while (current != null)
            {
                int comparison = current.CompareTo(item);

                if (comparison > 0) // искомое меньше - идем влево 
                {
                    parent = current;
                    current = current.Left;
                }
                else if (comparison < 0)// искомое больше - идем вправо
                {
                    parent = current;
                    current = current.Right;
                }
                else // равны
                {
                    break;
                }
            }

            return current; // если не найдется то вернет right или left, которые являются null
        }

        public void BypassInDepth() //обход в глубину с рекурсией
        {
            VisitRecursion(root);
        }

        private void VisitRecursion(TreeNode<T> node)
        {
            if (node != null)
            {
                Action(node);

                VisitRecursion(node.Left);
                VisitRecursion(node.Right);
            }
        }

        private void Action(TreeNode<T> node)
        {
            Console.Write(" " + node.Data);
        }

        public void BypassInDepthNonRecursion() // обход в глубину без рекурсии
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            TreeNode<T> current = root;

            stack.Push(root);

            while (stack.Count > 0)
            {
                current = stack.Pop();

                Action(current);

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }
        }

        public void BypassInWide() // обход в ширину
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> current = queue.Dequeue();

                if (current == null)
                {
                    continue;
                }

                queue.Enqueue(current.Left);
                queue.Enqueue(current.Right);

                Action(current);
            }
        }
    }
}
