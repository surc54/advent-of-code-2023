using _04;
using Shared;

var lines = args[0].ReadFile().SplitByNewLine();

var part1Sum = Part1.Run(lines);

Console.WriteLine("Part 1 sum: {0}", part1Sum);
