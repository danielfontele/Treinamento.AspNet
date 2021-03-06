using System.Collections.Generic;

namespace App.Servico.Infraestrutura.Objetos
{
    public class ObjetoPaginado<TObjeto> where TObjeto : ObjetoComCodigoNumerico
    {
        public int Pagina { get; set; }

        public int Quantidade { get; set; }

        public int TotalDeItens { get; set; }

        public List<TObjeto> Lista { get; set; }
    }
}
