using System.Collections.Generic;

namespace AdventOfCode.Year2018.Model
{

    public class NodeList<T>
    {
        private readonly List<Node<T>> nodeList = new();

        public Node<T> this[int index]
        {
            get => nodeList[index];
            set => nodeList[index] = value;
        }

        public int Count
        {
            get => nodeList.Count;
            set { }
        }

        public NodeList<T> GetEntryPoints()
        {
            var entries = new NodeList<T>();
            for (var i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].Parents.Count == 0)
                {
                    entries.Add(nodeList[i]);
                }
            }
            return entries;
        }

        public void Add(NodeList<T> nodes)
        {
            for (var i = 0; i < nodes.Count; i++)
            {
                if (!Contains(nodes[i]))
                {
                    Add(nodes[i]);
                }
            }
        }

        public void Add(Node<T> node)
        {
            nodeList.Add(node);
        }

        public Node<T>? Get(string name)
        {
            for (var i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].Name.Equals(name))
                {
                    return nodeList[i];
                }
            }
            return null;
        }

        public bool Contains(string nodeName)
        {
            var node = new Node<T>(nodeName);
            for (var i = 0; i < nodeList.Count; i++)
            {
                if (nodeList.Contains(node))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(Node<T> node)
        {
            return Contains(node.Name);
        }

        public bool Contains(NodeList<T> nodes)
        {
            for (var i = 0; i < nodes.Count; i++)
            {
                if (!Contains(nodes[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public void Remove(Node<T> node)
        {
            nodeList.Remove(node);
        }

        public void Sort()
        {
            nodeList.Sort();
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < nodeList.Count; i++)
            {
                result += "," + nodeList[i];
            }
            return result;
        }
    }

}
