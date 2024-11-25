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
        private double rallyCostIncrease;
        private double donation;
        private double donationCostIncrease;
        private double adsCostIncrease;
        private double campaignerCostIncrease;

        // Getters
        public string GetParty()
        {
            return party;
        }
        public int GetTurns()
        {
            return turns;
        }
        public double GetRallyCostIncrease() { return rallyCostIncrease; }
        public double GetDonationCostIncrease() { return donationCostIncrease; }
        public double GetAdsCostIncrease() { return adsCostIncrease; }
        public double GetCampaignerCostIncrease() { return campaignerCostIncrease; }

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
            rallyCostIncrease = 1.2;
            adsCostIncrease = 1.3;
            donationCostIncrease = 1.05;
            campaignerCostIncrease = 1.05;
        }
        // Methods
        public override void TurnTaken(Dictionary<string, int> statePolling, string[] states, Dictionary<string, int> campaignCosts)
        {
            throw new NotImplementedException();
        }

        public void Rally(string selectedState, Dictionary<string, int> statePolling, int rallyCost, double rallyCostIncrease)
        {
            if (funds >= rallyCost)
            {
                SetFundsPurchase(rallyCost);
                statePolling[selectedState] += 4;
                UpdateCampaignCost("Rally", Convert.ToInt32(rallyCost * rallyCostIncrease));
            }
            else
            {
                throw new InvalidOperationException("Not enough funds to rally.");
            }
        }

        public void Ads(string selectedState, Dictionary<string, int> statePolling, int adsCost, double adsCostIncrease)
        {
            if (funds >= adsCost)
            {
                SetFundsPurchase(adsCost);
                statePolling[selectedState] += 2;
                UpdateCampaignCost("Ads", Convert.ToInt32(adsCost * adsCostIncrease));
            }
            else
            {
                throw new InvalidOperationException("Not enough funds to run ads.");
            }
        }
        public void AddCampaigner(int campaignerCost, double campaignerCostIncrease)
        {
            if (funds >= campaignerCost)
            {
                SetFundsPurchase(campaignerCost);
                SetCampaigners();
                UpdateCampaignCost("Campaigner", Convert.ToInt32(campaignerCost * campaignerCostIncrease));
            }
            else
            {
                throw new InvalidOperationException("Not enough funds to hire a campaigner.");
            }
        }
        public void AddDonator(int donatorCost, double donatorCostIncrease)
        {
            if (funds >= donatorCost)
            {
                SetFundsPurchase(donatorCost);
                SetDonators();
                UpdateCampaignCost("Donators", Convert.ToInt32(donatorCost * donatorCostIncrease));
            }
            else
            {
                throw new InvalidOperationException("Not enough funds to add a donator.");
            }
        }
    }
}
