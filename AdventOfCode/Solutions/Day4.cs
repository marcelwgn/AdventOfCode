using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions {
  public class Day4 {

    public static List<Guard> convert(String[] data) {
      Event[] events = new Event[data.Length];
      Array.Sort(data);

      List<Guard> guards = new List<Guard>();

      for (int i = 0; i < data.Length; i++) {
        events[i] = new Event(data[i]);
        if (events[i].guardId > -1) {
          bool found = false;
          guards.ForEach(delegate (Guard guard) {
            if (guard.id == events[i].guardId) {
              found = true;
            }
          });
          if (!found) {
            guards.Add(new Guard(events[i].guardId));
          }
        }
      }

      DateTime lastEvent = new DateTime();
      int currentId = -1;
      for (int i = 0; i < events.Length; i++) {
        Event current = events[i];
        if (current.guardId > -1) {
          currentId = current.guardId;
          continue;
        }

        if (current.isSleepStart) {
          lastEvent = current.timeEvent;
          continue;
        }

        if (current.isSleepEnd) {
          //Finding right guard:
          Guard guard = guards[0];
          for (int guardIndex = 0; guardIndex < guards.Count; guardIndex++) {
            if (guards[guardIndex].id == currentId) {
              guard = guards[guardIndex];
            }
          }

          //Updating sleep times
          guard.calculateSleepTimes(lastEvent, current.timeEvent);

        }
      }

      return guards;
    }

    public static int firstProblem(List<Guard> guards) {
      Guard mostSlept = guards[0];
      for (int i = 0; i < guards.Count; i++) {
        if (guards[i].minutesSlept > mostSlept.minutesSlept) {
          mostSlept = guards[i];
        }
      }
      int highestMinuteIndex = 0;
      for (int i = 0; i < mostSlept.sleepingMinutes.Length; i++) {
        if (mostSlept.sleepingMinutes[i] > mostSlept.sleepingMinutes[highestMinuteIndex]) {
          highestMinuteIndex = i;
        }
      }
      return mostSlept.id * highestMinuteIndex;
    }


    public static int secondProblem(List<Guard> guards) {
      Guard mostSlept = guards[0];
      int highestMinuteIndex = 0;

      for (int i = 0; i < guards.Count; i++) {
        //Finding minute with highest sleep count
        int localMax = 0;
        for (int j = 0; j < guards[i].sleepingMinutes.Length; j++) {
          if (guards[i].sleepingMinutes[j] > guards[i].sleepingMinutes[localMax]) {
            localMax = j;
          }
        }

        if (guards[i].sleepingMinutes[localMax] > mostSlept.sleepingMinutes[highestMinuteIndex]) {
          mostSlept = guards[i];
          highestMinuteIndex = localMax;
        }
      }

      return mostSlept.id * highestMinuteIndex;
    }

  }

  public class Event {
    public DateTime timeEvent;

    public int guardId = -1;

    public bool isSleepStart = false;
    public bool isSleepEnd = false;

    public Event(String eventString) {
      String date = eventString.Substring(1, 16);
      date = date.Replace("-", "/");

      this.timeEvent = DateTime.Parse(date);

      String actualEvent = eventString.Substring(19, eventString.Length - 19);
      if (actualEvent.IndexOf("#") > -1) {
        String guardIdWithHashtag = actualEvent.Split(" ")[1];
        String guardId = guardIdWithHashtag.Substring(1, guardIdWithHashtag.Length - 1);
        this.guardId = int.Parse(guardId);
      }
      else {
        if (actualEvent.IndexOf("asleep") > -1) {
          this.isSleepStart = true;
        }
        if (actualEvent.IndexOf("wakes") > -1) {
          this.isSleepEnd = true;
        }
      }

    }

  }

  public class Guard {
    public int id, minutesSlept;

    public int[] sleepingMinutes = new int[60];

    public Guard(int id) {
      this.id = id;
    }

    public void calculateSleepTimes(DateTime start, DateTime end) {
      //Calculating minutes slept
      int minutes = (int)Math.Round(end.Subtract(start).TotalMinutes);

      int minuteStart = start.Minute;
      if (start.Hour != 0) {
        minuteStart = 0;
      }

      int minuteEnd = end.Minute;
      if (end.Hour != 0) {
        minuteEnd = 0;
      }

      for (int minuteIndex = minuteStart; minuteIndex < minuteEnd; minuteIndex++) {
        this.sleepingMinutes[minuteIndex]++;
      }
      this.minutesSlept += minutes;

    }
  }

}
