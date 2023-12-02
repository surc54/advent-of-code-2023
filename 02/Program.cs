using _02;

var fileName = args.Length > 0
    ? args[0]
    : throw new InvalidOperationException("File name must be provided as the first argument");
if (!File.Exists(fileName)) throw new FileNotFoundException($"Could not find file {fileName}");

var data = await File.ReadAllTextAsync(fileName);
var lines = data.Split('\n', '\r').Where(line => !string.IsNullOrWhiteSpace(line));

var gameParser = new GameParser();

var x = lines.Select(gameParser.Parse).ToList();

var check = new Dictionary<string, int>()
{
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 }
};

long part1Sum = 0;
long part2Sum = 0;
foreach (var game in x)
{
    if (game.IsCubesPossible(check)) part1Sum += game.Id;

    var power = game.MaxPerColor.Values.Aggregate(1, (acc, cur) => acc * cur);
    part2Sum += power;
}

Console.WriteLine("Got part 1 sum: {0}", part1Sum);
Console.WriteLine("Got part 2 sum: {0}", part2Sum);
