using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroDeVisitantes.Models
{
    public class CadastroPessoaViewModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
    }
}