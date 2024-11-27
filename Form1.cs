using Microsoft.VisualBasic;
using System;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Win538Electors
{
    public partial class Form1 : Form
    {
        Player player = new Player();
        Ai ai = new Ai(); // Initialise the AI with a difficulty of normal, this can be overwriten later.
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
        private Dictionary<string, int> electoralVotes = new Dictionary<string, int> {
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
        bool showAllStates = true;
        bool switchedViewState = false;
        public Form1(string aiDifficulty)
        {
            InitializeComponent();
            ai.SetDifficulty(aiDifficulty);
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
                int pollingValue = 0;
                if (ai.GetDifficulty() == "Easy") { pollingValue = rand.Next(0, 4); }
                if (ai.GetDifficulty() == "Normal") { pollingValue = rand.Next(-2, 3); }
                if (ai.GetDifficulty() == "Hard") { pollingValue = rand.Next(-4, 1); }
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
            lblDifficulty.Text = $"Difficulty: {ai.GetDifficulty()}";
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
                }
                else
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
                }
                else
                {
                    lblRaceCall.BackColor = Color.Red;
                    lblRaceCall.ForeColor = Color.White;
                }
                lblRaceCall.Text = "You've won this race.";
            }
            else if (ai.GetElectors() > 269)
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
            }
            else if (ai.GetElectors() == 269 && player.GetElectors() == 269)
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
            // Player's turn logic
            player.TurnTaken(statePolling, states, GetCampaignCosts(true));
            if (showAllStates == false)
            {
                switchedViewState = true;
            }
            player.SetTurns();
            // AI's turn
            ai.TurnTaken(statePolling, states, GetCampaignCosts(false));
            UpdateGameStatistics();
            if (player.GetTurns() == 0)
            {
                GameUI(true);
                btnEndTurn.Enabled = false;
                btnGetResults.Enabled = true;
            }
            else
            {
                GameUI(false);
            }
            ActionLogRefresh();
        }

        private Dictionary<string, int> GetCampaignCosts(bool isPlayer)
        {
            if (!isPlayer)
            {
                return new Dictionary<string, int> {
                    { "Rally", ai.GetCampaignCost("Rally") },
                    { "Ads", ai.GetCampaignCost("Ads") },
                    { "Campaigner", ai.GetCampaignCost("Campaigner") },
                    { "Donators", ai.GetCampaignCost("Donators") }
                };
            }
            else
            {
                return new Dictionary<string, int> {
                    { "Rally", player.GetCampaignCost("Rally") },
                    { "Ads", player.GetCampaignCost("Ads") },
                    { "Campaigner", player.GetCampaignCost("Campaigner") },
                    { "Donators", player.GetCampaignCost("Donators") }
                };
            }
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
                GameUI(true);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Action Failed");
            }
            UpdateGameStatistics();
        }

        private void btnDonator_Click(object sender, EventArgs e)
        {
            try
            {
                player.AddDonator(player.GetCampaignCost("Donators"), player.GetDonationCostIncrease());
                GameUI(true);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Action Failed");
            }
            UpdateGameStatistics();
        }

        private void btnAdvertisements_Click(object sender, EventArgs e)
        {
            if (listStates.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a state to rally in.");
                return;
            }
            string selectedState = listStates.SelectedItem.ToString();
            try
            {
                player.Ads(selectedState, statePolling, player.GetCampaignCost("Ads"), player.GetAdsCostIncrease());
                GameUI(true);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Action Failed");
            }
            UpdateGameStatistics();
        }
        private void btnCampaigner_Click(object sender, EventArgs e)
        {
            try
            {
                player.AddCampaigner(player.GetCampaignCost("Campaigner"), player.GetCampaignerCostIncrease());
                GameUI(true);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Action Failed");
            }
            UpdateGameStatistics();
        }

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

        public void ActionLogRefresh()
        {
            listActionLog.Items.Clear();
            listActionLogAI.Items.Clear();
            foreach (var action in player.GetLatestAction())
            {
                listActionLog.Items.Add("You: " + action);
            }
            foreach (var action in ai.GetLatestAction())
            {
                listActionLogAI.Items.Add("AI: " + action);
            }
        }
        async void GenerateResults()
        {
            Random rand = new Random();
            foreach (string state in states)
            {
                int odds = rand.Next(1, 11);
                await Task.Delay(1000);
                // Guarantee the AI wins if polling is -5 or below.
                if (statePolling[state] <= -10)
                {
                    AIWinState(state);
                    continue;
                }
                // Determine whether the AI or player wins. 
                bool winAI = statePolling[state] switch // Switch expression: https://www.w3schools.com/cs/cs_switch.php
                {
                    -10 or -9 => odds > 1,
                    -8 or -7 => odds > 2,
                    -6 or -5 => odds > 3,
                    -4 or -3 => odds > 4,
                    -2 or -1 => odds > 5,
                    0 or 1 => odds <= 5,
                    2 or 3 => odds <= 4,
                    4 or 5 => odds <= 3,
                    6 or 7 => odds <= 2,
                    8 or 9 => odds <= 1,
                    >= 10 => false,
                    _ => false
                };
                if (winAI)
                {
                    AIWinState(state);
                }
                else
                {
                    PlayerWinState(state);
                }
                UpdateGameStatistics();
            }
        }

        void PlayerWinState(string state)
        {
            player.SetElectors(electoralVotes[state]);
            ActionLog(true, $"Won {state} with its {electoralVotes[state]} electoral college votes.");
        }
        void AIWinState(string state)
        {
            ai.SetElectors(electoralVotes[state]);
            ActionLog(false, $"Won {state} with its {electoralVotes[state]} electoral college votes.");
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.SaveGame();
            ai.SaveGame();
            FileStream fs = new FileStream("polling.dat", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            foreach (var state in statePolling)
            {
                bw.Write(state.Value);
            }
            bw.Close();
            fs.Close();
            MessageBox.Show("Game saved succesfully.");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.LoadGame();
            ai.LoadGame();
            FileStream fs = new FileStream("polling.dat", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            foreach (var state in states)
            {
                statePolling[state] = br.ReadInt32();
            }
            br.Close();
            fs.Close();
            UpdateGameStatistics();
        }
    }
}