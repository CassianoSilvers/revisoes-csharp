using System.Globalization;

public static class EntradaNumerica
{
    public static bool TentarConverter(string? entrada, out double numero)
    {
        // Ponto e virgula representam decimais; separadores de milhar nao sao aceitos.
        string? normalizada = entrada?.Replace(',', '.');
        const NumberStyles estilos = NumberStyles.AllowLeadingWhite
            | NumberStyles.AllowTrailingWhite
            | NumberStyles.AllowLeadingSign
            | NumberStyles.AllowDecimalPoint;

        return double.TryParse(normalizada, estilos, CultureInfo.InvariantCulture, out numero)
            && double.IsFinite(numero);
    }
}
