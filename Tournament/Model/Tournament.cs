using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TournamentManager.Model
{
    public class Tournament : BaseModel
    {
        public List<Team> Teams { get; set; }
        public List<Round> Rounds { get; set; }
        public Round SelectedRound { get; set; }

        private int _cantidadEquipos { get; set; }
        private string _nombreTorneo { get; set; }

        public string NombreTorneo
        {
            get
            {
                return _nombreTorneo;
            }
        }

        public int CantidadEquipos
        {
            get
            {
                return _cantidadEquipos;
            }
        }
        public Tournament(string nombre)
        {
            _nombreTorneo = nombre;
            Teams = new List<Team>();
            Rounds = new List<Round>();
        }

        public void SetCantidadEquipos()
        {
            int equiposNumero;
            Console.WriteLine();
            do
            {
                Console.WriteLine("Ingrese el número de equipos");
            } while (!int.TryParse(Console.ReadLine(), out equiposNumero));
            Console.WriteLine();
            _cantidadEquipos = equiposNumero;
        }

        internal void AgregarEquipo()
        {
            if (Teams.Count < _cantidadEquipos)
            {
                string nuevoEquipoNombre;
                do
                {
                    Console.Write("Ingrese el nombre del equipo a agregar: ");
                    nuevoEquipoNombre = Console.ReadLine();
                } while (string.IsNullOrEmpty(nuevoEquipoNombre) || Teams.Any(t => string.Compare(t.Name, nuevoEquipoNombre, true) == 0));
                Teams.Add(new Team { Id = Teams.Count() + 1, Name = nuevoEquipoNombre });
            }
            else
            {
                Console.WriteLine($"Ya se han registrado la totalidad de los {_cantidadEquipos} equipos en el torneo");
            }
        }

        internal void AgregarNuevaFecha()
        {
            var newRound = new Round();
            Rounds.Add(newRound);
            Console.WriteLine($"Se agrego la fecha Numero {Rounds.Count()}");
            Console.WriteLine();
            SelectedRound = newRound;
        }
    }
}
