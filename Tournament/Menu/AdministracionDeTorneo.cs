using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TournamentManager.Controller;
using TournamentManager.Model;

namespace TournamentManager.Menu
{
    public class AdministracionDeTorneo : IMenuOpciones
    {
        private TournamentController _controller;
        private IMenuOpciones _menuAdministacionFecha;

        public AdministracionDeTorneo(TournamentController controller)
        {
            _controller = controller;
            _menuAdministacionFecha = new AdministracionDeFecha(_controller, this);
        }

        public Dictionary<int, string> Opciones => new Dictionary<int, string>
        {
            { 1, "Mostrar Equipos registrados" },
            { 2, "Mostrar Fechas del torneo" },
            { 3, "Setear la cantidad de Equipos que participaran del torneo" },
            { 4, "Agregar un nuevo equipo" },
            { 5, "Agregar una nueva fecha" },
            { 6, "Crear automaticamente un Fixture completo" },
            { 7, "Ir a administrar una fecha existente del torneo" },
            { 9, "Salir de la aplicacion" }
        };

        public string SectionName => "Administracion de Torneo";

        public void ProcessSelection(int selectedValue)
        {
            switch (selectedValue)
            {
                case 1:
                    MostrarEquipos();
                    _controller.ShowMenu(this);
                    break;
                case 2:
                    MostrarFechas();
                    _controller.ShowMenu(this);
                    break;
                case 3:
                    _controller.SelectedTournament.SetCantidadEquipos();
                    _controller.ShowMenu(this);
                    break;
                case 4:
                    _controller.SelectedTournament.AgregarEquipo();
                    _controller.ShowMenu(this);
                    break;
                case 5:
                    _controller.SelectedTournament.AgregarNuevaFecha();
                    _controller.ShowMenu(_menuAdministacionFecha);
                    break;
                case 6:
                    Console.WriteLine("Aun no tenemos implementada la funcionalidad para Agregar 1 equipo. Perdon... ya lo haremos");
                    _controller.ShowMenu(this);
                    break;
                case 7:
                    SeleccionarDeFecha();
                    _controller.ShowMenu(_menuAdministacionFecha);
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

        private void SeleccionarDeFecha()
        {
            MostrarFechas();
            int fechaNumero;
            Round fechaSeleccionada;
            Console.WriteLine();
            do
            {
                do
                {
                    Console.WriteLine("Ingrese el número de la fecha que quiere administrar: ");
                } while (!int.TryParse(Console.ReadLine(), out fechaNumero));
                fechaSeleccionada = _controller.SelectedTournament.Rounds.FirstOrDefault(r => r.Number == fechaNumero);
                if (fechaSeleccionada == null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"La fecha numero {fechaNumero} no existe en el torneo {_controller.SelectedTournament.NombreTorneo}.");
                    Console.WriteLine();
                }
            } while (fechaSeleccionada == null);
            Console.WriteLine();
            _controller.SelectedTournament.SelectedRound = fechaSeleccionada;
        }

        public void MostrarEquipos()
        {
            _controller.SelectedTournament.Teams.Sort();
            Console.WriteLine();
            Console.WriteLine($"******* Lista de Equipos ************");
            foreach (var team in _controller.SelectedTournament.Teams)
            {
                Console.WriteLine($"{team.Id} - {team.Name}");
            }
            Console.WriteLine($"*************************************");
            Console.WriteLine();
        }

        public void MostrarFechas()
        {
            _controller.SelectedTournament.Rounds.Sort();
            Console.WriteLine();
            Console.WriteLine($"******* Lista de Fechas ************");
            foreach (var round in _controller.SelectedTournament.Rounds)
            {
                Console.WriteLine($"Fecha # {round.Number}");
                Console.WriteLine();
                foreach (var match  in round.Matches)
                {
                    Console.WriteLine($"{match.Local.Name} ({match.ScoreLocal}) Vs. ({match.ScoreVisitant}) {match.Visitant.Name}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"*************************************");
            Console.WriteLine();
        }
    }
}
