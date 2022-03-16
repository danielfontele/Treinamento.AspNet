using App.Servico.Interfaces.Servicos;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Encodings.Web;

namespace App.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        private IServicoDeFuncionario _servico;

        public FuncionarioController(IServicoDeFuncionario servico)
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

            var funcionario = new Funcionario
            {
                Codigo = dto.Codigo,
                Nome = dto.Nome,
            };

            return View(funcionario);
        }

        public IActionResult Salvar()
        {
            // Impl...

            return RedirectToAction("Index");
        }

        public IActionResult Excluir()
        {
            //Impl....

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ConsulteParcial(string filtro)
        {
            int itensPorPagina = int.MaxValue;

            filtro = filtro != null ? HtmlEncoder.Default.Encode(filtro) : filtro;

            var resultado = _servico.ConsultePaginado(filtro, 1, itensPorPagina);

            var lista = resultado.Lista.Select(x => new Funcionario { Codigo = x.Codigo, Nome = x.Nome }).ToList();

            return Json(lista);
        }

        [HttpGet]
        public IActionResult ConsulteLista()
        {
            var listaDto = _servico.ConsulteLista();
            var lista = listaDto.Select(x => new Funcionario { Codigo = x.Codigo, Nome = x.Nome }).ToList();

            return Json(lista);
        }
    }
}
