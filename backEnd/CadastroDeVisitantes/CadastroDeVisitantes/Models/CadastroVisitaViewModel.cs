using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroDeVisitantes.Models
{
    public class CadastroVisitaViewModel
    {
        public string CPF { get; set; }
        public string Placa { get; set; }
        public string NomeSetor { get; set; }
        public string Ano { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}