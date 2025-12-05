namespace AdventOfCode.Year2018.Solutions;

public static class Day04
{

    public static IList<Guard> Convert(string[] data)
    {
        var events = new GuardEvent[data.Length];
        Array.Sort(data);

        var guards = new List<Guard>();

        for (var i = 0; i < data.Length; i++)
        {
            events[i] = new GuardEvent(data[i]);
            if (events[i].GuardId > -1)
            {
                var found = false;
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

        var lastEvent = new DateTime();
        var currentId = -1;
        for (var i = 0; i < events.Length; i++)
        {
            var current = events[i];
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
                var guard = guards[0];
                for (var guardIndex = 0; guardIndex < guards.Count; guardIndex++)
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

    public static int FirstProblem(IList<Guard> guards)
    {
        var mostSlept = guards[0];
        for (var i = 0; i < guards.Count; i++)
        {
            if (guards[i].MinutesSlept > mostSlept.MinutesSlept)
            {
                mostSlept = guards[i];
            }
        }
        var highestMinuteIndex = 0;
        for (var i = 0; i < mostSlept.SleepingMinutes.Length; i++)
        {
            if (mostSlept.SleepingMinutes[i] > mostSlept.SleepingMinutes[highestMinuteIndex])
            {
                highestMinuteIndex = i;
            }
        }
        return mostSlept.Id * highestMinuteIndex;
    }

    public static int SecondProblem(IList<Guard> guards)
    {
        var mostSlept = guards[0];
        var highestMinuteIndex = 0;

        for (var i = 0; i < guards.Count; i++)
        {
            //Finding minute with highest sleep count
            var localMax = 0;
            for (var j = 0; j < guards[i].SleepingMinutes.Length; j++)
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
        var date = eventString.Substring(1, 16);
        date = date.Replace("-", "/");

        TimeEvent = DateTime.Parse(date);

        var actualEvent = eventString[19..];
        if (actualEvent.IndexOf('#') > -1)
        {
            var guardIdWithHashtag = actualEvent.Split(" ")[1];
            var guardId = guardIdWithHashtag[1..];
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

public class Guard(int id)
{
    public int Id { get; set; } = id;
    public int MinutesSlept { get; set; }
    public int[] SleepingMinutes { get; set; } = new int[60];

    public void CalculateSleepTimes(DateTime start, DateTime end)
    {
        //Calculating minutes slept
        var minutes = (int)Math.Round(end.Subtract(start).TotalMinutes);

        var minuteStart = start.Minute;
        if (start.Hour != 0)
        {
            minuteStart = 0;
        }

        var minuteEnd = end.Minute;
        if (end.Hour != 0)
        {
            minuteEnd = 0;
        }

        for (var minuteIndex = minuteStart; minuteIndex < minuteEnd; minuteIndex++)
        {
            SleepingMinutes[minuteIndex]++;
        }
        MinutesSlept += minutes;

    }
}
