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
                pessoa.CPF = pessoa.CPF.Replace("-", "");
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
                var setor = db.Setors.FirstOrDefault(s => s.Nome == nomeSetor);
                var idSetor = 0;
                if (setor == null)
                {
                    db.InsertWithIdentity(new Setor()
                    {
                        Nome = nomeSetor
                    });
                    idSetor = db.Setors.ToList().Last().IDSetor;
                }

                var veiculopessoa = db.VeiculoPessoas.FirstOrDefault(v => v.IDPessoa == idPessoa && v.IDVeiculo == idVeiculo);
                if (veiculopessoa == null)
                {
                    veiculopessoa = new VeiculoPessoa()
                    {
                        IDPessoa = idPessoa,
                        IDVeiculo = idVeiculo,
                    };

                    db.InsertWithIdentity(veiculopessoa);
                }

                var visit = new Visita()
                {
                    DataEntrada = DateTime.Now,
                    DataSaida = null,
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
                          .LoadWith(c => c.Veiculospessoas.ElementAtOrDefault(0).VEICULOSVEICULO)
                        select p).FirstOrDefault(pe => pe.CPF == cpf);
            }
        }

        public static bool CadastrarVeiculo(Carro carro, Veiculo veiculo)
        {
            using (var db = new CadastroDeVisitantesDB())
            {
                if (db.Veiculoes.FirstOrDefault(v => v.Placa == veiculo.Placa) != null)
                    return true;
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
