namespace _03;

public static class Part2
{
    public static int Run(IList<string> lines)
    {
        return new GearParser()
            .ParseGears(lines)
            .Sum();
    }
}
