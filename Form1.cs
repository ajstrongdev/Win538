namespace Win538Electors
{
    public partial class Form1 : Form
    {
        Politician player = new Politician();
        Campaign playerCampaign = new Campaign();
        string[] states = new string[]
        {
                "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado",
                "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho",
                "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana",
                "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota",
                "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada",
                "New Hampshire", "New Jersey", "New Mexico", "New York",
                "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon",
                "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota",
                "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington",
                "West Virginia", "Wisconsin", "Wyoming"
        };
        Dictionary<string, int> statePolling = new Dictionary<string, int>();
        double rallyCostIncrease = 1.2;
        double adsCostIncrease = 1.3;
        double donationCostIncrease = 1.05;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GameInit();
        }
        void GameInit()
        {
            foreach (string state in states)
            {
                listStates.Items.Add(state);
            }
            GeneratePolling();
            GameUI(false); // False indicates that a turn has not been completed.
        }
        void GeneratePolling()
        {
            Random rand = new Random();
            foreach (string state in states)
            {
                int pollingValue = rand.Next(-2, 3);
                statePolling[state] = pollingValue;
            }
            UpdateGameStatistics();
        }
        void UpdateGameStatistics()
        {
            if (listStates.SelectedIndex != -1) // If an item is selected.
            {
                string selected = listStates.SelectedItem.ToString().Trim();
                if (statePolling[selected] > 0)
                {
                    lblStatePolling.Text = $"{selected} polling: +{statePolling[selected]}"; // The if statement is literally here only to render "+" if polling positive.
                }
                else
                {
                    lblStatePolling.Text = $"{selected} polling: {statePolling[selected]}";
                }

            }
            if (statePolling.Values.Count != 0)
            {
                int nationalPolls = statePolling.Values.Sum();
                if (nationalPolls > 0)
                {
                    lblNationalPolls.Text = $"National polling: +{nationalPolls}";
                }
                else
                {
                    lblNationalPolls.Text = $"National polling: {nationalPolls}";
                }
            }
            lblFunds.Text = $"Funds: ${player.funds.ToString()}";
            lblTurns.Text = $"Turns left: {player.turns.ToString()}/52";
            lblParty.Text = $"Party: {player.party}";
            lblCampaigners.Text = $"Campaigners: {player.campaigners}";
            lblDonators.Text = $"Donators: {player.donators}";
            lblMerchandise.Text = $"Merchandise sales: {player.sales}";
            lblResultsYou.Text = $"{player.electorsWon}";
            lblResultsAI.Text = $"0"; // Change this to use ai.electorsWon when the class has been created here.
            btnRally.Text = $"Rally: ${playerCampaign.campaignType["Rally"]}";
            btnDonator.Text = $"Donator: ${playerCampaign.campaignType["Donators"]}";
            if (player.party == "Democratic Party")
            {
                lblParty.ForeColor = Color.Blue;
                lblResultsYou.ForeColor = Color.Blue;
                lblResultsAI.ForeColor = Color.Red;
            }
            else if (player.party == "Republican Party")
            {
                lblParty.ForeColor = Color.Red;
                lblResultsYou.ForeColor = Color.Red;
                lblResultsAI.ForeColor = Color.Blue;
            }
            else
            {
                lblParty.ForeColor = Color.Black;
                lblResultsYou.ForeColor = Color.Black;
                lblResultsAI.ForeColor = Color.Black;
            }

            if (player.turns == 0) // If the player is out of turns, display the "get results" button
            {
                GameUI(true);
                btnGetResults.Enabled = true;
                btnEndTurn.Enabled = false;
                btnDonator.Enabled = false;
            }

        }
        private void listStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGameStatistics();
        }

        void GameUI(bool turnComplete)
        {
            if (turnComplete == true)
            {
                btnAdvertisements.Enabled = false;
                btnCampaigner.Enabled = false;
                btnRally.Enabled = false;
                btnCampaigner.Enabled = false;
                //btnSuperPAC.Enabled = false;
                btnEndTurn.Enabled = true;
            }
            else
            {
                btnAdvertisements.Enabled = true;
                btnCampaigner.Enabled = true;
                btnRally.Enabled = true;
            }
        }

        private void mnuDemocrat_Click(object sender, EventArgs e)
        {
            player.party = "Democratic Party";
            UpdateGameStatistics();
            mnuSelectParty.Enabled = false;
        }

        private void mnuRepublican_Click(object sender, EventArgs e)
        {
            player.party = "Republican Party";
            UpdateGameStatistics();
            mnuSelectParty.Enabled = false;
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {

            player.turns = player.turns - 1;
            int donationsCount = 0;
            // Count donations
            Enumerable.Range(0, player.donators).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int donated = rand.Next(350, 501);
                donationsCount += donated;
            });
            if (donationsCount > 0)
            {
                player.funds += donationsCount;
                ActionLog(true, $"secured ${donationsCount} of funding this turn from your {player.donators} donators.");
            }
            UpdateGameStatistics();
            if (player.turns != 0)
            {
                GameUI(false);
            }
        }

        private void btnCampaignRally_Click(object sender, EventArgs e)
        {
            int cost = playerCampaign.campaignType["Rally"];
            if (listStates.SelectedIndex != -1) // Make sure a user has a state selected when campaigning
            {
                if (player.funds >= cost)
                {
                    GameUI(true);
                    player.funds = player.funds - cost;
                    string selected = listStates.SelectedItem.ToString().Trim();
                    statePolling[selected] = statePolling[selected] + 4;
                    ActionLog(true, $"Held a campaign rally in {selected}, increasing your polling by: +4");
                    playerCampaign.campaignType["Rally"] = Convert.ToInt32(cost * rallyCostIncrease);
                }
                else
                {
                    MessageBox.Show("Not enough campaign points", "Warning: Insufficient funds");
                }
            }
            else
            {
                MessageBox.Show("Please select a state to campaign in");
            }
            UpdateGameStatistics();
        }

        void ActionLog(bool isPlayer, string action)
        {
            if (!isPlayer)
            {
                listActionLog.Items.Insert(0, $"Computer: {action}");
            }
            else
            {
                listActionLog.Items.Insert(0, $"You: {action}");
            }
        }

        private void btnDonator_Click(object sender, EventArgs e)
        {
            int cost = playerCampaign.campaignType["Donators"];
            if (player.funds >= cost)
            {
                player.funds = player.funds - cost;
                ActionLog(true, $"Purchased a donator.");
                player.donators += 1;
                playerCampaign.campaignType["Donators"] = Convert.ToInt32(cost * donationCostIncrease);
            }
            else
            {
                MessageBox.Show("Not enough funds.", "Warning: Insufficient funds");
            }
            UpdateGameStatistics();
        }

        private void btnAdvertisements_Click(object sender, EventArgs e)
        {
            int cost = playerCampaign.campaignType["Ads"];
            if (listStates.SelectedIndex != -1) // Make sure a user has a state selected when campaigning
            {
                if (player.funds >= cost)
                {
                    GameUI(true);
                    player.funds = player.funds - cost;
                    string selected = listStates.SelectedItem.ToString().Trim();
                    statePolling[selected] = statePolling[selected] + 2;
                    ActionLog(true, $"Placed TV Advertisements in {selected}, increasing your polling by: +2");
                    playerCampaign.campaignType["Ads"] = Convert.ToInt32(cost * adsCostIncrease);
                }
                else
                {
                    MessageBox.Show("Not enough campaign points", "Warning: Insufficient funds");
                }
            }
            else
            {
                MessageBox.Show("Please select a state to campaign in");
            }
            UpdateGameStatistics();
        }

    }
}
