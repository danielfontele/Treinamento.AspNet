using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Web.Helpers.Builders;

namespace App.Web.Helpers
{
    public static class HelperAppCombogridDepartamento
    {
        public static AppCombogridDepartamentoBuilder AppCombogridDepartamento<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            string nome)
        {
            return new AppCombogridDepartamentoBuilder(htmlHelper, nome);
        }

        public static AppCombogridDepartamentoBuilder AppCombogridDepartamentoFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var nome = System.Web.Mvc.ExpressionHelper.GetExpressionText(expression);
            return new AppCombogridDepartamentoBuilder(htmlHelper, nome);
        }
    }
}
