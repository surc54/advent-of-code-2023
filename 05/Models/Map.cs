using _05.Extensions;

namespace _05.Models;

public record Map(string SourceType, string DestinationType, IEnumerable<Map.Range> Ranges)
{
    public record Range(long SourceStart, long DestinationStart, long Length)
    {
        public long SourceEnd => SourceStart + Length - 1;
        public long DestinationEnd => DestinationStart + Length - 1;

        public bool ContainsSource(long value)
        {
            return value >= SourceStart && value <= SourceEnd;
        }

        public long GetDestinationValueForSource(long value)
        {
            var offset = value - SourceStart;
            return DestinationStart + offset;
        }
    }

    public long Get(long value)
    {
        foreach (var range in Ranges)
        {
            if (!range.ContainsSource(value)) continue;
            return range.GetDestinationValueForSource(value);
        }

        return value;
    }
}
