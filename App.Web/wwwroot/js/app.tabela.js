definaNamespace("app.tabela", {})

app.tabela = function ($el, caminhoConsulta, caminhoEditar, $elInput) {
    "use strict"

    if (!$el || !caminhoConsulta) {
        throw "Elemento não definido."
    }

    this.$el = $el
    this.$el.data("app.tabela", this)

    this.caminhoConsulta = caminhoConsulta[0] == '/' ? caminhoConsulta : "/" + caminhoConsulta;
    this.caminhoEditar = caminhoEditar[0] == '/' ? caminhoEditar : "/" + caminhoEditar;
    this.$elInput = $elInput;

    /*this.options = options ? jQuery.extend({}, this.options, options) : this.options*/

    this.inicialize()
}

app.tabela.prototype = {
    inicialize: function () {
        // Inicializar propriedades

        //this.$elFiltro = this.$el.find("[name='filtro']")
        //this.$elPesquisar = this.$el.find("[name='pesquisar']")

        this.$elTabelaItens = this.$el.find("tbody")
        this.$elTabelaTotal = this.$el.find("tfoot span")

        this.prepareComponente()

        this.ligaEventos()
    },

    prepareComponente: function () {
        this.pesquisar();
    },

    ligaEventos: function () {
        let _this = this

        this.$elInput.on("keyup", function () {
            _this.pesquisar();
        })

        //this.$elPesquisar.on("click", function () {
        //    _this.pesquisar();
        //})

        this.$elTabelaItens.on("click", ".item", function () {
            let codigo = $(this).find("[data-codigo]").text()
            _this.editar(codigo)
        })
    },

    pesquisar: function () {
        let _this = this;
        let url = location.origin + this.caminhoConsulta;
        let data = {
            filtro: this.$elInput.val()
        }

        $.ajax({
            type: "GET",
            url: url,
            data: data,
            dataType: "json",
            success: function (retorno) {
                _this.preencheTabela(retorno)
            },
            error: function (error) {
                console.log(error)
            }
        })

    },

    preencheTabela: function (dados) {
        let tbody = dados.reduce(function (linhas, modelo) {

            linhas += '<tr class="item">'


            for (const item in modelo) {
                if (typeof modelo[item] === 'object') {
                    let objetoParaString = "";
                    for (const item2 in modelo[item]) {
                        objetoParaString += `${modelo[item][item2]} - `
                    }
                    objetoParaString = objetoParaString.slice(0, objetoParaString.length - 3)
                    linhas += `<td data-codigo="${objetoParaString.slice(0, 1)}">${objetoParaString}</td>`
                } else {
                    linhas += `<td data-codigo="${modelo[item]}">${modelo[item]}</td>`
                }
            }

            linhas += '</tr>\n'
            return linhas
        }, "")

        this.$elTabelaItens.html(tbody.concat("<tr><td></td><td></td></tr>"))
        this.$elTabelaTotal.text(dados.length)
    },

    editar: function (codigo) {
        window.location.href = location.origin + this.caminhoEditar + codigo
    }


}