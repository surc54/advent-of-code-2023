using _06;
using _06.Models;
using Shared;

var lines = args[0].ReadFile().SplitByNewLine();

var part1Product = Part1.Run(lines);
Console.WriteLine("Part 1 Product: {0}", part1Product);

var part2Count = Part2.Run(lines);
Console.WriteLine("Part 2 Count: {0}", part2Count);
