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
    public class VisitaController : ApiController
    {
        [HttpPost]
        [Authorize]
        public bool Cadastro(CadastroPessoaViewModel Cadastro)
        {
            try
            {
                return VisitaService.CadastrarPessoa(new Pessoa()
                {
                    CPF = Cadastro.Cpf,
                    Nome = Cadastro.Nome,
                    Sexo = Cadastro.Sexo,
                    Telefone = Cadastro.Telefone
                });

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [HttpPost]
        [Authorize]
        public Pessoa TestarPessoa(ChecarRegistroViewModel registro)
        {
            try
            {
                return VisitaService.ConsultarPessoa(registro.CPF);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Authorize]
        public bool Visita(CadastroVisitaViewModel visita)
        {
            try
            {
                VisitaService.CadastrarVeiculo(
                    new Carro
                    {
                        Marca = visita.Marca,
                        Modelo = visita.Modelo
                    },
                    new Veiculo
                    {
                        Ano = visita.Ano,
                        Placa = visita.Placa
                    });
                return VisitaService.CadastrarVisita(visita.CPF, visita.Placa, visita.NomeSetor);
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
                return VisitaService.CadastrarVeiculo(
                    new Carro
                    {
                        Marca = veiculo.Marca,
                        Modelo = veiculo.Modelo
                    },
                    new Veiculo
                    {
                        Ano = veiculo.Ano,
                        Placa = veiculo.Placa
                    });
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult<List<HistoricoViewModel>> Historico()
        {
            try
            {

                var pessoas = VisitaService.PesquisaHistorico();

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
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Authorize]
        public List<Visita> Dashboard()
        {
            try
            {
                return VisitaService.PesquisaDashboard();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}