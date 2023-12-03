using _03;
using Shared;

var lines = args[0].ReadFile().SplitByNewLine();

var part1Sum = Part1.Run(lines);
Console.WriteLine("Part 1 Sum: {0}", part1Sum);

var part2Sum = Part2.Run(lines);
Console.WriteLine("Part 2 Sum: {0}", part2Sum);
