using System.Collections.Generic;

namespace AdventOfCode.Model {
  public class CyclicList<T> {
    private readonly LinkedList<T> list = new LinkedList<T>();


    public void addFirst(T elm)
    {
      this.list.AddFirst(elm);
    }

    public LinkedListNode<T> first {
      get {
        return this.list.First;
      }
    }
    public LinkedListNode<T> last {
      get {
        return this.list.Last;
      }
    }

    public void remove(LinkedListNode<T> node){
      this.list.Remove(node);
    }

    public LinkedListNode<T> getNextNode(LinkedListNode<T> node)
    {
      if (node.Next is null)
      {
        return this.list.First;
      }

      return node.Next;
    }

    public LinkedListNode<T> getPreviousNode(LinkedListNode<T> node)
    {
      if (node.Previous is null)
      {
        return this.list.Last;
      }

      return node.Previous;
    }

    public void addAfter(LinkedListNode<T> node, T v)
    {
      this.list.AddAfter(node, v);
    }

    public override string ToString()
    {
      string result = "";
      var node = this.list.First;
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
