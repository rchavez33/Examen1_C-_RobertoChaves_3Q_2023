using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examen1_C__RobertoChaves_3Q_2023.ClsEmpleado;

namespace Examen1_C__RobertoChaves_3Q_2023
{
    internal class ClsMenu
    {
        private static int opcion = 0;


        public static void Mostrar()
        {
            do
            {
                Console.WriteLine("1- Inicializar Arreglos");
                Console.WriteLine("2- Agregar Empleados");
                Console.WriteLine("3- Consultar Todos los Empleados (Si desea informacion mas especifica, ve a *Reportes*)");
                Console.WriteLine("4- Modificar Empleados");
                Console.WriteLine("5- Borrar Empleados");
                Console.WriteLine("6- Reportes");
                int.TryParse(Console.ReadLine(), out opcion); // no se caiga si se digita una opcion invalida

                switch (opcion)
                {
                    case 1:
                        ClsEmpleado.InicializarArreglos();
                        break;
                    case 2:
                        ClsEmpleado.AgregarEmpleado();
                        break;
                    case 3:
                        ClsEmpleado.ConsultarEmpleados();
                        break;
                    case 4:
                        ClsEmpleado.ModificarEmpleado();
                        break;
                    case 5:
                        ClsEmpleado.BorrarEmpleado();
                        break;
                    case 6:
                        ClsEmpleado.ReportesSubMenu();
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida");
                        break;
                }

            }
            while (opcion != 7);
        }

    }
}

