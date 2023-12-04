namespace _04;

public static class Part1
{
    public static int Run(List<string> lines)
    {
        var parser = new CardParser();

        return lines.Select(parser.ParseCard)
            .Select(card => card.Points)
            .Sum();
    }
}
