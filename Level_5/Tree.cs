using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level_5
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
        int RootCounter;
        public void AddItem(int value)
        {
            TreeNode node = new TreeNode { Value = value };
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                if (GetNodeByValue(value) != null)
                    Console.WriteLine("Значение уже записано");
                else
                {
                    TreeNode root = Root;
                    while (true)
                    {
                        if (value > root.Value)
                        {
                            if (root.RightChild != null)
                                root = root.RightChild;
                            else
                            {
                                root.RightChild = node;
                                RootCounter++;
                                break;
                            }
                        }
                        if (value < root.Value)
                        {
                            if (root.LeftChild != null)
                                root = root.LeftChild;
                            else
                            {
                                root.LeftChild = node;
                                RootCounter++;
                                break;
                            }
                        }
                    }
                }
            }
        }
        public TreeNode GetNodeByValue(int value)
        {
            TreeNode root = Root;
            while (root != null)
            {
                if (root.Value == value)
                {
                    return root;
                }
                if (value > root.Value)
                {
                    if (root.RightChild != null)
                        root = root.RightChild;
                    else
                        return null;
                }
                if (value < root.Value)
                {
                    if (root.LeftChild != null)
                        root = root.LeftChild;
                    else
                        return null;
                }
            }
            return null;
        }

        public TreeNode GetRoot()
        {
            return Root;
        }
        public void PrintTree()
        {
            string output = ($"-[{Root.Value}]");
            Console.WriteLine(output);
            int f = 0;
            for (int i = 0; i < output.Length - 2; i++)
            {
                f++;
            }
            if (Root.RightChild != null)
            {
                for (int i = 0; i < output.Length - 2; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|-[R]-");
                PrintNext(Root.RightChild, f + 4);
            }
            if (Root.LeftChild != null)
            {
                for (int i = 0; i < output.Length - 2; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|-[L]-");
                PrintNext(Root.LeftChild, f + 4);
            }
        }
        public void PrintNext(TreeNode root, int f)
        {
            string output = ($"[{root.Value}]");
            Console.WriteLine(output);
            int s = 0;
            for (int i = 0; i < output.Length + f; i++)
            {
                s++;
            }
            if (root.RightChild != null)
            {
                for (int i = 0; i < output.Length + f; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|-[R]-");
                PrintNext(root.RightChild, s + 4);
            }
            if (root.LeftChild != null)
            {
                for (int i = 0; i < output.Length + f; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|-[L]-");
                PrintNext(root.LeftChild, s + 4);
            }
        }
        public void RemoveItem(int value)
        {
            TreeNode root = Root;
            TreeNode prevroot = null;
            int l = 0;
            if (GetNodeByValue(value) != null && GetNodeByValue(value) == Root)
            {
                Root = null;
                RootCounter = 0;
            }

            while (root != null)
            {
                if (root.Value == value)
                {
                    if (l == 1)
                    {
                        prevroot.RightChild = null;
                    }
                    if (l == -1)
                    {
                        prevroot.LeftChild = null;
                    }
                    RootCounter--;
                    break;
                }
                if (value > root.Value)
                {
                    if (root.RightChild != null)
                    {
                        l = 1;
                        prevroot = root;
                        root = root.RightChild;
                    }
                    else
                    {
                        Console.WriteLine("Значение не найдено");
                        break;
                    }
                }
                if (value < root.Value)
                {
                    if (root.LeftChild != null)
                    {
                        l = -1;
                        prevroot = root;
                        root = root.LeftChild;
                    }
                    else
                    {
                        Console.WriteLine("Значение не найдено");
                        break;
                    }
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
