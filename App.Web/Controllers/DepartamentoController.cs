using App.Servico.Interfaces.Servicos;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public IActionResult Novo()
        {
            return View("Editar");
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
        public IActionResult ConsulteLista()
        {            
            var listaDto = _servico.ConsulteLista();
            var lista = listaDto.Select(x => new Departamento { Codigo = x.Codigo, Descricao = x.Descricao }).ToList();

            return Json(lista);
        }
    }
}
