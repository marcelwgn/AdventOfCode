using AdventOfCode.Common.DataStructures;

namespace AdventOfCode.Year2023.Solutions;

public static class Day16
{
    private sealed record Beam(Coordinate Position, Coordinate Direction);

    public static long FirstProblem(string[] data)
    {
        return Energize(data, new(new(0, 0), new(1, 0)));
    }

    public static long SecondProblem(string[] data)
    {

        var maxValue = 0L;

        var xMax = data[0].Length - 1;
        var yMax = data.Length - 1;



        for (int i = 0; i < data.Length; i++)
        {
            ProcessStartPosition(new(0, i));
            ProcessStartPosition(new(xMax, i));
        }

        for (int i = 0; i < data[0].Length; i++)
        {
            ProcessStartPosition(new(i, 0));
            ProcessStartPosition(new(i, yMax));
        }

        return maxValue;

        void ProcessStartPosition(Coordinate coordinate)
        {
            if (coordinate.X <= 0)
            {
                UpdateMaxUsingBeam(new(coordinate, new(1, 0)));
            }
            if (coordinate.X >= xMax)
            {
                UpdateMaxUsingBeam(new(coordinate, new(-1, 0)));
            }
            if (coordinate.Y <= 0)
            {
                UpdateMaxUsingBeam(new(coordinate, new(0, 1)));
            }
            if (coordinate.Y >= yMax)
            {
                UpdateMaxUsingBeam(new(coordinate, new(0, -1)));
            }
        }

        void UpdateMaxUsingBeam(Beam beam)
        {
            maxValue = Math.Max(maxValue, Energize(data, beam));
        }
    }

    private static long Energize(string[] data, Beam initialBeam)
    {
        var visitedPosition = new HashSet<Coordinate>();
        var existingBeams = new HashSet<Beam>();
        var beams = new List<Beam>()
        {
            initialBeam
        };

        while (beams.Any(x => x.Position.IsInGrid(data)) && beams.Any(x => !existingBeams.Contains(x)))
        {
            foreach (var beam in beams)
            {
                existingBeams.Add(beam);
            }

            var beamLength = beams.Count;
            for (int i = 0; i < beamLength; i++)
            {
                var beam = beams.ElementAt(i);
                if (!beam.Position.IsInGrid(data)) continue;

                var newDirections = GetNextDirections(data, beam.Position, beam.Direction);
                if (newDirections.Length == 2)
                {
                    var newBeam = new Beam(beam.Position + newDirections[1], newDirections[1]);
                    visitedPosition.Add(newBeam.Position);
                    beams.Add(newBeam);
                }
                beams[i] = new(beam.Position + newDirections[0], newDirections[0]);
                visitedPosition.Add(beam.Position);
            }

            beams = beams.Where(x => x.Position.IsInGrid(data) && !existingBeams.Contains(x)).ToList();

        }
        return visitedPosition.Where(x => x.IsInGrid(data)).Count();
    }

    private static Coordinate[] GetNextDirections(string[] data, Coordinate position, Coordinate direction)
    {
        var tile = data.Get(position);

        if (tile == '/')
        {
            // Moving down (0,1) -> (-1,0)
            // Moving right: (1,0) -> (0,-1)
            // Moving up: (0,-1) -> (1,0)
            // Moving left: (-1,0) -> (0,1)
            return [new(
                direction.Y * -1,
                direction.X * -1)];
        }
        else if (tile == '\\')
        {
            // Moving up (0,-1) -> (-1,0)
            return [new(direction.Y, direction.X)];
        }
        else if (tile == '|' && direction.X != 0)
        {
            return [
                new(0, 1),
                new(0, -1)
            ];
        }
        else if (tile == '-' && direction.Y != 0)
        {
            return [
                new(1, 0),
                new(-1, 0)
            ];
        }
        return [direction];
    }

}
