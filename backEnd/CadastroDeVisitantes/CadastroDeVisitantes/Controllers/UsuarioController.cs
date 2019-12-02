using CadastroDeVisitantes.Core;
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
using System.Web.Security;

namespace CadastroDeVisitantes.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Authorize]
        public JsonResult<bool> CadastroUsuario(Usuario usuario)
        {
            try
            {
                return Json(UsuarioService.Cadastrar(usuario));
            }
            catch (Exception ex)
            {
                return Json(false);
            }

        }

        [HttpPost]
        [Authorize]
        public List<Usuario> ReadUsuarios()
        {
            try
            {
                return UsuarioService.Ler();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult<bool> UpdateUsuario(Usuario usuario)
        {
            try
            {
                return Json(UsuarioService.Atualizar(usuario));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult<bool> DeleteUsuario(Usuario usuario)
        {
            try
            {
                return Json(UsuarioService.Deletar(usuario));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}