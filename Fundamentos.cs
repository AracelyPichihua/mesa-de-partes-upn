using System;
using System.Collections.Generic;

namespace MesaDePartesUPN
{
    // Estructura del Expediente
    class Expediente
    {
        public string Codigo { get; set; }
        public string Estudiante { get; set; }
        public string TipoTramite { get; set; }
        public string FechaRegistro { get; set; }
        public string Estado { get; set; }
    }

    class Program
    {
        // Arreglo / Lista global para almacenar los expedientes registrados
        static List<Expediente> listaExpedientes = new List<Expediente>();

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE MESA DE PARTES - UPN CHORRILLOS ===");
                Console.WriteLine("1. Registrar expediente");
                Console.WriteLine("2. Buscar expediente");
                Console.WriteLine("3. Ordenar expedientes por fecha");
                Console.WriteLine("4. Mostrar todos los expedientes");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: RegistrarExpediente(); break;
                        case 2: BuscarExpediente(); break;
                        case 3: OrdenarExpedientes(); break;
                        case 4: MostrarExpedientes(); break;
                        case 5: Console.WriteLine("Saliendo del sistema..."); break;
                        default: Console.WriteLine("Opción no válida."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número.");
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        // Módulo 1 & 2: Registro y Validación
        static void RegistrarExpediente()
        {
            Console.WriteLine("\n--- 1. REGISTRAR EXPEDIENTE ---");
            Console.Write("Ingrese código del expediente: ");
            string codigo = Console.ReadLine();

            // Validación de código duplicado
            if (listaExpedientes.Exists(e => e.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Error: El código de expediente ya existe.");
                return;
            }

            Console.Write("Nombre del estudiante: ");
            string estudiante = Console.ReadLine();
            Console.Write("Tipo de trámite: ");
            string tramite = Console.ReadLine();
            Console.Write("Fecha de registro (AAAA-MM-DD): ");
            string fecha = Console.ReadLine();

            Expediente nuevo = new Expediente
            {
                Codigo = codigo,
                Estudiante = estudiante,
                TipoTramite = tramite,
                FechaRegistro = fecha,
                Estado = "Registrado / Pendiente de derivación"
            };

            listaExpedientes.Add(nuevo);
            Console.WriteLine(" Confirmación: Expediente guardado exitosamente.");
        }

        // Módulo 3: Búsqueda
        static void BuscarExpediente()
        {
            Console.WriteLine("\n--- 2. BUSCAR EXPEDIENTE ---");
            Console.Write("Ingrese código a buscar: ");
            string codigo = Console.ReadLine();

            Expediente hallado = listaExpedientes.Find(e => e.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

            if (hallado != null)
            {
                Console.WriteLine($"\n[ENCONTRADO]");
                Console.WriteLine($"Código: {hallado.Codigo}");
                Console.WriteLine($"Estudiante: {hallado.Estudiante}");
                Console.WriteLine($"Trámite: {hallado.TipoTramite}");
                Console.WriteLine($"Fecha: {hallado.FechaRegistro}");
                Console.WriteLine($"Estado: {hallado.Estado}");
            }
            else
            {
                Console.WriteLine(" Expediente no encontrado.");
            }
        }

        // Módulo 4: Ordenamiento
        static void OrdenarExpedientes()
        {
            Console.WriteLine("\n--- 3. ORDENAR POR FECHA DE REGISTRO ---");
            if (listaExpedientes.Count == 0)
            {
                Console.WriteLine("No hay expedientes para ordenar.");
                return;
            }

            listaExpedientes.Sort((x, y) => string.Compare(x.FechaRegistro, y.FechaRegistro));
            Console.WriteLine(" Lista ordenada por fecha de registro correctamente.");
            MostrarExpedientes();
        }

        // Módulo 5: Consulta
        static void MostrarExpedientes()
        {
            Console.WriteLine("\n--- 4. LISTA GENERAL DE EXPEDIENTES ---");
            if (listaExpedientes.Count == 0)
            {
                Console.WriteLine("No existen registros en el sistema.");
                return;
            }

            foreach (var exp in listaExpedientes)
            {
                Console.WriteLine($"[{exp.Codigo}] {exp.Estudiante} | {exp.TipoTramite} | Fecha: {exp.FechaRegistro} | Estado: {exp.Estado}");
            }
        }
    }
}
