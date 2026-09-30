using System.Globalization;

public sealed class CalculadoraConsole
{
    private readonly TextReader entrada;
    private readonly TextWriter saida;
    private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("pt-BR");

    public CalculadoraConsole(TextReader entrada, TextWriter saida)
    {
        this.entrada = entrada;
        this.saida = saida;
    }

    public void Executar()
    {
        while (true)
        {
            ExibirMenu();
            saida.Write("Escolha uma opcao: ");
            string? opcao = entrada.ReadLine()?.Trim();

            if (opcao is null or "0")
            {
                break;
            }

            if (opcao is not ("1" or "2" or "3" or "4"))
            {
                saida.WriteLine("Opcao invalida.");
                continue;
            }

            double? primeiroNumero = LerNumero("Digite o primeiro numero: ");
            if (primeiroNumero is null)
            {
                break;
            }

            double? segundoNumero = LerNumero("Digite o segundo numero: ");
            if (segundoNumero is null)
            {
                break;
            }

            ExecutarOperacao(opcao, primeiroNumero.Value, segundoNumero.Value);
        }

        saida.WriteLine("Encerrando a calculadora...");
    }

    private void ExibirMenu()
    {
        saida.WriteLine("=== Calculadora ===");
        saida.WriteLine("1 - Somar");
        saida.WriteLine("2 - Subtrair");
        saida.WriteLine("3 - Multiplicar");
        saida.WriteLine("4 - Dividir");
        saida.WriteLine("0 - Sair");
        saida.WriteLine("Decimais: use virgula ou ponto, sem separador de milhar.");
    }

    private double? LerNumero(string mensagem)
    {
        while (true)
        {
            saida.Write(mensagem);
            string? texto = entrada.ReadLine();

            // Fim da entrada tambem deve encerrar o programa, sem repetir para sempre.
            if (texto is null)
            {
                return null;
            }

            if (EntradaNumerica.TentarConverter(texto, out double numero))
            {
                return numero;
            }

            saida.WriteLine("Entrada invalida. Digite um numero finito, sem separador de milhar.");
        }
    }

    private void ExecutarOperacao(string opcao, double primeiroNumero, double segundoNumero)
    {
        try
        {
            double resultado = opcao switch
            {
                "1" => Calculadora.Somar(primeiroNumero, segundoNumero),
                "2" => Calculadora.Subtrair(primeiroNumero, segundoNumero),
                "3" => Calculadora.Multiplicar(primeiroNumero, segundoNumero),
                "4" => Calculadora.Dividir(primeiroNumero, segundoNumero),
                _ => throw new ArgumentOutOfRangeException(nameof(opcao))
            };

            if (!double.IsFinite(resultado))
            {
                saida.WriteLine("Resultado fora do intervalo suportado.");
                return;
            }

            saida.WriteLine($"Resultado: {resultado.ToString(Cultura)}");
        }
        catch (DivideByZeroException erro)
        {
            saida.WriteLine(erro.Message);
        }
    }
}
