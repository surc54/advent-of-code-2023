namespace _02.Models;

public record Game
{
    private readonly Dictionary<string, int> _maxPerColor = new();
    
    public int Id { get; }
    private ICollection<Round> Rounds { get; }
    public long MinimumCubePower => _maxPerColor.Values.Aggregate(1L, (acc, cur) => acc * cur);
    
    public Game(int Id, ICollection<Round> Rounds)
    {
        this.Id = Id;
        this.Rounds = Rounds;
        
        foreach (var round in this.Rounds)
        {
            foreach (var (color, count) in round.CubesByColor)
            {
                if (_maxPerColor.TryGetValue(color, out var value))
                {
                    if (value < count) _maxPerColor[color] = count;
                }
                else
                {
                    _maxPerColor.Add(color, count);
                }
            }
        }
    }

    public bool IsCubesPossible(Dictionary<string, int> dict)
    {
        foreach (var (color, count) in dict)
        {
            if (!_maxPerColor.TryGetValue(color, out var maxSeenCount))
            {
                return false;
            }

            if (maxSeenCount > count) return false;
        }

        return true;
    }
}
