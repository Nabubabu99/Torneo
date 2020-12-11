using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentManager.Menu
{
    public interface IMenuOpciones
    {
        string SectionName { get; }
        Dictionary<int, string> Opciones { get; }
        void ProcessSelection(int selectedValue);
    }
}
