# Revisões C#

Repositório de estudos em C#. O primeiro projeto é uma calculadora de console com validação de entradas e testes com xUnit.

## Calculadora

- Soma, subtração, multiplicação e divisão de dois números.
- Validação de entradas e tratamento de divisão por zero.
- Números decimais com vírgula ou ponto.
- Menu para realizar outras operações ou sair.

## Como executar

É necessário ter o [SDK .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0) instalado. Para clonar o repositório, use o Git:

```sh
git clone https://github.com/CassianoSilvers/revisoes-csharp.git
cd revisoes-csharp
dotnet run --project Revisoes-CSharp.csproj
```

Exemplo de soma:

```text
Escolha uma opcao: 1
Digite o primeiro numero: 1,25
Digite o segundo numero: 2.5
Resultado: 3,75
```

## Testes

Na pasta do repositório, execute:

```sh
dotnet test Revisoes-CSharp.slnx
```

O comando restaura as dependências, compila a solução e executa os testes. A primeira execução precisa de acesso ao NuGet.

Os testes verificam as operações, divisão por zero, conversão de decimais, entradas inválidas e o fluxo do console, incluindo a recuperação após erros e o encerramento.

O workflow em `.github/workflows/dotnet.yml` está configurado para compilar e testar a solução em pushes e pull requests no GitHub.

## Observações

- Vírgula e ponto são sempre separadores decimais: `1,5` e `1.5` têm o mesmo valor. Para mil, digite `1000`, sem separador de milhar.
- Os resultados usam vírgula decimal. Texto, valores não finitos e notação científica, como `1e3`, não são aceitos na entrada.
- Os cálculos usam `double`, que pode apresentar pequenas diferenças de precisão. Por exemplo, `0.1 + 0.2` pode resultar em `0,30000000000000004`.
