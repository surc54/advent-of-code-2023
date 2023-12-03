namespace Shared;

public static class StringExtensions
{
    public static string ReadFile(this string fileName)
    {
        AssertFileExists(fileName);
        return File.ReadAllText(fileName);
    }
    
    public static Task<string> ReadFileAsync(this string fileName)
    {
        AssertFileExists(fileName);
        return File.ReadAllTextAsync(fileName);
    }
    
    public static List<string> SplitByNewLine(this string text, bool allowEmptyLines = false)
    {
        IEnumerable<string> result = text
            .Split('\n', '\r');

        if (!allowEmptyLines)
        {
            result = result.Where(line => !string.IsNullOrWhiteSpace(line));
        }

        return result.ToList();
    }
    
    private static void AssertFileExists(string fileName)
    {
        if (!File.Exists(fileName)) throw new FileNotFoundException($"Could not find file {fileName}");
    }
}
