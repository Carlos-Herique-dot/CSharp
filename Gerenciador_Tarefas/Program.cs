using System.Data.SQLite;
using Gerenciador_Tarefas.Models;

Console.WriteLine("Agenda Pessoal\n");
Console.WriteLine("Informe o que você gostaria de fazer:"); 
Console.WriteLine("1 - Adicionar compromisso");
Console.WriteLine("2 - Listar compromissos");
Console.WriteLine("3 - Cancelar compromisso");

ComandosSQLite comandos = new ComandosSQLite();

try
{
    comandos.Conexao();
}
catch (SQLiteException ex)
{
    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
}
finally
{
    Console.WriteLine("Operação finalizada.");
}
