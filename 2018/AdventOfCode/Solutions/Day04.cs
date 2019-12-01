using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Solutions
{
    public static class Day04
    {

        public static List<Guard> Convert(string[] data)
        {
            Event[] events = new Event[data.Length];
            Array.Sort(data);

            List<Guard> guards = new List<Guard>();

            for (int i = 0; i < data.Length; i++)
            {
                events[i] = new Event(data[i]);
                if (events[i].guardId > -1)
                {
                    bool found = false;
                    guards.ForEach(delegate (Guard guard)
                    {
                        if (guard.id == events[i].guardId)
                        {
                            found = true;
                        }
                    });
                    if (!found)
                    {
                        guards.Add(new Guard(events[i].guardId));
                    }
                }
            }

            DateTime lastEvent = new DateTime();
            int currentId = -1;
            for (int i = 0; i < events.Length; i++)
            {
                Event current = events[i];
                if (current.guardId > -1)
                {
                    currentId = current.guardId;
                    continue;
                }

                if (current.isSleepStart)
                {
                    lastEvent = current.timeEvent;
                    continue;
                }

                if (current.isSleepEnd)
                {
                    //Finding right guard:
                    Guard guard = guards[0];
                    for (int guardIndex = 0; guardIndex < guards.Count; guardIndex++)
                    {
                        if (guards[guardIndex].id == currentId)
                        {
                            guard = guards[guardIndex];
                        }
                    }

                    //Updating sleep times
                    guard.CalculateSleepTimes(lastEvent, current.timeEvent);

                }
            }

            return guards;
        }

        public static int FirstProblem(List<Guard> guards)
        {
            Guard mostSlept = guards[0];
            for (int i = 0; i < guards.Count; i++)
            {
                if (guards[i].minutesSlept > mostSlept.minutesSlept)
                {
                    mostSlept = guards[i];
                }
            }
            int highestMinuteIndex = 0;
            for (int i = 0; i < mostSlept.sleepingMinutes.Length; i++)
            {
                if (mostSlept.sleepingMinutes[i] > mostSlept.sleepingMinutes[highestMinuteIndex])
                {
                    highestMinuteIndex = i;
                }
            }
            return mostSlept.id * highestMinuteIndex;
        }


        public static int SecondProblem(List<Guard> guards)
        {
            Guard mostSlept = guards[0];
            int highestMinuteIndex = 0;

            for (int i = 0; i < guards.Count; i++)
            {
                //Finding minute with highest sleep count
                int localMax = 0;
                for (int j = 0; j < guards[i].sleepingMinutes.Length; j++)
                {
                    if (guards[i].sleepingMinutes[j] > guards[i].sleepingMinutes[localMax])
                    {
                        localMax = j;
                    }
                }

                if (guards[i].sleepingMinutes[localMax] > mostSlept.sleepingMinutes[highestMinuteIndex])
                {
                    mostSlept = guards[i];
                    highestMinuteIndex = localMax;
                }
            }

            return mostSlept.id * highestMinuteIndex;
        }

    }

    public class Event
    {
        public DateTime timeEvent;

        public int guardId = -1;

        public bool isSleepStart = false;
        public bool isSleepEnd = false;

        public Event(string eventString)
        {
            string date = eventString.Substring(1, 16);
            date = date.Replace("-", "/");

            timeEvent = DateTime.Parse(date);

            string actualEvent = eventString.Substring(19, eventString.Length - 19);
            if (actualEvent.IndexOf("#") > -1)
            {
                string guardIdWithHashtag = actualEvent.Split(" ")[1];
                string guardId = guardIdWithHashtag.Substring(1, guardIdWithHashtag.Length - 1);
                this.guardId = int.Parse(guardId);
            }
            else
            {
                if (actualEvent.IndexOf("asleep") > -1)
                {
                    isSleepStart = true;
                }
                if (actualEvent.IndexOf("wakes") > -1)
                {
                    isSleepEnd = true;
                }
            }

        }

    }

    public class Guard
    {
        public int id, minutesSlept;

        public int[] sleepingMinutes = new int[60];

        public Guard(int id)
        {
            this.id = id;
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
                sleepingMinutes[minuteIndex]++;
            }
            minutesSlept += minutes;

        }
    }

}
