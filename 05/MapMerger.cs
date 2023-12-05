using _05.Models;

namespace _05;

public class MapMerger
{
    public Map MergeMap(Map map1, Map map2)
    {
        if (map1.DestinationType != map2.SourceType)
            throw new ArgumentException("Expected map1 destination to be map2 source");

        var newRanges = new List<Map.Range>();

        foreach (var map1Range in map1.Ranges)
        {
            var equiv = GetRangeEquivalent(map1Range, map2.Ranges);
            newRanges.AddRange(equiv);
        }

        return new Map(map1.SourceType, map2.DestinationType, newRanges);
    }

    private static List<Map.Range> GetRangeEquivalent(Map.Range source, IEnumerable<Map.Range> ranges)
    {
        var potentials = ranges.Where(range => source.DestinationStart <= range.SourceEnd && source.DestinationEnd >= range.SourceStart);

        var start = source.DestinationStart;
        var equiv = new List<Map.Range>();

        while (start < source.DestinationEnd)
        {
            var inrange = potentials.FirstOrDefault(r => r.ContainsSource(start));
            if (inrange is null)
            {
                var ahead = potentials.FirstOrDefault(r => r.SourceStart > start);
                if (ahead is null)
                {
                    equiv.Add(new Map.Range(start, start, source.DestinationEnd - start + 1));
                    start = source.DestinationEnd;
                }
                else
                {
                    var end = Math.Min(ahead.SourceStart - 1, source.DestinationEnd);
                    equiv.Add(new Map.Range(start, start, end - start + 1));
                    start = end + 1;
                }
            }
            else
            {
                var end = Math.Min(inrange.SourceEnd, source.DestinationEnd);
                equiv.Add(new Map.Range(start, inrange.GetDestinationValueForSource(start), end - start + 1));
                start = end + 1;
            }
        }

        return equiv;
    }
}
