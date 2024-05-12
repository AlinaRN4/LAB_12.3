using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10lab;

namespace Лабораторная_работа_12._3
{
    public class MyTree<T> where T : IInit, IComparable, new()
    {
        Point<T>? root = null; // Корень дерева
        int count = 0;  // Количество элементов в дереве

        public int Count => count; // Свойство для получения количества элементов в дереве

        public void Insert(T data)
        {
            root = InsertRec(root, data);
        }

        private Point<T> InsertRec(Point<T> root, T data)
        {
            if (root == null)
            {
                root = new Point<T>(data);
            }
            else if (data.CompareTo(root.Data) < 0)
            {
                root.Left = InsertRec(root.Left, data);
            }
            else if (data.CompareTo(root.Data) > 0)
            {
                root.Right = InsertRec(root.Right, data);
            }

            return root;
        }

       
        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        Point<T>? MakeTree(int length, Point<T>? point)
        {
            // Базовый случай: если длина меньше или равна 0, возвращаем null
            if (length <= 0)
            {
                return null;
            }

            // Создаем новый элемент данных и узел
            T data = new T();
            data.RandomInit();
            Point<T> newItem = new Point<T>(data);

            // Рекурсивно создаем левое и правое поддерево
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Right = MakeTree(nl, newItem.Right);
            newItem.Left = MakeTree(nr, newItem.Left);

            return newItem;
        }

        public void AddPoint(T data)
        {
            Point<T> point = root;
            Point<T> current = null;
            bool isExist = false;

            while (point != null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else
                {
                    if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Right;
                    }
                    else
                    {
                        point = point.Left;
                    }
                }
            }

            if (isExist)
            {
                return;
            }

            Point<T> newPoint = new Point<T>(data);
            if (current == null)
            {
                root = newPoint;
            }
            else if (current.Data.CompareTo(data) < 0)
            {
                current.Right = newPoint;
            }
            else
            {
                current.Left = newPoint;
            }

            count++;
        }

        public void ShowTree()
        {
            Show(root);
        }
        static void Show(Point<T>? point, int space = 5)
        {
            if (point != null)
            {
                Show(point.Right, space + 5); // Рекурсивно вызываем сначала правое поддерево
                for (int i = 0; i < space; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(point.Data);
                Show(point.Left, space + 5); // Затем рекурсивно вызываем левое поддерево
            }
        }

        public T FindMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            Point<T> current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current.Data;
        }
        
        void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right, array, ref current);
            }
        }

        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);

            root = new Point<T>(array[0]);
            count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }

        public void RemoveByName(string name)
        {
            if (root == null)
            {
                return; // Дерево пустое, выходим из метода
            }

            root = Remove(root, name);
        }

        private Point<T>? Remove(Point<T>? current, string name)
        {
            if (current == null)
            {
                return null; // Достигнут конец дерева
            }

            // Рекурсивно ищем удаляемый элемент в левом и правом поддереве
            if (name.CompareTo(current.Data) < 0)
            {
                current.Left = Remove(current.Left, name);
            }
            else if (name.CompareTo(current.Data) > 0)
            {
                current.Right = Remove(current.Right, name);
            }
            else
            {
                // Нашли элемент для удаления

                // Если у удаляемого элемента нет детей или только один ребенок
                if (current.Left == null)
                {
                    return current.Right;
                }
                else if (current.Right == null)
                {
                    return current.Left;
                }
            
            }

            return current;
        }
       
        public void RemoveTree()
        {
            root = null;
            count = 0;
        }

        
    }
}
