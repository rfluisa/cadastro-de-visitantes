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
    public class ValuesController : ApiController
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
                using (var db = new CadastroDeVisitantesDB())
                {
                    usuario.Senha = Criptografia.Criptografar(usuario.Senha);
                    var usuariodb = db.Usuarios.FirstOrDefault(user => user.NomeUsuario == usuario.Usuario);
                    if (usuariodb != null && usuariodb.Senha == usuario.Senha)
                    {
                        FormsAuthentication.SetAuthCookie(usuario.Usuario, true);
                        return true;
                    }
                    FormsAuthentication.SignOut();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Authorize]
        public void Cadastro(CadastroPessoaViewModel Cadastro)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                Cadastro.Cpf = Cadastro.Cpf.Replace(".", "");
                db.InsertWithIdentity(new Pessoa()
                {
                    CPF = Cadastro.Cpf,
                    Nome = Cadastro.Nome,
                    Sexo = Cadastro.Sexo,
                    Telefone = Cadastro.Telefone
                });
            }
        }

        [HttpPost]
        [Authorize]
        public bool Visita(CadastroVisitaViewModel visita)
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var idPessoa = db.Pessoas.FirstOrDefault(p => p.CPF == visita.CPF).IDPessoa;
                    var idVeiculo = db.Veiculoes.FirstOrDefault(v => v.Placa == visita.Placa).IDVeiculo;
                    var idSetor = db.Setors.FirstOrDefault(s => s.Nome == visita.NomeSetor).IDSetor;
                    var visit = new Visita()
                    {
                        DataEntrada = DateTime.Now,
                        IDPessoa = idPessoa,
                        IDVeiculo = idVeiculo,
                        IDSetor = idSetor
                    };

                    db.InsertWithIdentity(visit);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Authorize]
        public bool CheckPessoa(string cpf)
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var pessoa = db.Pessoas.FirstOrDefault(p => p.CPF == cpf);
                    if (pessoa != null)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Authorize]
        public bool CadastroVeiculo(CadastroVeiculoViewModel veiculo)
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var carro = db.Carroes.FirstOrDefault(c => c.Marca == veiculo.Marca && c.Modelo == veiculo.Modelo);
                    if (carro == null)
                    {
                        db.InsertWithIdentity(carro);
                        carro = db.Carroes.FirstOrDefault(c => c.Marca == veiculo.Marca && c.Modelo == veiculo.Modelo);
                    }

                    db.InsertWithIdentity(new Veiculo()
                    {
                        Placa = veiculo.Placa,
                        Ano = veiculo.Ano,
                        IDCarro = carro.IDCarro
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult<bool> CadastroUsuario(Usuario usuario)
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    usuario.Senha = Criptografia.Criptografar(usuario.Senha);
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [HttpPost]
        [Authorize]
        public JsonResult<List<HistoricoViewModel>> Historico()
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var pessoas = (from p in db.Pessoas
                                  .LoadWith(v => v.Visitapessoas)
                                  .LoadWith(s => s.Visitapessoas.ElementAtOrDefault(0).VISITASETOR)
                                  .LoadWith(c => c.Visitapessoas.ElementAtOrDefault(0).VISITAVEICULO)
                                   select p).ToList();

                    var historico = new List<HistoricoViewModel>();

                    foreach (var pessoa in pessoas)
                    {
                        foreach (var visita in pessoa.Visitapessoas)
                        {
                            historico.Add(new HistoricoViewModel()
                            {
                                NomePessoa = pessoa.Nome,
                                DataEntrada = visita.DataEntrada,
                                DataSaida = visita.DataSaida,
                                NomeSetor = visita.VISITASETOR.Nome,
                                PlacaCarro = visita.VISITAVEICULO.Placa
                            });
                        }

                    }
                    return Json(historico);
                } 
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult<DashboardViewModel> Dashboard()
        {
            try
            {
                using (var db = new CadastroDeVisitantesDB())
                {
                    var visitas = (from v in db.Visitas
                                   .LoadWith(s => s.VISITASETOR)
                                   orderby v.VISITASETOR.Nome
                                   select v).ToList();

                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
