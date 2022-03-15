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
            // To-Do
            return RedirectToAction("Index");
        }
        public IActionResult Excluir()
        {
            // To-Do
            return RedirectToAction("Index");
        }
    }
}
