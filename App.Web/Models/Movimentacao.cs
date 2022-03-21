using System;

namespace App.Web.Models
{
    public class Movimentacao : ModeloBase
    {
        public DateTime DataOcorrencia { get; set; }
        public Funcionario Funcionario { get; set; }
        public Departamento DepartamentoAtual { get; set; }
        public Departamento DepartamentoDestino { get; set; }
    }
}
