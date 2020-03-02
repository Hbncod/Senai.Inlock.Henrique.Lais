using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuariosDomain
    {
        public int Id_Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Fk_TipoUsuario { get; set; }
        public TipousuarioDomain TipoUsuario { get; set; }
    }
}
