using System.ComponentModel;

namespace App.Web.Models
{
    public class Departamento
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set;}
    }
}
