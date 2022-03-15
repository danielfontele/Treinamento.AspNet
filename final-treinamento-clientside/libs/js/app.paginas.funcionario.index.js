var app = { paginas: { funcionario: {} } };

app.paginas.funcionario.index = function($el) {
    if (!$el) {
        throw ("Elemento não definido.")
    }

    this.$el = $el;
    this.db = new bd("listaDeFuncionarios");
    
    $(this.$el).data('paginas-funcionario-index', this);

    this.inicialize();
};

app.paginas.funcionario.index.prototype = {    
    inicialize: function() {
        // mapear os campos
        this.$elFiltro = this.$el.parentElement.querySelector("[name='filtro']");
        this.$elPesquisar = this.$el.parentElement.querySelector("[name='pesquisar']");

        this.$elGrid = this.$el.parentElement.querySelector('[name="grid"]');
        this.$elTbody = this.$el.parentElement.querySelector('[name="grid"] tbody');
        this.$elTotal = this.$el.parentElement.querySelector('[name="grid"] tfoot span'); 

        // preparar componentes
        this.prepareComponentes();

        // ligar os eventos
        this.ligaEventos();
    },

    prepareComponentes: function() {
        var lista = this.db.obtenhaLista();
        this.preencheGrid(lista);
    },

    ligaEventos: function() {
        var _this = this;
        
        $(this.$elGrid).on('click', 'tbody .item', function(e) {
            var id = e.target.parentElement.querySelector("td").innerText;
            location = "editar.html?id=" + id;
        });
        
        this.$elFiltro.addEventListener("keyup", function() {    
            _this.pesquisar();
        });

        this.$elPesquisar.addEventListener("click", function(){
            _this.pesquisar(); 
        });
    },

    preencheGrid: function(lista) {        
        var strTbody = lista.reduce(function(linha, funcionario){
            linha = linha
            .concat("<tr class='item'>")
            .concat("<td>").concat(funcionario.id).concat("</td>")
            .concat("<td>").concat(funcionario.nome).concat("</td>")
            .concat("<td>").concat(funcionario.departamento.id + " - " + funcionario.departamento.descricao).concat("</td>")
            .concat("</tr>")
            
            return linha;
        }, "");
        
        this.$elTbody.innerHTML = strTbody.concat("<tr><td></td><td></td><td></td></tr>");
        this.$elTotal.innerText = lista.length;    
    },

    pesquisar: function() {
        var filtro = this.$elFiltro.value.toLocaleUpperCase();
        var listaDeFuncionarios = this.db.obtenhaLista();
        var lista = listaDeFuncionarios.filter(x => x.nome.toLocaleUpperCase().startsWith(filtro) || x.id.toString().toLocaleUpperCase().startsWith(filtro));
        
        this.preencheGrid(lista);
    }
};