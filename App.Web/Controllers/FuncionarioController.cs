using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class FuncionarioController : Controller
    {
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
            return View("Index");
        }
        public IActionResult Excluir()
        {
            return View("Index");
        }
        public IActionResult Cancelar()
        {
            return View("Index");
        }
    }
}
