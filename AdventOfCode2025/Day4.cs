using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day4
    {
        public static void SolvePart1(string input)
        {
            var rows = input.TrimEnd().Split('\n');
            int[,] grid = new int[rows[0].Length, rows.Length];
            for (int i = 0; i < rows.Length; i++) {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    grid[j, i] = rows[i][j] == '@' ? 1 : 0;
                }
            }

            int accessibleRolls = 0;
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
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
                    if (amountAdjacent < 4) { accessibleRolls++; }
                }
            }
            Console.WriteLine(accessibleRolls);
        }
        public static void SolvePart2(string input)
        {
            var rows = input.TrimEnd().Split('\n');
            int[,] grid = new int[rows[0].Length, rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    grid[j, i] = rows[i][j] == '@' ? 1 : 0;
                }
            }

            int removedRolls = 0;
            int thisLoopRemovedRolls = 0;
            do {
                Console.WriteLine("Removal Loop...");
                thisLoopRemovedRolls = RemoveAccessibleRolls(grid, rows.Length, rows[0].Length);
                removedRolls += thisLoopRemovedRolls;
            } while (thisLoopRemovedRolls > 0);
            Console.WriteLine(removedRolls);

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
