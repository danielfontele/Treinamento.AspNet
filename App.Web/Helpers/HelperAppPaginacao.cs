using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Web.Helpers.Builders;

namespace App.Web.Helpers
{
    public static class HelperAppPaginacao
    {
        public static AppPaginacaoBuilder AppPaginacao<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            string nome)
        {
            return new AppPaginacaoBuilder(htmlHelper, nome);
        }

        public static AppPaginacaoBuilder AppPaginacaoFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var nome = System.Web.Mvc.ExpressionHelper.GetExpressionText(expression);
            return new AppPaginacaoBuilder(htmlHelper, nome);
        }
    }
}
