using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AdventOfCode.Year2019.Solutions
{
    public static class Day01
    {

        public static int FirstProblem(int[] data)
        {
            int sum = 0;
            foreach (var mass in data)
            {
                sum += CalculateFuelFirstProblem(mass);
            }
            return sum;
        }

        public static int SecondProblem(int[] data)
        {
            int sum = 0;
            foreach (var mass in data)
            {
                sum += CalculateFuelSecondProblem(mass);
            }
            return sum;
        }

        public static int CalculateFuelFirstProblem(int mass)
        {
            return mass / 3 - 2;
        }

        public static int CalculateFuelSecondProblem(int mass)
        {
            int fuelRequired = 0;
            int prevFuel = CalculateFuelFirstProblem(mass);
            while ( prevFuel > 0)
            {
                fuelRequired += prevFuel;
                prevFuel = CalculateFuelFirstProblem(prevFuel);
            }
            return fuelRequired;
        }
    }
}
