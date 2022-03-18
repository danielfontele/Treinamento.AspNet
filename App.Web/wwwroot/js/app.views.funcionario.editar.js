definaNamespace("app.views.funcionario.editar", {})

app.views.funcionario.editar = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido."
    }

    this.$el = $el
    this.$el.data("app.views.funcionario.editar", this)
    this.modelParaOClientSide = modelParaOClientSide

    this.options = options ? jQuery.extend({}, this.options, options) : this.options

    this.inicialize()
}

app.views.funcionario.editar.prototype = {
    inicialize: function () {
        this.$elForm = this.$el.find("form")
        this.$elSalvar = this.$el.find("[name='salvar']");

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
    },

    salvar: function () {
        this.$elForm.submit();
    },

}