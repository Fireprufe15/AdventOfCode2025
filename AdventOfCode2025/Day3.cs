using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day3
    {
        public static void SolvePart1(string input) {

            var totalJoltage = 0;
            var banks = input.TrimEnd().Split('\n');
            foreach (var bank in banks) { 
                var bankInts = bank.Select(x => x - '0').ToList();
                var largestNumber = bankInts.Max(x => x);
                bankInts.RemoveAll(x => x == largestNumber);
                var secondLargestNumber = bankInts.Max(x => x);
                if (bank.IndexOf(largestNumber.ToString()[0]) != bank.Length - 1) {
                    var largestNumberInSubstring = GetLargestIntFromString(bank[(bank.IndexOf(largestNumber.ToString()[0])+1)..]);
                    var numberString = largestNumber.ToString() + largestNumberInSubstring.ToString();
                    totalJoltage += int.Parse(numberString);
                    continue;
                } else {
                    var largestNumberInSubstring = GetLargestIntFromString(bank[(bank.IndexOf(secondLargestNumber.ToString()[0])+1)..]);
                    var numberString = secondLargestNumber.ToString() + largestNumberInSubstring.ToString();
                    totalJoltage += int.Parse(numberString);
                }
            }
            Console.WriteLine(totalJoltage);

        }
        public static void SolvePart2(string input) {

            Int64 total = 0;
            var banks = input.TrimEnd().Split('\n');
            foreach (var bank in banks) {
                var currentWorkingBankString = bank;
                string finalString = "";
                for (int i = 12; i > 0; i--)
                {

                    var shortenedString = currentWorkingBankString[..(currentWorkingBankString.Length-i+1)];
                    var largestDigit = GetLargestIntFromString(shortenedString);
                    finalString += largestDigit.ToString();
                    var largestDigitIndex = shortenedString.IndexOf(largestDigit.ToString());
                    currentWorkingBankString = currentWorkingBankString[(largestDigitIndex+1)..];                    
                }
                total += Int64.Parse(finalString);
            }

            Console.WriteLine(total.ToString());

        }

        public static int GetLargestIntFromString(string input)
        {
            var bankInts = input.Select(x => x - '0').ToList();
            var largestNumber = bankInts.Max(x => x);
            return largestNumber;
        }
    }
}
