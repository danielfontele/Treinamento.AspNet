
using App.Servico.Dtos;
using App.Servico.Interfaces.Servicos;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Encodings.Web;

namespace App.Web.Controllers
{
    public class FuncionarioController : ControladorBase<IServicoDeFuncionario, DtoFuncionario, Funcionario>
    {
        public FuncionarioController(IServicoDeFuncionario servico) : base(servico)
        {
        }
        protected override Funcionario ConvertaParaModel(DtoFuncionario dto)
        {
            return new Funcionario
            {
                Codigo = dto.Codigo,
                Nome = dto.Nome,
                Departamento = new Departamento
                {
                    Codigo = dto.Departamento.Codigo,
                    Descricao = dto.Departamento.Descricao
                }
            };
        }

        protected override DtoFuncionario ConvertaParaDto(Funcionario model)
        {
            var dto = new DtoFuncionario
            {
                Codigo = model.Codigo,
                Nome = model.Nome
            };

            dto.Departamento = model.Departamento == null ? null : new DtoDepartamento
            {
                Codigo = model.Departamento.Codigo,
                Descricao = model.Departamento.Descricao
            };

            return dto;
        }
    }
}
