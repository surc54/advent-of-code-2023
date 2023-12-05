using _05.Models;

namespace _05;

public static class Part2
{
    public static long Run(List<string> lines)
    {
        lines = new List<string>(lines);
        var seeds = ParseSeed(lines[0]);
        lines.RemoveAt(0);

        var maps = new MapParser().Run(lines).ToDictionary(keySelector: map => map.SourceType);

        var seedLocationMap = new Dictionary<long, long>();

        foreach (var range in seeds)
        {
            for (var seed = range.SourceStart; seed <= range.SourceEnd; seed++)
            {
                var currentType = "seed";
                var value = seed;

                while (currentType != "location")
                {
                    var map = maps[currentType];
                    value = map.Get(value);
                    currentType = map.DestinationType;
                }

                seedLocationMap.Add(seed, value);
            }
        }

        var lowest = seedLocationMap.Select(pair => pair.Value).Min();

        return lowest;
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
            tuples.Add((nums[i-1], nums[i]));
        }

        return tuples.Select(tuple => new Map.Range(tuple.Item1, 0, tuple.Item2));
    }
}
