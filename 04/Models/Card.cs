namespace _04.Models;

public record Card
{
    public int Id { get; init; }
    public HashSet<int> WinningNumbers { get; init; }
    public HashSet<int> MyNumbers { get; init; }
    public int Points { get; }
    
    public Card(int Id, HashSet<int> WinningNumbers, HashSet<int> MyNumbers)
    {
        this.Id = Id;
        this.WinningNumbers = WinningNumbers;
        this.MyNumbers = MyNumbers;
        this.Points = CalculatePoints();
    }

    private HashSet<int> GetCommonNumbers()
    {
        var set = new HashSet<int>(WinningNumbers);
        set.IntersectWith(MyNumbers);
        return set;
    }

    private int CalculatePoints()
    {
        var common = GetCommonNumbers();
        if (common.Count == 0) return 0;
        return (int)Math.Pow(2, common.Count - 1);
    }
}
