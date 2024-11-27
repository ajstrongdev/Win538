using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            SetTurnTicker(); // Count a turn
            // Count donations
            int donationsCount = 0;
            Enumerable.Range(0, GetDonators()).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int donated = rand.Next(350, 501);
                donationsCount += donated;
            });
            // Increase polling by +1 per campaigner for a random state (per campaigner)
            Enumerable.Range(0, GetCampaigners()).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int stateChosen = rand.Next(0, 50);
                statePolling[states[stateChosen]] += 1;
                SetLatestAction($"A campaigner increased your polling by +1 in {states[stateChosen]} ({GetTurnTicker()})");
            });
            if (donationsCount > 0)
            {
                SetFundsIncrease(donationsCount);
                SetLatestAction($"secured ${donationsCount} of funding this turn from your {GetDonators()} donators. ({GetTurnTicker()})");
            }
        }

        public override void SaveGame()
        {
            FileStream fs = new FileStream("player.dat", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(GetFunds());
            bw.Write(GetCampaigners());
            bw.Write(GetDonators());
            bw.Write(GetCampaignCost("Rally"));
            bw.Write(GetCampaignCost("Ads"));
            bw.Write(GetCampaignCost("Campaigner"));
            bw.Write(GetCampaignCost("Donators"));
            bw.Write(GetParty());
            bw.Write(GetTurns());
            bw.Close();
            fs.Close();
        }

        public override void LoadGame()
        {
            FileStream fs = new FileStream("player.dat", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            this.funds = br.ReadInt32();
            this.campaigners = br.ReadInt32();
            this.donators = br.ReadInt32();
            UpdateCampaignCost("Rally", br.ReadInt32());
            UpdateCampaignCost("Ads", br.ReadInt32());
            UpdateCampaignCost("Campaigner", br.ReadInt32());
            UpdateCampaignCost("Donators", br.ReadInt32());
            this.party = br.ReadString();
            this.turns = br.ReadInt32();
            br.Close();
            fs.Close();
        }

        public void Rally(string selectedState, Dictionary<string, int> statePolling, int rallyCost, double rallyCostIncrease)
        {
            if (funds >= rallyCost)
            {
                SetFundsPurchase(rallyCost);
                statePolling[selectedState] += 4;
                UpdateCampaignCost("Rally", Convert.ToInt32(rallyCost * rallyCostIncrease));
                SetLatestAction($"Held a campaign rally in {selectedState}, increasing your polling by: +4 ({GetTurnTicker()})");
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
                SetLatestAction($"Placed TV Advertisements in {selectedState}, increasing your polling by: +2 ({GetTurnTicker()})");
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
                SetLatestAction($"Purchased a campaigner. ({GetTurnTicker()})");
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
                SetLatestAction($"Purchased a donator. ({GetTurnTicker()})");
            }
            else
            {
                throw new InvalidOperationException("Not enough funds to add a donator.");
            }
        }
    }
}
