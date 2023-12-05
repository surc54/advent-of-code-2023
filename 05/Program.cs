using System.Text.RegularExpressions;
using _05;
using Shared;

var lines = args[0].ReadFile().SplitByNewLine(allowEmptyLines: true);

var part1Lowest = Part1.Run(lines);
Console.WriteLine("Part 1 Lowest: {0}", part1Lowest);

var part2Lowest = Part2.Run(lines);
Console.WriteLine("Part 2 Lowest: {0}", part2Lowest);
