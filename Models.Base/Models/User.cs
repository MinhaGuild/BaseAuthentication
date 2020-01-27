using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Base.Models
{
    /// <summary>
    /// Classe de usuário contendo informações básicas para o login e autenticação desta aplicação.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Actived { get; set; }
    }
}
