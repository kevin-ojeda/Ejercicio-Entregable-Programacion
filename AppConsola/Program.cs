using System.ComponentModel.DataAnnotations;
using ClasesEjercicioPrueba.Models;
using ClasesEjercicioPrueba.Repository;

bool salir = true;

while (salir)
{
    Console.WriteLine("===== MENÚ PRINCIPAL =====");
    Console.WriteLine("1. Registrar nuevo empleado");
    Console.WriteLine("2. Actualizar salario de empleado");
    Console.WriteLine("3. Eliminar empleado");
    Console.WriteLine("4. Registrar nuevo departamento");
    Console.WriteLine("5. Estadísticas de empleados");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            //Pedir nombre, email, departamento y salario.
            //Validar que no exista un empleado con el mismo email antes de insertar.
            Console.WriteLine("Ingrese el nombre del empleado:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el email del empleado:");
            string email = Console.ReadLine();
            Console.WriteLine("Ingrese el id Departamento del empleado:");
            var lista = DepartamentoRepository.ObtenerTodos();
            var listaDepartamentos = DepartamentoRepository.ObtenerTodos();
            if (listaDepartamentos.Count == 0)
            {
                Console.WriteLine("No hay departamentos registrados. Debe crear uno primero.");
                break;
            }

            Console.WriteLine("===== TABLA DE DEPARTAMENTOS =====");
            foreach (var dep in listaDepartamentos)
            {
                Console.WriteLine($"{dep.Id} - {dep.Nombre} ({dep.Descripcion})");
            }
            Console.Write("Seleccione el id del departamento: ");
            int idDepartamento = int.Parse(Console.ReadLine());
            var departamentoSeleccionado = DepartamentoRepository.ObtenerPorId(idDepartamento);
            if (departamentoSeleccionado == null)
            {
                Console.WriteLine("Departamento no encontrado. Operación cancelada.");
                break;
            }
            Console.WriteLine("Ingrese el salario del empleado:");
            double salario;
            while (!double.TryParse(Console.ReadLine(), out salario) || salario < 0)
            {
                Console.WriteLine("Salario inválido. Ingrese un número positivo:");
            }
            var empleado = new Empleado(nombre,email,departamentoSeleccionado,salario);
            EmpleadoRepository.AgregarEmpleado(empleado);
            Console.WriteLine("Empleado registrado exitosamente.");
            break;

        case "2":
            // Pedir el email del empleado.
            //Si existe, permitir ingresar un nuevo salario y actualizarlo.
            Console.WriteLine("Ingrese el email del empleado:");
            string Email = Console.ReadLine();
            var empleadoExistente = EmpleadoRepository.ObtenerTodos().FirstOrDefault(e => e.Email == Email);
            if (empleadoExistente == null)
            {
                Console.WriteLine("No se encontró un empleado con ese email.");
                break;
            }
            string emailActualizar = empleadoExistente.Email;
            Console.WriteLine("Ingrese el nuevo salario del empleado:");
            double nuevoSalario;
            while (!double.TryParse(Console.ReadLine(), out nuevoSalario) || nuevoSalario < 0)
            {
                Console.WriteLine("Salario inválido. Ingrese un número positivo:");
            }
            EmpleadoRepository.ActualizarSalario(emailActualizar, nuevoSalario);
            Console.WriteLine("Salario del empleado actualizado exitosamente.");
            break;

        case "3":
            // Pedir el email del empleado.
            //Si existe, eliminarlo de la base.

                        Console.WriteLine("Ingrese el email del empleado a eliminar:");
            string emailEliminar = Console.ReadLine();
            var empleadoAEliminar = EmpleadoRepository.ObtenerTodos().FirstOrDefault(e => e.Email == emailEliminar);
            if (empleadoAEliminar == null)
            {
                Console.WriteLine("No se encontró un empleado con ese email.");
                break;
            }
            EmpleadoRepository.EliminarEmpleado(emailEliminar);
            break;

        case "4":
            // Pedir nombre y descripción.
            //Validar que no exista un departamento con el mismo nombre antes de insertar.
            Console.WriteLine("Ingrese el nombre del departamento:");
            string nombreDep = Console.ReadLine();
            Console.WriteLine("Ingrese la descripción del departamento:");
            string descripcionDep = Console.ReadLine();
            var nuevoDepartamento = new Departamento
            {
                Nombre = nombreDep,
                Descripcion = descripcionDep
            };
            DepartamentoRepository.AgregarDepartamento(nuevoDepartamento);
            Console.WriteLine("Departamento registrado exitosamente.");
            break;

        case "5":
            //Calcular y mostrar:
            //Total de empleados registrados.
            //Promedio de salario general.
            //Salario máximo y mínimo. 
            //Cantidad de empleados por departamento.

            var empleados = EmpleadoRepository.ObtenerTodos();
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                break;
            }
            int totalEmpleados = empleados.Count;
            double promedioSalario = empleados.Average(e => e.Salario);
            double salarioMaximo = empleados.Max(e => e.Salario);
            double salarioMinimo = empleados.Min(e => e.Salario);
            var empleadosPorDepartamento = empleados
                .GroupBy(e => e.Departamento.Nombre)
                .Select(g => new { Departamento = g.Key, Cantidad = g.Count() })
                .ToList();
            Console.WriteLine($"Total de empleados: {totalEmpleados}");
            Console.WriteLine($"Promedio de salario: {promedioSalario:C}");
            Console.WriteLine($"Salario máximo: {salarioMaximo:C}");
            Console.WriteLine($"Salario mínimo: {salarioMinimo:C}");
            Console.WriteLine("Cantidad de empleados por departamento:");
            foreach (var grupo in empleadosPorDepartamento)
            {
                Console.WriteLine($"- {grupo.Departamento}: {grupo.Cantidad}");
            }
            Console.WriteLine("Presione Enter para continuar...");
            break;

        case "6":
            salir = false;
            break;

        default:
            Console.WriteLine("Opción no válida, intente de nuevo.");
            break;
    }

    Console.WriteLine();
}
