using App.Web.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Web.WebPages;

namespace App.Web.Helpers.Builders
{
    public class AppTextBoxBuilder : IHtmlContent
    {
        private IHtmlHelper _htmlHelper;
        private string _propriedade;
        private bool _habilite;
        private string _placeholder;

        public AppTextBoxBuilder(IHtmlHelper htmlHelper, string propriedade)
        {
            _habilite = true;
            _placeholder = "Novo";
            _htmlHelper = htmlHelper;
            _propriedade = propriedade;
        }

        public AppTextBoxBuilder Habilite(bool habilite)
        {
            _habilite = habilite;
            return this;
        }

        public AppTextBoxBuilder Placeholder(string placeholder)
        {
            _placeholder = placeholder;
            return this;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var nomeDaView = "_textBox";

            var model = new TextBoxModel {
                Propriedade = _propriedade,
                Habilite = _habilite,
                Placeholder = _placeholder
            };

            if (model.Valor == null)
            {
                var modelViewData = _htmlHelper.ViewData.Model;
                model.Valor = ObtenhaValorDaPropriedade(modelViewData, model.Propriedade);
            }

            _htmlHelper.RenderPartial(nomeDaView, model, null);
        }

        private object ObtenhaValorDaPropriedade(object objeto, string nomeDaPropriedade)
        {
            object retorno = null;

            if (objeto != null && nomeDaPropriedade != null)
            {
                // Cobre expressions do tipo x => x.y.z
                if (nomeDaPropriedade.Contains("."))
                {
                    var fimDaPropriedade = nomeDaPropriedade.IndexOf('.');
                    var nomeEspecificoDaPropriedade = nomeDaPropriedade.Substring(0, fimDaPropriedade);
                    var nomeRealDaPropriedade = ObtenhaNomeReal(nomeEspecificoDaPropriedade);
                    var propriedade = objeto.GetType().GetProperty(nomeRealDaPropriedade);

                    if (propriedade != null)
                    {
                        var valor = propriedade.GetValue(objeto, null);

                        if (valor is IEnumerable)
                        {
                            valor = ObtenhaValorDaLista(nomeEspecificoDaPropriedade, valor);
                        }

                        nomeDaPropriedade = nomeDaPropriedade.Substring(fimDaPropriedade + 1);
                        retorno = ObtenhaValorDaPropriedade(valor, nomeDaPropriedade);
                    }
                }
                else
                {
                    var nomeRealDaPropriedade = ObtenhaNomeReal(nomeDaPropriedade);
                    var prop = objeto.GetType().GetProperty(nomeRealDaPropriedade);

                    // Por Ordem:
                    // 1. Cobre expressions do tipo x => x
                    // 2. Cobre expressions do tipo x => x[n]
                    // 3. Outras expressions
                    if (nomeDaPropriedade.IsEmpty())
                    {
                        retorno = objeto;
                    }
                    else if (new Regex(@"^\[\d+\]$").IsMatch(nomeDaPropriedade))
                    {
                        retorno = ObtenhaValorDaLista(nomeDaPropriedade, objeto);
                    }
                    else if (prop != null)
                    {
                        var valor = prop.GetValue(objeto, null);

                        if (nomeDaPropriedade.Contains("[") && valor.GetType() != typeof(string) && valor is IEnumerable)
                        {
                            valor = ObtenhaValorDaLista(nomeDaPropriedade, valor);
                        }

                        retorno = valor;
                    }
                }
            }

            return retorno;
        }

        private object ObtenhaValorDaLista(string nomeDaPropriedade, object objeto)
        {
            object retorno = null;
            var lista = objeto as IList;

            if (lista != null && lista.Count > 0)
            {
                var indice = ObtenhaIndice(nomeDaPropriedade);

                if (indice >= 0)
                {
                    retorno = lista[indice];
                }
            }

            return retorno;
        }

        private int ObtenhaIndice(string nomeDaPropriedade)
        {
            return int.Parse(
                             Regex.Match(nomeDaPropriedade, "\\[\\d+\\]").ToString().Replace("[", string.Empty).Replace("]", string.Empty),
                             CultureInfo.InvariantCulture);
        }

        private string ObtenhaNomeReal(string nomePropriedade)
        {
            var nomeReal = nomePropriedade;

            if (nomeReal.Contains("["))
            {
                var indice = nomeReal.IndexOf('[');
                nomeReal = nomeReal.Substring(0, indice);
            }

            return nomeReal;
        }
    }
}
