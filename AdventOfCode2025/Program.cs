// See https://aka.ms/new-console-template for more information
using AdventOfCode2025;

/// Note on AI use:
/// I thought it would be fun to compare what Gemini 3 Pro shits out versus what I code myself.
/// The rule I've set for myself is the following: Do the problem, both parts, then submit the answer.
/// If you get both correct, only then am I allowed to go to Gemini to get its version
/// Whenever I do this, I should write a comment explaining what the difference between mine and the AIs solution is.

Console.WriteLine("Welcome to the Elf on a Shelf Project Management System");
Console.WriteLine("Please paste input file path:");
var inputPath = Console.ReadLine();
var input = File.ReadAllText(inputPath);
Console.WriteLine("Select operation:");
Console.WriteLine("1. Day 1 part 1");
Console.WriteLine("1.2. Day 1 part 2");
Console.WriteLine("2. Day 2 part 1");
Console.WriteLine("2.2. Day 2 part 2");
var operation = Console.ReadLine();

switch (operation)
{
	case "1":
		Day1.SolvePart1(input);
		break;
	case "1.2":
		Day1.SolvePart2(input); 
		break;
	case "2":
		Day2.SolvePart1(input);
		break;
	case "2.2":
		Day2.SolvePart2(input);
		break;
	case "101":
        Day1.AISolvePart1(input);
        break;
	case "101.2":
        Day1.AISolvePart2(input);
        break;
	default:
		break;
}

Console.ReadKey();
