using System;
using System.Collections.Generic;

namespace AdventOfCode.Model {

 


  public class NodeList<T> {
    private readonly List<Node<T>> nodeList = new List<Node<T>>();

    public Node<T> this[int index] {
      get => this.nodeList[index];
      set => this.nodeList[index] = value;
    }

    public int Count {
      get { return this.nodeList.Count; }
      set { }
    }

    public NodeList<T> getEntryPoints()
    {
      NodeList<T> entries = new NodeList<T>();
      for (int i = 0; i < this.nodeList.Count; i++)
      {
        if (this.nodeList[i].parents.Count == 0)
        {
          entries.add(this.nodeList[i]);
        }
      }
      return entries;
    }

    public void add(NodeList<T> nodes)
    {
      for (int i = 0; i < nodes.Count; i++)
      {
        if (!this.contains(nodes[i]))
        {
          this.add(nodes[i]);
        }
      }
    }

    public void add(Node<T> node)
    {
      this.nodeList.Add(node);
    }

    public Node<T> get(String name)
    {
      for (int i = 0; i < this.nodeList.Count; i++)
      {
        if (this.nodeList[i].name.Equals(name))
        {
          return this.nodeList[i];
        }
      }
      return null;
    }

    public bool contains(String nodeName)
    {
      Node<T> node = new Node<T>(nodeName);
      for (int i = 0; i < this.nodeList.Count; i++)
      {
        if (this.nodeList.Contains(node))
        {
          return true;
        }
      }
      return false;
    }

    public bool contains(Node<T> node)
    {
      return this.contains(node.name);
    }

    public bool contains(NodeList<T> nodes)
    {
      for (int i = 0; i < nodes.Count; i++)
      {
        if (!this.contains(nodes[i]))
        {
          return false;
        }
      }

      return true;
    }

    public void remove(Node<T> node)
    {
      this.nodeList.Remove(node);
    }

    public void sort()
    {
      this.nodeList.Sort();
    }

    public override string ToString()
    {
      String result = "";
      for (int i = 0; i < this.nodeList.Count; i++)
      {
        result += "," + this.nodeList[i];
      }
      return result;
    }
  }

}
