using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win538Electors
{
    internal class Player : Politician
    {
        private string party;
        private int turns;

        // Getters
        public string GetParty()
        {
            return party;
        }
        public int GetTurns()
        {
            return turns;
        }

        // Setters
        public void SetParty(string chosenParty)
        {
            party = chosenParty;
        }
        public void SetTurns()
        {
            // Player taken turn
            turns = turns - 1;
        }

        // Constructor
        public Player()
        {
            party = "Independent";
            turns = 52;
        }
    }
}
