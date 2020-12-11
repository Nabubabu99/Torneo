using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentManager.Model
{
    public class Match : BaseModel
    {
        public Team Local { get; set; }
        public Team Visitant { get; set; }
        public int ScoreLocal { get; set; }
        public int ScoreVisitant { get; set; }
        public DateTime Date { get; set; }

        public Match(Team local, Team visitant)
        {
            Local = local;
            Visitant = visitant;
            Date = DateTime.Today;
        }

        public override string ToString()
        {
            return $"{Local.Name} ({ScoreLocal}) Vs. ({ScoreVisitant}) {Visitant.Name}";
        }
    }
}
