using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;

namespace ClasesEjercicioPrueba.Repository
{
    public static class EmpleadoRepository
    {
        public static void AgregarEmpleado(Empleado empleado)
        {
            using var context = new ApplicationDbContext();

            var existe = (from emp in context.Empleados
                          where emp.Email == empleado.Email
                          select emp).FirstOrDefault();

            if (existe == null)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                Console.WriteLine("Empleado agregado correctamente.");
            }
            else
            {
                Console.WriteLine("Ya existe un empleado con ese email.");
            }
        }

        // Actualizar salario
        public static void ActualizarSalario(string email, double nuevoSalario)
        {
            using var context = new ApplicationDbContext();

            var empleado = (from emp in context.Empleados
                            where emp.Email == email
                            select emp).FirstOrDefault();

            if (empleado != null)
            {
                empleado.Salario = nuevoSalario;
                context.SaveChanges();
                Console.WriteLine("Salario actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró un empleado con ese email.");
            }
        }

        // Eliminar empleado
        public static void EliminarEmpleado(string email)
        {
            using var context = new ApplicationDbContext();

            var empleado = (from emp in context.Empleados
                            where emp.Email == email
                            select emp).FirstOrDefault();

            if (empleado != null)
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                Console.WriteLine("Empleado eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró un empleado con ese email.");
            }
        }

        // Obtener todos los empleados
        public static List<Empleado> ObtenerTodos()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.ToList();
        }
    }
}
