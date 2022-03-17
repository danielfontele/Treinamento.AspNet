using App.Web.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Text.Encodings.Web;

namespace App.Web.Helpers.Builders
{
    public class AppTextBoxBuilder : IHtmlContent
    {
        private IHtmlHelper _htmlHelper;
        private string _propriedade;

        public AppTextBoxBuilder(IHtmlHelper htmlHelper, string propriedade)
        {
            _htmlHelper = htmlHelper;
            _propriedade = propriedade;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var nomeDaView = "_textBox";

            var model = new ComponenteModel { Propriedade = _propriedade };

            _htmlHelper.RenderPartial(nomeDaView, model, null);
        }
    }
}
