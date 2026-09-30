namespace Revisoes_CSharp.Tests;

public class CalculadoraConsoleTests
{
    [Theory]
    [InlineData("1", "8")]
    [InlineData("2", "4")]
    [InlineData("3", "12")]
    [InlineData("4", "3")]
    public void Executar_OperacaoValida_ExibeResultado(string opcao, string esperado)
    {
        string saida = Executar($"{opcao}\n6\n2\n0\n");
        Assert.Contains($"Resultado: {esperado}{Environment.NewLine}", saida);
        Assert.Contains("Encerrando a calculadora...", saida);
    }

    [Fact]
    public void Executar_EntradasInvalidas_PermiteCorrigirEContinuar()
    {
        string saida = Executar("9\n1\nabc\n1,5\n2.5\n0\n");
        Assert.Contains("Opcao invalida.", saida);
        Assert.Contains("Entrada invalida.", saida);
        Assert.Contains($"Resultado: 4{Environment.NewLine}", saida);
    }

    [Fact]
    public void Executar_DivisaoPorZero_ExibeErroEPermiteNovaOperacao()
    {
        string saida = Executar("4\n10\n0\n1\n2\n3\n0\n");
        Assert.Contains("Nao e possivel dividir por zero.", saida);
        Assert.Contains($"Resultado: 5{Environment.NewLine}", saida);
        Assert.DoesNotContain("Infinity", saida);
    }

    [Fact]
    public void Executar_ResultadoDecimal_UsaVirgula()
    {
        string saida = Executar("1\n1.25\n1,5\n0\n");
        Assert.Contains($"Resultado: 2,75{Environment.NewLine}", saida);
    }

    [Fact]
    public void Executar_ResultadoInfinito_ExibeErroEContinua()
    {
        string grande = "1" + new string('0', 308);
        string saida = Executar($"3\n{grande}\n10\n1\n2\n3\n0\n");
        Assert.Contains("Resultado fora do intervalo suportado.", saida);
        Assert.Contains($"Resultado: 5{Environment.NewLine}", saida);
    }

    [Theory]
    [InlineData("0\n")]
    [InlineData("")]
    [InlineData("1\n")]
    [InlineData("1\n2\n")]
    [InlineData("1\nabc\n")]
    public void Executar_SaidaOuFimDaEntrada_EncerraSemCalcular(string entrada)
    {
        string saida = Executar(entrada);
        Assert.Contains("Encerrando a calculadora...", saida);
        Assert.DoesNotContain("Resultado:", saida);
    }

    private static string Executar(string texto)
    {
        using var entrada = new StringReader(texto);
        using var saida = new StringWriter();
        var aplicativo = new CalculadoraConsole(entrada, saida);

        aplicativo.Executar();

        return saida.ToString();
    }
}
