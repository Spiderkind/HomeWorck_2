using System;
using System.Collections.Generic;

namespace _2
{
    interface TreeIn
    {
        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode LeftChild { get; set; }
            public TreeNode RightChild { get; set; }

            public override bool Equals(object obj)
            {
                var node = obj as TreeNode;

                if (node == null)
                    return false;

                return node.Value == Value;
            }
        }

        public interface ITree
        {
            TreeNode GetRoot();
            void AddItem(int value); // добавить узел
            void RemoveItem(int value); // удалить узел по значению
            TreeNode GetNodeByValue(int value); //получить узел дерева по значению
            void PrintTree(); //вывести дерево в консоль
        }

        public class Tree : ITree
        {
            TreeNode Root;
            TreeNode RealRoot;
            TreeNode TempRoot;
            int n;
            int c;
            public void AddItem(int value)
            {
                TreeNode Newnode = new TreeNode { Value = value };
                if (RealRoot == null)
                {
                    Root = Newnode;
                    RealRoot = Newnode;
                }
                else
                {
                    if (GetNodeByValue(value) != null)
                    {
                        Console.WriteLine("Значение уже записано");
                    }
                    else
                    {
                        if (Root.Value > Newnode.Value)
                        {
                            if (Root.LeftChild == null)
                            {
                                Root.LeftChild = Newnode;
                                Root = RealRoot;
                            }
                            else
                            {
                                Root = Root.LeftChild;
                                AddItem(value);
                            }
                        }
                        else
                        {
                            if (Root.RightChild == null)
                            {
                                Root.RightChild = Newnode;
                                Root = RealRoot;
                            }
                            else
                            {
                                Root = Root.RightChild;
                                AddItem(value);
                            }
                        }
                    }
                }
            }
                public TreeNode GetNodeByValue(int value)
            {
                if (Root.Value < value)
                {
                    if (Root.RightChild == null)
                    {
                        Root = RealRoot;
                        Console.WriteLine("Значение не найдено");
                        return null;
                    }
                    else
                    {
                        Root = Root.RightChild;
                        TempRoot = GetNodeByValue(value);
                    }
                }
                else if (Root.Value > value || TempRoot.Value != value)
                {
                    if (Root.LeftChild == null)
                    {
                        Console.WriteLine("Значение не найдено");
                        Root = RealRoot;
                        return null;
                    }
                    else
                    {
                        Root = Root.LeftChild;
                        TempRoot = GetNodeByValue(value);
                    }
                }
                else if (Root.Value == value || TempRoot.Value != value)
                {
                    TempRoot = Root;
                    Root = RealRoot;
                    return TempRoot;
                }
                else if (TempRoot.Value == value)
                {
                    c++;
                    return TempRoot;
                }
                return null;
            }
            public TreeNode GetRoot()
            {
                return RealRoot;
            }
            public void PrintTree()
            {
                if (RealRoot != null)
                {
                    Console.WriteLine($"({RealRoot.Value})");
                    if (RealRoot.RightChild != null)
                    {
                        Console.WriteLine(" |-[R]-");
                        PrintTreeNext(RealRoot.RightChild);
                    }
                    if (RealRoot.LeftChild != null)
                    {
                        Console.WriteLine(" |-[L]-");
                        PrintTreeNext(RealRoot.LeftChild);
                    }
                }
                else
                    Console.WriteLine("-ПУСТО-");
            }
            public void PrintTreeNext(TreeNode Root1)
            {
                Console.Write($"({Root1.Value})\n");
                if (Root1.RightChild != null)
                {
                    c = 0;
                    GetNodeByValue(Root1.RightChild.Value);
                    for (int i = 1; i < c * 7 + 1; i++)
                        Console.Write(" ");
                    Console.WriteLine(" |-[R]-");
                    PrintTreeNext(Root1.RightChild);
                }
                if (Root1.LeftChild != null)
                {
                    c = 0;
                    GetNodeByValue(Root1.RightChild.Value);
                    for (int i = 1; i < c * 7 + 1; i++)
                        Console.Write(" ");
                    Console.WriteLine(" |-[L]-");
                    PrintTreeNext(Root1.LeftChild);
                }
            }
            public void RemoveItem(int value)
            {
                if (RealRoot.Value == value)
                {
                    RealRoot.LeftChild = null;
                    RealRoot.RightChild = null;
                    RealRoot = null;
                    Root = null;
                }
                else
                {
                    if (Root.Value < value)
                    {
                        if (Root.RightChild == null)
                        {
                            Root = RealRoot;
                            Console.WriteLine("Значение не найдено");
                        }
                        else
                        {
                            TempRoot = Root;
                            n = 1;
                            Root = Root.RightChild;
                            RemoveItem(value);
                        }
                    }
                    else if (Root.Value > value)
                    {
                        if (Root.LeftChild == null)
                        {
                            Root = RealRoot;
                            Console.WriteLine("Значение не найдено");
                        }
                        else
                        {
                            TempRoot = Root;
                            n = 0;
                            Root = Root.LeftChild;
                            RemoveItem(value);
                        }
                    }
                    else if (Root.Value == value)
                    {
                        if (n == 1)
                            TempRoot.RightChild = null;
                        else if (n == 0)
                            TempRoot.LeftChild = null;
                        Root = null;
                    }
                }
            }
        }
        public class NodeInfo
        {
            public int Depth { get; set; }
            public TreeNode Node { get; set; }
        }
        public static class TreeHelper
        {
            public static NodeInfo[] GetTreeInLine(ITree tree)
            {
                var bufer = new Queue<NodeInfo>();
                var returnArray = new List<NodeInfo>();
                var root = new NodeInfo() { Node = tree.GetRoot() };
                bufer.Enqueue(root);

                while (bufer.Count != 0)
                {
                    var element = bufer.Dequeue();
                    returnArray.Add(element);

                    var depth = element.Depth + 1;

                    if (element.Node.LeftChild != null)
                    {
                        var left = new NodeInfo()
                        {
                            Node = element.Node.LeftChild,
                            Depth = depth,
                        };
                        bufer.Enqueue(left);
                    }
                    if (element.Node.RightChild != null)
                    {
                        var right = new NodeInfo()
                        {
                            Node = element.Node.RightChild,
                            Depth = depth,
                        };
                        bufer.Enqueue(right);
                    }
                }
                return returnArray.ToArray();
            }
        }
    }
}
