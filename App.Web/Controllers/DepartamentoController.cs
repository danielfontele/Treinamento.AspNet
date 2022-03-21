
using App.Servico.Dtos;
using App.Servico.Infraestrutura.Servicos;
using App.Servico.Interfaces.Servicos;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Encodings.Web;

namespace App.Web.Controllers
{
    public class DepartamentoController : ControladorBase<IServicoDeDepartamento, DtoDepartamento, Departamento>
    {
        public DepartamentoController(IServicoComCodigoNumerico<DtoDepartamento> servico) : base(servico)
        {
        }

        protected override Departamento ConvertaParaModel(DtoDepartamento dto)
        {
            return new Departamento
            {
                Codigo = dto.Codigo,
                Descricao = dto.Descricao,
            };
        }

        protected override DtoDepartamento ConvertaParaDto(Departamento model)
        {
            return new DtoDepartamento
            {
                Codigo = model.Codigo,
                Descricao = model.Descricao,
            };
        }
    }
}
