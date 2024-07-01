using NumberToTextConverter;

internal class Program
{
    private static void Main(string[] args)
    {
        var text_to_write = TextConverter.WriteLong(123456789.12M);
        Console.WriteLine(text_to_write);
        Console.WriteLine(JsonStringReader.ReadStringsJson());
        Console.WriteLine("Press any key to exit...");
    }
}