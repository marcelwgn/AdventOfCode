﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Extensions
{
    public static class SetUtils
    {
        // Code taken from https://stackoverflow.com/a/19891145/6061965
        public static T[][] FastPowerSet<T>(T[] seq)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = []; // starting only with empty set

            for (var i = 0; i < seq.Length; i++)
            {
                var cur = seq[i];
                var count = 1 << i; // doubling list each time
                for (var j = 0; j < count; j++)
                {
                    var source = powerSet[j];
                    var destination = powerSet[count + j] = new T[source.Length + 1];
                    for (var q = 0; q < source.Length; q++)
                    {
                        destination[q] = source[q];
                    }

                    destination[source.Length] = cur;
                }
            }
            return powerSet;
        }

        // Code taken from https://stackoverflow.com/a/10630026/6061965
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
