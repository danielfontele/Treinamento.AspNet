using App.Web.Helpers.Builders;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace App.Web.Helpers
{
    public static class HelperAppTitulo
    {
        public static AppTituloBuilder AppTitulo(this IHtmlHelper htmlHelper, string titulo)
        {
            return new AppTituloBuilder(htmlHelper, titulo);
        }

        //public static AppTituloBuilder AppTituloFor<TModel, TPropriedade>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TPropriedade>> expression)
        //{
        //    var propriedade = System.Web.Mvc.ExpressionHelper.GetExpressionText(expression);
        //    return new AppTituloBuilder(htmlHelper, propriedade);
        //}
    }
}
