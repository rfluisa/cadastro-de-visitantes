using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroDeVisitantes.Models
{
    public class HistoricoViewModel
    {
        public string NomePessoa { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public string NomeSetor { get; set; }
        public string PlacaCarro { get; set; }
    }
}