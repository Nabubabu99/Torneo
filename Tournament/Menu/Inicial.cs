using System;
using System.Collections.Generic;
using System.Text;
using TournamentManager.Controller;
using TournamentManager.Model;

namespace TournamentManager.Menu
{
    public class Inicial : IMenuOpciones
    {
        private readonly TournamentController _controller;
        private IMenuOpciones _menuAdministacionTorneo;
        public Inicial(TournamentController controller)
        {
            _controller = controller;
            _menuAdministacionTorneo = new AdministracionDeTorneo(_controller);
        }
        public Dictionary<int, string> Opciones => new Dictionary<int, string>
        {
            { 1, "Cargar un backup del sistema" },
            { 2, "Agregar un torneo guardado" },
            { 3, "Iniciar con la aplication en blanco" },
            { 9, "Salir de la aplicacion" }
        };
        public string SectionName => "Menu Inicial";

        public void ProcessSelection(int selectedValue)
        {
            switch (selectedValue)
            {
                case 1:
                    Console.WriteLine("Aun no tenemos implementada la funcionalidad para restaurar un backup del sistema (primero tenemos que hacer el backup!!). Perdon... ya lo haremos");
                    _controller.ShowMenu(this);
                    break;
                case 2:
                    Console.WriteLine("Aun no tenemos implementada la funcionalidad para cargar un torneo desde archivo. Perdon... ya lo haremos");
                    _controller.ShowMenu(this);
                    break;
                case 3:
                    CreateEmptyTournamentAndAddToManager();
                    _controller.ShowMenu(_menuAdministacionTorneo);
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

        private void CreateEmptyTournamentAndAddToManager()
        {
            string nombre;
            do
            {
                Console.Write("Ingrese el nombre del torneo: ");
                nombre = Console.ReadLine();
            } while (string.IsNullOrEmpty(nombre));

            var torneo = new Tournament(nombre);
            _controller.Tournaments.Add(torneo);
            _controller.SelectedTournament = torneo;
        }
    }
}
