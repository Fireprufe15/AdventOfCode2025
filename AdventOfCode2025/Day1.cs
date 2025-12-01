using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day1
    {
        public static void SolvePart1(string input)
        {
            int maxValue = 100;
            int number = 50;
            int zeroCount = 0;

            var steps = input.TrimEnd().Split('\n');
            foreach (var step in steps) {
                var direction = step[0];
                int count = int.Parse(step[1..]);
                if (direction == 'L') count = count * -1;
                number = (number + count + maxValue) % maxValue;
                if (number == 0) zeroCount++;
            }
            Console.WriteLine(zeroCount);
            Console.ReadKey();
        }

        public static void SolvePart2(string input)
        {
            int maxValue = 100;
            int number = 50;
            int zeroCount = 0;

            var steps = input.TrimEnd().Split('\n');
            foreach (var step in steps)
            {
                var direction = step[0];
                int count = int.Parse(step[1..]);
                for (int i = 0; i < count; i++) {
                    int stepInc = 1;
                    if (direction == 'L') stepInc = stepInc * -1;
                    number += stepInc;
                    if (number == -1) number = 99;
                    if (number == 100) number = 0;
                    if (number == 0) zeroCount++;
                }
            }
            Console.WriteLine(zeroCount);
            Console.ReadKey();
        }
    }
}
