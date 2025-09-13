using Microsoft.VisualBasic;
using MySqlConnector;
using Back.Models;
using BCrypt.Net;

namespace Back.Models
{
    public class SQL
    {
        Usuarios usuario = new Usuarios();

        public void Cadastrar(string nome, string senha, string email)
        {
            var builder = WebApplication.CreateBuilder();
            var connectionString = builder.Configuration.GetConnectionString("Default");
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                string sql = "INSERT INTO pessoa (Nome, Senha, Email) VALUES (@nome, @senha, @email)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@senha", BCrypt.Net.BCrypt.HashPassword(senha));
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Usuário cadastrado com sucesso.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro" + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void Login(string email, string senha)
        {
            var builder = WebApplication.CreateBuilder();
            var connectionString = builder.Configuration.GetConnectionString("Default");
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                
                string sql = "SELECT Nome, Senha FROM pessoa WHERE Email = @email";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@email", email);

                con.Open();
                var data = cmd.ExecuteReader();

                while (data.Read())
                {
                    string nome = data.GetString("Nome");
                    string senhaHash = data.GetString("Senha");

                    bool compare = BCrypt.Net.BCrypt.Verify(senha, senhaHash);

                    if (nome == "")
                    {
                        Console.WriteLine("Nada Encontrado");
                    }
                    else if (compare == true)
                    {
                        Console.WriteLine($"Senhor {nome} seu login foi feito com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao efetuar login");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}