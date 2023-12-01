using _01;

var fileName = args.Length > 0
    ? args[0]
    : throw new InvalidOperationException("File name must be provided as the first argument");
if (!File.Exists(fileName)) throw new FileNotFoundException($"Could not find file {fileName}");

var data = await File.ReadAllTextAsync(fileName);
var lines = data.Split('\n', '\r').Where(line => !string.IsNullOrWhiteSpace(line));

Console.WriteLine("Part 1: {0}", Part1.Run(lines));
Console.WriteLine("Part 2: {0}", Part2.Run(lines));
