using System.Collections.Generic;

namespace AdventOfCode.Year2018.Model
{
    public class CyclicList<T>
    {
        private readonly LinkedList<T> list = new LinkedList<T>();
        public int Count => list.Count;

        public void AddLast(T elm)
        {
            list.AddLast(elm);
        }

        public void AddFirst(T elm)
        {
            list.AddFirst(elm);
        }

        public LinkedListNode<T> First => list.First;
        public LinkedListNode<T> Last => list.Last;

        public void Remove(LinkedListNode<T> node)
        {
            list.Remove(node);
        }

        public LinkedListNode<T> GetNextNode(LinkedListNode<T> node)
        {
            if (node.Next is null)
            {
                return list.First;
            }

            return node.Next;
        }

        public LinkedListNode<T> GetPreviousNode(LinkedListNode<T> node)
        {
            if (node.Previous is null)
            {
                return list.Last;
            }

            return node.Previous;
        }

        public void AddAfter(LinkedListNode<T> node, T v)
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
