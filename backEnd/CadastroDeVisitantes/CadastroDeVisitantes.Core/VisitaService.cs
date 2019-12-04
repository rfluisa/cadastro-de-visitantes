using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeVisitantes.Core
{
    public static class VisitaService
    {
        public static bool CadastrarPessoa(Pessoa pessoa)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                pessoa.CPF = pessoa.CPF.Replace(".", "");
                db.InsertWithIdentity(pessoa);
                return true;
            }
        }

        public static bool CadastrarVisita(string cpf, string placa, string nomeSetor)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                var idPessoa = db.Pessoas.FirstOrDefault(p => p.CPF == cpf).IDPessoa;
                var idVeiculo = db.Veiculoes.FirstOrDefault(v => v.Placa == placa).IDVeiculo;
                var idSetor = db.Setors.FirstOrDefault(s => s.Nome == nomeSetor).IDSetor;
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

        public static Pessoa ConsultarPessoa(string cpf)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                return (from p in db.Pessoas
                          .LoadWith(v => v.Veiculospessoas)
                        select p).FirstOrDefault(pe => pe.CPF == cpf);
            }
        }

        public static bool CadastrarVeiculo(Carro carro, Veiculo veiculo)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                var carrodb = db.Carroes.FirstOrDefault(c => c.Marca == carro.Marca && c.Modelo == carro.Modelo);
                if (carrodb == null)
                {
                    db.InsertWithIdentity(carro);
                    carrodb = db.Carroes.ToList().Last();
                }

                db.InsertWithIdentity(new Veiculo()
                {
                    Placa = veiculo.Placa,
                    Ano = veiculo.Ano,
                    IDCarro = carrodb.IDCarro
                });
            }
            return true;
        }

        public static List<Pessoa> PesquisaHistorico()
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                return (from p in db.Pessoas
                              .LoadWith(v => v.Visitapessoas)
                              .LoadWith(s => s.Visitapessoas.ElementAtOrDefault(0).VISITASETOR)
                              .LoadWith(c => c.Visitapessoas.ElementAtOrDefault(0).VISITAVEICULO)
                        select p).ToList();

            }
        }

        public static List<Visita> PesquisaDashboard()
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                return (from v in db.Visitas
                               .LoadWith(s => s.VISITASETOR)
                               orderby v.VISITASETOR.Nome
                               select v).ToList();
            }
        }
    }
}
