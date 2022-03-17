using Antlr.Runtime.Misc;
using App.Web.Helpers.Builders;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace App.Web.Helpers
{
    public static class HelperAppTextBox
    {
        public static AppTextBoxBuilder AppTextBox<TModel, TPropriedade>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TPropriedade>> expression)
        {
            var propriedade = System.Web.Mvc.ExpressionHelper.GetExpressionText(expression);
            return new AppTextBoxBuilder(htmlHelper, propriedade);
        }

    }
}
