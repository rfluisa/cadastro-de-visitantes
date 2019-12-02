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
    public class LoginController : ApiController
    {
        [HttpPost]
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }


        [HttpPost]
        public bool Login(LoginViewModel usuario)
        {
            try
            {
                return LoginService.Logar(new Usuario { NomeUsuario = usuario.Usuario, Senha = usuario.Senha });
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}