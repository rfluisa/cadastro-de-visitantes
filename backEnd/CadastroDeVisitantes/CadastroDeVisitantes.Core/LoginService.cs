using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace CadastroDeVisitantes.Core
{
    public static class LoginService
    {
        public static bool Logar(Usuario usuario)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                usuario.Senha = Criptografia.Criptografar(usuario.Senha);
                var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.NomeUsuario);
                if (usuariodb != null && usuariodb.Senha == usuario.Senha)
                {
                    FormsAuthentication.SetAuthCookie(usuario.NomeUsuario, true);
                    return true;
                }
                FormsAuthentication.SignOut();
                return false;
            }
        }
    }
}
