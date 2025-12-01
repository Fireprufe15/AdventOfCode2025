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

        public static void AISolvePart1(string input) {
            // The dial starts at position 50
            int currentPosition = 50;
            int zeroCount = 0;
            int dialSize = 100;

            // Split input into lines, removing empty entries to avoid parse errors
            string[] instructions = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string instruction in instructions)
            {
                // Parse direction (first char) and amount (rest of string)
                char direction = instruction[0];

                // We use substring(1) to get the number part
                if (int.TryParse(instruction.Substring(1), out int amount))
                {
                    if (direction == 'R')
                    {
                        // Right means adding to the number
                        currentPosition = (currentPosition + amount) % dialSize;
                    }
                    else if (direction == 'L')
                    {
                        // Left means subtracting. 
                        // In C#, modulus of a negative number is negative, so we handle the wrap manually.
                        currentPosition = (currentPosition - amount) % dialSize;
                        if (currentPosition < 0)
                        {
                            currentPosition += dialSize;
                        }
                    }

                    // Check if the dial landed on 0
                    if (currentPosition == 0)
                    {
                        zeroCount++;
                    }
                }
            }

            Console.WriteLine($"Password: {zeroCount}");
        }
        public static void AISolvePart2(string input) {
            int currentPosition = 50;
            long zeroHits = 0; // Use long to prevent overflow on large inputs
            int dialSize = 100;

            string[] instructions = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string instruction in instructions)
            {
                char direction = instruction[0];

                if (int.TryParse(instruction.Substring(1), out int amount))
                {
                    // 1. Count full rotations
                    // Every 100 clicks loops the dial completely, hitting 0 exactly once.
                    zeroHits += amount / dialSize;

                    // 2. Simulate the remaining clicks
                    int remainder = amount % dialSize;

                    if (direction == 'R')
                    {
                        // Distance to next 0 going Right:
                        // If at 50, distance is 50. If at 99, distance is 1. 
                        // If at 0, distance is 100 (needs a full loop to hit it again).
                        int distToZero = dialSize - currentPosition;

                        // If our remaining moves are equal to or greater than the distance, we hit 0.
                        if (remainder >= distToZero)
                        {
                            zeroHits++;
                        }

                        currentPosition = (currentPosition + remainder) % dialSize;
                    }
                    else // 'L'
                    {
                        // Distance to next 0 going Left:
                        // If at 50, distance is 50. If at 1, distance is 1.
                        // If at 0, distance is 100.
                        int distToZero = (currentPosition == 0) ? dialSize : currentPosition;

                        if (remainder >= distToZero)
                        {
                            zeroHits++;
                        }

                        // Handle wrapping for negative numbers
                        currentPosition = (currentPosition - remainder) % dialSize;
                        if (currentPosition < 0)
                        {
                            currentPosition += dialSize;
                        }
                    }
                }
            }

            Console.WriteLine($"Password Method 0x434C49434B: {zeroHits}");
        }

        /// Notes on Day 1:
        /// For part 1 me and Gemini had the same solution, however I feel that my code is a bit more concise.
        /// For part 2, I went with a very brute-forcy method of just doing each rotation click manually, while the AI went with a math-based approach
        /// Certianly the math-based approach is the better one, but where is the fun in that :D
        /// Also, once again, Gemini used a lot more lines than is really neccesary.
    }
}
