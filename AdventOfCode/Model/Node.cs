using System;

namespace AdventOfCode.Model {
  public class Node<T> : IComparable<Node<T>> {
    public string name;
    public readonly NodeList<T> parents = new NodeList<T>();
    public readonly NodeList<T> children = new NodeList<T>();

    public T data;

    public Node()
    {
      //Should generate unigue names
      this.name = (new Random().Next(0, 1000) + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()).ToString();
    }

    public Node(string name)
    {
      this.name = name;
    }

    public Node(T data)
    {
      //Should generate unigue names
      this.name = (new Random().Next(0, 1000) + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()).ToString();
      this.data = data;
    }

    public Node(string name, T data)
    {
      this.name = name;
      this.data = data;
    }


    public void addParent(Node<T> nodeToAdd)
    {
      this.parents.add(nodeToAdd);
    }

    public void addChild(Node<T> nodeToAdd)
    {
      this.children.add(nodeToAdd);
    }

    public override bool Equals(System.Object obj)
    {
      if (obj == null)
      {
        return false;
      }
      Node<T> node = obj as Node<T>;

      if (node == null)
      {
        return false;
      }

      return this.name.Equals(node.name);
    }

    public int CompareTo(Node<T> node)
    {
      return this.name.CompareTo(node.name);
    }

    internal int Aggregate()
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return this.name;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(this.name);
    }
  }

}
