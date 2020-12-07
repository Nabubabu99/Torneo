using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Torneo
{
    class Partido : Torneo
    {
        private Equipo equipoLocal;
        private Equipo equipoVisitante;
        private int golesEquipoLocal;
        private int golesEquipoVisitante;
        public List<Partido> partidosCreados;

        public Partido()
        {

        }

        public Partido(Equipo equipoLocal, Equipo equipoVisitante)
        {
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
        }

        public Partido(string equipo1, string equipo2)
        {
            Equipo equipoLocal = new Equipo(equipo1);
            this.equipoLocal = equipoLocal;

            Equipo equipoVisitante = new Equipo(equipo2);
            this.equipoVisitante = equipoVisitante;

            listaEquipos.Add(equipoLocal);
            listaEquipos.Add(equipoVisitante);
        }
        public string getNombrEquipoLocal()
        {
            return equipoLocal.Nombre();
        }
        public string getNombreEquipoVisitante()
        {
            return equipoVisitante.Nombre();
        }
        public void setGoles(int golesEquipoLocal, int golesEquipoVisitante)
        {
            this.golesEquipoLocal = golesEquipoLocal;
            this.golesEquipoVisitante = golesEquipoVisitante;
            equipoLocal.setGolesFavor(golesEquipoLocal);
            equipoLocal.setGolesContra(golesEquipoVisitante);
            equipoVisitante.setGolesFavor(golesEquipoVisitante);
            equipoVisitante.setGolesContra(golesEquipoLocal);
        }
        public void getGanador()
        {
            Console.WriteLine($"{equipoLocal.Nombre()} {golesEquipoLocal} vs {equipoVisitante.Nombre()} {golesEquipoVisitante}");
            if (golesEquipoLocal > golesEquipoVisitante)
            {
                Console.WriteLine($"\n{equipoLocal.Nombre()} le ganó a {equipoVisitante.Nombre()}");
                equipoLocal.setPuntaje(3);
            }
            else if (golesEquipoVisitante > golesEquipoLocal)
            {
                Console.WriteLine($"\n{equipoVisitante.Nombre()} le ganó a {equipoLocal.Nombre()}");
                equipoVisitante.setPuntaje(3);
            }
            else
            {
                Console.WriteLine($"\nHubo un empate entre {equipoLocal.Nombre()} y {equipoVisitante.Nombre()}");
                equipoLocal.setPuntaje(1);
                equipoVisitante.setPuntaje(1);
            }
        }
        public string partidoCreado()
        {
            return $"{equipoLocal.Nombre()} vs {equipoVisitante.Nombre()}";
        }
        //public void GuardarPartido()
        //{
        //    TextWriter archivoPartidos = File.AppendText("partidos.txt");
        //    TextWriter archivoEquipoVisitante = File.AppendText("equipoVisitante.txt");
        //    TextWriter archivoGoles = File.AppendText("goles.txt");

        //    archivoPartidos.WriteLine($"{equipoLocal.Nombre()}");
        //    archivoPartidos.WriteLine($"{equipoVisitante.Nombre()}");
        //    archivoGoles.WriteLine($"{golesEquipoLocal}");
        //    archivoGoles.WriteLine($"{golesEquipoVisitante}");

        //    archivoPartidos.Close();
        //    archivoEquipoVisitante.Close();
        //    archivoGoles.Close();
        //}
    }
}
