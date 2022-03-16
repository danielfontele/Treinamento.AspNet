using System;

namespace App.Web.Models
{
    [Serializable]
    public class PaginacaoModel : ComponenteModel
    {
        public int Pagina { get; set; }

        public int Quantidade { get; set; }

        public string SeletorTabela { get; set; }

        public string ApiTabela { get; set; }
    }
}
