using System.Text.RegularExpressions;
using _02.Models;

namespace _02;

public class GameParser
{
    public Game Parse(string line)
    {
        var lineRegex = new Regex("^Game (\\d+): (.+)$");

        var match = lineRegex.Match(line);
        if (!match.Success) throw new ArgumentException("Line is not formatted correctly");
        var groups = match.Groups;

        var id = int.Parse(groups[1].Value);
        var rounds = groups[2].Value.Split(";").Select(str => str.Trim()).Select(ParseRound).ToList();
        
        return new Game(id, rounds);
    }

    private Round ParseRound(string text)
    {
        var roundResults = text.Split(",");
        var lineRegex = new Regex("(\\d+) (\\w+)");

        var colorCounts = new Dictionary<string, int>();

        foreach (var roundResult in roundResults)
        {
            var match = lineRegex.Match(roundResult);
            if (!match.Success) throw new ArgumentException("Line could not be parsed as a Round");
            var groups = match.Groups;

            var count = int.Parse(groups[1].Value);
            var color = groups[2].Value;

            colorCounts.Add(color, count);
        }

        return new Round(colorCounts);
    }
}
