
using App.Servico.Dtos;
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
                Departamento = new Departamento
                {
                    Codigo = dto.Departamento.Codigo,
                    Descricao = dto.Departamento.Descricao
                }
            };

            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario model)
        {
            if (model == null)
            {
                return NotFound();
            }

            var novoRegistro = model.Codigo == 0;

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

            if (novoRegistro)
            {
                _servico.Cadastre(dto);
            }
            else
            {
                _servico.Atualize(dto);
            }

            return RedirectToAction("Index");
        }

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

            var lista = resultado.Lista.Select(x => new Funcionario { Codigo = x.Codigo, Nome = x.Nome, Departamento = new Departamento { Codigo = x.Departamento.Codigo, Descricao = x.Departamento.Descricao } }).ToList();

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
            var lista = listaDto.Select(x => new Funcionario { Codigo = x.Codigo, Nome = x.Nome, Departamento = new Departamento { Codigo = x.Departamento.Codigo, Descricao = x.Departamento.Descricao } }).ToList();

            return Json(lista);
        }

        [HttpGet]
        public IActionResult Consulte(string filtro, int quantidade)
        {
            filtro = filtro != null ? HtmlEncoder.Default.Encode(filtro) : filtro;

            var resultado = _servico.Consulte(filtro, quantidade);

            return Json(resultado);
        }
    }
}
