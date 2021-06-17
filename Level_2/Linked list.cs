namespace _1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class LinkedList : ILinkedList
    {
        Node HeadNode;
        Node TailNode;
        int n;
        public void AddNode(int value)
        {
            Node Newnode = new Node { Value = value };
            if (HeadNode == null)
                HeadNode = Newnode;
            else
            {
                TailNode.NextNode = Newnode;
                Newnode.PrevNode = TailNode;
            }
            TailNode = Newnode;
            n++;
        }
        public void AddNodeAfter(Node node, int value)
        {
            Node Newnode = new Node { Value = value };
            if (node.NextNode == null)
            {
                TailNode.NextNode = Newnode;
                Newnode.PrevNode = TailNode;
                TailNode = Newnode;
            }
            else
            {
                Newnode.NextNode = node.NextNode;
                Newnode.PrevNode = node;
                node.NextNode.PrevNode = Newnode;
                node.NextNode = Newnode;
            }
            n++;
        }

        public Node FindNode(int searchValue)
        {
            Node current = HeadNode;
            while (current != null)
            {
                if (current.Value == searchValue)
                {
                    break;
                }
                current = current.NextNode;
            }
            return current;
        }

        public int GetCount()
        {
            if (n <= 0)
                return 0;
            else
                return n;
        }

        public void RemoveNode(int index)
        {
            Node current = HeadNode;
            int l = 1;
            while (l < index)
            {
                l++;
                current = current.NextNode;
            }
            RemoveNode(current);
        }

        public void RemoveNode(Node node)
        {
            if (node.NextNode != null)
                node.NextNode.PrevNode = node.PrevNode;
            else
                TailNode = node.PrevNode;
            if (node.PrevNode != null)
                node.PrevNode.NextNode = node.NextNode;
            else
                HeadNode = node.NextNode;
            n--;
        }
    }
}
