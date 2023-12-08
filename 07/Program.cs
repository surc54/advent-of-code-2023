using _07;
using _07.Models;
using Shared;

var lines ="input.txt".ReadFile().SplitByNewLine();

var hands = new HandParser().Parse(lines).ToList();
hands.Sort();

var sum = 0L;

for (var i = 0; i < hands.Count; i++)
{
    sum += (i + 1) * hands[i].Bid;
}

Console.WriteLine("Part 1 sum: {0}", sum);
