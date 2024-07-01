using System.Text.Json;
using NumberToTextConverter.Models;

namespace NumberToTextConverter;

public class JsonStringReader
{
    public static Translations? ReadStringsJson()
    {
        string jsonFilePath = "../src/strings.json";
        var values = GetValuesFromJson(jsonFilePath);
        return values;
    }

    private static Translations? GetValuesFromJson(string filePath)
    {
        try
        {
            // Read the file content
            string jsonContent = File.ReadAllText(filePath);

            // Deserialize the JSON content into a dictionary
            var values = JsonSerializer.Deserialize<Translations>(jsonContent);

            return values;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}