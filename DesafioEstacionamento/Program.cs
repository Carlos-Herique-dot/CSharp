using DesafioEstacionamento;
//Variáveis 
string? sEntrada, sHora, placaEntra;
double entrada, hora, pagar, tempo;
List<string> placa = new List<string>();
//Fim variáveis

Funcoes funcoes = new Funcoes();

Console.WriteLine("###### Bem - Vindo ao Estacionamento ######");

Console.WriteLine("Insira o valor da entrada:");
sEntrada = Console.ReadLine();
entrada = funcoes.ConverterDouble(sEntrada);

Console.WriteLine("Insira o valor da hora:");
sHora = Console.ReadLine();
hora = funcoes.ConverterDouble(sHora);

Console.WriteLine($"Valor da entrada {entrada} e valor da hora {hora}");

while (true)
{
    string escolha = funcoes.Menu();
    
    switch (escolha)
    {
        case "1" or "Cadastrar":
            Console.WriteLine("Informe a placa do veículo");
            placaEntra = Console.ReadLine();
            placa.Add(placaEntra!);
            break;

        case "2" or "Remover":
            Console.WriteLine("Informe a placa do veículo");
            placaEntra = Console.ReadLine();
            placa.Remove(placaEntra!);
            break;

        case "3" or "Listar":
           for (int i = 0; i < placa.Count; i++)
           {
                Console.WriteLine($"{i+1} º Placa: {placa[i]}");
           }
            Console.ReadLine();
            break;

        case "4" or "Encerrar":
            Console.WriteLine("Qual placa do seu carro?");
            placaEntra = Console.ReadLine();
            if (placa.Contains(placaEntra!) == false)
            {
                Console.WriteLine("Placa Não Existe");
                Console.ReadKey();
                continue;
            }
            
            Console.WriteLine("Quantas horas ficou?");
            sHora = Console.ReadLine();
            tempo = funcoes.ConverterDouble(sHora);
            pagar = (hora * tempo) + entrada;
            Console.WriteLine($"O valor a pagar é {pagar}");
            Console.WriteLine("Muito Obrigado!");
            Console.ReadKey();
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Nada válido");
            Console.ReadKey();
            break;  
    }    
}





