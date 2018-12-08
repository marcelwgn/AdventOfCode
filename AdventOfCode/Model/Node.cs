using System;

namespace AdventOfCode.Model {
  public class Node : IComparable<Node> {
    public string name;
    public readonly NodeList parents = new NodeList();
    public readonly NodeList children = new NodeList();

    public Node(string name)
    {
      this.name = name;
    }

    public void addParent(Node nodeToAdd)
    {
      this.parents.add(nodeToAdd);
    }

    public void addChild(Node nodeToAdd)
    {
      this.children.add(nodeToAdd);
    }

    public override bool Equals(System.Object obj)
    {
      if (obj == null)
      {
        return false;
      }
      Node node = obj as Node;

      if (node == null)
      {
        return false;
      }

      return this.name.Equals(node.name);
    }

    public int CompareTo(Node node)
    {
      return this.name.CompareTo(node.name);
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
