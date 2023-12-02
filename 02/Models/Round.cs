namespace _02.Models;

public record Round(Dictionary<string, int> CubesByColor)
{
    public ICollection<string> GetAllColors() => CubesByColor.Keys;
    public bool HasColor(string color) => CubesByColor.ContainsKey(color);
    public int GetCountForColor(string color) => HasColor(color) ? CubesByColor[color] : 0;
}
