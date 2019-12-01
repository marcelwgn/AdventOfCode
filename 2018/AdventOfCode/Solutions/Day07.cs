using AdventOfCode2018.Model;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Solutions
{
    public static class Day07
    {

        public static NodeList<string> Convert(string[] data)
        {
            NodeList<string> list = new NodeList<string>();
            for (int i = 0; i < data.Length; i++)
            {
                string[] split = data[i].Split(" ");
                string parentName = split[1];
                string childName = split[7];
                if (!list.contains(childName))
                {
                    list.add(new Node<string>(childName));
                }
                Node<string> childNode = list.get(childName);

                if (!list.contains(parentName))
                {
                    list.add(new Node<string>(parentName));
                }
                Node<string> parentNode = list.get(parentName);
                childNode.AddParent(parentNode);
                parentNode.AddChild(childNode);
            }

            return list;
        }


        //Needs refactoring
        public static string FirstProblem(NodeList<string> nodes)
        {
            string result = "";
            Node<string> current = null;

            NodeList<string> nodesToClean = new NodeList<string>();
            NodeList<string> alreadyAdded = new NodeList<string>();

            nodesToClean.add(nodes.getEntryPoints());

            while (nodesToClean.Count != 0)
            {
                nodesToClean.sort();
                //Finding suitable node
                for (int i = 0; i < nodesToClean.Count; i++)
                {
                    //Checking if prequisites are met
                    NodeList<string> neededNodes = nodesToClean[i].parents;
                    if (alreadyAdded.contains(neededNodes))
                    {
                        current = nodesToClean[i];
                        break;
                    }
                }

                //Skip if was already added to solution
                if (alreadyAdded.contains(current))
                {
                    nodesToClean.remove(current);
                }
                //Process node
                else
                {
                    result += current.name;
                    alreadyAdded.add(current);
                    nodesToClean.remove(current);
                    nodesToClean.add(current.children);
                }

            }

            return result;
        }

        //Needs even more refactoring !
        public static int SecondProblem(NodeList<string> nodes)
        {

            NodeList<string> nodesToClean = new NodeList<string>();
            NodeList<string> alreadyAdded = new NodeList<string>();

            List<NodeProcessor> procs = new List<NodeProcessor>();

            int procCount = 6;
            int minuteCount = -1;
            nodesToClean.add(nodes.getEntryPoints());

            while (nodesToClean.Count != 0 || procs.Count != 0)
            {
                //Update workers
                NodeList<string> finished = new NodeList<string>();
                for (int i = 0; i < procs.Count; i++)
                {
                    procs[i].minutesToCompletion--;
                    if (procs[i].minutesToCompletion == 0)
                    {
                        if (procs[i].toProcess != null)
                        {
                            finished.add(procs[i].toProcess);
                        }
                    }
                }

                //Removing all processors that are finished
                procs = procs.Where(x => !x.IsReady()).ToList();

                //Maximum reached, just wait
                if (procs.Count == procCount)
                {
                }
                else
                {
                    //Add finished nodes to add list and add their children for availability
                    for (int i = 0; i < finished.Count; i++)
                    {
                        alreadyAdded.add(finished[i]);
                        nodesToClean.add(finished[i].children);
                    }
                    int maxNodes = nodesToClean.Count;
                    for (int i = procs.Count; i < procCount; i++)
                    {
                        Node<string> current = null;
                        for (int j = 0; j < nodesToClean.Count; j++)
                        {
                            //Checking if prequisites are met
                            NodeList<string> neededNodes = nodesToClean[j].parents;
                            if (alreadyAdded.contains(neededNodes))
                            {
                                current = nodesToClean[j];
                                break;
                            }

                        }

                        if (current == null)
                        {
                            break;
                        }

                        NodeProcessor proc = new NodeProcessor(current);
                        procs.Add(proc);
                        nodesToClean.remove(current);
                    }

                }
                minuteCount++;
            }
            return minuteCount;
        }

    }

    public class NodeProcessor
    {
        public int minutesToCompletion;
        public Node<string> toProcess;

        public NodeProcessor(Node<string> toProcess)
        {
            int charOffset = toProcess.name[0] - 64;
            minutesToCompletion = 60 + charOffset;
            this.toProcess = toProcess;
        }

        public void GoStep()
        {
            minutesToCompletion--;
        }

        public override string ToString()
        {
            if (toProcess == null)
            {
                return "-----";
            }
            return toProcess.ToString();
        }

        public bool IsReady()
        {
            if (toProcess == null)
            {
                return true;
            }
            else
            {
                return minutesToCompletion < 1;
            }
        }
    }

}
