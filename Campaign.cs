using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win538Electors
{
    internal class Campaign
    {
        private Dictionary<string, int> campaignType;
        // Getters
        public int GetCampaignCost(string type)
        {
            return campaignType[type];
        }
        // Setters
        public void SetCampaignCost(string type, int newCost)
        {
            campaignType[type] = newCost;
        }
        // Constructors
        public Campaign()
        {
            campaignType = new Dictionary<string, int>
                {
                    { "Rally", 10000 },
                    { "Ads", 4000 },
                    { "Campaigner", 2000 },
                    { "Donators", 1000 }
                };
        }
    }
}
