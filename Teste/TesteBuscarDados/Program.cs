using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TesteBuscarDados;

TesteBuscarDados.BuscarSql busca = new TesteBuscarDados.BuscarSql();
Console.WriteLine("Digite um nome");
string? nome = Console.ReadLine();
busca.BuscarSQL(nome);


