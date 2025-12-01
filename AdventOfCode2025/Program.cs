// See https://aka.ms/new-console-template for more information
using AdventOfCode2025;

Console.WriteLine("Welcome to the Elf on a Shelf Project Management System");
Console.WriteLine("Please paste input file path:");
var inputPath = Console.ReadLine();
var input = File.ReadAllText(inputPath);
Console.WriteLine("Select operation:");
Console.WriteLine("1. Day 1 part 1");
Console.WriteLine("2. Day 1 part 2");
var operation = Console.Read();

switch (operation)
{
	case '1':
		Day1.SolvePart1(input);
		break;
	case '2':
		Day1.SolvePart2(input); 
		break;
	default:
		break;
}

Console.ReadKey();
