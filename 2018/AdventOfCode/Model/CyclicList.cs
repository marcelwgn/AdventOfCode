using System.Collections.Generic;

namespace AdventOfCode2018.Model
{
    public class CyclicList<T>
    {
        private readonly LinkedList<T> list = new LinkedList<T>();
        public int count
        {
            get => list.Count;
            set { }
        }

        public void addLast(T elm)
        {
            list.AddLast(elm);
        }

        public void addFirst(T elm)
        {
            list.AddFirst(elm);
        }

        public LinkedListNode<T> first => list.First;
        public LinkedListNode<T> last => list.Last;

        public void remove(LinkedListNode<T> node)
        {
            list.Remove(node);
        }

        public LinkedListNode<T> getNextNode(LinkedListNode<T> node)
        {
            if (node.Next is null)
            {
                return list.First;
            }

            return node.Next;
        }

        public LinkedListNode<T> getPreviousNode(LinkedListNode<T> node)
        {
            if (node.Previous is null)
            {
                return list.Last;
            }

            return node.Previous;
        }

        public void addAfter(LinkedListNode<T> node, T v)
        {
            list.AddAfter(node, v);
        }

        public override string ToString()
        {
            string result = "";
            LinkedListNode<T> node = list.First;
            result += node.Value;
            while (node.Next != null)
            {
                result += "," + node.Next.Value;
                node = node.Next;
            }
            return result;
        }
    }
}
