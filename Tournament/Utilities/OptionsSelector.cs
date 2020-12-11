using System;
using System.Collections.Generic;

namespace TournamentManager.Utilities
{
    public class OptionsSelector
    {
        private Dictionary<int, string> _options;

        public void SetNewOptions(Dictionary<int, string> options)
        {
            _options = options;
        }

        public int ShowOptionsAndWaitForSelection()
        {
            ShowOptions();
            return SelectOption();
        }

        public void ShowOptions()
        {
            foreach (var key in _options.Keys)
            {
                Console.WriteLine($"{key} - {_options[key]}");
            }
        }
        public int SelectOption()
        {
            int selection;
            do
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Ingrese su seleccion: ");
                } while (!int.TryParse(Console.ReadLine(), out selection));
            } while (!_options.ContainsKey(selection));
            return selection;
        }
    }
}
