using _02.Models;

namespace _02;

public static class Part1
{
    public static long Run(IEnumerable<Game> games, Dictionary<string, int> check)
    {
        return games
            .Where(game => game.IsCubesPossible(check))
            .Select(game => game.Id)
            .Sum();
    }
}
