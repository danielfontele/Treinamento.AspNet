using App.Servico.Infraestrutura.Dtos;
using App.Servico.Infraestrutura.Servicos;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.Encodings.Web;

namespace App.Web.Controllers
{
    public abstract class ControladorBase<TServico, TDto, TModel> : Controller
        where TServico : IServicoComCodigoNumerico<TDto>
        where TDto : DtoComCodigoNumerico
        where TModel : ModeloBase
    {
        protected IServicoComCodigoNumerico<TDto> Servico { get; private set; }

        protected ControladorBase(IServicoComCodigoNumerico<TDto> servico)
        {
            Servico = servico;
        }

        public virtual IActionResult Index()
        {
            return View();
        }

        public virtual IActionResult Novo(int codigo)
        {
            return View("Editar");
        }

        public virtual IActionResult Editar(int codigo)
        {
            var dto = Servico.Consulte(codigo);

            if (dto == null)
            {
                return NotFound();
            }

            var model = ConvertaParaModel(dto);

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Salvar(TModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            var novoRegistro = model.Codigo == 0;

            var dto = ConvertaParaDto(model);

            if (novoRegistro)
            {
                Servico.Cadastre(dto);
            }
            else
            {
                Servico.Atualize(dto);
            }

            return RedirectToAction("Index");
        }
        public virtual IActionResult Excluir(int codigo)
        {
            Servico.Exclue(codigo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual IActionResult ConsulteParcial(string filtro)
        {
            int itensPorPagina = int.MaxValue;

            filtro = filtro != null ? HtmlEncoder.Default.Encode(filtro) : filtro;

            var resultado = Servico.ConsultePaginado(filtro, 1, itensPorPagina);

            var lista = resultado.Lista.Select(x =>
            {
                return ConvertaParaModel(x);
            }).ToList();

            return Json(lista);
        }

        [HttpGet]
        public virtual IActionResult ConsultPorId(int id)
        {
            var resultado = Servico.Consulte(id);

            return Json(resultado);
        }

        [HttpGet]
        public virtual IActionResult ConsulteLista()
        {
            var listaDto = Servico.ConsulteLista();

            var lista = listaDto.Select(x =>
            {
                return ConvertaParaModel(x);
            }).ToList();

            return Json(lista);
        }

        [HttpGet]
        public virtual IActionResult Consulte(string filtro, int quantidade)
        {
            filtro = filtro != null ? HtmlEncoder.Default.Encode(filtro) : filtro;

            var resultado = Servico.Consulte(filtro, quantidade);

            return Json(resultado);
        }

        protected abstract TModel ConvertaParaModel(TDto dto);
        protected abstract TDto ConvertaParaDto(TModel model);



    }
}
