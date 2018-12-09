using System.Collections.Generic;

namespace AdventOfCode.Model {
  public class CyclicList<T> {
    public List<T> list = new List<T>();
    
    public void insert(int index, T element){
      list.Insert(index,element);
    }

    public void remove(T element){
      list.Remove(element);
    }

    public void remove(int index){
      list.RemoveAt(index);
    }

    public T this[int index]{
      int newIndex = index % this.list,Count;
      return list[newIndex]
    }
    
  }
}
