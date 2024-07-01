using NumberToTextConverter.Enums;
using NumberToTextConverter.Services;

namespace NumberToTextConverter;

/// <summary>
/// Provides methods to convert a double value to its corresponding extended text representation.
/// </summary>
public class TextConverter
{
    //// <summary>
    /// Converts a double value to its corresponding extended text representation.
    /// </summary>
    /// <param name="valor">The double value to convert.</param>
    /// <param name="language">The language to use for the conversion. Default is LanguageEnum.Pt.</param>
    /// <returns>The extended text representation of the double value.</returns>
    public static string WriteLong(double value, LanguageEnum language = LanguageEnum.Pt)
    {
        Dictionary<string, string> _languageValues = GetLanguageValues(language);

        if (value <= 0 | value >= 1000000000000000)
            return "Valor não suportado pelo sistema.";
        else
        {
            string strValor = value.ToString("000000000000000.00");
            string value_in_length = string.Empty;
            for (int i = 0; i <= 15; i += 3)
            {
                value_in_length += Write_Extended_Value(Convert.ToDecimal(strValor.Substring(i, 3)), language);
                if (i == 0 & value_in_length != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                        value_in_length += $" {_languageValues["1000000000000"]}" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? $" {_languageValues[""]} " : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                        value_in_length += $" {_languageValues["1000000000000-plural"]}" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? $" {_languageValues[""]} " : string.Empty);
                }
                else if (i == 3 & value_in_length != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                        value_in_length += $" {_languageValues["000000000"]}" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? $" {_languageValues[""]} " : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                        value_in_length += $" {_languageValues["000000000-plural"]}" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? $" {_languageValues[""]} " : string.Empty);
                }
                else if (i == 6 & value_in_length != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                        value_in_length += $" {_languageValues["000000"]}" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? $" {_languageValues[""]} " : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                        value_in_length += $" {_languageValues["000000-plural"]}" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? $" {_languageValues[""]} " : string.Empty);
                }
                else if (i == 9 & value_in_length != string.Empty)
                    if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                        value_in_length += $" {_languageValues["000"]}" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? $" {_languageValues[""]} " : string.Empty);
                if (i == 12)
                {
                    if (value_in_length.Length > 8)
                        if (value_in_length.Substring(value_in_length.Length - 6, 6) == _languageValues["000000000"] | value_in_length.Substring(value_in_length.Length - 6, 6) == _languageValues["000000"])
                            value_in_length += " DE";
                        else
                            if (value_in_length.Substring(value_in_length.Length - 7, 7) == _languageValues["000000000-plural"] | value_in_length.Substring(value_in_length.Length - 7, 7) == _languageValues["000000-plural"]
| value_in_length.Substring(value_in_length.Length - 8, 7) == _languageValues["1000000000000"])
                            value_in_length += " DE";
                        else
                                if (value_in_length.Substring(value_in_length.Length - 8, 8) == _languageValues["1000000000000-plural"])
                            value_in_length += " DE";
                    if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                        value_in_length += $" {_languageValues["01"]}";
                    else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                        value_in_length += $" {_languageValues["01-plural"]}";
                    if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && value_in_length != string.Empty)
                        value_in_length += $" {_languageValues[""]} ";
                }
                if (i == 15)
                    if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                        value_in_length += $" {_languageValues["1/100"]}";
                    else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                        value_in_length += $" {_languageValues["1/100-plural"]}";
            }
            return value_in_length;
        }
    }
    private static string Write_Extended_Value(decimal valor, LanguageEnum language = LanguageEnum.Pt)
    {
        Dictionary<string, string> _languageValues = GetLanguageValues(language);

        if (valor <= 0)
            return string.Empty;
        else
        {
            string assembly = string.Empty;
            if (valor > 0 & valor < 1)
            {
                valor *= 100;
            }
            string strValor = valor.ToString("000");
            int a = Convert.ToInt32(strValor.Substring(0, 1));
            int b = Convert.ToInt32(strValor.Substring(1, 1));
            int c = Convert.ToInt32(strValor.Substring(2, 1));
            if (a == 1) assembly += (b + c == 0) ? _languageValues["100"] : _languageValues["100-plural"];
            else if (a == 2) assembly += _languageValues["200"];
            else if (a == 3) assembly += _languageValues["300"];
            else if (a == 4) assembly += _languageValues["400"];
            else if (a == 5) assembly += _languageValues["500"];
            else if (a == 6) assembly += _languageValues["600"];
            else if (a == 7) assembly += _languageValues["700"];
            else if (a == 8) assembly += _languageValues["800"];
            else if (a == 9) assembly += _languageValues["900"];
            if (b == 1)
            {
                if (c == 0) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["10"];
                else if (c == 1) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["11"];
                else if (c == 2) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["12"];
                else if (c == 3) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["13"];
                else if (c == 4) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["14"];
                else if (c == 5) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["15"];
                else if (c == 6) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["16"];
                else if (c == 7) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["17"];
                else if (c == 8) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["18"];
                else if (c == 9) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["19"];
            }
            else if (b == 2) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["20"];
            else if (b == 3) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["30"];
            else if (b == 4) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["40"];
            else if (b == 5) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["50"];
            else if (b == 6) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["60"];
            else if (b == 7) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["70"];
            else if (b == 8) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["80"];
            else if (b == 9) assembly += ((a > 0) ? $" {_languageValues[""]} " : string.Empty) + _languageValues["90"];
            if (strValor.Substring(1, 1) != "1" & c != 0 & assembly != string.Empty) assembly += $" {_languageValues[""]} ";
            if (strValor.Substring(1, 1) != "1")
                if (c == 1) assembly += _languageValues["1"];
                else if (c == 2) assembly += _languageValues["2"];
                else if (c == 3) assembly += _languageValues["3"];
                else if (c == 4) assembly += _languageValues["4"];
                else if (c == 5) assembly += _languageValues["5"];
                else if (c == 6) assembly += _languageValues["6"];
                else if (c == 7) assembly += _languageValues["7"];
                else if (c == 8) assembly += _languageValues["8"];
                else if (c == 9) assembly += _languageValues["9"];
            return assembly;
        }
    }
    /// <summary>
    /// Retrieves the language values for the specified language.
    /// </summary>
    /// <param name="language">The language to retrieve the values for. Defaults to LanguageEnum.Pt.</param>
    /// <returns>A dictionary containing the language values.</returns>
    private static Dictionary<string, string> GetLanguageValues(LanguageEnum language = LanguageEnum.Pt)
    {
        Dictionary<string, string>? _languageValues;
        var values = JsonStringReader.ReadStringsJson();

        if (language == LanguageEnum.Pt)
            _languageValues = values?.Pt;
        else
            _languageValues = values?.En;

        return _languageValues ?? throw new Exception("Error reading the language values.");
    }
}

