using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Back.Models;

namespace Back.Models
{
    public class Usuarios
    {
        private string? _Senha;
        public string? Nome { get; set; }
        public string? Senha { get{ return BCrypt.Net.BCrypt.HashPassword(_Senha); } set => _Senha = value; }
        public string? Email { get; set; }


        
    }
}