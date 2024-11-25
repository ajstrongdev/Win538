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
        private double rallyCostIncrease;
        private double donationCostIncrease;
        private double adsCostIncrease;
        private double campaignerCostIncrease;

        // Getters
        public string GetDifficulty()
        {
            return difficulty;
        }
        public double GetRallyCostIncrease() { return rallyCostIncrease; }
        public double GetDonationCostIncrease() { return donationCostIncrease; }
        public double GetAdsCostIncrease() { return adsCostIncrease; }
        public double GetCampaignerCostIncrease() { return campaignerCostIncrease; }

        // Constructor
        public Ai(string difficulty)
        {
            this.difficulty = difficulty;
            rallyCostIncrease = 1.2;
            adsCostIncrease = 1.3;
            donationCostIncrease = 1.05;
            campaignerCostIncrease = 1.05;
        }

        // Methods
        public override void TurnTaken(Dictionary<string, int> statePolling, string[] states, Dictionary<string, int> campaignCosts)
        {
            int donationsCount = 0;
            // Count donations for the computer
            Enumerable.Range(0, GetDonators()).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int donated = rand.Next(350, 501);
                donationsCount += donated;
            });
            if (donationsCount > 0)
            {
                SetFundsIncrease(donationsCount);
            }
            Enumerable.Range(0, GetCampaigners()).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int stateChosen = rand.Next(0, 50);
                statePolling[states[stateChosen]] -= 1;
            });
            // Start turn logic here.
            string[] statesLosing = statePolling // This will get the states in which the AI is losing in currently
                .Where(state => state.Value > 0)
                .Select(state => state.Key)
                .ToArray();
            // Force the computer to purchase donators early game, making it more balanced.
            if ((GetFunds() < GetCampaignCost("Rally") && GetFunds() < GetCampaignCost("Ads") && GetFunds() < GetCampaignCost("Campaigner") && GetFunds() < GetCampaignCost("Donators")) || GetDonators() < 2)
            {
                if (GetFunds() > GetCampaignCost("Donators"))
                {
                    SetFundsPurchase(GetCampaignCost("Donators"));
                    //ActionLog(false, $"Purchased a donator.");
                    SetDonators();
                    UpdateCampaignCost("Donators", Convert.ToInt32(GetCampaignCost("Donators") * donationCostIncrease));
                    return;
                }
            }
            // State selection
            Random randomState = new Random();
            string selectedState;
            if (statesLosing.Length > 0)
            {
                selectedState = statesLosing[randomState.Next(statesLosing.Length)];
            }
            else
            {
                selectedState = states[randomState.Next(states.Length)];
            }
            if (GetFunds() > GetCampaignCost("Rally"))
            {
                SetFundsPurchase(GetCampaignCost("Rally"));
                statePolling[selectedState] = statePolling[selectedState] - 4;
                //ActionLog(false, $"Held a campaign rally in {selectedState}, decreasing your polling by: -4");
                UpdateCampaignCost("Rally", Convert.ToInt32(GetCampaignCost("Rally") * rallyCostIncrease));
                return;
            }
            else if (GetFunds() > GetCampaignCost("Ads"))
            {
                SetFundsPurchase(GetCampaignCost("Ads"));
                statePolling[selectedState] = statePolling[selectedState] - 2;
                //ActionLog(false, $"Placed TV Advertisements in {selectedState}, decreasing your polling by: -2");
                UpdateCampaignCost("Ads", Convert.ToInt32(GetCampaignCost("Ads") * rallyCostIncrease));
                return;
            }
            else if (GetFunds() > GetCampaignCost("Campaigner"))
            {
                SetFundsPurchase(GetCampaignCost("Campaigner"));
                //ActionLog(false, $"Purchased a campaigner.");
                SetCampaigners();
                UpdateCampaignCost("Campaigner", Convert.ToInt32(GetCampaignCost("Campaigner") * campaignerCostIncrease));
                return;
            }
            else if (GetFunds() > GetCampaignCost("Donators"))
            {
                SetFundsPurchase(GetCampaignCost("Donators"));
                //ActionLog(false, $"Purchased a donator.");
                SetDonators();
                UpdateCampaignCost("Donators", Convert.ToInt32(GetCampaignCost("Donators") * donationCostIncrease));
                return;
            }
            else
            {
                //ActionLog(false, "Skipped their turn, having no money to make an action.");
                return;
            }
        }
    }
}
