namespace Shared;

public static class InputHelper
{
    public static async Task<List<string>> ParseLinesFromFileInArgs(IReadOnlyList<string> args)
    {
        var fileName = args.Count > 0
            ? args[0]
            : throw new InvalidOperationException("File name must be provided as the first argument");

        return (await fileName.ReadFileAsync()).SplitByNewLine();
    }
}
