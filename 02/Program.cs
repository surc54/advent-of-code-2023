using _02;
using Shared;

var lines = await InputHelper.ParseLinesFromFileInArgs(args);

var gameParser = new GameParser();
var games = lines.Select(gameParser.Parse).ToList();

var check = new Dictionary<string, int>()
{
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 }
};

var part1Sum = Part1.Run(games, check);
var part2Sum = Part2.Run(games);

Console.WriteLine("Got part 1 sum: {0}", part1Sum);
Console.WriteLine("Got part 2 sum: {0}", part2Sum);
