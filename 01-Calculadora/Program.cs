string? opcao;

do
{
    Console.WriteLine("=== Calculadora ===");
    Console.WriteLine("1 - Somar");
    Console.WriteLine("2 - Subtrair");
    Console.WriteLine("3 - Multiplicar");
    Console.WriteLine("4 - Dividir");
    Console.WriteLine("0 - Sair");

    Console.Write("Escolha uma opcao: ");
    opcao = Console.ReadLine();

    if (opcao == "0")
    {
        Console.WriteLine("Encerrando a calculadora...");
        break;
    }

    Console.Write("Digite o primeiro numero: ");
    string? entradaPrimeiroNumero = Console.ReadLine();

    Console.Write("Digite o segundo numero: ");
    string? entradaSegundoNumero = Console.ReadLine();

    bool primeiroNumeroValido = double.TryParse(entradaPrimeiroNumero, out double primeiroNumero);
    bool segundoNumeroValido = double.TryParse(entradaSegundoNumero, out double segundoNumero);

    if (primeiroNumeroValido && segundoNumeroValido)
    {
        switch (opcao)
        {
            case "1":
                Console.WriteLine($"Resultado: {Calculadora.Somar(primeiroNumero, segundoNumero)}");
                break;

            case "2":
                Console.WriteLine($"Resultado: {Calculadora.Subtrair(primeiroNumero, segundoNumero)}");
                break;

            case "3":
                Console.WriteLine($"Resultado: {Calculadora.Multiplicar(primeiroNumero, segundoNumero)}");
                break;

            case "4":
                if (segundoNumero == 0)
                {
                    Console.WriteLine("Nao e possivel dividir por zero.");
                }
                else
                {
                    Console.WriteLine($"Resultado: {Calculadora.Dividir(primeiroNumero, segundoNumero)}");
                }
                break;

            default:
                Console.WriteLine("Opcao invalida.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Entrada invalida. Digite apenas numeros.");
    }
}
while (opcao != "0");
