using System;
using System.Collections.Generic;

namespace Level_6
{
    internal class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public List<Node> Links { get; set; }
            public int active { get; set; }
        }
        static void Main(string[] args)
        {
        }
        static Node BFS(Node Graph, int value)
        {
            Console.WriteLine("=====Начало BFS Поиска=====");
            Queue<Node> graphs = new Queue<Node>();
            if (Graph.Value == value)
            {
                Console.WriteLine("Значение найдено");
                Console.WriteLine("=====Конец BFS Поиска=====");
                return Graph;
            }
            else
            {
                foreach (var link in Graph.Links)
                {
                    if (link.active != 1)
                    {
                        graphs.Enqueue(link);
                        Console.WriteLine($"Ветка со значением {link.Value} добавлена в очередь");
                        link.active = 1;
                    }
                }
                if (graphs.Count == 0)
                {
                    Console.WriteLine("Очердь пуста, значение не найдено");
                    Console.WriteLine("=====Конец BFS Поиска=====");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Ветка со значением {Graph.Value} убирается из очереди");
                    Graph = graphs.Dequeue();
                    while (true)
                    {
                        if (Graph.Value == value)
                        {
                            Console.WriteLine("Значение найдено");
                            Console.WriteLine("=====Конец BFS Поиска=====");
                            return Graph;
                        }
                        else
                        {
                            foreach (var link in Graph.Links)
                            {
                                if (link.active != 1)
                                {
                                    graphs.Enqueue(link);
                                    Console.WriteLine($"Ветка со значением {link.Value} добавлена в очередь");
                                    link.active = 1;
                                }
                            }
                            if (graphs.Count == 0)
                            {
                                Console.WriteLine("Очердь пуста, значение не найдено");
                                Console.WriteLine("=====Конец BFS Поиска=====");
                                return null;
                            }
                            else
                            {
                                Console.WriteLine($"Ветка со значением {Graph.Value} убирается из очереди");
                                Graph = graphs.Dequeue();
                            }
                        }
                    }
                }
            }
        }
        static Node DFS(Node Graph, int value)
        {
            Console.WriteLine("=====Начало DFS Поиска=====");
            Stack<Node> graphs = new Stack<Node>();
            if (Graph.Value == value)
            {
                Console.WriteLine("Значение найдено");
                Console.WriteLine("=====Конец DFS Поиска=====");
                return Graph;
            }
            else
            {
                foreach (var link in Graph.Links)
                {
                    if (link.active != 1)
                    {
                        graphs.Push(link);
                        Console.WriteLine($"Ветка со значением {link.Value} добавлена в очередь");
                        link.active = 1;
                    }
                }
                if (graphs.Count == 0)
                {
                    Console.WriteLine("Очердь пуста, значение не найдено");
                    Console.WriteLine("=====Конец DFS Поиска=====");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Ветка со значением {Graph.Value} убирается из стака");
                    Graph = graphs.Pop();
                    while (true)
                    {
                        if (Graph.Value == value)
                        {
                            Console.WriteLine("Значение найдено");
                            Console.WriteLine("=====Конец DFS Поиска=====");
                            return Graph;
                        }
                        else
                        {
                            foreach (var link in Graph.Links)
                            {
                                if (link.active != 1)
                                {
                                    graphs.Push(link);
                                    Console.WriteLine($"Ветка со значением {link.Value} добавлена в очередь");
                                    link.active = 1;
                                }
                            }
                            if (graphs.Count == 0)
                            {
                                Console.WriteLine("Очердь пуста, значение не найдено");
                                Console.WriteLine("=====Конец DFS Поиска=====");
                                return null;
                            }
                            else
                            {
                                Console.WriteLine($"Ветка со значением {Graph.Value} убирается из стака");
                                Graph = graphs.Pop();
                            }
                        }
                    }
                }
            }
        }
    }
}
