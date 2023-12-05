using _05.Models;

namespace _05;

public class MapParser
{
    public List<Map> Run(List<string> lines)
    {
        var maps = new List<Map>();
        var list = new List<string>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (list.Count != 0)
                {
                    maps.Add(ParseMap(list));
                }

                list = new List<string>();
                continue;
            }
            
            list.Add(line);
        }

        return maps;
    }

    private static Map ParseMap(ICollection<string> lines)
    {
        var nameParts = lines.First().Split(" ").First().Split("-to-");
        var source = nameParts[0];
        var destination = nameParts[1];
        var ranges = new List<Map.Range>();

        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(" ");
            var destinationStart = long.Parse(parts[0]);
            var sourceStart = long.Parse(parts[1]);
            var length = long.Parse(parts[2]);

            var range = new Map.Range(sourceStart, destinationStart, length);
            ranges.Add(range);
        }
        
        return new Map(source, destination, ranges);
    }
}
