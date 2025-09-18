using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesEjercicioPrueba.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }
        public double Salario { get; set; }

        public Empleado() { }
        public Empleado(string nombre, string email, Departamento departamento, double salario)
        {
            this.Nombre = nombre;
            this.Email = email;
            this.IdDepartamento = departamento.Id;
            this.Departamento = departamento;
            this.Salario = salario;
        }
    }
}
