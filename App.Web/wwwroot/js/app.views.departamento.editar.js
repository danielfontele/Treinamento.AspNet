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
        debugger;
        // mapear os campos
        this.$elSalvar = this.$el.find("[name='salvar']");
        this.$elExcluir = this.$el.find("[name='excluir']");

        console.log(this.$elSalvar)

        this.$elId = this.$el.find("[name='id']");
        this.$elDescricao = this.$el.find("[name='descricao']");

        this.ehFluxoDeCadastro = true;

        // preparar componentes
        this.prepareComponentes();

        // ligar os eventos
        this.ligaEventos();
    },

    prepareComponentes: function () {
        debugger;
        this.preencheDadosDaTela();
        this.habiliteCampos();
    },

    ligaEventos: function () {
        debugger;
        var _this = this;

        this.$elSalvar.on('click', function () {
            debugger;
            _this.salvar();
            _this.voltarParaTelaInicial();
        });

        this.$elExcluir.on("click", function () {
            _this.excluir();
            _this.voltarParaTelaInicial();
        });
    },

    preencheDadosDaTela: function () {
        debugger;
        var id = window.location.search.replace("?", "").split("=")[1];

        if (id) {
            let _this = this;
            let url = location.origin + "/Departamento/ObtenhaPorId";
            let data = {
                id: id
            }

            $.ajax({
                type: "GET",
                url: url,
                data: data,
                dataType: "json",
                success: function (retorno) {
                    var departamento = retorno;

                    _this.$elId.val(departamento.id);
                    _this.$elDescricao.val(departamento.descricao);

                    _this.ehFluxoDeCadastro = false;
                },
                error: function (error) {
                    console.log("erro ajax - get---------------------")
                    console.log(error)
                    console.log("------------------------------------")
                }
            })
        }
    },

    habiliteCampos: function () {
        debugger;
        if (this.ehFluxoDeCadastro) {
            this.$elExcluir.hide();
        }

        this.$elId.prop('disabled', true);
        this.$elId.prop('readOnly', true);
        this.$elDescricao.focus();
    },

    salvar: function () {
        let _this = this;
        let url = location.origin + "/Departamento/Salvar";
        let departamento = {
            codigo: Number(this.$elId.val()),
            descricao: this.$elDescricao.val()
        }

        debugger;
        if (!departamento.descricao) {
            var mensagem = "O campo Descrição é obrigatório.";
            alert(mensagem);
            throw (mensagem);
        }
        //let sla = departamento, departamentoParaAtualizar => departamentoParaAtualizar.descricao = departamento.descricao;

        console.log("salvar: \n" + id)

        $.ajax({
            type: "POST",
            url: url,
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "aplication/json",
            success: function () {
                
            },
            error: function (error) {
                console.log("erro ajax - post--------------------")
                console.log(error)
                console.log("------------------------------------")
            }
        })

    },

    excluir: function () {
        debugger;
        let _this = this;
        let url = location.origin + "/Departamento/Excluir";
        let data = {
            codigo: Number(this.$elId.val())
        }

        console.log("excluir: \n" + id)

        $.ajax({
            type: "DELETE",
            url: url,
            data: data,
            dataType: "json",
            success: function (retorno) {
                
            },
            error: function (error) {
                console.log("erro ajax - get---------------------")
                console.log(error)
                console.log("------------------------------------")
            }
        })
    },

    voltarParaTelaInicial: function () {
        debugger;
        window.location = "index.html";
    },

}