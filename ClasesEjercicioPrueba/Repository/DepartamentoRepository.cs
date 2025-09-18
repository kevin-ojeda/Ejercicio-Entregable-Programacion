using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;

namespace ClasesEjercicioPrueba.Repository
{
    public static class DepartamentoRepository
    {
        // Agregar departamento
        public static void AgregarDepartamento(Departamento departamento)
        {
            using var context = new ApplicationDbContext();
            var existe = (from dep in context.Departamentos
                          where dep.Nombre == departamento.Nombre
                          select dep).FirstOrDefault();

            if (existe == null)
            {
                context.Departamentos.Add(departamento);
                context.SaveChanges();
                Console.WriteLine("Departamento agregado correctamente.");
            }
            else
            {
                Console.WriteLine("Ya existe un departamento con ese nombre.");
            }
        }

        // Obtener todos los departamentos
        public static List<Departamento> ObtenerTodos()
        {
            using var context = new ApplicationDbContext();
            return context.Departamentos.ToList();
        }

        // Obtener por Id
        public static Departamento ObtenerPorId(int id)
        {
            using var context = new ApplicationDbContext();
            return (from dep in context.Departamentos
                    where dep.Id == id
                    select dep).FirstOrDefault();
        }
    }
}
