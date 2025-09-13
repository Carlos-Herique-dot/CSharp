using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;



namespace ApiCadastro.Classes
{
    public class Usuarios
    {
        private string? _Nome;
        private string? _Senha;
        public string Nome { get{ return _Nome!; } private set => _Nome = value; }
        public string Senha { get{ return _Senha!; } set => _Senha = value; }

        public void MostrarUsuario()
        {
            Console.WriteLine($"Seu nome é {Nome}\nSua senha é {Senha}");
        }

        public void SalvarMySql()
        {
            var builder = WebApplication.CreateBuilder();
            var stringConexao = builder.Configuration.GetConnectionString("DefaultConnection");

            string sql = "INSERT INTO pessoa (Nome, Senha) VALUES (@nome, @senha)";
            var conexao = new MySqlConnection(stringConexao);

            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conexao);

                cmd.Parameters.AddWithValue("@nome", _Nome);
                cmd.Parameters.AddWithValue("@senha", _Senha);

                var executado = cmd.ExecuteNonQuery();

                Console.WriteLine("Deu certo, olha o MySql");
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                
            }
            finally
            {
                conexao.Close();
            }
        }
    }

}