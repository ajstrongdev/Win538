using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win538Electors
{
    internal class Ai : Politician
    {
        private string difficulty;

        // Getters
        public string GetDifficulty()
        {
            return difficulty;
        }

        // Constructor
        public Ai(string difficulty)
        {
            this.difficulty = difficulty;
        }
    }
}
