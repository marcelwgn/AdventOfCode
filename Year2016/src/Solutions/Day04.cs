using System.Linq;

namespace AdventOfCode.Year2016.Solutions
{
    public static class Day04
    {
        public static (string, int, string)[] Convert(string[] data)
        {
            return data.Select(entry =>
            {
                var roomEnd = entry.IndexOf('[');
                var roomName = entry[0..(roomEnd - 4)];
                var roomId = int.Parse(entry[(roomEnd - 3)..roomEnd]);
                var checkKeys = entry[(roomEnd + 1)..(entry.Length - 1)];

                return (roomName, roomId, checkKeys);
            }).ToArray();
        }

        public static int FirstProblem((string, int, string)[] data)
        {
            return data.Select(Process).Where(x => x.Item1).Sum(x => x.Item2);

            static (bool, int) Process((string roomName, int roomId, string checkKeys) room)
            {
                var sorted = room.roomName.Replace("-", "").GroupBy(x => x).Select(x => (Count: x.Count(), Character: x.Key)).OrderByDescending(x => x.Count).ThenBy(x => x.Character).ToArray();

                for (var i = 0; i < 5; i++)
                {
                    if (sorted[i].Character != room.checkKeys[i])
                    {
                        return (false, room.roomId);
                    }
                }
                return (true, room.roomId);
            }
        }

        public static int SecondProblem((string, int, string)[] data)
        {
            return data.Select(Process).Where(x => x.Item1.Contains("pole")).Select(x => x.Item2).First();

            static (string, int) Process((string roomName, int roomId, string checkKeys) room)
            {
                var newString = "";
                foreach (var key in room.roomName)
                {
                    if (key != '-')
                    {
                        // lowercase a: 97
                        newString += (char)(((key - 97 + room.roomId) % 26) + 97);
                    }
                    else
                    {
                        newString += '-';
                    }
                }
                return (newString, room.roomId);
            }
        }
    }
}
