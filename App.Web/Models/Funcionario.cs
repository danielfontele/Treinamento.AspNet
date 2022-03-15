using System.ComponentModel;

namespace App.Web.Models
{
    public class Funcionario
    {
        public string Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
