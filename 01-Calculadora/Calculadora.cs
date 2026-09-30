public static class Calculadora
{
    public static double Somar(double primeiroNumero, double segundoNumero)
    {
        return primeiroNumero + segundoNumero;
    }
    
    public static double Subtrair(double primeiroNumero, double segundoNumero)
    {
        return primeiroNumero - segundoNumero;
    }

    public static double Multiplicar(double primeiroNumero, double segundoNumero)
    {
        return primeiroNumero * segundoNumero;
    }

    public static double Dividir(double primeiroNumero, double segundoNumero)
    {
        if (segundoNumero == 0)
        {
            throw new DivideByZeroException("Nao e possivel dividir por zero.");
        }

        return primeiroNumero / segundoNumero;
    }
}

