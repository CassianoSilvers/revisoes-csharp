using System.Globalization;

namespace Revisoes_CSharp.Tests;

public class EntradaNumericaTests
{
    [Theory]
    [InlineData("10", 10)]
    [InlineData("-2,5", -2.5)]
    [InlineData("2.5", 2.5)]
    [InlineData(" +3,75 ", 3.75)]
    [InlineData("0", 0)]
    [InlineData("1.234", 1.234)]
    [InlineData("1,234", 1.234)]
    public void TentarConverter_NumeroValido_RetornaValor(string entrada, double esperado)
    {
        Assert.True(EntradaNumerica.TentarConverter(entrada, out double numero));
        Assert.Equal(esperado, numero, precision: 10);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("abc")]
    [InlineData("1.234,56")]
    [InlineData("1,234.56")]
    [InlineData("1,2,3")]
    [InlineData("1 000")]
    [InlineData("NaN")]
    [InlineData("Infinity")]
    [InlineData("-Infinity")]
    [InlineData("1e3")]
    public void TentarConverter_EntradaInvalida_RetornaFalso(string? entrada)
    {
        Assert.False(EntradaNumerica.TentarConverter(entrada, out _));
    }

    [Fact]
    public void TentarConverter_NumeroMaiorQueDouble_RejeitaInfinito()
    {
        Assert.False(EntradaNumerica.TentarConverter(new string('9', 400), out _));
    }

    [Theory]
    [InlineData("pt-BR")]
    [InlineData("en-US")]
    public void TentarConverter_IndependeDaCulturaAtual(string cultura)
    {
        CultureInfo original = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(cultura);
            Assert.True(EntradaNumerica.TentarConverter("1,5", out double comVirgula));
            Assert.True(EntradaNumerica.TentarConverter("1.5", out double comPonto));
            Assert.Equal(1.5, comVirgula);
            Assert.Equal(1.5, comPonto);
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }
    }
}
