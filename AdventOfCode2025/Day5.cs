using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day5
    {
        public static void SolvePart1(string input)
        {
            List<Tuple<Int64, Int64>> ranges = [];
            List<Int64> ids = [];
            var lines = input.TrimEnd().Split('\n');
            bool idMode = false;
            foreach (var line in lines) {
                if (string.IsNullOrEmpty(line)) { idMode = true; continue; }
                if (idMode) {
                    ids.Add(Int64.Parse(line));
                } else { 
                    var rangeItems = line.Split('-');
                    ranges.Add(new Tuple<Int64, Int64>(Int64.Parse(rangeItems[0]), Int64.Parse(rangeItems[1])));
                }
            }
            int freshIngredients = 0;
            foreach (var id in ids) {
                foreach (var range in ranges) { 
                
                    if (id >= range.Item1 && id <= range.Item2)
                    {
                        freshIngredients++;
                        break;
                    }

                }
            }
            Console.WriteLine(freshIngredients);

        }
        public static void SolvePart2(string input)
        {
            Int64 freshIdCount = 0;
            List<Tuple<Int64, Int64>> ranges = [];
            List<Tuple<Int64, Int64>> deOverlappedRanges = [];
            var lines = input.TrimEnd().Split('\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) { break; }
                var rangeItems = line.Split('-');
                ranges.Add(new Tuple<Int64, Int64>(Int64.Parse(rangeItems[0]), Int64.Parse(rangeItems[1])));
            }
            ranges = ranges.OrderBy(x => x.Item1).ToList();
            deOverlappedRanges.Add(new Tuple<long, long>(ranges[0].Item1, ranges[0].Item2));
            for (int i = 1; i < ranges.Count; i++) {
                var lastActiveRange = deOverlappedRanges.Last();
                if (ranges[i].Item1 <= lastActiveRange.Item2)
                {
                    deOverlappedRanges.RemoveAt(deOverlappedRanges.Count-1);
                    long newEnd = Math.Max(lastActiveRange.Item2, ranges[i].Item2);
                    deOverlappedRanges.Add(new Tuple<long, long>(lastActiveRange.Item1, newEnd));
                } else
                {
                    deOverlappedRanges.Add(new Tuple<long, long>(ranges[i].Item1, ranges[i].Item2));
                }
            }
            foreach (var range in deOverlappedRanges)
            {
                freshIdCount += (range.Item2 - range.Item1) + 1;
            }
            Console.WriteLine(freshIdCount);

        }

        public static int RemoveAccessibleRolls(int[,] grid, int amtRows, int amtCols)
        {
            int removedRolls = 0;
            for (int i = 0; i < amtRows; i++)
            {
                for (int j = 0; j < amtCols; j++)
                {
                    if (grid[j, i] == 0) continue;
                    int amountAdjacent = 0;
                    try { amountAdjacent += grid[j - 1, i]; } catch { }
                    try { amountAdjacent += grid[j + 1, i]; } catch { }
                    try { amountAdjacent += grid[j, i - 1]; } catch { }
                    try { amountAdjacent += grid[j, i + 1]; } catch { }
                    try { amountAdjacent += grid[j - 1, i - 1]; } catch { }
                    try { amountAdjacent += grid[j - 1, i + 1]; } catch { }
                    try { amountAdjacent += grid[j + 1, i - 1]; } catch { }
                    try { amountAdjacent += grid[j + 1, i + 1]; } catch { }
                    
                    if (amountAdjacent < 4) { removedRolls++; grid[j, i] = 0; }
                }
            }
            return removedRolls;
        }
    }
}
