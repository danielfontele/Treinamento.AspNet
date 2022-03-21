using App.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class MovimentacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Movimentacao model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
