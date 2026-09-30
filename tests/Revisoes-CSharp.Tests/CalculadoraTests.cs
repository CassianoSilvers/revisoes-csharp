namespace Revisoes_CSharp.Tests;

public class CalculadoraTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-5, 2, -3)]
    [InlineData(0, 0, 0)]
    [InlineData(0.1, 0.2, 0.3)]
    public void Somar_RetornaSoma(double primeiro, double segundo, double esperado)
    {
        Assert.Equal(esperado, Calculadora.Somar(primeiro, segundo), precision: 10);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(2, 5, -3)]
    [InlineData(-5, -2, -3)]
    [InlineData(2.5, 0.75, 1.75)]
    public void Subtrair_RetornaDiferenca(double primeiro, double segundo, double esperado)
    {
        Assert.Equal(esperado, Calculadora.Subtrair(primeiro, segundo), precision: 10);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-2, 3, -6)]
    [InlineData(-2, -3, 6)]
    [InlineData(4, 0, 0)]
    [InlineData(1.5, 2.5, 3.75)]
    public void Multiplicar_RetornaProduto(double primeiro, double segundo, double esperado)
    {
        Assert.Equal(esperado, Calculadora.Multiplicar(primeiro, segundo), precision: 10);
    }

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(-6, 3, -2)]
    [InlineData(0, 3, 0)]
    [InlineData(5, 2, 2.5)]
    [InlineData(1, 3, 0.3333333333)]
    public void Dividir_RetornaQuociente(double primeiro, double segundo, double esperado)
    {
        Assert.Equal(esperado, Calculadora.Dividir(primeiro, segundo), precision: 10);
    }

    [Theory]
    [InlineData(5, 0)]
    [InlineData(0, 0)]
    [InlineData(-5, -0.0)]
    public void Dividir_PorZero_LancaExcecao(double primeiro, double segundo)
    {
        Assert.Throws<DivideByZeroException>(() => Calculadora.Dividir(primeiro, segundo));
    }
}
