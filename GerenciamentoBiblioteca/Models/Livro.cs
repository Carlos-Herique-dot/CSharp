using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Models
{
    public class Livro
    {
        public Livro() { }
        public Livro(string titulo, string autor, int anoPublicado, int quantidade)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicado = anoPublicado;
            Quantidade = quantidade;
        }
        public Livro(string titulo)
        {
            Titulo = titulo;
        }
        private string? _Titulo;
        private string? _Autor;
        private int _AnoPublicado;
        private int _Quantidade;

        public string? Titulo
        {
            get
            {
                return _Titulo;
            }
            set
            {
                _Titulo = value!;
            }
        }

        public string? Autor { get => _Autor; set => _Autor = value!; }
        public int AnoPublicado { get => _AnoPublicado; set => _AnoPublicado = value; }
        public int Quantidade { get => _Quantidade; set => _Quantidade = value; }

        public void InserirLivro()
        {
            SQL sql = new SQL();
            sql.Inserir(_Titulo!, _Autor!, _AnoPublicado, _Quantidade);
        }

        public void ListarLivro()
        {
            SQL sql = new SQL();
            sql.Listar();
            Console.ReadKey();
        }

        public void EmprestarLivro()
        {
            SQL sql = new SQL();
            sql.EmprestarLivro(_Titulo!);
        }

    }
}