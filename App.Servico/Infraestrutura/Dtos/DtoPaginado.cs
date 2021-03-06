using System;
using System.Collections.Generic;

namespace App.Servico.Infraestrutura.Dtos
{
    [Serializable]
    public class DtoPaginado<TDto> where TDto : DtoComCodigoNumerico
    {
        public int Pagina { get; set; }

        public int Quantidade { get; set; }

        public int TotalDeItens { get; set; }

        public List<TDto> Lista { get; set; }
    }
}
