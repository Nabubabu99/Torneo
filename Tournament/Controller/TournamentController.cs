using System;
using System.Collections.Generic;
using TournamentManager.Menu;
using TournamentManager.Model;
using TournamentManager.Utilities;

namespace TournamentManager.Controller
{
    public class TournamentController
    {
        private OptionsSelector _optionsSelector;

        public List<Tournament> Tournaments { get; set; }
        public Tournament SelectedTournament { get; set; }

        public TournamentController()
        {
            _optionsSelector = new OptionsSelector();
            Tournaments = new List<Tournament>();
        }

        public void StartManager()
        {
            var menuInicial = new Inicial(this);
            ShowMenu(menuInicial);
        }

        public void ShowMenu(IMenuOpciones menuOpciones)
        {
            Console.WriteLine($"****** Section: {menuOpciones.SectionName} ***********");
            Console.WriteLine();
            _optionsSelector.SetNewOptions(menuOpciones.Opciones);
            var selectedOption = _optionsSelector.ShowOptionsAndWaitForSelection();
            menuOpciones.ProcessSelection(selectedOption);
        }
    }
}
