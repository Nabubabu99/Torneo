using System;
using TournamentManager.Controller;

namespace TournamentManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var tournamentManager = new TournamentController();
            tournamentManager.StartManager();
        }
    }
}
