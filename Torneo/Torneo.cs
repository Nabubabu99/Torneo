using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Torneo
{
    class Torneo
    {
        private int equiposNumero;
        public List<Equipo> listaEquipos;
        public List<string> equiposSeleccionados;
        string[] equiposListados;
        int numeroDelEquipo;
        public List<Equipo> partidoUltimo;
        public List<Partido> partidosCreados;

        //public Posiciones posiciones;
        //public List<string> resultadosPartidos;

        public Torneo(int numeroDeEquipos)
        {
            equiposNumero = numeroDeEquipos;
            listaEquipos = new List<Equipo>();
        }

        public Torneo()
        {
            listaEquipos = new List<Equipo>();
        }

        public void InscribirEquipos()
        {
            //TextWriter archivo = File.AppendText("equipos.txt");

            do
            {
                Console.WriteLine($"\nIngrese el nombre del equipo número {listaEquipos.Count + 1}");
                string equipoNombre = Console.ReadLine();
                numeroDelEquipo = listaEquipos.Count + 1;
                Equipo equipo = new Equipo() {nombreEquipo = equipoNombre, numeroEquipo = numeroDelEquipo};
                if (ComprobarEquipo(equipo) == true)
                {
                    listaEquipos.Add(equipo);

                    //archivo.WriteLine($"{equipo.Nombre()}");
                }
            } while (listaEquipos.Count < equiposNumero);
            //archivo.Close();
        }
        //public void InscribirEquiposListados()
        //{
            
        //    string[] lineas = File.ReadAllLines("equipos.txt");
        //    do
        //    {
        //        var i = 1;
        //        foreach (var equipoGuardado in lineas)
        //        {
        //            Equipo equipoGua = new Equipo(equipoGuardado, i);
        //            listaEquipos.Add(equipoGua);
        //            i++;
        //        }
        //    } while (listaEquipos.Count < lineas.Length);
        //    equiposNumero = lineas.Length;
        //}
        public bool ComprobarEquipo(Equipo equipo)
        {
            for (var i = 0; i < listaEquipos.Count; i++)
            {
                if (listaEquipos[i].Nombre() == equipo.Nombre())
                {
                    Console.WriteLine($"El equipo {equipo.Nombre()} ya fue registrado");
                    return false;
                }
            }
            return true;
            //for (var i = 0; i < listaEquipos.Count; i++)
            //{
            //    for (var e = 1; e < listaEquipos.Count; e++)
            //    {
            //        if (i != e)
            //        {
            //            if (listaEquipos[i].Nombre() == listaEquipos[e].Nombre())
            //            {
            //                Console.WriteLine($"El equipo {i + 1} es igual al equipo {e + 1}");
            //                return false;
            //            }
            //        }
            //    }
            //}
        }
        public void CrearFecha()
        {
            string respuestaFecha;
            equiposListados = new string[equiposNumero];
            equiposSeleccionados = new List<string>();
            partidoUltimo = new List<Equipo>();
            partidosCreados = new List<Partido>();
            BaseDeDatos bd = new BaseDeDatos("partidos.json");

            for (var i = 0; i < listaEquipos.Count; i++)
            {
                equiposListados[i] = listaEquipos[i].Nombre();
            }
            do
            {
                Console.WriteLine("\n¿Quieres crear una fecha del torneo? Si/No");
                respuestaFecha = Console.ReadLine();
                if (respuestaFecha == "Si")
                {
                    string respuestaPartido;
                    do
                    {
                        respuestaPartido = "";
                        if (equiposSeleccionados.Count != listaEquipos.Count - 2)
                        {
                            Console.WriteLine("\n¿Quieres crear un partido? Si/No");
                            respuestaPartido = Console.ReadLine();
                            if (respuestaPartido == "Si")
                            {
                                MostrarEquipos();

                                int resPrimerEquipo;
                                do
                                {
                                    Console.WriteLine("\nSeleccione el primer equipo");
                                    string equipoElegido = Console.ReadLine();
                                    int.TryParse(equipoElegido, out resPrimerEquipo);
                                } while (resPrimerEquipo == 0 || resPrimerEquipo > listaEquipos.Count);

                                int resSegundoEquipo;
                                do
                                {
                                    Console.WriteLine("\nSeleccione el segundo equipo");
                                    string equipoElegido = Console.ReadLine();
                                    int.TryParse(equipoElegido, out resSegundoEquipo);
                                } while (resSegundoEquipo == 0 || resSegundoEquipo > listaEquipos.Count);

                                if (CompararEquipos(equiposListados[resPrimerEquipo - 1], equiposListados[resSegundoEquipo - 1]) && CompararPartidos($"{equiposListados[resPrimerEquipo - 1]} vs {equiposListados[resSegundoEquipo - 1]}"))
                                {
                                    equiposSeleccionados.Add(listaEquipos[resPrimerEquipo - 1].Nombre());
                                    equiposSeleccionados.Add(listaEquipos[resSegundoEquipo - 1].Nombre());
                                    Console.WriteLine($"\n{equiposListados[resPrimerEquipo - 1]} vs {equiposListados[resSegundoEquipo - 1]}");
                                    Partido partido = new Partido() { equipoLocal = listaEquipos[resPrimerEquipo - 1], equipoVisitante = listaEquipos[resSegundoEquipo - 1] };
                                    partidosCreados.Add(partido);
                                    bd.CargarPartidos(partido);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n¿Quieres crear un partido con los ultimos dos equipos? Si/No");
                            string respuestaUltimo = Console.ReadLine();
                            if (respuestaUltimo == "Si")
                            {
                                var ultimoPartido = listaEquipos.Where(nombreEquipo => !equiposSeleccionados.Contains(nombreEquipo.Nombre()));
                                foreach (var equipo in ultimoPartido)
                                {
                                    equiposSeleccionados.Add(equipo.Nombre());
                                    partidoUltimo.Add(equipo);
                                }
                                Partido partido = new Partido() { equipoLocal = partidoUltimo[0], equipoVisitante = partidoUltimo[1] };
                                partidosCreados.Add(partido);
                                bd.CargarPartidos(partido);
                                Console.WriteLine($"{partidoUltimo[0].Nombre()} vs {partidoUltimo[1].Nombre()}");
                                foreach(var equipoEnLista in equiposListados)
                                {
                                    partidoUltimo.RemoveAll(equipo => equipo.Nombre() == equipoEnLista);
                                }
                            }
                        }
                    } while (respuestaPartido == "Si" && equiposSeleccionados.Count < listaEquipos.Count);

                    foreach(var equipoEnLista in equiposListados)
                    {
                        equiposSeleccionados.RemoveAll(equipo => equipo == equipoEnLista);
                    }
                }
            } while (respuestaFecha == "Si");

            Console.WriteLine("\nPartidos creados:");

            foreach (var partido in partidosCreados)
            {
                Console.WriteLine(partido.partidoCreado());
            }
        }
        public bool CompararEquipos(string nombreEquipo1, string nombreEquipo2)
        {
            if (nombreEquipo1 != nombreEquipo2)
            {
                var retornar = true;
                if (equiposSeleccionados.Count > 0)
                {
                    foreach(var nombreEquipo in equiposSeleccionados)
                    {
                        if (equiposSeleccionados.Contains(nombreEquipo1))
                        {
                            Console.WriteLine($"El equipo {nombreEquipo1} ya fue registrado");
                            return false;
                        }
                    }
                    foreach(var nombreEquipo in equiposSeleccionados)
                    {
                        if (equiposSeleccionados.Contains(nombreEquipo2))
                        {
                            Console.WriteLine($"El equipo {nombreEquipo2} ya fue registrado");
                            return false;
                        }
                    }
                }
                return retornar;
            }
            else
            {
                Console.WriteLine("Elija equipos diferentes");
                return false;
            }
        }
        public bool CompararPartidos(string partido)
        {
            var retornar = true;
              if(partidosCreados.Count > 0)
            {
                foreach (var partidoCreado in partidosCreados)
                {
                    if(partidoCreado.partidoCreado() == partido)
                    {
                        Console.WriteLine($"Este partido de {partido} ya fue creado");
                        return false;
                    }
                }
            }
            return retornar;
        }
        public void MostrarEquipos()
        {
            Console.WriteLine("\nLista de equipos por agregar:");
            var equiposDisponibles = listaEquipos.Where(nombreEquipo => !equiposSeleccionados.Contains(nombreEquipo.Nombre()));
            //var equiposDisponibles = new List<string>();
            //foreach (var nombreEquipo in equiposListados)
            //{
            //    var agregarEquipo = true;
            //    var j = 0;
            //    while (j < equiposSeleccionados.Count)
            //    {
            //        if (equiposSeleccionados[j] == nombreEquipo)
            //        {
            //            agregarEquipo = false;
            //            break;
            //        }
            //        j++;
            //    }
            //    //if (!equiposSeleccionados.Contains(nombreEquipo))
            //    if (agregarEquipo)
            //    {
            //        equiposDisponibles.Add(nombreEquipo);
            //    }
            //}
            var i = 1;
            foreach (var equipoDisponible in equiposDisponibles)
            {
                Console.WriteLine($"{equipoDisponible.NumeroEquipo()} : {equipoDisponible.Nombre()}");
                i++;
            }
        }
        public void AgregarResultados()
        {
            foreach (var partido in partidosCreados)
            {
                Console.WriteLine($"\nColoque el resultado del {partido.partidoCreado()}");
                Console.WriteLine($"\nGoles de {partido.getNombrEquipoLocal()}");
                int golesEquipoLocal = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nGoles de {partido.getNombreEquipoVisitante()}");
                int golesEquipoVisitante = int.Parse(Console.ReadLine());
                partido.setGoles(golesEquipoLocal, golesEquipoVisitante);
                partido.getGanador();
            }
        }
        //public void GuardarPartidos()
        //{
        //    BaseDeDatos bd = new BaseDeDatos("partidos.json");
        //    foreach(var partido in partidosCreados)
        //    {
        //        bd.CargarPartidos(new Partido(partido.equipoLocal, partido.equipoVisitante));
        //        Console.WriteLine(partido.partidoCreado());
        //    }
        //    bd.Guardar();
        //    bd.Cargar();
        //}
        public void MostrarTablaPosiciones()
        {
            BaseDeDatos bd = new BaseDeDatos("partidos.json");
            var ordenarPuntos = listaEquipos.OrderByDescending(puntosEquipo => puntosEquipo.getPuntaje());
            var ordenarGoles = ordenarPuntos.OrderByDescending(golesEquipo => golesEquipo.getDiferenciaGoles());
            foreach (var equipo in ordenarGoles)
            {
                Console.WriteLine($"{equipo.Nombre()} puntos: {equipo.getPuntaje()} | GF: {equipo.getGolesFavor()} | GC: {equipo.getGolesContra()} | DF: {equipo.getDiferenciaGoles()}");
            }
            bd.Cargar();
        }
    }
}