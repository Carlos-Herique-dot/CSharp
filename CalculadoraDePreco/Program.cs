using System;
using System.Formats.Asn1;
using System.Globalization;
using CalculadoraDePreco;

public class Calculadora
{
    static void Main(string[] args)
    {
        Calcular calcular = new Calcular();
        string? SValor, SMargem, SImposto;
        double Valor, Margem, Imposto;

        Console.WriteLine("Calculadora de valor de produtos");
        Console.WriteLine("\nCaso queira sair em algum momento digite sair em qualquer parte\n");
        Console.WriteLine("Informe aqui o valor de custo do seu produto:");

        while (true)
        {
            SValor = Console.ReadLine();
            if (SValor!.Equals("sair", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Muito Obrigado");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (double.TryParse(SValor, out Valor) == false)
            {
                Console.WriteLine("Insira um valor válido");
            }
            else
            {
                calcular.Valor = Valor;
                break;
            }
        }

        Console.WriteLine("Informe a margem de lucro que deseja ter");
        while (true)
        {
            SMargem = Console.ReadLine();
            if (SMargem!.Equals("sair", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Muito Obrigado");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (double.TryParse(SMargem, out Margem) == false)
            {
                Console.WriteLine("Insira um valor válido");
            }
            else
            {
                calcular.Margem = Margem;
                break;
            }
        }

        Console.WriteLine("Informe a porcentagem de imposto");
        while (true)
        {
            SImposto = Console.ReadLine();
            if (SImposto!.Equals("sair", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Muito Obrigado");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (double.TryParse(SImposto, out Imposto) == false)
            {
                Console.WriteLine("Insira um valor válido");
            }
            else
            {
                calcular.Imposto = Imposto;
                break;
            }
        }

        string resultado = calcular.Calculo().ToString("C", new CultureInfo("pt-BR"));
        Console.WriteLine($"O valor do seu produto deve ser {resultado}");
        
        
    }
}