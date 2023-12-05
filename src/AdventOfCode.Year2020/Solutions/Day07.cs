using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Solutions
{
    public static class Day07
    {
        public static int FirstProblem(string[] lines)
        {
            return ConvertData(lines).Values.Where(x => x.CanHoldGoldBag()).Count();
        }
        public static int SecondProblem(string[] data)
        {
            return ConvertData(data)["shiny gold"].GetBagCount() - 1;
        }

        public static Dictionary<string, Bag> ConvertData(string[] data)
        {
            var dictionary = new Dictionary<string, Bag>();
            foreach (var item in data)
            {
                var split = item.Split(" ");
                var name = split[0] + " " + split[1];
                dictionary.Add(name, new Bag(name, item.IndexOf("shiny gold") > 3));
            }

            foreach (var item in data)
            {
                if (item.Contains("no other bags."))
                {
                    continue;
                }
                var newLine = item.Replace("contain ", "").Replace("bags, ", "").Replace("bag, ", "").Replace(" bag.", "").Replace(" bags.", "");
                var dataSplit = newLine.Split(" ");
                var bag = dictionary[dataSplit[0] + " " + dataSplit[1]];
                var split = dataSplit[3..];
                for (var i = 0; i < split.Length && split.Length > 2; i += 3)
                {
                    var amount = int.Parse(split[i]);
                    var name = split[i + 1] + " " + split[i + 2];
                    for (var j = 0; j < amount; j++)
                    {
                        bag.AddBag(dictionary[name]);
                    }
                }
            }
            return dictionary;
        }
    }

    public class Bag
    {
        public string Name { get; init; }
        private readonly bool selfContainsGoldBag;
        private readonly List<Bag> Bags = new();
        private int? bagCountCached = 1;
        private bool? canHoldGoldBagCached = null;

        public Bag(string name, bool holdGoldBg)
        {
            selfContainsGoldBag = holdGoldBg;
            Name = name;
        }

        public void AddBag(Bag bag)
        {
            Bags.Add(bag);
            canHoldGoldBagCached = null;
            bagCountCached = null;
        }

        public int GetBagCount()
        {
            if (bagCountCached is null)
            {
                bagCountCached = Bags.Sum(x => x.GetBagCount()) + 1;
            }
            return bagCountCached.Value;
        }

        public bool CanHoldGoldBag()
        {
            if (canHoldGoldBagCached is null)
            {
                if (selfContainsGoldBag)
                {
                    canHoldGoldBagCached = true;
                }
                else
                {
                    foreach (var item in Bags)
                    {
                        if (Name != item.Name)
                        {
                            if (item.CanHoldGoldBag())
                            {
                                canHoldGoldBagCached = true;
                                break;
                            }
                        }
                    }
                }
                if (canHoldGoldBagCached == null)
                {
                    canHoldGoldBagCached = false;
                }
            }
            return canHoldGoldBagCached.Value;
        }
    }
}
