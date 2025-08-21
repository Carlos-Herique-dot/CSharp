using System;

public class Calculadora
{
    static double Soma(double sNum, double pNum)
    {
        double resul = sNum + pNum;
        return resul;
    }

    static double Su(double sNum, double pNum)
    {
        double resul = pNum - sNum;
        return resul;
    }

    static double Div(double sNum, double pNum)
    {
        double resul = pNum / sNum;
        return resul;
    }

    static double Mu(double sNum, double pNum)
    {
        double resul = pNum * sNum;
        return resul;
    }
    static void Main()
    {
        double pNum, sNum, val;
        string operacao;

        Console.WriteLine("Essa é uma calculadora simples");
        for (int i = 0; i < 15; i++)
        {
            Console.Write("-*");
        }
        Console.WriteLine();

        while (true)
        {
            while (true)
            {
                Console.WriteLine("Digite o primeiro número:");
                string SpNum = Console.ReadLine()!;
                string parar;
                if (double.TryParse(SpNum, out pNum) == false)
                {
                    Console.WriteLine("Digite um número válido");
                    Console.WriteLine("Ou deseja parar?[S/N]");
                    parar = Console.ReadLine()!;
                    if (parar.ToLower() == "s")
                    {
                        break;
                    }
                    else if (parar.ToLower() == "n")
                    {
                        continue;
                    }
                }
                Console.WriteLine("Digite um segundo número:");
                string SsNum = Console.ReadLine()!;
                if (double.TryParse(SsNum, out sNum) == false)
                {
                    Console.WriteLine("Digite um número válido");
                    Console.WriteLine("Ou deseja parar?[S/N]");
                    parar = Console.ReadLine()!;
                    if (parar.ToLower() == "s")
                    {
                        break;
                    }
                    else if (parar.ToLower() == "n")
                    {
                        continue;
                    }
                }

                Console.WriteLine("Qual operação deseja fazer?[S, Sub, Mu, Di]");
                operacao = Console.ReadLine()!.ToLower();

                switch (operacao)
                {
                    case "s":
                        val = Soma(sNum, pNum);
                        Console.WriteLine($"Resultado: {val}");
                        break;
                    case "sub":
                        val = Su(sNum, pNum);
                        Console.WriteLine($"Resultado: {val}");
                        break;
                    case "mu":
                        val = Mu(sNum, pNum);
                        Console.WriteLine($"Resultado: {val}");
                        break;
                    case "di":
                        val = Div(sNum, pNum);
                        Console.WriteLine($"Resultado: {val}");
                        break;
                }
                break;
            }

            Console.WriteLine("Muito Obrigado");
            Console.WriteLine("Deseja fazer outra operação:[S/N]");
            string outra = Console.ReadLine()!;
            if (outra.ToLower() == "s")
            {
                continue;
            }    
            else if (outra.ToLower() == "n")
            {
                break;
            }
        }
        
    }
}

