using System;
using static System.Windows.Forms.AxHost;

namespace Win538Electors
{
    public partial class Form1 : Form
    {
        Player player = new Player();
        Ai ai = new Ai("Normal");
        private string[] states = new string[]
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
        private Dictionary<string,int> electoralVotes = new Dictionary<string, int> {
                { "Alabama", 9 },
                { "Alaska", 3 },
                { "Arizona", 11 },
                { "Arkansas", 6 },
                { "California", 54 },
                { "Colorado", 10 },
                { "Connecticut", 7 },
                { "Delaware", 3 },
                { "District of Columbia", 3 },
                { "Florida", 30 },
                { "Georgia", 16 },
                { "Hawaii", 4 },
                { "Idaho", 4 },
                { "Illinois", 19 },
                { "Indiana", 11 },
                { "Iowa", 6 },
                { "Kansas", 6 },
                { "Kentucky", 8 },
                { "Louisiana", 8 },
                { "Maine", 4 },
                { "Maryland", 10 },
                { "Massachusetts", 11 },
                { "Michigan", 15 },
                { "Minnesota", 10 },
                { "Mississippi", 6 },
                { "Missouri", 10 },
                { "Montana", 4 },
                { "Nebraska", 5 },
                { "Nevada", 6 },
                { "New Hampshire", 4 },
                { "New Jersey", 14 },
                { "New Mexico", 5 },
                { "New York", 28 },
                { "North Carolina", 16 },
                { "North Dakota", 3 },
                { "Ohio", 17 },
                { "Oklahoma", 7 },
                { "Oregon", 8 },
                { "Pennsylvania", 19 },
                { "Rhode Island", 4 },
                { "South Carolina", 9 },
                { "South Dakota", 3 },
                { "Tennessee", 11 },
                { "Texas", 40 },
                { "Utah", 6 },
                { "Vermont", 3 },
                { "Virginia", 13 },
                { "Washington", 12 },
                { "West Virginia", 4 },
                { "Wisconsin", 10 },
                { "Wyoming", 3 },
            };
    private Dictionary<string, int> statePolling = new Dictionary<string, int>();
        int turnsTaken = 1;
        bool showAllStates = true;
        bool switchedViewState = false;
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
            //GameUI(false); // False indicates that a turn has not been completed.
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
                lblStateElectors.Text = $"Electors: {electoralVotes[selected]}";
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
            lblFunds.Text = $"Funds: ${player.GetFunds().ToString()}";
            lblFundsAI.Text = $"Funds: ${ai.GetFunds().ToString()}";
            lblTurns.Text = $"Turns left: {player.GetTurns().ToString()}/52";
            lblParty.Text = $"Party: {player.GetParty()}";
            lblCampaigners.Text = $"Campaigners: {player.GetCampaigners()}";
            lblCampaignersAI.Text = $"Campaigners: {ai.GetCampaigners()}";
            lblDonators.Text = $"Donators: {player.GetDonators()}";
            lblDonatorsAI.Text = $"Donators: {ai.GetDonators()}";
            lblResultsYou.Text = $"{player.GetElectors()}";
            lblResultsAI.Text = $"{ai.GetElectors()}"; // Change this to use ai.electorsWon when the class has been created here.
            btnRally.Text = $"Rally: ${player.GetCampaignCost("Rally")}";
            btnDonator.Text = $"Donator: ${player.GetCampaignCost("Donators")}";
            btnCampaigner.Text = $"Campaigner: ${player.GetCampaignCost("Campaigner")}";
            btnAdvertisements.Text = $"Advertisements: ${player.GetCampaignCost("Ads")}";
            if (player.GetParty() == "Democratic Party")
            {
                lblParty.ForeColor = Color.Blue;
                lblResultsYou.ForeColor = Color.Blue;
                lblResultsAI.ForeColor = Color.Red;
            }
            else if (player.GetParty() == "Republican Party")
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
            // Display by states losing if selected.
            if (switchedViewState == true)
            {
                if (showAllStates == true)
                {
                    listStates.Items.Clear();
                    foreach (string state in states)
                    {
                        listStates.Items.Add(state);
                    }
                } else
                {
                    listStates.Items.Clear();
                    string[] losingStates = statePolling // This will get the states in which the AI is losing in currently
                        .Where(state => state.Value < 0)
                        .Select(state => state.Key)
                        .ToArray();
                    foreach (string state in losingStates)
                    {
                        listStates.Items.Add(state);
                    }
                }
                switchedViewState = false;
            }

            if (player.GetTurns() == 0)
            {
                lblRaceCall.Text = "Race yet to be called.";
            }

