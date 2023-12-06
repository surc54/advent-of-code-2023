namespace _06;

public class Part1
{
    public static int Run(List<string> lines)
    {
        var races = new InputParser().Parse1(lines);
        var counts = new List<int>();

        foreach (var race in races)
        {
            Console.WriteLine("Race " + race.TotalMilliseconds);

            var midpoint = race.TotalMilliseconds / 2;
            var count = 0;

            for (var i = 0; i < midpoint; i++)
            {
                var backward = midpoint - i;
                var forward = midpoint + i + 1;
                var backwardValid = false;
                var forwardValid = false;

                if (backward > 0 && race.CanBeatRecordWithHoldTime(backward))
                {
                    backwardValid = true;
                    count++;
                }

                if (forward < race.TotalMilliseconds && race.CanBeatRecordWithHoldTime(forward))
                {
                    forwardValid = true;
                    count++;
                }

                if (!backwardValid && !forwardValid) break;
            }
    
            counts.Add(count);
        }

        return counts.Aggregate(1, ((acc, cur) => acc * cur));
    }
}
