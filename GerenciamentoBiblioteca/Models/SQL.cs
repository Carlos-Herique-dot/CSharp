using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

        public void Listar()
        {
            try
            {
                con.Open();
                string sql = "SELECT Titulo, Autor, AnoPublicado, Quantidade from livro";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tituloLido = reader.GetString(0);
                    string autorLido = reader.GetString(1);
                    int anoPublicadoLido = reader.GetInt32(2);
                    int quantidadeLido = reader.GetInt32(3);

                    Console.WriteLine($"Título: {tituloLido}\nAutor: {autorLido}\nAno de Publicação: {anoPublicadoLido}\nQuantidade: {quantidadeLido}");
                    Console.WriteLine("------------------------------");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao listar livros: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void EmprestarLivro(string titulo)
        {
            try
            {
                con.Open();
                string sql = "UPDATE livro SET Quantidade = Quantidade - 1 WHERE Titulo = @Titulo";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                var comando = cmd.ExecuteNonQuery();
                if (comando == 0)
                {
                    Console.WriteLine("Livro não encontrado ou sem exemplares disponíveis.");
                    return;
                }
                else if (comando < 0)
                {
                    Console.WriteLine("Não há exemplares disponíveis para empréstimo.");
                    return;
                }
                else
                {
                    Console.WriteLine("Livro emprestado com sucesso!");
                }
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}