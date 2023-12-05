namespace _05.Extensions;

public static class RangeExtensions
{
    public static bool Contains(this Range range, int number)
    {
        return number >= range.Start.Value && number <= range.End.Value;
    }
}