            if (player.GetElectors() > 269)
            {
                if (player.GetParty() == "Democratic Party")
                {
                    lblRaceCall.BackColor = Color.Blue;
                    lblRaceCall.ForeColor = Color.White;
                } else
                {
                    lblRaceCall.BackColor = Color.Red;
                    lblRaceCall.ForeColor = Color.White;
                }
                lblRaceCall.Text = "You've won this race.";
            } else if (ai.GetElectors() > 269)
            {
                if (player.GetParty() == "Democratic Party")
                {
                    lblRaceCall.BackColor = Color.Red;
                    lblRaceCall.ForeColor = Color.White;
                }
                else
                {
                    lblRaceCall.BackColor = Color.Blue;
                    lblRaceCall.ForeColor = Color.White;
                }
                lblRaceCall.Text = "You've lost this race.";
            } else if (ai.GetElectors() == 269 && player.GetElectors() == 269)
            {
                lblRaceCall.Text = "Electoral college tie.";
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
            player.SetParty("Democratic Party");
            UpdateGameStatistics();
            mnuSelectParty.Enabled = false;
        }

        private void mnuRepublican_Click(object sender, EventArgs e)
        {
            player.SetParty("Republican Party");
            UpdateGameStatistics();
            mnuSelectParty.Enabled = false;
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            if (showAllStates == false)
            {
                switchedViewState = true;
            }
            turnsTaken += 1;
            player.SetTurns();
            int donationsCount = 0;
            // Count donations
            Enumerable.Range(0, player.GetDonators()).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int donated = rand.Next(350, 501);
                donationsCount += donated;
            });
            // Increase polling by +1 per campaigner for a random state (per campaigner)
            Enumerable.Range(0, player.GetCampaigners()).ToList().ForEach(i =>
            {
                Random rand = new Random();
                int stateChosen = rand.Next(0, 50);
                statePolling[states[stateChosen]] += 1;
                ActionLog(true, $"A campaigner increased your polling by +1 in {states[stateChosen]}");
            });
            if (donationsCount > 0)
            {
                player.SetFundsIncrease(donationsCount);
                ActionLog(true, $"secured ${donationsCount} of funding this turn from your {player.GetDonators()} donators.");
            }
            ComputerTurn();
            UpdateGameStatistics();
            if (player.GetTurns() != 0)
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
            if (listStates.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a state to rally in.");
                return;
            }
            string selectedState = listStates.SelectedItem.ToString();
            try
            {
                player.Rally(selectedState, statePolling, player.GetCampaignCost("Rally"), player.GetRallyCostIncrease());
                ActionLog(true, $"Held a rally in {selectedState}.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Action Failed");
            }
            UpdateGameStatistics();
        }

        // Public as game messages from Ai.cs and Player.cs need to be passed through to the form.
        public void ActionLog(bool isPlayer, string action)
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
            int cost = player.GetCampaignCost("Donators");
            if (player.GetFunds() >= cost)
            {
                player.SetFundsPurchase(cost);
                ActionLog(true, $"Purchased a donator.");
                player.SetDonators();
                player.SetCampaignCost("Donators", Convert.ToInt32(cost * donationCostIncrease));
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
            int cost = player.GetCampaignCost("Ads");
            if (listStates.SelectedIndex != -1) // Make sure a user has a state selected when campaigning
            {
                if (player.GetFunds() >= cost)
                {
                    GameUI(true);
                    player.SetFundsPurchase(cost);
                    string selected = listStates.SelectedItem.ToString().Trim();
                    statePolling[selected] = statePolling[selected] + 2;
                    ActionLog(true, $"Placed TV Advertisements in {selected}, increasing your polling by: +2");
                    player.SetCampaignCost("Ads", Convert.ToInt32(cost * adsCostIncrease));
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
            int cost = player.GetCampaignCost("Campaigner");
            if (player.GetFunds() >= cost)
            {
                GameUI(true);
                player.SetFundsPurchase(cost);
                ActionLog(true, $"You purchased a campaigner.");
                player.SetCampaigners();
                player.SetCampaignCost("Campaigner", Convert.ToInt32(cost * campaignerCostIncrease));
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
                    ai.SetElectors(electoralVotes[state]);
                    ActionLog(false, $"Won {state} with its {electoralVotes[state]} electoral college votes.");
                }
                else if (statePolling[state] > 0)
                {
                    player.SetElectors(electoralVotes[state]);
                    ActionLog(true, $"Won {state} with its {electoralVotes[state]} electoral college votes.");
                }
                else if (statePolling[state] == 0)
                {
                    Random rand = new Random();
                    int swingStateWinner = rand.Next(0, 2);
                    if (swingStateWinner == 0)
                    {
                        ai.SetElectors(electoralVotes[state]);
                        ActionLog(false, $"Won {state} with its {electoralVotes[state]} electoral college votes.");
                    }
                    else if (swingStateWinner == 1)
                    {
                        player.SetElectors(electoralVotes[state]);
                        ActionLog(true, $"Won {state} with its {electoralVotes[state]} electoral college votes.");
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

        private void mnuAllStates_Click(object sender, EventArgs e)
        {
            switchedViewState = true;
            showAllStates = true;
            UpdateGameStatistics();
        }

        private void mnuStatesLosing_Click(object sender, EventArgs e)
        {
            switchedViewState = true;
            showAllStates = false;
            UpdateGameStatistics();
        }
    }
}