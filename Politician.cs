using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win538Electors
{
    internal class Politician
    {
        public string party;
        public int funds;
        public int turns;
        public int campaigners;
        public int donators;
        public int sales;
        public int electorsWon;
        public Politician()
        {
            party = "Independent";
            funds = 10000;
            turns = 52;
            campaigners = 0;
            donators = 1;
            sales = 0;
            electorsWon = 0;
        }
    }
}
