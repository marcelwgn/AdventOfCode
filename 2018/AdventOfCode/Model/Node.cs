using System;

namespace AdventOfCode2018.Model
{
    public class Node<T> : IComparable<Node<T>>
    {
        public string name;
        public readonly NodeList<T> parents = new NodeList<T>();
        public readonly NodeList<T> children = new NodeList<T>();

        public T data;

        public Node()
        {
            //Should generate unigue names
            name = (new Random().Next(0, 1000) + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()).ToString();
        }

        public Node(string name)
        {
            this.name = name;
        }

        public Node(T data)
        {
            //Should generate unigue names
            name = (new Random().Next(0, 1000) + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()).ToString();
            this.data = data;
        }

        public Node(string name, T data)
        {
            this.name = name;
            this.data = data;
        }


        public void AddParent(Node<T> nodeToAdd)
        {
            parents.add(nodeToAdd);
        }

        public void AddChild(Node<T> nodeToAdd)
        {
            children.add(nodeToAdd);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Node<T> node))
            {
                return false;
            }

            return name.Equals(node.name);
        }

        public int CompareTo(Node<T> node)
        {
            return name.CompareTo(node.name);
        }

        internal int Aggregate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name);
        }
    }

}
