using _05.Models;

namespace _05;

public static class Part2
{
    public static long Run(List<string> lines)
    {
        lines = new List<string>(lines);
        var seeds = ParseSeed(lines[0]);
        var seedMap = new Map("meme", "seed", seeds);
        lines.RemoveAt(0);

        var maps = new MapParser().Run(lines).ToDictionary(keySelector: map => map.SourceType);

        var seedLocationMap = new Dictionary<long, long>();

        var finalMap = seedMap;
        var merger = new MapMerger();

        while (finalMap.DestinationType != "location")
        {
            var nextMap = maps[finalMap.DestinationType];
            finalMap = merger.MergeMap(finalMap, nextMap);
        }


        return finalMap.Ranges.Select(range => range.DestinationStart).Min();
    }

    private static IEnumerable<Map.Range> ParseSeed(string line)
    {
        var nums = line
            .Split(" ")
            .Skip(1)
            .Select(long.Parse)
            .ToList();

        var tuples = new List<(long, long)>();

        for (var i = 0; i < nums.Count; i++)
        {
            if (i % 2 == 0) continue;
            tuples.Add((nums[i - 1], nums[i]));
        }

        return tuples.Select(tuple => new Map.Range(tuple.Item1, tuple.Item1, tuple.Item2));
    }
}
