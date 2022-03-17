definaNamespace("app.views.departamento.editar", {})

app.views.departamento.editar = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido."
    }

    this.$el = $el
    this.$el.data("app.views.departamento.editar", this)
    this.modelParaOClientSide = modelParaOClientSide

    this.options = options ? jQuery.extend({}, this.options, options) : this.options

    this.inicialize()
}

app.views.departamento.editar.prototype = {
    inicialize: function () {
        this.$elForm = this.$el.find("form")
        this.$elSalvar = this.$el.find("[name='salvar']");
        this.$elExcluir = this.$el.find("[name='excluir']")

        this.prepareComponentes();

        this.ligaEventos();
    },

    prepareComponentes: function () {
        
    },

    ligaEventos: function () {
        let _this = this;

        this.$elSalvar.on('click', function () {
            _this.salvar();
        });

        this.$elExcluir.on("click", function () {
            _this.excluir();
        });
    },

    salvar: function () {
        this.$elForm.submit();
    },

    excluir: function () {

    }
}