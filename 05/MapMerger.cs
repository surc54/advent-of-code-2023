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
            // map1Range.
        }

        return new Map(map1.SourceType, map2.DestinationType, newRanges);
    }
}
