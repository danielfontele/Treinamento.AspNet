using System.ComponentModel;

namespace App.Web.Models
{
    public class Funcionario
    {
        [DisplayName("Código")]
        public string Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
