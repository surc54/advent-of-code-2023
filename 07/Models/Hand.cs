namespace _07.Models;

public record Hand : IComparable<Hand>
{
    public ICollection<CardLabel> Cards { get; init; }
    public int Bid { get; init; }
    public HandType Type { get; }

    public Hand(ICollection<CardLabel> Cards, int Bid)
    {
        this.Cards = Cards;
        this.Bid = Bid;
    }

    public int CompareTo(Hand? other)
    {
        ArgumentNullException.ThrowIfNull(other);

        
    }

    private static HandType GetType(ICollection<CardLabel> labels)
    {
        var distinctCount = labels.Distinct().Count();

        if (distinctCount == 1)
        {
            return HandType.FiveOfAKind;
        } else if (distinctCount == 2)
        {
            // Options:
            // Four of a kind
            // Full house
        } else if (distinctCount == 3)
    }
}
