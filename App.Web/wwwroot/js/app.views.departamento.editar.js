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
        //this.$elForm = this.$el.find("form")
        //this.$elSalvar = this.$el.find("[name='salvar']");

        //this.prepareComponentes();

        //this.ligaEventos();


        this.$elSalvar = this.$el.find("[name='salvar']");
        this.$elExcluir = this.$el.find("[name='excluir']");

        this.$elId = this.$el.find("[name='Id']");
        this.$elDescricao = this.$el.find("[name='Descricao']");

        this.ehFluxoDeCadastro = true;

        this.prepareComponentes();

        this.ligaEventos();
    },

    prepareComponentes: function () {
        this.preencheDadosDaTela();
        this.habiliteCampos();
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

    preencheDadosDaTela: function () {
        let id = window.location.search.replace("?", "").split("=")[1];

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
                    let departamento = retorno;

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
        if (this.ehFluxoDeCadastro) {
            this.$elExcluir.hide();
        }

        this.$elId.prop('disabled', true);
        this.$elId.prop('readOnly', true);
        this.$elDescricao.focus();
    },

    salvar: function () {
        //this.$elForm.submit();
        let _this = this;
        let url = location.origin + "/Departamento/Salvar";
        let departamento = {
            codigo: Number(this.$elId.val()),
            descricao: this.$elDescricao.val()
        }
        console.log(this.$elDescricao)
        console.log(this.$elDescricao.val())

        if (!departamento.descricao) {
            let mensagem = "O campo Descrição é obrigatório.";
            alert(mensagem);
            throw (mensagem);
        }

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
        window.location = "index.html";
    },

}