using App.Web.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Text.Encodings.Web;

namespace App.Web.Helpers.Builders
{
    public class AppTituloBuilder : IHtmlContent
    {
        private IHtmlHelper _htmlHelper;
        private string _titulo;

        public AppTituloBuilder(IHtmlHelper htmlHelper, string titulo)
        {
            _htmlHelper = htmlHelper;
            _titulo = titulo;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var model = new AppTituloModel
            {
                Titulo = _titulo,
            };

            _htmlHelper.RenderPartial("_AppTitulo", model, null);
        }
    }
}
