using App.Web.Helpers.Builders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Helpers
{
    public static class HelperAppTabela
    {
        public static AppTabelaBuilder AppTabela(this IHtmlHelper htmlHelper)
        {
            return new AppTabelaBuilder(htmlHelper);
        }
    }
}
