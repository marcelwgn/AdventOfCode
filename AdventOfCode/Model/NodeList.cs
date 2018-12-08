using System;
using System.Collections.Generic;

namespace AdventOfCode.Model {

 


  public class NodeList {
    private readonly List<Node> nodeList = new List<Node>();

    public Node this[int index] {
      get => this.nodeList[index];
      set => this.nodeList[index] = value;
    }

    public int Count {
      get { return this.nodeList.Count; }
      set { }
    }

    public NodeList getEntryPoints()
    {
      NodeList entries = new NodeList();
      for (int i = 0; i < this.nodeList.Count; i++)
      {
        if (this.nodeList[i].parents.Count == 0)
        {
          entries.add(this.nodeList[i]);
        }
      }
      return entries;
    }

    public void add(NodeList nodes)
    {
      for (int i = 0; i < nodes.Count; i++)
      {
        if (!this.contains(nodes[i]))
        {
          this.add(nodes[i]);
        }
      }
    }

    public void add(Node node)
    {
      this.nodeList.Add(node);
    }

    public Node get(String name)
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
      Node node = new Node(nodeName);
      for (int i = 0; i < this.nodeList.Count; i++)
      {
        if (this.nodeList.Contains(node))
        {
          return true;
        }
      }
      return false;
    }

    public bool contains(Node node)
    {
      return this.contains(node.name);
    }

    public bool contains(NodeList nodes)
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

    public void remove(Node node)
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
