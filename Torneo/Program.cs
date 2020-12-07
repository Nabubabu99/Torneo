using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Torneo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var torneoGuardado = new Torneo();

            //Console.WriteLine("¿Quieres usar los equipos que están guardados? Si/No");
            //string respuesta = Console.ReadLine();
            //if (respuesta == "No")
            //{
                int resultado;
                string equiposNumero;
                do
                {
                    Console.WriteLine("Ingrese el número de equipos");
                    equiposNumero = Console.ReadLine();
                } while (!int.TryParse(equiposNumero, out resultado));

                //File.Delete("equipos.txt");
                //File.Delete("partidos.txt");
                //File.Delete("goles.txt");

                var torneo = new Torneo(resultado);
                torneo.InscribirEquipos();

                Console.WriteLine($"\nTotal de equipos: {torneo.listaEquipos.Count}");
                foreach (var equipo in torneo.listaEquipos)
                {
                    Console.WriteLine(equipo.Nombre());
                }

                torneo.CrearFecha();
                torneo.AgregarResultados();
                torneo.MostrarTablaPosiciones();
                //torneo.GuardarPartidos();

            //}
            //else
            //{
            //    Console.WriteLine($"\nTotal de equipos: {torneoGuardado.listaEquipos.Count}");
            //    foreach (var equipo in torneoGuardado.listaEquipos)
            //    {
            //        Console.WriteLine(equipo.Nombre());
            //    }
            //    torneoGuardado.CrearFecha();
            //    torneoGuardado.AgregarResultados();
            //    torneoGuardado.MostrarTablaPosiciones();
            //}
        }
    }
}
// TryParse - any - Contains

//private int equiposNumero;
//public void numeroEquipos()
//{
//    Console.WriteLine("Ingrese el número de equipos");
//    equiposNumero = int.Parse(Console.ReadLine());
//}
//public void nombreEquipos()
//{
//    List<string> equipos = new List<string>();
//    for (int i = 0; i < equiposNumero; i++)
//    {
//        Console.WriteLine($"Ingrese el nombre del equipo número {i + 1}");
//        string equipoNombre = Console.ReadLine();
//        equipos.Add(equipoNombre);
//    }
//    for (int i = 0; i < equipos.Count; i++)
//    {
//        Console.WriteLine(equipos[i]);
//    }
//}
