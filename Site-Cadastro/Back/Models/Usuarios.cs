using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Back.Models
{
    public class Usuarios
    {
        private string? _Senha;
        public string? Nome { get; set; }
        public string? Senha { get { return _Senha; } set => _Senha = value; }
        public string? Email { get; set; }


        public void CadastrarUsuario()
        {
            SQL sql = new SQL();
            sql.Cadastrar(Nome!, Senha!, Email!);
        }

        public void LoginUsuario()
        {
            SQL sql = new SQL();
            sql.Login(Email!, Senha!);
        }
        
    }
}