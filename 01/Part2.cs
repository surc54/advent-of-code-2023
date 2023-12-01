using System.Text;
using System.Text.RegularExpressions;

internal static partial class Part2
{
  internal static async Task Run(string[] args)
  {
    var fileName = args[0] ?? throw new ArgumentNullException("args[0]", "Specify the input file as the first argument.");
    if (!File.Exists(fileName)) throw new FileNotFoundException($"Could not find file {fileName}");

    var data = await File.ReadAllTextAsync(fileName);
    var lines = data.Split('\n', '\r').Where(line => !string.IsNullOrWhiteSpace(line));

    Console.WriteLine($"Detected {lines.Count()} lines");

    long sum1 = 0;
    long sum2 = 0;
    long sum3 = 0;

    foreach (var line in lines)
    {
      var parsed1 = ParseSpelledNumbers(line);
      var parsed2 = ParseSpelledNumbers2(line);
      var parsed3 = ParseSpelledNumbers3(line);
      if (parsed1 != parsed2)
      {
        Console.WriteLine("-- {0}", line);
        Console.WriteLine("   1: {0}", parsed1);
        Console.WriteLine("   2: {0}", parsed2);
        Console.WriteLine("   3: {0}", parsed3);
      }
      sum1 += GetFirstAndLastDigitsCombined(parsed1);
      sum2 += GetFirstAndLastDigitsCombined(parsed2);
      sum3 += GetFirstAndLastDigitsCombined(parsed3);
    }

    Console.WriteLine("Sum 1: {0}", sum1);
    Console.WriteLine("Sum 2: {0}", sum2);
    Console.WriteLine("Sum 3: {0}", sum3);
  }

  static Dictionary<string, string> numMap = new() {
    { "one", "1" },
    { "two", "2" },
    { "three", "3" },
    { "four", "4" },
    { "five", "5" },
    { "six", "6" },
    { "seven", "7" },
    { "eight", "8" },
    { "nine", "9" }
  };

  static string ParseSpelledNumbers(string text)
  {
    var regex = MyRegex();
    var matches = regex.Matches(text);

    var values = matches.Select(x => x.Value);

    var parsed = text;

    foreach (var value in values)
    {
      parsed = parsed.Replace(value, numMap[value.ToLower()]);
    }

    return parsed;
  }

  static string ParseSpelledNumbers2(string text)
  {
    var regex = MyRegex1();

    var builder = new StringBuilder();

    foreach (var character in text)
    {
      builder.Append(character);
      var match = regex.Match(builder.ToString());
      if (match.Success)
      {
        builder.Replace(match.Value, numMap[match.Value.ToLower()]);
      }
    }

    return builder.ToString();
  }

  static string ParseSpelledNumbers3(string text)
  {
    var regex = MyRegex1();

    var builder = new StringBuilder();
    var final = new StringBuilder();

    foreach (var character in text)
    {
      builder.Append(character);
      final.Append(character);
      var match = regex.Match(builder.ToString());
      if (match.Success)
      {
        final.Append(numMap[match.Value.ToLower()]);
      }
    }

    return final.ToString();
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

  [GeneratedRegex("one|two|three|four|five|six|seven|eight|nine", RegexOptions.IgnoreCase | RegexOptions.Multiline, "en-US")]
  private static partial Regex MyRegex();
  [GeneratedRegex("(?:one|two|three|four|five|six|seven|eight|nine)$")]
  private static partial Regex MyRegex1();
}