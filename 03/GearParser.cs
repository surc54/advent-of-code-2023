using System.Text.RegularExpressions;

namespace _03;

public class GearParser
{
    public IEnumerable<int> ParseGears(IList<string> lines)
    {
        var gears = new List<int>();
        
        for (var i = 0; i < lines.Count; i++)
        {
            var previous = i != 0 ? lines[i - 1] : null;
            var next = i != lines.Count - 1 ? lines[i + 1] : null;
            var nums = ParseGearsInLine(lines[i], previous, next);
            
            gears.AddRange(nums);
        }

        return gears;
    }

    private IEnumerable<int> ParseGearsInLine(string current, string? previous, string? next)
    {
        var numberRegex = new Regex(@"\*");
        var matches = numberRegex.Matches(current);
        if (matches.Count == 0) return Enumerable.Empty<int>();

        var gears = new List<int>();
        
        foreach (Match match in matches)
        {
            var index = match.Index;
            var length = match.Length;
            var searchStart = index - 1; 
            var searchEnd = index + length;

            var adjacentNumbers = new List<int>();

            var c1 = FindNumbersInRange(current, searchStart, searchEnd);
            adjacentNumbers.AddRange(c1);

            var c2 = FindNumbersInRange(previous, searchStart, searchEnd);
            adjacentNumbers.AddRange(c2);

            var c3 = FindNumbersInRange(next, searchStart, searchEnd);
            adjacentNumbers.AddRange(c3);

            if (adjacentNumbers.Count == 2)
            {
                gears.Add(adjacentNumbers[0] * adjacentNumbers[1]);
            }

            if (adjacentNumbers.Count > 2) throw new Exception("something went wrong");
        }

        return gears;
    }

    private static IEnumerable<int> FindNumbersInRange(string? line, int startIndex, int endIndex)
    {
        if (line is null) return Enumerable.Empty<int>();
        var numberRegex = new Regex(@"\d+");
        
        startIndex = Math.Max(0, startIndex);
        endIndex = Math.Min(line.Length - 1, endIndex);

        (startIndex, endIndex) = ExpandToFitFullNumber(line, startIndex, endIndex);
        
        var substring = line.Substring(startIndex, endIndex - startIndex + 1);
        var matches = numberRegex.Matches(substring);

        if (matches.Count == 0) return Enumerable.Empty<int>();

        var list = new List<int>();
        foreach (Match match in matches)
        {
            if (match.Success)
            {
                list.Add(int.Parse(match.Value));
            }
        }

        return list;
    }

    private static (int, int) ExpandToFitFullNumber(string line, int start, int end)
    {
        while (char.IsDigit(line[start]) && start > 0)
        {
            start -= 1;
        }
        while (char.IsDigit(line[end]) && end < line.Length - 1)
        {
            end += 1;
        }

        return (start, end);
    }
    
}
