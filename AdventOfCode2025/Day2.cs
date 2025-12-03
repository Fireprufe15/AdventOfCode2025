using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day2
    {
        public static void SolvePart1(string input) { 
            var ranges = input.Split(',');
            Int64 invalidIdSum = 0;
            foreach (var range in ranges) {
                var rangeEnds = range.Split("-");
                for (var i = Int64.Parse(rangeEnds[0]); i < Int64.Parse(rangeEnds[1]); i++) {
                    var idString = i.ToString();
                    if (idString.Length % 2 != 0) continue;
                    var firstHalf = idString[..(idString.Length / 2)];
                    var secondHalf = idString[(idString.Length / 2)..];
                    if (firstHalf == secondHalf) { invalidIdSum += i; }
                }                                                
            }
            Console.WriteLine(invalidIdSum.ToString());
        }

        public static void SolvePart2(string input) {
            var ranges = input.Split(',');
            Int64 invalidIdSum = 0;
            var regexPattern = @"^(.+)\1+$";
            Regex regex = new Regex(regexPattern, RegexOptions.None, TimeSpan.FromMilliseconds(100));
            foreach (var range in ranges)
            {
                var rangeEnds = range.Split("-");
                for (var i = Int64.Parse(rangeEnds[0]); i < Int64.Parse(rangeEnds[1]); i++)
                {
                    var idString = i.ToString();
                    Match match = regex.Match(idString);
                    if (match.Success) invalidIdSum += i;
                }
            }
            Console.WriteLine(invalidIdSum.ToString());
        }
    }
}
