using System.Text.Json;
using NumberToTextConverter.Models;

namespace NumberToTextConverter.Services;

class JsonStringReader
{
    /// <summary>
    /// Reads the strings.json file and returns the translations.
    /// </summary>
    /// <returns>The translations read from the strings.json file.</returns>
    public static Translations? ReadStringsJson()
    {
        string jsonFilePath = "../src/strings.json";
        var values = GetValuesFromJson(jsonFilePath);
        return values;
    }

    /// <summary>
    /// Reads the JSON content from a file and deserializes it into a dictionary of translations.
    /// </summary>
    /// <param name="filePath">The path to the JSON file.</param>
    /// <returns>A dictionary of translations.</returns>
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