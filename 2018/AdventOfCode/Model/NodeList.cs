using System.Collections.Generic;

namespace AdventOfCode2018.Model
{




    public class NodeList<T>
    {
        private readonly List<Node<T>> nodeList = new List<Node<T>>();

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

        public NodeList<T> getEntryPoints()
        {
            NodeList<T> entries = new NodeList<T>();
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].parents.Count == 0)
                {
                    entries.add(nodeList[i]);
                }
            }
            return entries;
        }

        public void add(NodeList<T> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!contains(nodes[i]))
                {
                    add(nodes[i]);
                }
            }
        }

        public void add(Node<T> node)
        {
            nodeList.Add(node);
        }

        public Node<T> get(string name)
        {
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].name.Equals(name))
                {
                    return nodeList[i];
                }
            }
            return null;
        }

        public bool contains(string nodeName)
        {
            Node<T> node = new Node<T>(nodeName);
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList.Contains(node))
                {
                    return true;
                }
            }
            return false;
        }

        public bool contains(Node<T> node)
        {
            return contains(node.name);
        }

        public bool contains(NodeList<T> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!contains(nodes[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public void remove(Node<T> node)
        {
            nodeList.Remove(node);
        }

        public void sort()
        {
            nodeList.Sort();
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < nodeList.Count; i++)
            {
                result += "," + nodeList[i];
            }
            return result;
        }
    }

}
