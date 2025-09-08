using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Models
{
    public class Membro
    {
        private string? _Nome;
        private int _DataNascimento;
        private bool _PegouLivroEmprestado;
        private Livro? _LivroEmprestado;
        public string? Nome { get; set; }
        public int DataNascimento { get; set; }
        public bool PegouLivroEmprestado { get; set; }
        public Livro? LivroEmprestado { get; set; }
        
        
    }
}