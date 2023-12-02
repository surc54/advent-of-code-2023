namespace Shared;

public static class InputHelper
{
    public static async Task<List<string>> ParseLinesFromFileInArgs(string[] args)
    {
        var data = await ReadFileFromArgs(args);
        return data
            .Split('\n', '\r')
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();
    }
    
    private static Task<string> ReadFileFromArgs(string[] args)
    {
        var fileName = args.Length > 0
            ? args[0]
            : throw new InvalidOperationException("File name must be provided as the first argument");
        
        if (!File.Exists(fileName)) throw new FileNotFoundException($"Could not find file {fileName}");

        return File.ReadAllTextAsync(fileName);
    }
}
