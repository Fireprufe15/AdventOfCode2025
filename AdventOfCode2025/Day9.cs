using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day9
    {
        public static void SolvePart1(string input)
        { 
            var lines = input.TrimEnd().Split('\n').Select(x => new Coord(x));
            long currentLargestArea = 0;
            foreach (var line in lines) { 
                foreach (var line2 in lines)
                {
                    var area = (Math.Abs(line2.X - line.X) + 1) * (Math.Abs(line2.Y - line.Y) + 1);
                    if (area > currentLargestArea) currentLargestArea = area;
                }
            }
            Console.WriteLine(currentLargestArea);
        }

        public static void SolvePart2(string input)
        { }

        
    }

    internal class Coord
    {
        public long X { get; set; }
        public long Y { get; set; }

        public Coord(string line)
        {
            var coords = line.TrimEnd().Split(',');
            X = long.Parse(coords[0]);
            Y = long.Parse(coords[1]);
        }
    }
}
