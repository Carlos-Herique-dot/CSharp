using GerenciamentoBiblioteca.Models;
using MySqlConnector;

static string Menu()
{
    Console.Clear();
    Console.WriteLine("Bem-vindo ao Gerenciamento de Biblioteca!");
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Inserir novo livro");
    Console.WriteLine("2 - Listar livros");
    Console.WriteLine("3 - Listar Pessoas Com Livros Emprestados");
    Console.WriteLine("4 - Emprestar livro");
    Console.WriteLine("5 - Devolver livro");
    Console.WriteLine("6 - Sair");
    string? opcao = Console.ReadLine();
    return opcao!;
}

while (true)
{
    switch (Menu())
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Digite o título do livro:");
            string? titulo = Console.ReadLine()!;
            Console.WriteLine("Digite o autor do livro:");
            string? autor = Console.ReadLine()!;
            Console.WriteLine("Digite o ano de publicação do livro (formato: AAAA-MM-DD):");
            int anoPublicado = Convert.ToInt32(Console.ReadLine()!);
            Console.WriteLine("Digite a quantidade de exemplares do livro:");
            int quantidade = int.Parse(Console.ReadLine()!);

            var livro = new Livro(titulo, autor, anoPublicado, quantidade);
            
            livro.InserirLivro();
            Console.ReadKey();
            continue;
    }
}