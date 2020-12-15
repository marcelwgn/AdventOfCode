using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2018.Solutions
{
    public static class Day04
    {

        public static List<Guard> Convert(string[] data)
        {
            GuardEvent[] events = new GuardEvent[data.Length];
            Array.Sort(data);

            List<Guard> guards = new List<Guard>();

            for (int i = 0; i < data.Length; i++)
            {
                events[i] = new GuardEvent(data[i]);
                if (events[i].GuardId > -1)
                {
                    bool found = false;
                    guards.ForEach(delegate (Guard guard)
                    {
                        if (guard.Id == events[i].GuardId)
                        {
                            found = true;
                        }
                    });
                    if (!found)
                    {
                        guards.Add(new Guard(events[i].GuardId));
                    }
                }
            }

            DateTime lastEvent = new DateTime();
            int currentId = -1;
            for (int i = 0; i < events.Length; i++)
            {
                GuardEvent current = events[i];
                if (current.GuardId > -1)
                {
                    currentId = current.GuardId;
                    continue;
                }

                if (current.IsSleepStart)
                {
                    lastEvent = current.TimeEvent;
                    continue;
                }

                if (current.IsSleepEnd)
                {
                    //Finding right guard:
                    Guard guard = guards[0];
                    for (int guardIndex = 0; guardIndex < guards.Count; guardIndex++)
                    {
                        if (guards[guardIndex].Id == currentId)
                        {
                            guard = guards[guardIndex];
                        }
                    }

                    //Updating sleep times
                    guard.CalculateSleepTimes(lastEvent, current.TimeEvent);

                }
            }

            return guards;
        }

        public static int FirstProblem(List<Guard> guards)
        {
            Guard mostSlept = guards[0];
            for (int i = 0; i < guards.Count; i++)
            {
                if (guards[i].MinutesSlept > mostSlept.MinutesSlept)
                {
                    mostSlept = guards[i];
                }
            }
            int highestMinuteIndex = 0;
            for (int i = 0; i < mostSlept.SleepingMinutes.Length; i++)
            {
                if (mostSlept.SleepingMinutes[i] > mostSlept.SleepingMinutes[highestMinuteIndex])
                {
                    highestMinuteIndex = i;
                }
            }
            return mostSlept.Id * highestMinuteIndex;
        }


        public static int SecondProblem(List<Guard> guards)
        {
            Guard mostSlept = guards[0];
            int highestMinuteIndex = 0;

            for (int i = 0; i < guards.Count; i++)
            {
                //Finding minute with highest sleep count
                int localMax = 0;
                for (int j = 0; j < guards[i].SleepingMinutes.Length; j++)
                {
                    if (guards[i].SleepingMinutes[j] > guards[i].SleepingMinutes[localMax])
                    {
                        localMax = j;
                    }
                }

                if (guards[i].SleepingMinutes[localMax] > mostSlept.SleepingMinutes[highestMinuteIndex])
                {
                    mostSlept = guards[i];
                    highestMinuteIndex = localMax;
                }
            }

            return mostSlept.Id * highestMinuteIndex;
        }

    }

    public class GuardEvent
    {
        public DateTime TimeEvent { get; set; }
        public int GuardId { get; set; } = -1;
        public bool IsSleepStart { get; set; }
        public bool IsSleepEnd { get; set; }

        public GuardEvent(string eventString)
        {
            string date = eventString.Substring(1, 16);
            date = date.Replace("-", "/");

            TimeEvent = DateTime.Parse(date);

            string actualEvent = eventString[19..];
            if (actualEvent.IndexOf("#") > -1)
            {
                string guardIdWithHashtag = actualEvent.Split(" ")[1];
                string guardId = guardIdWithHashtag[1..];
                GuardId = int.Parse(guardId);
            }
            else
            {
                if (actualEvent.IndexOf("asleep") > -1)
                {
                    IsSleepStart = true;
                }
                if (actualEvent.IndexOf("wakes") > -1)
                {
                    IsSleepEnd = true;
                }
            }
        }

    }

    public class Guard
    {
        public int Id { get; set; }
        public int MinutesSlept { get; set; }
#pragma warning disable CA1819
        public int[] SleepingMinutes { get; set; } = new int[60];
#pragma warning restore CA1819

        public Guard(int id)
        {
            Id = id;
        }
        public void CalculateSleepTimes(DateTime start, DateTime end)
        {
            //Calculating minutes slept
            int minutes = (int)Math.Round(end.Subtract(start).TotalMinutes);

            int minuteStart = start.Minute;
            if (start.Hour != 0)
            {
                minuteStart = 0;
            }

            int minuteEnd = end.Minute;
            if (end.Hour != 0)
            {
                minuteEnd = 0;
            }

            for (int minuteIndex = minuteStart; minuteIndex < minuteEnd; minuteIndex++)
            {
                SleepingMinutes[minuteIndex]++;
            }
            MinutesSlept += minutes;

        }
    }

}
