using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win538Electors
{
    internal class Campaign
    {
        public Dictionary<string, int> campaignType = new Dictionary<string, int>()
        {
            { "Rally", 10000 },
            { "Ads", 4000 },
            { "Campaigner", 2000 },
            { "Donators", 1000 },
        };
    }
}
