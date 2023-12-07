using _07.Models;

namespace _07;

public class HandParser
{
    public IEnumerable<Hand> Parse(IEnumerable<string> lines)
    {
        var hands = new List<Hand>();
        
        foreach (var line in lines)
        {
            var parts = line.Split(" ");
            var labels = parts[0].Select(ParseLabel).ToList();
            var bid = int.Parse(parts[1]);
            hands.Add(new Hand(labels, bid));    
        }

        return hands;
    }

    private static CardLabel ParseLabel(char c)
    {
        return c switch
        {
            '2' => CardLabel.TWO,
            '3' => CardLabel.THREE,
            '4' => CardLabel.FOUR,
            '5' => CardLabel.FIVE,
            '6' => CardLabel.SIX,
            '7' => CardLabel.SEVEN,
            '8' => CardLabel.EIGHT,
            '9' => CardLabel.NINE,
            'T' => CardLabel.TEN,
            'J' => CardLabel.JACK,
            'Q' => CardLabel.QUEEN,
            'K' => CardLabel.KING,
            'A' => CardLabel.ACE,
            _ => throw new ArgumentException($"Character {c} is not valid")
        };
    }
}
