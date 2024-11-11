using System;
using static System.Windows.Forms.AxHost;

namespace Win538Electors
{
    public partial class Form1 : Form
    {
        Politician player = new Politician();
        Campaign playerCampaign = new Campaign();
        Politician ai = new Politician();
        Campaign aiCampaign = new Campaign();
        ElectoralCollege electors = new ElectoralCollege();
        string[] states = new string[]
        {
                "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado",
                "Connecticut", "Delaware", "District of Columbia", "Florida", "Georgia", "Hawaii", "Idaho",
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
        double campaignerCostIncrease = 1.05;
        int turnsTaken = 1;
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
            listActionLog.Items.Insert(0, $"--- TURN: {turnsTaken} ^ ---");
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
                lblStateElectors.Text = $"Electors: {electors.electoralVotes[selected]}";
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
            lblFundsAI.Text = $"Funds: ${ai.funds.ToString()}";
            lblTurns.Text = $"Turns left: {player.turns.ToString()}/52";
            lblParty.Text = $"Party: {player.party}";
            lblCampaigners.Text = $"Campaigners: {player.campaigners}";
            lblCampaignersAI.Text = $"Campaigners: {ai.campaigners}";
            lblDonators.Text = $"Donators: {player.donators}";
            lblDonatorsAI.Text = $"Donators: {ai.donators}";
            lblResultsYou.Text = $"{player.electorsWon}";
            lblResultsAI.Text = $"{ai.electorsWon}"; // Change this to use ai.electorsWon when the class has been created here.
            btnRally.Text = $"Rally: ${playerCampaign.campaignType["Rally"]}";
            btnDonator.Text = $"Donator: ${playerCampaign.campaignType["Donators"]}";
            btnCampaigner.Text = $"Campaigner: ${playerCampaign.campaignType["Campaigner"]}";
            btnAdvertisements.Text = $"Advertisements: ${playerCampaign.campaignType["Ads"]}";
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
                btnEndTurn.Enabled = true;
                btnDonator.Enabled = false;
            }
            else
            {
                btnAdvertisements.Enabled = true;
                btnCampaigner.Enabled = true;
                btnRally.Enabled = true;
                btnDonator.Enabled = true;
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
            turnsTaken += 1;
            player.turns = player.turns - 1;
            int donationsCount = 0;
            // Count donations
            Enumerable.Range(0, player.donators).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int donated = rand.Next(350, 501);
                donationsCount += donated;
            });
            // Increase polling by +1 per campaigner for a random state (per campaigner)
            Enumerable.Range(0, player.campaigners).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int stateChosen = rand.Next(0, 50);
                statePolling[states[stateChosen]] += 1;
                ActionLog(true, $"A campaigner increased your polling by +1 in {states[stateChosen]}");
            });
            if (donationsCount > 0)
            {
                player.funds += donationsCount;
                ActionLog(true, $"secured ${donationsCount} of funding this turn from your {player.donators} donators.");
            }
            ComputerTurn();
            UpdateGameStatistics();
            if (player.turns != 0)
            {
                GameUI(false);
            }
            else
            {
                GameUI(true);
                btnGetResults.Enabled = true;
                btnEndTurn.Enabled = false;
                btnDonator.Enabled = false;
            }
            listActionLog.Items.Insert(0, $"--- TURN: {turnsTaken} ^ ---");
            listActionLogAI.Items.Insert(0, $"--- TURN: {turnsTaken} ^ ---");
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
                    MessageBox.Show("Not enough funds.", "Warning: Insufficient funds");
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
                listActionLogAI.Items.Insert(0, $"The Computer: {action}");
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
            GameUI(true);
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
                    MessageBox.Show("Not enough funds.", "Warning: Insufficient funds");
                }
            }
            else
            {
                MessageBox.Show("Please select a state to campaign in");
            }
            UpdateGameStatistics();
        }

        private void btnCampaigner_Click(object sender, EventArgs e)
        {
            int cost = playerCampaign.campaignType["Campaigner"];
            if (player.funds >= cost)
            {
                GameUI(true);
                player.funds = player.funds - cost;
                ActionLog(true, $"You purchased a campaigner.");
                player.campaigners += 1;
                playerCampaign.campaignType["Campaigner"] = Convert.ToInt32(cost * campaignerCostIncrease);
            }
            else
            {
                MessageBox.Show("Not enough funds.", "Warning: Insufficient funds");
            }
            UpdateGameStatistics();
        }

        async void GenerateResults()
        {
            foreach (string state in states)
            {
                await Task.Delay(1000);
                if (statePolling[state] < 0)
                {
                    ai.electorsWon = ai.electorsWon + electors.electoralVotes[state];
                    ActionLog(false, $"Won {state} with its {electors.electoralVotes[state]} electoral college votes.");
                }
                else if (statePolling[state] > 0)
                {
                    player.electorsWon = player.electorsWon + electors.electoralVotes[state];
                    ActionLog(true, $"Won {state} with its {electors.electoralVotes[state]} electoral college votes.");
                }
                else if (statePolling[state] == 0)
                {
                    Random rand = new Random();
                    int swingStateWinner = rand.Next(0, 2);
                    if (swingStateWinner == 0)
                    {
                        ai.electorsWon = ai.electorsWon + electors.electoralVotes[state];
                        ActionLog(false, $"Won {state} with its {electors.electoralVotes[state]} electoral college votes.");
                    }
                    else if (swingStateWinner == 1)
                    {
                        player.electorsWon = player.electorsWon + electors.electoralVotes[state];
                        ActionLog(true, $"Won {state} with its {electors.electoralVotes[state]} electoral college votes.");
                    }
                }
                UpdateGameStatistics();
            }
        }

        private void btnGetResults_Click(object sender, EventArgs e)
        {
            btnGetResults.Enabled = false;
            GenerateResults();
        }

        void ComputerTurn()
        {
            int donationsCount = 0;
            // Count donations for the computer
            Enumerable.Range(0, ai.donators).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int donated = rand.Next(350, 501);
                donationsCount += donated;
            });
            if (donationsCount > 0)
            {
                ai.funds += donationsCount;
            }
            // Decrease (increase for the computer) polling by -1 per campaigner for a random state (per campaigner)
            Enumerable.Range(0, ai.campaigners).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int stateChosen = rand.Next(0, 50);
                statePolling[states[stateChosen]] -= 1;
                //ActionLog(false, $"A campaigner decreased your polling by -1 in {states[stateChosen]}");
            });

            // Computer turn logic here.
            string[] statesLosing = statePolling // This will get the states in which the AI is losing in currently
                .Where(state => state.Value > 0)
                .Select(state => state.Key)
                .ToArray();
            if ((ai.funds < aiCampaign.campaignType["Rally"] && ai.funds < aiCampaign.campaignType["Ads"] && ai.funds < aiCampaign.campaignType["Campaigner"] && ai.funds < aiCampaign.campaignType["Donators"]) || ai.donators < 2)
            {
                if (ai.funds > aiCampaign.campaignType["Donators"])
                {
                    ai.funds = ai.funds - aiCampaign.campaignType["Donators"];
                    ActionLog(false, $"Purchased a donator.");
                    ai.donators += 1;
                    aiCampaign.campaignType["Donators"] = Convert.ToInt32(aiCampaign.campaignType["Donators"] * donationCostIncrease);
                    return;
                }
            }

            Random randomState = new Random();
            string selectedState;
            if (statesLosing.Length > 0)
            {
                selectedState = statesLosing[randomState.Next(statesLosing.Length)];
            } else
            {
                selectedState = states[randomState.Next(states.Length)];
            }
                if (ai.funds > aiCampaign.campaignType["Rally"])
            {
                ai.funds = ai.funds - aiCampaign.campaignType["Rally"];
                statePolling[selectedState] = statePolling[selectedState] - 4;
                ActionLog(false, $"Held a campaign rally in {selectedState}, decreasing your polling by: -4");
                aiCampaign.campaignType["Rally"] = Convert.ToInt32(aiCampaign.campaignType["Rally"] * rallyCostIncrease);
                return;
            }
            else if (ai.funds > aiCampaign.campaignType["Ads"])
            {
                ai.funds = ai.funds - aiCampaign.campaignType["Ads"];
                statePolling[selectedState] = statePolling[selectedState] - 2;
                ActionLog(false, $"Placed TV Advertisements in {selectedState}, decreasing your polling by: -2");
                aiCampaign.campaignType["Ads"] = Convert.ToInt32(aiCampaign.campaignType["Ads"] * rallyCostIncrease);
                return;
            }
            else if (ai.funds > aiCampaign.campaignType["Campaigner"])
            {
                ai.funds = ai.funds - aiCampaign.campaignType["Campaigner"];
                ActionLog(false, $"Purchased a campaigner.");
                ai.campaigners += 1;
                aiCampaign.campaignType["Campaigner"] = Convert.ToInt32(aiCampaign.campaignType["Campaigner"] * campaignerCostIncrease);
                return;
            }
            else if (ai.funds > aiCampaign.campaignType["Donators"])
            {
                ai.funds = ai.funds - aiCampaign.campaignType["Donators"];
                ActionLog(false, $"Purchased a donator.");
                ai.donators += 1;
                aiCampaign.campaignType["Donators"] = Convert.ToInt32(aiCampaign.campaignType["Donators"] * donationCostIncrease);
                return;
            } else
            {
                ActionLog(false, "Skipped their turn, having no money to make an action.");
                return;
            }
        }
    }
}