using System.Text.RegularExpressions;
using _04.Models;

namespace _04;

public class CardParser
{
    public Card ParseCard(string text)
    {
        var regex = new Regex(@"^Card\s+(\d+):\s+([^|]+)\s+\|\s+([^|]+)$");
        var match = regex.Match(text);
        if (!match.Success) throw new ArgumentException("Line does not represent a card");

        var cardId = int.Parse(match.Groups[1].Value);
        var winningNumbers = GetNumList(match.Groups[2].Value).ToHashSet();
        var myNumbers = GetNumList(match.Groups[3].Value).ToHashSet();

        return new Card(cardId, winningNumbers, myNumbers);
    }

    private static IEnumerable<int> GetNumList(string text)
    {
        return new Regex(@"\s+").Split(text.Trim()).Select(int.Parse);
    }
}
