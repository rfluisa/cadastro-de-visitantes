using CadastroDeVisitantes.Models;
using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace CadastroDeVisitantes.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {

        [HttpPost]
        public bool Login(LoginViewModel usuario)
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.Usuario);
                    if (usuariodb != null && usuariodb.Senha == usuario.Senha)
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public void Cadastro(CadastroPessoaViewModel Cadastro)
        {

        }

        [HttpPost]
        public JsonResult<bool> CadastroUsuario(Usuario usuario)
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.NomeUsuario);
                    if (usuariodb == null)
                    {
                        db.InsertWithIdentity(usuario);
                        return Json(true);
                    }
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(false);
            }

        }

        [HttpPost]
        public List<Usuario> ReadUsuarios()
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var usuarios = db.Usuarios.ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public JsonResult<bool> UpdateUsuario(Usuario usuario)
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.NomeUsuario);
                    if (usuariodb != null)
                    {
                        usuariodb.Senha = usuario.Senha;
                        db.Update(usuariodb);
                        return Json(true);
                    }
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult<bool> DeleteUsuario(Usuario usuario)
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.NomeUsuario);
                    if (usuariodb != null)
                    {
                        db.Delete(usuariodb);
                        return Json(true);
                    }
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}
