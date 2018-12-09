using System.Collections.Generic;

namespace AdventOfCode.Model {
  public class CyclicList<T> {
    public List<T> list = new List<T>();

    public void insertAfter(int index, T element)
    {
      int insertionIndex = this.calculateCorrectIndex(index) + 1;
      if (insertionIndex > this.list.Count)
      {
        this.list.Add(element);
      }
      else
      {
        this.list.Insert(insertionIndex, element);
      }
    }

    public int getIndex(T value)
    {
      return this.list.IndexOf(value);
    }

    public int Count {
      get {
        return this.list.Count;
      }
    }

    public void remove(T element)
    {
      this.list.Remove(element);
    }

    public void remove(int index)
    {
      this.list.RemoveAt(this.calculateCorrectIndex(index));
    }

    public T this[int index] {
      get {
        int newIndex = this.calculateCorrectIndex(index);
        return this.list[newIndex];

      }
      set {
        int newIndex = this.calculateCorrectIndex(index);
        this.list[newIndex] = value;
      }
    }

    private int calculateCorrectIndex(int index)
    {
      while (index < 0)
      {
        index += this.list.Count + 1;
      }
      if (this.list.Count == 0)
      {
        return 0;
      }
      return (index % this.list.Count);
    }

    public override string ToString()
    {
      string result = "";
      for (int i = 0; i < this.list.Count; i++)
      {
        result += this.list[i] + ",";
      }
      return result;
    }
  }
}
