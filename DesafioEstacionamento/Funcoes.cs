using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEstacionamento
{
    public class Funcoes
    {
        public double ConverterDouble(string? sValor)
        {
            double valor;
            while (true)
            {
                if (double.TryParse(sValor, out valor) == false)
                {
                    Console.WriteLine("Insira um valor válido");
                    Console.WriteLine("Novo Valor:");
                    sValor = Console.ReadLine();
                    continue;
                }
                else
                {
                    break;
                }
            }
            return valor;
        }

        public string Menu()
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo\n" +
            "2 - Remover veículo\n" +
            "3 - Listar veículos\n" +
            "4 - Encerrar");

            string? escolha = Console.ReadLine();
            if (escolha == "")
            {
                escolha = "4";
            }

            return escolha!;
        }
    }
}