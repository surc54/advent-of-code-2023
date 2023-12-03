using System.Text.RegularExpressions;

namespace _03;

public class PartNumberParser
{
    public IEnumerable<int> ParsePartNumbers(IList<string> lines)
    {
        var partNumbers = new List<int>();
        
        for (var i = 0; i < lines.Count; i++)
        {
            var previous = i != 0 ? lines[i - 1] : null;
            var next = i != lines.Count - 1 ? lines[i + 1] : null;
            var nums = ParsePartNumbersInLine(lines[i], previous, next);
            
            partNumbers.AddRange(nums);
        }

        return partNumbers;
    }

    private IEnumerable<int> ParsePartNumbersInLine(string current, string? previous, string? next)
    {
        var numberRegex = new Regex(@"\d+");
        var matches = numberRegex.Matches(current);
        if (matches.Count == 0) return Enumerable.Empty<int>();

        var partNumbers = new List<int>();
        
        foreach (Match match in matches)
        {
            var index = match.Index;
            var length = match.Length;
            var text = match.Value;

            var isPartNumber = DoesLineHaveSymbolInRange(current, index - 1, index + length);
            if (!isPartNumber && previous is not null)
            {
                isPartNumber = DoesLineHaveSymbolInRange(previous, index - 1, index + length);
            }
            if (!isPartNumber && next is not null)
            {
                isPartNumber = DoesLineHaveSymbolInRange(next, index - 1, index + length);
            }

            if (isPartNumber)
            {
                partNumbers.Add(int.Parse(text));
            }
        }

        return partNumbers;
    }

    private static bool DoesLineHaveSymbolInRange(string line, int startIndex, int endIndex)
    {
        startIndex = Math.Max(0, startIndex);
        endIndex = Math.Min(line.Length - 1, endIndex);

        for (var i = startIndex; i <= endIndex; i++)
        {
            var character = line[i];
            if (!char.IsDigit(character) && character != '.') return true;
        }

        return false;
    }
    
}
