using _04.Models;

namespace _04;

public static class Part2
{
    public static int Run(List<string> lines)
    {
        var parser = new CardParser();
        var copyCounts = new Dictionary<int, int>();
        var cards = lines.Select(parser.ParseCard).ToList();

        foreach (var card in cards)
        {
            var multiplier = copyCounts.TryGetValue(card.Id, out var count) ? count + 1 : 1;

            for (var j = 1; j <= card.MatchingCount; j++)
            {
                var key = card.Id + j;
                if (!copyCounts.TryAdd(key, multiplier))
                {
                    copyCounts[key] += multiplier;
                }
            }
        }

        return cards
            .Select(card => card.Id)
            .Select(id => copyCounts.TryGetValue(id, out var count) ? count + 1 : 1)
            .Sum();
    }
}
