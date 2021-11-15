using System;
using System.Collections.Generic;

namespace Level_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            tree.AddItem(10);
            tree.AddItem(20);
            tree.AddItem(15);
            tree.AddItem(59);
            tree.AddItem(12);
            tree.AddItem(28);
            tree.AddItem(28);
            tree.AddItem(35);
            tree.AddItem(8);
            tree.AddItem(5);
            tree.PrintTree();
            Console.WriteLine("======================================");
            TreeNode BFSout1 = BFS(tree, 8);
            TreeNode DFSout1 = DFS(tree, 5);
            TreeNode BFSout2 = BFS(tree, 5);
            TreeNode DFSout2 = DFS(tree, 8);
            TreeNode BFSout3 = BFS(tree, 125);
            TreeNode DFSout3 = DFS(tree, 512);
            TreeNode BFSout4 = BFS(tree, 512);
            TreeNode DFSout4 = DFS(tree, 125);
        }
        static TreeNode BFS(Tree tree, int value)
        {
            Console.WriteLine("=====Начало BFS Поиска=====");
            var root = tree.GetRoot();
            Queue<TreeNode> roots = new Queue<TreeNode>();
            if (root.Value == value)
            {
                Console.WriteLine("Значение найдено");
                Console.WriteLine("=====Конец BFS Поиска=====");
                return root;
            }
            else
            {
                if (root.RightChild != null)
                {
                    roots.Enqueue(root.RightChild);
                    Console.WriteLine($"Правая ветка со значением {root.RightChild.Value} добавлена в очередь");
                }
                if (root.LeftChild != null)
                {
                    roots.Enqueue(root.LeftChild);
                    Console.WriteLine($"Левая ветка со значением {root.LeftChild.Value} добавлена в очередь");
                }
                if (roots.Count == 0)
                {
                    Console.WriteLine("Очердь пуста, значение не найдено");
                    Console.WriteLine("=====Конец BFS Поиска=====");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Ветка со значением {root.Value} убирается из очереди");
                    root = roots.Dequeue();
                    while (true)
                    {
                        if (root.Value == value)
                        {
                            Console.WriteLine("Значение найдено");
                            Console.WriteLine("=====Конец BFS Поиска=====");
                            return root;
                        }
                        else
                        {
                            if (root.RightChild != null)
                            {
                                roots.Enqueue(root.RightChild);
                                Console.WriteLine($"Правая ветка со значением {root.RightChild.Value} добавлена в очередь");
                            }
                            if (root.LeftChild != null)
                            {
                                roots.Enqueue(root.LeftChild);
                                Console.WriteLine($"Левая ветка со значением {root.LeftChild.Value} добавлена в очередь");
                            }
                            if (roots.Count == 0)
                            {
                                Console.WriteLine("Очердь пуста, значение не найдено");
                                Console.WriteLine("=====Конец BFS Поиска=====");
                                return null;
                            }
                            else
                            {
                                Console.WriteLine($"Ветка со значением {root.Value} убирается из очереди");
                                root = roots.Dequeue();
                            }
                        }
                    }
                }

            }
        }
        static TreeNode DFS(Tree tree, int value)
        {
            Console.WriteLine("=====Начало DFS Поиска=====");
            var root = tree.GetRoot();
            Stack<TreeNode> roots = new Stack<TreeNode>();
            if (root.Value == value)
            {
                Console.WriteLine("Значение найдено");
                Console.WriteLine("=====Конец DFS Поиска=====");
                return root;
            }
            else
            {
                if (root.RightChild != null)
                {
                    roots.Push(root.RightChild);
                    Console.WriteLine($"Правая ветка со значением {root.RightChild.Value} добавлена в стак");
                }
                if (root.LeftChild != null)
                {
                    roots.Push(root.LeftChild);
                    Console.WriteLine($"Левая ветка со значением {root.LeftChild.Value} добавлена в стак");
                }
                if (roots.Count == 0)
                {
                    Console.WriteLine("Очердь пуста, значение не найдено");
                    Console.WriteLine("=====Конец DFS Поиска=====");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Ветка со значением {root.Value} убирается из стака");
                    root = roots.Pop();
                    while (true)
                    {
                        if (root.Value == value)
                        {
                            Console.WriteLine("Значение найдено");
                            Console.WriteLine("=====Конец DFS Поиска=====");
                            return root;
                        }
                        else
                        {
                            if (root.RightChild != null)
                            {
                                roots.Push(root.RightChild);
                                Console.WriteLine($"Правая ветка со значением {root.RightChild.Value} добавлена в стак");
                            }
                            if (root.LeftChild != null)
                            {
                                roots.Push(root.LeftChild);
                                Console.WriteLine($"Левая ветка со значением {root.LeftChild.Value} добавлена в стак");
                            }
                            if (roots.Count == 0)
                            {
                                Console.WriteLine("Очердь пуста, значение не найдено");
                                Console.WriteLine("=====Конец DFS Поиска=====");
                                return null;
                            }
                            else
                            {
                                Console.WriteLine($"Ветка со значением {root.Value} убирается из стака");
                                root = roots.Pop();
                            }
                        }
                    }
                }
            }
        }
    }
}
