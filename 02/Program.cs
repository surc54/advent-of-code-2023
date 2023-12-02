using _02;

var fileName = args.Length > 0
    ? args[0]
    : throw new InvalidOperationException("File name must be provided as the first argument");
if (!File.Exists(fileName)) throw new FileNotFoundException($"Could not find file {fileName}");

var data = await File.ReadAllTextAsync(fileName);
var lines = data.Split('\n', '\r').Where(line => !string.IsNullOrWhiteSpace(line));

var gameParser = new GameParser();

var game = lines.Select(gameParser.Parse).ToList();

var check = new Dictionary<string, int>()
{
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 }
};

var part1Sum = Part1.Run(game, check);
var part2Sum = Part2.Run(game);

Console.WriteLine("Got part 1 sum: {0}", part1Sum);
Console.WriteLine("Got part 2 sum: {0}", part2Sum);
