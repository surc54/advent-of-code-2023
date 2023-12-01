using System.Text;
using System.Text.RegularExpressions;

namespace _01;

internal static partial class Part2
{
    [GeneratedRegex("(?:one|two|three|four|five|six|seven|eight|nine)$")]
    private static partial Regex SpelledOutNumberAtEndOfStringRegex();
    private static readonly Dictionary<string, string> NumMap = new() {
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

    public static long Run(IEnumerable<string> lines)
    {
        long sum = 0;

        foreach (var line in lines)
        {
            var parsedLine = ParseSpelledNumbers(line);
            sum += Part1.GetFirstAndLastDigitsCombined(parsedLine);
        }

        return sum;
    }

    private static string ParseSpelledNumbers(string text)
    {
        var regex = SpelledOutNumberAtEndOfStringRegex();

        var builder = new StringBuilder();
        var final = new StringBuilder();

        foreach (var character in text)
        {
            builder.Append(character);
            final.Append(character);
            var match = regex.Match(builder.ToString());
            if (match.Success)
            {
                final.Append(NumMap[match.Value.ToLower()]);
            }
        }

        return final.ToString();
    }
}
