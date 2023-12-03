namespace _03;

public static class Part1
{
    public static int Run(IList<string> lines)
    {
        return new PartNumberParser()
            .ParsePartNumbers(lines)
            .Sum();
    }
}
