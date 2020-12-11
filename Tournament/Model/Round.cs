using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentManager.Model
{
    public class Round : BaseModel, IComparable
    {
        public List<Match> Matches { get; set; }
        public int Number { get; set; }

        public Round()
        {
            Matches = new List<Match>();
        }

        public int CompareTo(object obj)
        {
            return Number.CompareTo(((Round)obj).Number);
        }
    }
}
