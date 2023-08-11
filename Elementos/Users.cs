using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL=0,
        ADMIN=1
    }
    public class Users
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UrlImagen { get; set; }
        public TipoUsuario TipoUsuario { get; set;}
        public Users(string email, string pass, bool admin)
        {
            Email = email;
            Password= pass;
            TipoUsuario=admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }

    }
}
