namespace _01;

internal static class Part1
{
    public static long Run(IEnumerable<string> lines)
    {
        long sum = 0;

        foreach (var line in lines)
        {
            var number = GetFirstAndLastDigitsCombined(line);
            sum += number;
        }

        return sum;
    }

    public static int GetFirstAndLastDigitsCombined(string text)
    {
        char? firstDigit = null;
        char? lastDigit = null;

        foreach (var character in text)
        {
            if (!char.IsDigit(character)) continue;

            firstDigit ??= character;
            lastDigit = character;
        }

        if (firstDigit is null || lastDigit is null) throw new ArgumentException("Provided text does not have digits");

        return int.Parse($"{firstDigit}{lastDigit}");
    }
}
