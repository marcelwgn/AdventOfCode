using System;

namespace AdventOfCode.Year2018.Model
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "It's fine here since it is not used for cryptography")]
    public class Node<T> : IComparable<Node<T>>
    {
        public string Name { get; set; }
        public NodeList<T> Parents => parents;
        public NodeList<T> Children => children;
        public T? Data { get; set; }

        private readonly NodeList<T> parents = new();
        private readonly NodeList<T> children = new();

		public Node()
        {
            //Should generate unique names
            Name = (new Random().Next(0, 1000) + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()).ToString();
        }

        public Node(string name)
        {
            Name = name;
        }

        public Node(T data)
        {
            //Should generate unique names
            Name = (new Random().Next(0, 1000) + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()).ToString();
            Data = data;
        }

        public Node(string name, T data)
        {
            Name = name;
            Data = data;
        }

        public void AddParent(Node<T> nodeToAdd)
        {
            Parents.Add(nodeToAdd);
        }

        public void AddChild(Node<T> nodeToAdd)
        {
            Children.Add(nodeToAdd);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not Node<T> node)
            {
                return false;
            }

            return Name.Equals(node.Name);
        }

        public int CompareTo(Node<T>? other)
        {
            return other is null ? -1 : Name.CompareTo(other.Name);
        }

        internal int Aggregate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public static bool operator ==(Node<T>? left, Node<T>? right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Node<T>? left, Node<T>? right)
        {
            return !(left == right);
        }

        public static bool operator <(Node<T>? left, Node<T>? right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Node<T>? left, Node<T>? right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Node<T>? left, Node<T>? right)
        {
            return left is not null && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Node<T>? left, Node<T>? right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }

}
