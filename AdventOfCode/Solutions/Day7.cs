using AdventOfCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions {
  public class Day7 {

    public static NodeList<String> convert(String[] data)
    {
      NodeList<String> list = new NodeList<String>();
      for (int i = 0; i < data.Length; i++)
      {
        string[] split = data[i].Split(" ");
        string parentName = split[1];
        string childName = split[7];
        if (!list.contains(childName))
        {
          list.add(new Node<String>(childName));
        }
        Node<String> childNode = list.get(childName);

        if (!list.contains(parentName))
        {
          list.add(new Node<String>(parentName));
        }
        Node<String> parentNode = list.get(parentName);
        childNode.addParent(parentNode);
        parentNode.addChild(childNode);
      }

      return list;
    }


    //Needs refactoring
    public static string firstProblem(NodeList<String> nodes)
    {
      string result = "";
      Node<String> current = null;

      NodeList<String> nodesToClean = new NodeList<String>();
      NodeList<String> alreadyAdded = new NodeList<String>();

      nodesToClean.add(nodes.getEntryPoints());

      while (nodesToClean.Count != 0)
      {
        nodesToClean.sort();
        //Finding suitable node
        for (int i = 0; i < nodesToClean.Count; i++)
        {
          //Checking if prequisites are met
          NodeList<String> neededNodes = nodesToClean[i].parents;
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
    public static int secondProblem(NodeList<String> nodes)
    {

      NodeList<String> nodesToClean = new NodeList<String>();
      NodeList<String> alreadyAdded = new NodeList<String>();

      List<NodeProcessor> procs = new List<NodeProcessor>();

      int procCount = 6;
      int minuteCount = -1;
      nodesToClean.add(nodes.getEntryPoints());

      while (nodesToClean.Count != 0 || procs.Count != 0)
      {
        //Update workers
        NodeList<String> finished = new NodeList<String>();
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
        procs = procs.Where(x => !x.isReady()).ToList();

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
            Node<String> current = null;
            for (int j = 0; j < nodesToClean.Count; j++)
            {
              //Checking if prequisites are met
              NodeList<String> neededNodes = nodesToClean[j].parents;
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

  public class NodeProcessor {
    public int minutesToCompletion;
    public Node<String> toProcess;

    public NodeProcessor(Node<String> toProcess)
    {
      int charOffset = toProcess.name[0] - 64;
      this.minutesToCompletion = 60 + charOffset;
      this.toProcess = toProcess;
    }

    public void goStep()
    {
      this.minutesToCompletion--;
    }

    public override string ToString()
    {
      if (this.toProcess == null)
      {
        return "-----";
      }
      return this.toProcess.ToString();
    }

    public bool isReady()
    {
      if (this.toProcess == null)
      {
        return true;
      }
      else
      {
        return this.minutesToCompletion < 1;
      }
    }
  }

}
