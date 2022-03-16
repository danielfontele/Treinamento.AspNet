using App.Servico.Dtos;
using App.Servico.Interfaces.Servicos;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Encodings.Web;

namespace App.Web.Controllers
{
    public class DepartamentoController : Controller
    {
        private IServicoDeDepartamento _servico;

        public DepartamentoController(IServicoDeDepartamento servico)
        {
            _servico = servico;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo(int codigo)
        {
            return View("Editar");
        }

        public IActionResult Editar(int codigo)
        {
            var dto = _servico.Consulte(codigo);

            if (dto == null)
            {
                return NotFound();
            }

            var departamento = new Departamento
            {
                Codigo = dto.Codigo,
                Descricao = dto.Descricao,
            };

            return View(departamento);
        }

        [HttpPost]
        public IActionResult Salvar(int codigo, string descricao)
        {
            var departamento = new DtoDepartamento { Codigo = codigo, Descricao = descricao };
            
            _servico.Cadastre(new DtoDepartamento { Codigo = codigo, Descricao = descricao });

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Excluir(int codigo)
        {
            _servico.Exclue(codigo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ConsulteParcial(string filtro)
        {
            int itensPorPagina = int.MaxValue;

            filtro = filtro != null ? HtmlEncoder.Default.Encode(filtro) : filtro;

            var resultado = _servico.ConsultePaginado(filtro, 1, itensPorPagina);

            var lista = resultado.Lista.Select(x => new Departamento { Codigo = x.Codigo, Descricao = x.Descricao }).ToList();

            return Json(lista);
        }

        [HttpGet]
        public IActionResult ConsultPorId(int id)
        {
            var resultado = _servico.Consulte(id);

            return Json(resultado);
        }


        [HttpGet]
        public IActionResult ConsulteLista()
        {            
            var listaDto = _servico.ConsulteLista();
            var lista = listaDto.Select(x => new Departamento { Codigo = x.Codigo, Descricao = x.Descricao }).ToList();

            return Json(lista);
        }
    }
}
