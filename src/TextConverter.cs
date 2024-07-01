using System.Transactions;

namespace NumberToTextConverter;

public class TextConverter
{
    public static string WriteLong(decimal valor, string language = "pt")
    {
        Dictionary<string, string> _languageValues = TakeValuesForLanguagee(language);
        var values = JsonStringReader.ReadStringsJson();

        if (valor <= 0 | valor >= 1000000000000000)
            return "Valor não suportado pelo sistema.";
        else
        {
            string strValor = valor.ToString("000000000000000.00");
            string value_in_length = string.Empty;
            for (int i = 0; i <= 15; i += 3)
            {
                value_in_length += Write_Extended_Value(Convert.ToDecimal(strValor.Substring(i, 3)));
                if (i == 0 & value_in_length != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                        value_in_length += $" {_languageValues["1000000000000"]}" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                        value_in_length += $" {_languageValues["1000000000000-plural"]}" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                }
                else if (i == 3 & value_in_length != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                        value_in_length += " BILHÃO" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                        value_in_length += " BILHÕES" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                }
                else if (i == 6 & value_in_length != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                        value_in_length += " MILHÃO" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                        value_in_length += " MILHÕES" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                }
                else if (i == 9 & value_in_length != string.Empty)
                    if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                        value_in_length += " MIL" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);
                if (i == 12)
                {
                    if (value_in_length.Length > 8)
                        if (value_in_length.Substring(value_in_length.Length - 6, 6) == "BILHÃO" | value_in_length.Substring(value_in_length.Length - 6, 6) == "MILHÃO")
                            value_in_length += " DE";
                        else
                            if (value_in_length.Substring(value_in_length.Length - 7, 7) == "BILHÕES" | value_in_length.Substring(value_in_length.Length - 7, 7) == "MILHÕES"
| value_in_length.Substring(value_in_length.Length - 8, 7) == "TRILHÕES")
                            value_in_length += " DE";
                        else
                                if (value_in_length.Substring(value_in_length.Length - 8, 8) == "TRILHÕES")
                            value_in_length += " DE";
                    if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                        value_in_length += " REAL";
                    else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                        value_in_length += " REAIS";
                    if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && value_in_length != string.Empty)
                        value_in_length += " E ";
                }
                if (i == 15)
                    if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                        value_in_length += " CENTAVO";
                    else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                        value_in_length += " CENTAVOS";
            }
            return value_in_length;
        }
    }
    static string Write_Extended_Value(decimal valor, string language = "pt")
    {
        Dictionary<string, string> _languageValues = TakeValuesForLanguagee(language);

        if (valor <= 0)
            return string.Empty;
        else
        {
            string montagem = string.Empty;
            if (valor > 0 & valor < 1)
            {
                valor *= 100;
            }
            string strValor = valor.ToString("000");
            int a = Convert.ToInt32(strValor.Substring(0, 1));
            int b = Convert.ToInt32(strValor.Substring(1, 1));
            int c = Convert.ToInt32(strValor.Substring(2, 1));
            if (a == 1) montagem += (b + c == 0) ? "CEM" : "CENTO";
            else if (a == 2) montagem += "DUZENTOS";
            else if (a == 3) montagem += "TREZENTOS";
            else if (a == 4) montagem += "QUATROCENTOS";
            else if (a == 5) montagem += "QUINHENTOS";
            else if (a == 6) montagem += "SEISCENTOS";
            else if (a == 7) montagem += "SETECENTOS";
            else if (a == 8) montagem += "OITOCENTOS";
            else if (a == 9) montagem += "NOVECENTOS";
            if (b == 1)
            {
                if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "ONZE";
                else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "DOZE";
                else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUATORZE";
                else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "QUINZE";
                else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSEIS";
                else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSETE";
                else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "DEZOITO";
                else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "DEZENOVE";
            }
            else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "VINTE";
            else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TRINTA";
            else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUARENTA";
            else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "CINQUENTA";
            else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "SESSENTA";
            else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "SETENTA";
            else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "OITENTA";
            else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "NOVENTA";
            if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " E ";
            if (strValor.Substring(1, 1) != "1")
                if (c == 1) montagem += "UM";
                else if (c == 2) montagem += "DOIS";
                else if (c == 3) montagem += "TRÊS";
                else if (c == 4) montagem += "QUATRO";
                else if (c == 5) montagem += "CINCO";
                else if (c == 6) montagem += "SEIS";
                else if (c == 7) montagem += "SETE";
                else if (c == 8) montagem += "OITO";
                else if (c == 9) montagem += "NOVE";
            return montagem;
        }
    }

    private static Dictionary<string, string> TakeValuesForLanguagee(string language = "pt")
    {
        Dictionary<string, string> _languageValues;
        var values = JsonStringReader.ReadStringsJson();
        if (values == null)
        {
            throw new Exception("Error reading the language values.");
        }

        if (language == "pt")
            _languageValues = values.Pt;
        else if (language == "en")
            _languageValues = values.En;
        else
            _languageValues = values.Pt;

        return _languageValues;
    }
}

