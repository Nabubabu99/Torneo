using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentManager.Model
{
    public class Team : BaseModel, IComparable
    {
        public string Name { get; set; }
        public List<Match> Matches { get; set; }

        public int CompareTo(object obj)
        {
            return Name.CompareTo(((Team)obj).Name);
        }
    }
}
