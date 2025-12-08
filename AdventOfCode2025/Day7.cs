using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day7
    {
        public static void SolvePart1(string input)
        {
            int splitsOccured = 0;
            var lines = input.TrimEnd().Split('\n');
            for (int i = 0; i < lines.Length; i++) {
                for (int j = 0; j < lines[i].Length; j++) {
                    if (lines[i][j] == 'S')
                    {
                        if (i == lines.Length - 1) break;
                        if (lines[i + 1][j] == '.')
                        {
                            var arr = lines[i + 1].ToCharArray();
                            arr[j] = 'S';
                            lines[i + 1] = new string(arr);
                        } else if (lines[i + 1][j] == '^')
                        {
                            var arr = lines[i + 1].ToCharArray();
                            arr[j-1] = 'S';
                            arr[j+1] = 'S';
                            lines[i + 1] = new string(arr);
                            splitsOccured++;
                        }
                    }
                }
            }
            Console.WriteLine(splitsOccured);
        }

        public static void SolvePart2(string input)
        {
            var lines = input.TrimEnd().Split('\n');
            long[] timelinesPerCol = new long[lines[0].Length];
            var starterIndex = lines[0].IndexOf('S');
            timelinesPerCol[starterIndex] = 1;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == 'S')
                    {
                        if (i == lines.Length - 1) break;
                        if (lines[i + 1][j] == '.')
                        {
                            var arr = lines[i + 1].ToCharArray();
                            arr[j] = 'S';
                            lines[i + 1] = new string(arr);
                        }
                        else if (lines[i + 1][j] == '^')
                        {
                            var arr = lines[i + 1].ToCharArray();
                            arr[j - 1] = 'S';
                            arr[j + 1] = 'S';
                            lines[i + 1] = new string(arr);

                            timelinesPerCol[j + 1] += timelinesPerCol[j];
                            timelinesPerCol[j - 1] += timelinesPerCol[j];
                            timelinesPerCol[j] = 0;

                        }
                    }
                }
            }
            Console.WriteLine(timelinesPerCol.Sum());
        }
    }
}
