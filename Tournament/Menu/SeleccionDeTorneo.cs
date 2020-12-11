using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TournamentManager.Controller;

namespace TournamentManager.Menu
{
    public class SeleccionDeTorneo : IMenuOpciones
    {
        private TournamentController _controller;

        public SeleccionDeTorneo(TournamentController controller)
        {
            _controller = controller;
        }

        public Dictionary<int, string> Opciones => new Dictionary<int, string>
        {
            { 1, "Elegir el torneo a administrar entre los torneos dispobibles" },
            { 2, "Volver al Menu Inicial de opciones" },
            { 3, "Exportar el torneo actual" },
            { 4, "Exportar el sistema completo" },
            { 9, "Salir de la aplicacion" }
        };
        public string SectionName => "Seleccion de Torneo";

        public void ProcessSelection(int selectedValue)
        {
            switch (selectedValue)
            {
                case 1:
                    Console.WriteLine("Aun no tenemos implementada la funcionalidad para Agregar todos los equipos restantes. Perdon... ya lo haremos");
                    break;
                case 2:
                    Console.WriteLine("Aun no tenemos implementada la funcionalidad para Agregar 1 equipo. Perdon... ya lo haremos");
                    break;
                case 3:
                    Console.WriteLine("Aun no tenemos implementada la funcionalidad para Agregar 1 nueva fecha. Perdon... ya lo haremos");
                    break;
                case 4:
                    Console.WriteLine("Aun no tenemos implementada la funcionalidad para Crear automaticamente un Fixture completo. Perdon... ya lo haremos");
                    break;
                default:
                    Console.WriteLine("Algo raro paso... no deberia haber llegado aca");
                    break;
            }
        }

        public void PrintAndSelectTournament()
        {
            foreach (var tournament in _controller.Tournaments)
            {
                Console.WriteLine($"{tournament.Id} - {tournament.NombreTorneo}");
            }

            _controller.SelectedTournament = null;
            while (_controller.SelectedTournament == null)
            {
                int idTournament;
                do
                {
                    Console.Write("Ingrese el número de torneo: ");
                } while (!int.TryParse(Console.ReadLine(), out idTournament));
                SelectTournament(idTournament);
            }
        }

        public void SelectTournament(int id)
        {
            _controller.SelectedTournament = _controller.Tournaments.FirstOrDefault(t => t.Id == id);

            if (_controller.SelectedTournament == null)
            {
                Console.WriteLine("El Id ingresado es incorrecto. Ningun torneo ha sido seleccionado.");
            }
            else
            {
                Console.WriteLine($"Torneo {_controller.SelectedTournament.NombreTorneo} ha sido seleccionado");
            }
        }
    }
}
