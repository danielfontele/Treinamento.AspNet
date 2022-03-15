using System.Collections.Generic;
using System.ComponentModel;

namespace App.Web.Models
{
    public class Departamento
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set;}
        public List<Funcionario> Funcionarios { get; set; }

    }
}
