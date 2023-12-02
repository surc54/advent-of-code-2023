using _01;
using Shared;

var lines = await InputHelper.ParseLinesFromFileInArgs(args);

Console.WriteLine("Part 1: {0}", Part1.Run(lines));
Console.WriteLine("Part 2: {0}", Part2.Run(lines));
