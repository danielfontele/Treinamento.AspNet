using App.Web.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace App.Web.Helpers.Builders
{
    public class AppTabelaBuilder : IHtmlContent
    {
        private IHtmlHelper _htmlHelper;
        private string _nome;
        private string[] _colunas;
        private string _caminho;
        private string _stringPesquisa;
        private string _caminhoEditar;
        private string[] _colunasBody;

        public AppTabelaBuilder(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
            _colunas = new string[] { };
        }

        public AppTabelaBuilder Colunas(string[] colunas)
        {
            _colunas = colunas;
            return this;
        }

        public AppTabelaBuilder Nome(string nome)
        {
            _nome = nome;
            return this;
        }

        public AppTabelaBuilder CaminhoGet(string caminho)
        {
            _caminho = caminho;
            return this;
        }

        public AppTabelaBuilder Pesquisar(string pesquisa)
        {
            _stringPesquisa = pesquisa;
            return this;
        }

        public AppTabelaBuilder CaminhoEditar(string caminho)
        {
            _caminhoEditar = caminho;
            return this;
        }

        /// <summary>
        /// Para cada elemento, definir em letras minusculas
        /// </summary>
        public AppTabelaBuilder ColunasBody(string[] colunasBody)
        {
            _colunasBody = colunasBody;
            return this;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var model = new AppTabelaModel
            {
                Nome = _nome,
                Colunas = _colunas,
                Caminho = _caminho,
                StringPesquisa = _stringPesquisa,
                CaminhoEditar = _caminhoEditar,
                ColunasBody = _colunasBody,
            };

            _htmlHelper.RenderPartial("_AppTabela", model);
        }
    }
}
