using System.Text.RegularExpressions;
using _06.Models;
using Shared;

namespace _06;

public class InputParser
{
    public List<Race> Parse1(List<string> lines)
    {
        var spaceRegex = new Regex(@"\s+");

        var times = spaceRegex.Split(lines[0]).Skip(1).Select(int.Parse);
        var distances = spaceRegex.Split(lines[1]).Skip(1).Select(int.Parse);
        var pairs = times.Zip(distances).Select(tuple => new Race(tuple.First, tuple.Second));

        return pairs.ToList();
    }
    
    public Race Parse2(List<string> lines)
    {
        var spaceRegex = new Regex(@"\s+");

        var time = long.Parse(spaceRegex.Split(lines[0]).Skip(1).StringJoin(""));
        var distance = long.Parse(spaceRegex.Split(lines[1]).Skip(1).StringJoin(""));

        return new Race(time, distance);
    }
}
