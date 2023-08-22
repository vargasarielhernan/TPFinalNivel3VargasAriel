using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(Object user)
        {
            Users usuario = user != null?(Users)user : null;
            if(usuario != null && usuario.Id !=0)
                return true;
            else
                return false;
        }
        public static bool esAdmin(Object user)
        {
            Users usuario = user!=null?(Users)user : null;
            return usuario !=null?usuario.TipoUsuario:false;
        }

    }
}
