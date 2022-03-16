definaNamespace("app.views.departamento.index", {})

app.views.departamento.index = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido."
    }

    this.$el = $el
    this.$el.data("app.views.departamento.index", this)
    this.modelParaOClientSide = modelParaOClientSide

    this.options = options ? jQuery.extend({}, this.options, options) : this.options

    this.inicialize()
}

app.views.departamento.index.prototype = {

    inicialize: function () {
      // Inicializar propriedades

        this.$elFiltro = this.$el.find("[name='filtro']")
        this.$elPesquisar = this.$el.find("[name='pesquisar']")

        this.$elTabelaItens = this.$el.find("[name='grid'] tbody")
        this.$elTabelaTotal = this.$el.find("[name='grid'] tfoot span")

        this.prepareComponente()

        this.ligaEventos()
    },

    prepareComponente: function () {
        this.pesquisar();
    },

    ligaEventos: function () {
        let _this = this

        this.$elFiltro.on("keyup", function () {
            _this.pesquisar();
        })

        this.$elPesquisar.on("click", function () {
            _this.pesquisar();
        })

        this.$elTabelaItens.on("click", ".item", function () {
            let codigo = $(this).find("[data-codigo]").text()
            _this.editar(codigo)
        })
    },

    pesquisar: function () {
        let _this = this;
        let url = location.origin + "/Departamento/ConsulteParcial";
        let data = {}

        $.ajax({
            type: "GET",
            url: url,
            data: data,
            dataType: "json",
            success: function (retorno) {
                console.log("Sucess Ajax ----------------------")
                _this.preencheTabela(retorno)
            },
            error: function (error) {
                console.log("erro ajax ------------------------")
                console.log(error)
                console.log("----------------------------------")
            }
        })

    },

    preencheTabela: function (dados) {
        let tbody = dados.reduce(function (linhas, departamento) {
            linhas = linhas
                .concat("<tr class='item'>")
                .concat("<td data-codigo='" + departamento.codigo + "' >").concat(departamento.codigo).concat("</td>")
                .concat("<td>").concat(departamento.descricao).concat("</td>")
                .concat("</tr>")

            return linhas
        }, "")

        this.$elTabelaItens.html(tbody.concat("<tr><td></td><td></td></tr>"))
        this.$elTabelaTotal.text(dados.length)
    }
    
}