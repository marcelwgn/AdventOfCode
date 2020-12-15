using System.Collections.Generic;
using AdventOfCode.Year2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2018.Tests.Solutions
{
    [TestClass()]
    public class Day04Tests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            string[] data = {
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-05 00:55] wakes up"
            };

            List<Guard> converted = Day04.Convert(data);

            Assert.AreEqual(2, converted.Count);
            Guard first = converted[0];
            Guard second = converted[1];

            Assert.AreEqual(10, first.Id);
            Assert.AreEqual(50, first.MinutesSlept);

            Assert.AreEqual(99, second.Id);
            Assert.AreEqual(30, second.MinutesSlept);
        }

        [TestMethod()]
        public void FirstProblemTest()
        {
            List<Guard> data = new List<Guard>();
            Guard first = new Guard(10)
            {
                MinutesSlept = 50,
                SleepingMinutes = new int[]{
                    0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,
                }
            };

            Guard second = new Guard(99)
            {
                MinutesSlept = 24,
                SleepingMinutes = new int[]{
                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,2,3,2,2,2,2,1,1,1,1,1,0,0,0,0,0,
                }
            };

            data.Add(first);
            data.Add(second);

            int result = Day04.FirstProblem(data);

            Assert.AreEqual(240, result);
        }

        [TestMethod()]
        public void SecondProblemTest()
        {
            List<Guard> data = new List<Guard>();
            Guard first = new Guard(10)
            {
                MinutesSlept = 50,
                SleepingMinutes = new int[]{
                    0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,
                }
            };

            Guard second = new Guard(99)
            {
                MinutesSlept = 24,
                SleepingMinutes = new int[]{
                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,2,3,2,2,2,2,1,1,1,1,1,0,0,0,0,0,
                }
            };

            data.Add(first);
            data.Add(second);

            int result = Day04.SecondProblem(data);

            Assert.AreEqual(4455, result);
        }
    }
}