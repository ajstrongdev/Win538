using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win538Electors
{
    internal class Politician
    {
        private string party;
        private int funds;
        private int turns;
        private int campaigners;
        private int donators;
        private int electorsWon;
        // Getters
        public string GetParty()
        {
            return party;
        }
        public int GetFunds()
        {
            return funds;
        }
        public int GetTurns()
        {
            return turns;
        }
        public int GetCampaigners()
        {
            return campaigners;
        }
        public int GetDonators()
        {
            return donators;
        }
        public int GetElectors()
        {
            return electorsWon;
        }
        // Setters
        public void SetParty(string chosenParty)
        {
            party = chosenParty;
        }
        public void SetFundsIncrease(int increase)
        {
            funds += increase;
        }
        public void SetFundsPurchase(int price)
        {
            funds = funds - price;
        }
        public void SetTurns()
        {
            // Player taken turn
            turns = turns - 1;
        }
        public void SetCampaigners()
        {
            campaigners += 1;
        }
        public void SetDonators()
        {
            donators += 1;
        }
        public void SetElectors(int electors)
        {
            electorsWon += electors;
        }
        // Constructors
        public Politician()
        {
            party = "Independent";
            funds = 10000;
            turns = 52;
            campaigners = 0;
            donators = 1;
            electorsWon = 0;
        }
    }
}
