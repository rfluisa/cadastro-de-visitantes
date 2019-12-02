using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeVisitantes.Core
{
    public static class UsuarioService
    {
        public static bool Cadastrar(Usuario usuario)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                usuario.Senha = Criptografia.Criptografar(usuario.Senha);
                var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.NomeUsuario);
                if (usuariodb == null)
                {
                    db.InsertWithIdentity(usuario);
                    return true;
                }
            }
            return false;
        }

        public static List<Usuario> Ler()
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                var usuarios = db.Usuarios.ToList();
                return usuarios;
            }
        }

        public static bool Atualizar(Usuario usuario)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.NomeUsuario);
                if (usuariodb != null)
                {
                    usuariodb.Senha = Criptografia.Criptografar(usuario.Senha);
                    db.Update(usuariodb);
                    return true;
                }
            }
            return false;
        }

        public static bool Deletar(Usuario usuario)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.NomeUsuario);
                if (usuariodb != null)
                {
                    db.Delete(usuariodb);
                    return true;
                }
            }
            return false;
        }
    }
}
