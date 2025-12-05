using AdventOfCode.Year2018.Model;

namespace AdventOfCode.Year2018.Solutions;

public static class Day07
{

    public static NodeList<string> Convert(string[] data)
    {
        var list = new NodeList<string>();
        for (var i = 0; i < data.Length; i++)
        {
            var split = data[i].Split(" ");
            var parentName = split[1];
            var childName = split[7];
            if (!list.Contains(childName))
            {
                list.Add(new Node<string>(childName));
            }
            var childNode = list.Get(childName)!;

            if (!list.Contains(parentName))
            {
                list.Add(new Node<string>(parentName));
            }
            var parentNode = list.Get(parentName)!;
            childNode.AddParent(parentNode);
            parentNode.AddChild(childNode);
        }

        return list;
    }

    //Needs refactoring
    public static string FirstProblem(NodeList<string> nodes)
    {
        var result = "";
        Node<string>? current = null;

        var nodesToClean = new NodeList<string>();
        var alreadyAdded = new NodeList<string>();

        nodesToClean.Add(nodes.GetEntryPoints());

        while (nodesToClean.Count != 0)
        {
            nodesToClean.Sort();
            //Finding suitable node
            for (var i = 0; i < nodesToClean.Count; i++)
            {
                //Checking if prequisites are met
                var neededNodes = nodesToClean[i].Parents;
                if (alreadyAdded.Contains(neededNodes))
                {
                    current = nodesToClean[i];
                    break;
                }
            }

            //Skip if was already added to solution
            if (current != null && alreadyAdded.Contains(current))
            {
                nodesToClean.Remove(current);
            }
            //Process node
            else
            {
                result += current!.Name;
                alreadyAdded.Add(current);
                nodesToClean.Remove(current);
                nodesToClean.Add(current.Children);
            }

        }

        return result;
    }

    //Needs even more refactoring !
    public static int SecondProblem(NodeList<string> nodes)
    {

        var nodesToClean = new NodeList<string>();
        var alreadyAdded = new NodeList<string>();

        var procs = new List<NodeProcessor>();

        var procCount = 6;
        var minuteCount = -1;
        nodesToClean.Add(nodes.GetEntryPoints());

        while (nodesToClean.Count != 0 || procs.Count != 0)
        {
            //Update workers
            var finished = new NodeList<string>();
            for (var i = 0; i < procs.Count; i++)
            {
                procs[i].MinutesToCompletion--;
                if (procs[i].MinutesToCompletion == 0)
                {
                    if (procs[i].ToProcess != null)
                    {
                        finished.Add(procs[i].ToProcess);
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
                for (var i = 0; i < finished.Count; i++)
                {
                    alreadyAdded.Add(finished[i]);
                    nodesToClean.Add(finished[i].Children);
                }
                var maxNodes = nodesToClean.Count;
                for (var i = procs.Count; i < procCount; i++)
                {
                    Node<string>? current = null;
                    for (var j = 0; j < nodesToClean.Count; j++)
                    {
                        //Checking if prequisites are met
                        var neededNodes = nodesToClean[j].Parents;
                        if (alreadyAdded.Contains(neededNodes))
                        {
                            current = nodesToClean[j];
                            break;
                        }

                    }

                    if (current == null)
                    {
                        break;
                    }

                    var proc = new NodeProcessor(current);
                    procs.Add(proc);
                    nodesToClean.Remove(current);
                }

            }
            minuteCount++;
        }
        return minuteCount;
    }

}

public class NodeProcessor
{
    public int MinutesToCompletion { get; set; }
    public Node<string> ToProcess { get; }

    public NodeProcessor(Node<string> toProcess)
    {
        var charOffset = toProcess.Name[0] - 64;
        MinutesToCompletion = 60 + charOffset;
        ToProcess = toProcess;
    }

    public void GoStep()
    {
        MinutesToCompletion--;
    }

    public override string ToString()
    {
        if (ToProcess == null)
        {
            return "-----";
        }
        return ToProcess.ToString();
    }

    public bool IsReady()
    {
        if (ToProcess == null)
        {
            return true;
        }
        else
        {
            return MinutesToCompletion < 1;
        }
    }
}
