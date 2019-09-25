using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroDeVisitantes.Models
{
    public class CadastroPessoaViewModel
    {
        public bool CpfCnpj { get; set; }//true = cpf, false = cnpj
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public bool SexoM { get; set; }
        public bool SexoF { get; set; }
        public bool SexoO { get; set; }
        public string Telefone { get; set; }
    }
}