namespace _05;

public static class Part1
{
    public static long Run(List<string> lines)
    {
        lines = new List<string>(lines);
        var seeds = lines[0].Split(" ").Skip(1).Select(long.Parse).ToList();
        lines.RemoveAt(0);

        var maps = new MapParser().Run(lines).ToDictionary(keySelector: map => map.SourceType);

        var seedLocationMap = new Dictionary<long, long>();

        foreach (var seed in seeds)
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

        var lowest = seedLocationMap.Select(pair => pair.Value).Min();

        return lowest;
    }
}
