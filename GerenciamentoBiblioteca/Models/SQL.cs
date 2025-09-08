using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using MySqlConnector;
namespace GerenciamentoBiblioteca.Models
{
    public class SQL
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=biblioteca;password=;");

        public void Inserir(string titulo, string autor, int anoPublicado, int quantidade)
        {
            try
            {
                con.Open();
                Console.WriteLine("Conexão bem-sucedida!");
                string sql = "INSERT INTO livro (Titulo, Autor, AnoPublicado, Quantidade) VALUES (@Titulo, @Autor, @AnoPublicado, @Quantidade)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.Parameters.AddWithValue("@Autor", autor);
                cmd.Parameters.AddWithValue("@AnoPublicado", anoPublicado);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Livro inserido com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao inserir livro: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}