internal static class Part1
{
  internal static async Task Run(string[] args)
  {
    var fileName = args[0] ?? throw new ArgumentNullException("args[0]", "Specify the input file as the first argument.");
    if (!File.Exists(fileName)) throw new FileNotFoundException($"Could not find file {fileName}");

    var data = await File.ReadAllTextAsync(fileName);
    var lines = data.Split('\n', '\r').Where(line => !string.IsNullOrWhiteSpace(line));

    long sum = 0;

    foreach (var line in lines)
    {
      var number = GetFirstAndLastDigitsCombined(line);
      sum += number;
    }

    Console.WriteLine("Sum: {0}", sum);
  }


  static int GetFirstAndLastDigitsCombined(string text)
  {
    char? firstDigit = null;
    char? lastDigit = null;

    foreach (var character in text)
    {
      if (!char.IsDigit(character)) continue;

      firstDigit ??= character;
      lastDigit = character;
    }

    if (firstDigit is null || lastDigit is null) throw new ArgumentException("Provided text does not have digits");

    return int.Parse($"{firstDigit}{lastDigit}");
  }
}