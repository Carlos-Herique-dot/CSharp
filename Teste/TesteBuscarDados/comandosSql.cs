using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
namespace TesteBuscarDados
{
    public class BuscarSql
    {
            private readonly string stringConexao = "Server=localhost;DataBase=testesdeconexao;Uid=root;Pwd=;";

    public void BuscarSQL(string? nomeCliente)
    {
        using var conexao = new MySqlConnection(stringConexao);
        string sql = "SELECT Id, Nome, Telefone FROM testes WHERE Nome = @nome";
        try
        {
            conexao.Open();

            Console.WriteLine("Conexão feita com sucesso");

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            comando.Parameters.AddWithValue("@nome", nomeCliente);
            using var reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string? nome = reader.GetString(1).ToString();
                    string? telefone = reader.GetInt32(2).ToString();

                    Console.WriteLine($"Nome: {nome}, Telefone: {telefone}");
                }
            }
            else
            {
                Console.WriteLine("Não existe registro");
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            conexao.Close();
        }
    }

    }
}