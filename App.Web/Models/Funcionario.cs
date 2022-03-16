namespace App.Web.Models
{
    public class Funcionario
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public Departamento Departamento { get; set; }
    }
}
