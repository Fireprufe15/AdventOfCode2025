using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public class Day6
    {
        public static void SolvePart1(string input)
        {
            var lines = input.TrimEnd().Split('\n');
            var problems = new List<Problem>();
            var amountOfCols = lines[0].TrimEnd().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            for (int i = 0; i < amountOfCols; i++) {
                problems.Add(new Problem());
            }
            foreach (var line in lines)
            {
                var lineItems = line.TrimEnd().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (!int.TryParse(lineItems[0], out int result))
                {
                    for (int i = 0; i < lineItems.Length; i++)
                    {
                        problems[i].Operation = lineItems[i][0];
                    }
                }
                else
                {
                    for (int i = 0; i < lineItems.Length; i++) {
                        if (!string.IsNullOrEmpty(lineItems[i]))
                        {
                            problems[i].Numbers.Add(int.Parse(lineItems[i]));
                        }
                    }
                }
            }

            long runningSum = 0;
            foreach (var problem in problems) {
                if (problem.Operation == '*')
                {
                    runningSum += problem.Numbers.Aggregate(1, (long accumulator, long currentNumber) => accumulator * currentNumber);
                } else
                {
                    runningSum += problem.Numbers.Sum();
                }
            }

            Console.WriteLine(runningSum);

        }

        public static void SolvePart2(string input)
        {

            var lines = input.Split('\n');
            var problems = new List<Problem>();

            var operatorLine = lines[4];
            var currentProblem = new Problem();
            for (int i = 0; i < operatorLine.Length; i++)
            {
                if (operatorLine[i] == '*' || operatorLine[i] == '+')
                {
                    currentProblem = new Problem() { Operation = operatorLine[i], ColumnLength = 1 };
                    problems.Add(currentProblem);
                } else
                {
                    currentProblem.ColumnLength++;
                }
            }

            foreach (var problem in problems)
            {
                for (int i = 0; i < problem.ColumnLength; i++)
                {
                    var numberString = "";
                    numberString = $"{lines[0][i]}{lines[1][i]}{lines[2][i]}{lines[3][i]}";
                    if (!string.IsNullOrWhiteSpace(numberString)) problem.Numbers.Add(int.Parse(numberString.Trim()));
                }
                lines[0] = lines[0][problem.ColumnLength..];
                lines[1] = lines[1][problem.ColumnLength..];
                lines[2] = lines[2][problem.ColumnLength..];
                lines[3] = lines[3][problem.ColumnLength..];
            }


            long runningSum = 0;
            foreach (var problem in problems)
            {
                if (problem.Operation == '*')
                {
                    runningSum += problem.Numbers.Aggregate(1, (long accumulator, long currentNumber) => accumulator * currentNumber);
                }
                else
                {
                    runningSum += problem.Numbers.Sum();
                }
            }

            Console.WriteLine(runningSum);

        }
    }

    public class Problem
    {
        public List<long> Numbers { get; set; } = [];
        public char Operation { get; set; }
        public int ColumnLength { get; set; } = 0;
    }
}
