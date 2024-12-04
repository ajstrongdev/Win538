using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win538Electors
{
    internal abstract class Politician
    {
        protected int funds;
        protected int campaigners;
        protected int donators;
        protected int electorsWon;
        protected List<string> latestAction;
        protected int turnTicker;
        protected Campaign campaign;
        // Getters
        public int GetFunds()
        {
            return funds;
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
        public int GetCampaignCost(string type)
        {
            return campaign.GetCampaignCost(type);
        }
        public List<string> GetLatestAction()
        {
            return latestAction;
        }
        public int GetTurnTicker()
        {
            return turnTicker;
        }

        // Setters
        public void SetFundsIncrease(int increase)
        {
            funds += increase;
        }
        public void SetFundsPurchase(int price)
        {
            funds = funds - price;
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
        public void UpdateCampaignCost(string type, int change)
        {
            campaign.SetCampaignCost(type, change);
        }
        public void SetLatestAction(string action)
        {
            latestAction.Insert(0, action);
        }
        public void SetTurnTicker()  // This tracks the amount of turns have occured, used to display in action log.
        {
            turnTicker += 1;
        }

        // Constructors
        public Politician()
        {
            funds = 10000;
            campaigners = 0;
            donators = 1;
            electorsWon = 0;
            campaign = new Campaign(); // Composition instead of inheritence: https://code-maze.com/csharp-composition-vs-inheritance/
            turnTicker = 0;
            latestAction = new List<string>();
        }
        // Methods
        public abstract void TurnTaken(Dictionary<string, int> statePolling, string[] states, Dictionary<string, int> campaignCosts);
        public abstract void SaveGame();
        public abstract void LoadGame();
    }
}
