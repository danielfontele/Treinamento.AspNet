
using System.Collections.Generic;

namespace App.Web.Models
{
    public class AppTabelaModel
    {
        public string Nome { get; set; }
        public string[] Colunas { get; set; }
        public string Caminho { get; set; }
        public string StringPesquisa { get; set; }
        public string CaminhoEditar { get; set; }
        public string[] ColunasBody { get; set; }
    }
}
