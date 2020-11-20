using System;
using System.Collections.Generic;
using System.Text;

namespace Torneo
{
    class Equipo
    {
        private string nombreEquipo;
        private int numeroEquipo;
        private int puntaje;
        private int golesFavor;
        private int golesContra;

        public Equipo(string nombreEquipo, int numeroEquipo)
        {
            this.nombreEquipo = nombreEquipo;
            this.numeroEquipo = numeroEquipo;
        }
        public Equipo(string nombreEquipo)
        {
            this.nombreEquipo = nombreEquipo;
        }

        public string Nombre()
        {
            return nombreEquipo;
        }
        
        public int NumeroEquipo()
        {
            return numeroEquipo;
        }

        public void setPuntaje(int puntaje)
        {
            this.puntaje = this.puntaje + puntaje;
        }

        public int getPuntaje()
        {
            return puntaje;
        }

        public void setGolesFavor(int golesFavor)
        {
            this.golesFavor = this.golesFavor + golesFavor;
        }

        public int getGolesFavor()
        {
            return golesFavor;
        }

        public void setGolesContra(int golesContra)
        {
            this.golesContra = this.golesContra + golesContra;
        }

        public int getGolesContra()
        {
            return golesContra;
        }

        public int getDiferenciaGoles()
        {
            return golesFavor - golesContra;
        }
    }
}
