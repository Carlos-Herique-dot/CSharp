using Gerenciador_Tarefas_SemSQL.Models;
Tarefas tarefas = new Tarefas();

static string ExibirMenu()
{
    Console.Clear();
    Console.WriteLine("===================================");
    Console.WriteLine("      Gerenciador de Tarefas      ");
    Console.WriteLine("===================================");
    Console.WriteLine("Sistema para Gerenciar Tarefas");
    Console.WriteLine("Digite o que deseja fazer:");
    Console.WriteLine("1 - Adicionar Tarefa");
    Console.WriteLine("2 - Listar Tarefas");
    Console.WriteLine("3 - Remover Tarefa");
    Console.WriteLine("4 - Sair\n");
    Console.Write("Opção: ");
    string? opcao = Console.ReadLine();

    return opcao!;

}


while (true)
{
    switch (ExibirMenu())
    {
        case "1":
            Console.WriteLine("Adicionando uma nova tarefa...");
            tarefas.AdicionarTituloTarefa(Console.ReadLine()!);
            continue;

        case "2":
            tarefas.ListarTarefas();
            Console.ReadKey();
            continue;
        case "3":
            tarefas.RemoverTarefa();
            Console.ReadKey();
            continue;
        case "4":
            Console.WriteLine("Obrigado por usar o sistema!");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.ReadKey();
            break;
    }
}

