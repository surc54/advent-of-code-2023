using _02.Models;

namespace _02;

public static class Part2
{
    public static long Run(IEnumerable<Game> games)
    {
        return games
            .Select(game => game.MinimumCubePower)
            .Sum();
    }
}
