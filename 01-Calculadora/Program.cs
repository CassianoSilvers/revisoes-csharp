string? opcao;

do
{
    ExibirMenu();

    Console.Write("Escolha uma opcao: ");
    opcao = Console.ReadLine();

    if (opcao == "0")
    {
        Console.WriteLine("Encerrando a calculadora...");
        break;
    }

    double primeiroNumero = LerNumero("Digite o primeiro numero: ");
    double segundoNumero = LerNumero("Digite o segundo numero: ");

    ExecutarOperacao(opcao, primeiroNumero, segundoNumero);


}
while (opcao != "0");

static void ExibirMenu()
{
    Console.WriteLine("=== Calculadora ===");
    Console.WriteLine("1 - Somar");
    Console.WriteLine("2 - Subtrair");
    Console.WriteLine("3 - Multiplicar");
    Console.WriteLine("4 - Dividir");
    Console.WriteLine("0 - Sair");
}

static double LerNumero(string mensagem)
{
    Console.Write(mensagem);
    string? entrada = Console.ReadLine();

    double numero;

    while (!double.TryParse(entrada, out numero))
    {
        Console.WriteLine("Entrada invalida. Digite apenas numeros.");
        Console.Write(mensagem);
        entrada = Console.ReadLine();
    }

    return numero;
}

static void ExecutarOperacao(string? opcao, double primeiroNumero, double segundoNumero)
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
