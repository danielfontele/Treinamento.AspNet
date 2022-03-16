definaNamespace("app.views.departamento.edit", {})

app.views.departamento.edit = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido."
    }

    this.$el = $el
    this.$el.data("app.views.departamento.edit", this)
    this.modelParaOClientSide = modelParaOClientSide

    this.options = options ? jQuery.extend({}, this.options, options) : this.options

    this.inicialize()
}

app.views.departamento.edit.prototype = {
    
}