using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Gerenciador_Tarefas.Models
{
    public class ComandosSQLite
    {
        private string connectionString = @"/Arquivos/agenda.db";
        private string dataSource = @"/Arquivos/agenda.db";
        public void Conexao()
        {
            using (SQLiteConnection conexao = new SQLiteConnection(connectionString))
            {

                conexao.Open();
                Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS compromissos (
                                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            titulo TEXT NOT NULL,
                                            data TEXT NOT NULL,
                                            hora TEXT NOT NULL, 
                                            anotacao TEXT
                                        );";
                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, conexao))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Tabela 'compromissos' criada ou já existe.");
                }
                
            }
       }
    }
}