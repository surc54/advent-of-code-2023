namespace _02.Models;

public record Game
{
    public int Id { get; init; }
    public ICollection<Round> Rounds { get; init; }
    private Dictionary<string, int> maxPerColor = new();
    
    public Game(int Id, ICollection<Round> Rounds)
    {
        this.Id = Id;
        this.Rounds = Rounds;
        
        foreach (var round in this.Rounds)
        {
            foreach (var (color, count) in round.CubesByColor)
            {
                if (maxPerColor.TryGetValue(color, out var value))
                {
                    if (value < count) maxPerColor[color] = count;
                }
                else
                {
                    maxPerColor.Add(color, count);
                }
            }
        }
    }

    public bool IsCubesPossible(Dictionary<string, int> dict)
    {
        foreach (var (color, count) in dict)
        {
            if (!maxPerColor.TryGetValue(color, out var maxSeenCount))
            {
                return false;
            }

            if (maxSeenCount > count) return false;
        }

        return true;
    }
}
