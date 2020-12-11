using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TournamentManager.Controller;
using TournamentManager.Model;

namespace TournamentManager.Menu
{
    public class AdministracionDeFecha : IMenuOpciones
    {
        private readonly TournamentController _controller;
        private readonly AdministracionDeTorneo _administracionDeTorneo;

        public AdministracionDeFecha(TournamentController controller, AdministracionDeTorneo administracionDeTorneo)
        {
            _controller = controller;
            _administracionDeTorneo = administracionDeTorneo;
        }

        public string SectionName => "Administracion de Fecha";

        public Dictionary<int, string> Opciones => new Dictionary<int, string>
        {
            { 1, "Ver partidos de la fecha" },
            { 2, "Agregar nuevos partido a la fecha" },
            { 3, "Cargar el resultado de un partido en la fecha" },
            { 4, "Volver al menu de administracion del torneo" },
            { 9, "Salir de la aplicacion" }
        };

        public void ProcessSelection(int selectedValue)
        {
            switch (selectedValue)
            {
                case 1:
                    MostrarPartidos();
                    _controller.ShowMenu(this);
                    break;
                case 2:
                    AgregarPartido();
                    _controller.ShowMenu(this);
                    break;
                case 3:
                    Console.WriteLine("Aun no tenemos implementada la funcionalidad. Perdon... ya lo haremos");
                    _controller.ShowMenu(this);
                    break;
                case 4:
                    _controller.ShowMenu(_administracionDeTorneo);
                    break;
                case 9:
                    Console.WriteLine("Muchas gracias por usar la aplicacion");
                    break;
                default:
                    Console.WriteLine("Algo raro paso... no deberia haber llegado aca");
                    _controller.ShowMenu(this);
                    break;
            }
        }

        public void MostrarPartidos()
        {
            Console.WriteLine();
            Console.WriteLine($"******* Lista de Partidos en la Fecha {_controller.SelectedTournament.SelectedRound.Number} ************");
            foreach (var match in _controller.SelectedTournament.SelectedRound.Matches)
            {
                Console.WriteLine($"{match.Id} - {match}");
            }
            Console.WriteLine($"*************************************");
            Console.WriteLine();
        }

        public void AgregarPartido()
        {
            var availableTeams = MostrarEquiposDisponibles(null);
            if(availableTeams.Count() < 2)
            {
                Console.WriteLine("No hay suficientes equipos para agregar un nuevo partido en esta fecha.");
                Console.WriteLine();
                return;
            }
            var local = ElegirEquipo(availableTeams, "local", null);
            availableTeams = availableTeams.Where(t => t != local);
            var visitant = ElegirEquipo(availableTeams, "visitante", local);
            _controller.SelectedTournament.SelectedRound.Matches.Add(new Match(local, visitant));
            Console.WriteLine();
        }

        private Team ElegirEquipo(IEnumerable<Team> availableTeams, string calidad, Team local)
        {
            int equipoSeleccionado;
            Team equipo;
            Console.WriteLine();
            do
            {
                do
                {
                    Console.WriteLine($"Ingrese el número del equipo {calidad}: ");
                } while (!int.TryParse(Console.ReadLine(), out equipoSeleccionado));
                equipo = availableTeams.FirstOrDefault(r => r.Id == equipoSeleccionado);
                if (equipo == null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"El equipo numero {equipoSeleccionado} no esta disponible. Por favor elija dentro de los equipos disponibles");
                    Console.WriteLine();
                    MostrarEquiposDisponibles(local);
                }
            } while (equipo == null);
            return equipo;
        }

        private IEnumerable<Team> MostrarEquiposDisponibles(Team adversario)
        {
            Console.WriteLine();
            Console.WriteLine($"******* Lista de Equipos disponibles para la Fecha {_controller.SelectedTournament.SelectedRound.Number} ************");
            var teamAlreadyWithMatches = _controller.SelectedTournament.SelectedRound.Matches.SelectMany(m => new[] { m.Local, m.Visitant });
            var availableTeams = _controller.SelectedTournament.Teams.Where(t => !teamAlreadyWithMatches.Contains(t));
            foreach (var team in availableTeams)
            {
                if (team == adversario)
                {
                    Console.WriteLine($"X - {team.Name} (adversario)");
                }
                else
                {
                    Console.WriteLine($"{team.Id} - {team.Name}");
                }
            }
            Console.WriteLine($"******************************************************************");
            return availableTeams;
        }
    }
}
