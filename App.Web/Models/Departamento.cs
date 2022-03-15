using System.ComponentModel;

namespace App.Web.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set;}
    }
}
