namespace _07.Models;

public record Hand : IComparable<Hand>
{
    public IReadOnlyList<CardLabel> Cards { get; init; }
    public int Bid { get; init; }
    public HandType Type { get; }

    public Hand(IReadOnlyList<CardLabel> Cards, int Bid)
    {
        this.Cards = Cards;
        this.Bid = Bid;
        this.Type = GetType(this.Cards);
    }

    public int CompareTo(Hand? other)
    {
        ArgumentNullException.ThrowIfNull(other);

        if (Type == other.Type)
        {
            int mine;
            int theirs;
            var index = 0;

            do
            {
                mine = (int)Cards[index];
                theirs = (int)other.Cards[index];
                index++;
            } while (mine == theirs);

            return mine.CompareTo(theirs);
        }
        else
        {
            return Type.CompareTo(other.Type);
        }
    }

    private static HandType GetType(IEnumerable<CardLabel> labels)
    {
        var labelCount = labels
            .GroupBy(label => label)
            .ToDictionary(
                group => group.Key,
                group => group.Count()
            );
        var distinctCount = labelCount.Count;

        return distinctCount switch
        {
            1 => HandType.FiveOfAKind,
            2 when labelCount.Values.Any(count => count == 4) => HandType.FourOfAKind,
            2 => HandType.FullHouse,
            3 when labelCount.Values.Any(count => count == 3) => HandType.ThreeOfAKind,
            3 => HandType.TwoPair,
            4 => HandType.OnePair,
            5 => HandType.HighCard,
            _ => throw new InvalidDataException("This shouldn't happen (TM)")
        };
    }
}
