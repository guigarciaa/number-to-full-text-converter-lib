using NumberToTextConverter;
using NumberToTextConverter.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        var text_to_write = TextConverter.WriteLong(42, LanguageEnum.En);
        Console.WriteLine(text_to_write);
    }
}