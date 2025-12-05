
namespace AdventOfCode.Year2025.Solutions;

public static class Day01
{
    public static string FirstProblem(string[] data)
    {
        int cRotationWasZero = 0;
        int uCurRotation = 50;
        foreach (var st in data)
        {
            bool fLeft = st[0] == 'L';
            int uDegrees = int.Parse(st[1..]);
            if (fLeft)
            {
                uCurRotation = (uCurRotation + 100 - uDegrees) % 100;
            }
            else
            {
                uCurRotation = (uCurRotation + uDegrees) % 100;
            }
            if (uCurRotation == 0)
            {
                cRotationWasZero++;
            }
        }

        return cRotationWasZero.ToString();
    }

    public static string SecondProblem(string[] data)
    {
        int cRotationWasZero = 0;
        int uCurRotation = 50;
        foreach (var st in data)
        {
            bool fLeft = st[0] == 'L';
            int uDegrees = int.Parse(st[1..]);
            bool fWasZero = uCurRotation == 0;
            if (fLeft)
            {
                uCurRotation -= (uDegrees % 100);
            }
            else
            {
                uCurRotation += (uDegrees % 100);
            }

            cRotationWasZero += uDegrees / 100;

            if (!fWasZero && (uCurRotation <= 0 || uCurRotation >= 100))
            {
                cRotationWasZero++;
            }
            uCurRotation = ((uCurRotation % 100) + 100) % 100;
        }

        return cRotationWasZero.ToString();
    }
}
