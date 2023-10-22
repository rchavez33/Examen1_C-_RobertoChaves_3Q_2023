using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_C__RobertoChaves_3Q_2023
{
    internal class ClsEmpleado
    {
        public static Empleado[] empleados = new Empleado[10]; 
        public static int numEmpleados;


        /// CRUD EMPLEADOS //



        // Agregar Empleados
        public static void AgregarEmpleado()
        {

            Console.WriteLine("Ingrese la cédula del empleado:");
            string cedula = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del empleado:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección del empleado:");
            string direccion = Console.ReadLine();
            Console.WriteLine("Ingrese el teléfono del empleado:");
            string telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el salario del empleado:");
            double salario = Convert.ToDouble(Console.ReadLine());

            Empleado nuevoEmpleado = new Empleado(cedula, nombre, direccion, telefono, salario);
            empleados[numEmpleados] = nuevoEmpleado;
            numEmpleados++;
            Console.WriteLine("Empleado agregado correctamente.");
        }


        //Consultar Empleados
        public static void ConsultarEmpleados()
        {
            Console.WriteLine("Lista de Empleados:");
            for (int i = 0; i < numEmpleados; i++)
            {
                Console.WriteLine($"Cédula: {empleados[i].Cedula}, Nombre: {empleados[i].Nombre}, Dirección: {empleados[i].Direccion}, Teléfono: {empleados[i].Telefono}, Salario: {empleados[i].Salario}");
            }
        }


        // Modificar Empleados
        public static void ModificarEmpleado()
        {
            if (empleados == null)
            {
                Console.WriteLine("Primero inicialice los arreglos.");
                return;
            }

            Console.WriteLine("Ingrese la cédula del empleado que desea modificar:");
            string cedula = Console.ReadLine();

            bool empleadoEncontrado = false;

            foreach (var empleado in empleados)
            {
                if (empleado != null && empleado.Cedula == cedula)
                {
                    Console.WriteLine($"Empleado encontrado. Ingrese los nuevos datos:");

                    Console.WriteLine("Ingrese el nuevo nombre del empleado (deje en blanco para mantener el existente):");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva dirección del empleado (deje en blanco para mantener la existente):");
                    string nuevaDireccion = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo teléfono del empleado (deje en blanco para mantener el existente):");
                    string nuevoTelefono = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo salario del empleado (deje en blanco para mantener el existente):");
                    string nuevoSalarioInput = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(nuevoNombre))
                    {
                        empleado.Nombre = nuevoNombre;
                    }
                    if (!string.IsNullOrWhiteSpace(nuevaDireccion))
                    {
                        empleado.Direccion = nuevaDireccion;
                    }
                    if (!string.IsNullOrWhiteSpace(nuevoTelefono))
                    {
                        empleado.Telefono = nuevoTelefono;
                    }
                    if (!string.IsNullOrWhiteSpace(nuevoSalarioInput))
                    {
                        double nuevoSalario = Convert.ToDouble(nuevoSalarioInput);
                        empleado.Salario = nuevoSalario;
                    }

                    Console.WriteLine("Empleado modificado correctamente.");
                    empleadoEncontrado = true;
                    break;
                }
            }

            if (!empleadoEncontrado)
            {
                Console.WriteLine("No se encontró ningún empleado con esa cédula.");
            }
        }


        //Borrar Empleados
        public static void BorrarEmpleado()
        {
            if (empleados == null || numEmpleados == 0)
            {
                Console.WriteLine("No hay empleados para borrar.");
                return;
            }

            Console.WriteLine("Ingrese la cédula del empleado que desea eliminar:");
            string cedula = Console.ReadLine();

            for (int i = 0; i < numEmpleados; i++)
            {
                if (empleados[i].Cedula == cedula)
                {
                    for (int j = i; j < numEmpleados - 1; j++)
                    {
                        empleados[j] = empleados[j + 1];
                    }
                    empleados[numEmpleados - 1] = null;
                    numEmpleados--;
                    Console.WriteLine("Empleado borrado correctamente.");
                    return;
                }
            }
            Console.WriteLine("No se encontró ningún empleado con esa cédula.");
        }


        // Iniciar Arreglos
        public static void InicializarArreglos()
        {
            numEmpleados = 0;
            empleados = new Empleado[10];
            Console.WriteLine("Arreglos inicializados.");
        }


        //Sub Menu de reportes
        public static void ReportesSubMenu()
        {
            Console.WriteLine("1. Consultar empleados con número de cédula");
            Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
            Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el número de cédula:");
                    string cedula = Console.ReadLine();
                    ConsultarPorCedula(cedula);
                    break;

                case 2:
                    ListarPorNombre();
                    break;

                case 3:
                    CalcularPromedioSalarios();
                    break;

                case 4:
                    double salarioMaximo, salarioMinimo;
                    EncontrarSalariosExtremos(out salarioMaximo, out salarioMinimo);
                    Console.WriteLine($"El salario máximo es: {salarioMaximo}");
                    Console.WriteLine($"El salario mínimo es: {salarioMinimo}");
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
        public static void ConsultarPorCedula(string cedula)
        {
            bool encontrado = false;
            foreach (var empleado in empleados)
            {
                if (empleado != null && empleado.Cedula == cedula)
                {
                    Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró ningún empleado con esa cédula.");
            }
        }

        public static void ListarPorNombre()
        {
            Array.Sort(empleados, (x, y) => string.Compare(x?.Nombre, y?.Nombre));
            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
                }
            }
        }

        public static void CalcularPromedioSalarios()
        {
            double totalSalarios = 0;
            int totalEmpleados = 0;

            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    totalSalarios += empleado.Salario;
                    totalEmpleados++;
                }
            }

            if (totalEmpleados > 0)
            {
                double promedio = totalSalarios / totalEmpleados;
                Console.WriteLine($"El promedio de los salarios es: {promedio}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el promedio de salarios.");
            }
        }

        public static void EncontrarSalariosExtremos(out double salarioMaximo, out double salarioMinimo)
        {
            salarioMaximo = double.MinValue;
            salarioMinimo = double.MaxValue;

            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    salarioMaximo = Math.Max(salarioMaximo, empleado.Salario);
                    salarioMinimo = Math.Min(salarioMinimo, empleado.Salario);
                }
            }

            if (salarioMaximo == double.MinValue || salarioMinimo == double.MaxValue)
            {
                salarioMaximo = salarioMinimo = 0;
                Console.WriteLine("No hay empleados para calcular los salarios máximos y mínimos.");
            }
        }
    }
    public class Empleado


        {
            public string Cedula { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public double Salario { get; set; }
            public static object Empleados { get; internal set; }

            public Empleado()
            {
                Cedula = "";
                Nombre = "";
                Direccion = "";
                Telefono = "";
                Salario = 0.0;
            }

            public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
            {
                Cedula = cedula;
                Nombre = nombre;
                Direccion = direccion;
                Telefono = telefono;
                Salario = salario;
            }



    }
}
