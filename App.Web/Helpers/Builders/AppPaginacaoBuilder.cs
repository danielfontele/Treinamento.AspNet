using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Web.Models;

namespace App.Web.Helpers.Builders
{
    public class AppPaginacaoBuilder : ComponenteBuilder<AppPaginacaoBuilder, PaginacaoModel>
    {
        public AppPaginacaoBuilder(IHtmlHelper htmlHelper, string propriedade)
            : base(htmlHelper, propriedade)
        {
            Model.Quantidade = 0;
        }

        public AppPaginacaoBuilder(IHtmlHelper htmlHelper, Expression<Func<object, object>> propriedade)
            : base(htmlHelper, propriedade)
        {
            Model.Quantidade = 0;
        }

        public AppPaginacaoBuilder Action(string action)
        {
            Model.Action = action;
            return this;
        }

        public AppPaginacaoBuilder Controller(string controller)
        {
            Model.Controller = controller;
            return this;
        }

        public AppPaginacaoBuilder Quantidade(int quantidade)
        {
            Model.Quantidade = quantidade;
            return this;
        }

        public AppPaginacaoBuilder Pagina(int pagina)
        {
            Model.Pagina = pagina;
            return this;
        }

        public AppPaginacaoBuilder ApiTabela(string apiTabela)
        {
            Model.ApiTabela = apiTabela;
            return this;
        }
        public AppPaginacaoBuilder SeletorTabela(string seletorTabela)
        {
            Model.SeletorTabela = seletorTabela;
            return this;
        }

        protected override string ObtenhaNomeDaView()
        {
            return "_Paginacao";
        }
    }
}
