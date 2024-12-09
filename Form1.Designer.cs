namespace Win538Electors
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listStates = new ListBox();
            lblResultsAI = new Label();
            lblResultsYou = new Label();
            groupBox1 = new GroupBox();
            lblStateElectors = new Label();
            lblStatePolling = new Label();
            lblNationalPolls = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            lblRaceCall = new Label();
            lblDonators = new Label();
            lblCampaigners = new Label();
            lblTurns = new Label();
            lblFunds = new Label();
            lblParty = new Label();
            groupBox4 = new GroupBox();
            btnDonator = new Button();
            btnEndTurn = new Button();
            btnGetResults = new Button();
            menuStrip1 = new MenuStrip();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            mnuAllStates = new ToolStripMenuItem();
            mnuStatesLosing = new ToolStripMenuItem();
            gameToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            mnuSelectParty = new ToolStripMenuItem();
            mnuDemocrat = new ToolStripMenuItem();
            mnuRepublican = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            groupBox3 = new GroupBox();
            btnRally = new Button();
            btnAdvertisements = new Button();
            btnCampaigner = new Button();
            groupBox5 = new GroupBox();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            label15 = new Label();
            label13 = new Label();
            groupBox6 = new GroupBox();
            listActionLog = new ListBox();
            groupBox7 = new GroupBox();
            lblDifficulty = new Label();
            lblFundsAI = new Label();
            lblDonatorsAI = new Label();
            lblCampaignersAI = new Label();
            groupBox8 = new GroupBox();
            listActionLogAI = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // listStates
            // 
            listStates.Font = new Font("Noto Sans", 12F);
            listStates.FormattingEnabled = true;
            listStates.ItemHeight = 30;
            listStates.Location = new Point(9, 40);
            listStates.Name = "listStates";
            listStates.Size = new Size(150, 604);
            listStates.TabIndex = 0;
            listStates.SelectedIndexChanged += listStates_SelectedIndexChanged;
            // 
            // lblResultsAI
            // 
            lblResultsAI.AutoSize = true;
            lblResultsAI.Font = new Font("Noto Sans", 35.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultsAI.ForeColor = Color.Red;
            lblResultsAI.Location = new Point(661, 74);
            lblResultsAI.Name = "lblResultsAI";
            lblResultsAI.Size = new Size(141, 91);
            lblResultsAI.TabIndex = 1;
            lblResultsAI.Text = "312";
            // 
            // lblResultsYou
            // 
            lblResultsYou.AutoSize = true;
            lblResultsYou.Font = new Font("Noto Sans", 35.9999962F, FontStyle.Bold);
            lblResultsYou.ForeColor = Color.Blue;
            lblResultsYou.Location = new Point(146, 74);
            lblResultsYou.Name = "lblResultsYou";
            lblResultsYou.Size = new Size(141, 91);
            lblResultsYou.TabIndex = 2;
            lblResultsYou.Text = "226";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStateElectors);
            groupBox1.Controls.Add(lblStatePolling);
            groupBox1.Controls.Add(lblNationalPolls);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblResultsYou);
            groupBox1.Controls.Add(lblResultsAI);
            groupBox1.Font = new Font("Noto Sans", 16F);
            groupBox1.Location = new Point(185, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(950, 232);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Results";
            // 
            // lblStateElectors
            // 
            lblStateElectors.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblStateElectors.AutoSize = true;
            lblStateElectors.Font = new Font("Noto Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStateElectors.Location = new Point(361, 167);
            lblStateElectors.Name = "lblStateElectors";
            lblStateElectors.Size = new Size(108, 30);
            lblStateElectors.TabIndex = 6;
            lblStateElectors.Text = "Electors: 0";
            // 
            // lblStatePolling
            // 
            lblStatePolling.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblStatePolling.AutoSize = true;
            lblStatePolling.Font = new Font("Noto Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatePolling.Location = new Point(361, 119);
            lblStatePolling.Name = "lblStatePolling";
            lblStatePolling.Size = new Size(149, 30);
            lblStatePolling.TabIndex = 5;
            lblStatePolling.Text = "State polling: 0";
            // 
            // lblNationalPolls
            // 
            lblNationalPolls.AutoSize = true;
            lblNationalPolls.Font = new Font("Noto Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNationalPolls.Location = new Point(361, 74);
            lblNationalPolls.Name = "lblNationalPolls";
            lblNationalPolls.Size = new Size(191, 30);
            lblNationalPolls.TabIndex = 3;
            lblNationalPolls.Text = "National Polling: +8";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Noto Sans", 24F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(793, 96);
            label4.Name = "label4";
            label4.Size = new Size(67, 61);
            label4.TabIndex = 4;
            label4.Text = "AI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Noto Sans", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(55, 96);
            label3.Name = "label3";
            label3.Size = new Size(97, 61);
            label3.TabIndex = 3;
            label3.Text = "You";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblRaceCall);
            groupBox2.Controls.Add(lblDonators);
            groupBox2.Controls.Add(lblCampaigners);
            groupBox2.Controls.Add(lblTurns);
            groupBox2.Controls.Add(lblFunds);
            groupBox2.Controls.Add(lblParty);
            groupBox2.Font = new Font("Noto Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(185, 278);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(319, 266);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Information";
            // 
            // lblRaceCall
            // 
            lblRaceCall.AutoSize = true;
            lblRaceCall.BackColor = Color.LightGray;
            lblRaceCall.Font = new Font("Noto Sans", 16.2F);
            lblRaceCall.Location = new Point(10, 202);
            lblRaceCall.Name = "lblRaceCall";
            lblRaceCall.Size = new Size(277, 42);
            lblRaceCall.TabIndex = 15;
            lblRaceCall.Text = "Campaign on-going";
            // 
            // lblDonators
            // 
            lblDonators.AutoSize = true;
            lblDonators.Font = new Font("Noto Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDonators.Location = new Point(6, 169);
            lblDonators.Name = "lblDonators";
            lblDonators.Size = new Size(132, 30);
            lblDonators.TabIndex = 4;
            lblDonators.Text = "Donators: 12";
            // 
            // lblCampaigners
            // 
            lblCampaigners.AutoSize = true;
            lblCampaigners.Font = new Font("Noto Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCampaigners.Location = new Point(6, 139);
            lblCampaigners.Name = "lblCampaigners";
            lblCampaigners.Size = new Size(169, 30);
            lblCampaigners.TabIndex = 3;
            lblCampaigners.Text = "Campaigners: 30";
            // 
            // lblTurns
            // 
            lblTurns.AutoSize = true;
            lblTurns.Font = new Font("Noto Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTurns.Location = new Point(6, 109);
            lblTurns.Name = "lblTurns";
            lblTurns.Size = new Size(161, 30);
            lblTurns.TabIndex = 2;
            lblTurns.Text = "Turns left: 03/52";
            // 
            // lblFunds
            // 
            lblFunds.AutoSize = true;
            lblFunds.Font = new Font("Noto Sans", 12F);
            lblFunds.Location = new Point(6, 77);
            lblFunds.Name = "lblFunds";
            lblFunds.Size = new Size(145, 30);
            lblFunds.TabIndex = 1;
            lblFunds.Text = "Funds: $10000";
            // 
            // lblParty
            // 
            lblParty.AutoSize = true;
            lblParty.Font = new Font("Noto Sans", 12F);
            lblParty.ForeColor = Color.Blue;
            lblParty.Location = new Point(6, 45);
            lblParty.Name = "lblParty";
            lblParty.Size = new Size(232, 30);
            lblParty.TabIndex = 0;
            lblParty.Text = "Party: Democratic Party";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnDonator);
            groupBox4.Font = new Font("Noto Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(522, 477);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(203, 164);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Fundraising";
            // 
            // btnDonator
            // 
            btnDonator.Font = new Font("Noto Sans", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDonator.Location = new Point(15, 57);
            btnDonator.Name = "btnDonator";
            btnDonator.Size = new Size(173, 91);
            btnDonator.TabIndex = 13;
            btnDonator.Text = "Donator: $1000";
            btnDonator.UseVisualStyleBackColor = true;
            btnDonator.Click += btnDonator_Click;
            // 
            // btnEndTurn
            // 
            btnEndTurn.Font = new Font("Noto Sans", 10.2F);
            btnEndTurn.Location = new Point(185, 550);
            btnEndTurn.Name = "btnEndTurn";
            btnEndTurn.Size = new Size(148, 91);
            btnEndTurn.TabIndex = 7;
            btnEndTurn.Text = "End Turn";
            btnEndTurn.UseVisualStyleBackColor = true;
            btnEndTurn.Click += btnEndTurn_Click;
            // 
            // btnGetResults
            // 
            btnGetResults.Enabled = false;
            btnGetResults.Font = new Font("Noto Sans", 10.2F);
            btnGetResults.Location = new Point(356, 550);
            btnGetResults.Name = "btnGetResults";
            btnGetResults.Size = new Size(148, 91);
            btnGetResults.TabIndex = 8;
            btnGetResults.Text = "Results";
            btnGetResults.UseVisualStyleBackColor = true;
            btnGetResults.Click += btnGetResults_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { optionsToolStripMenuItem, mnuSelectParty, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1355, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, viewToolStripMenuItem, gameToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(75, 24);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(133, 26);
            aboutToolStripMenuItem.Text = "About";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuAllStates, mnuStatesLosing });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(133, 26);
            viewToolStripMenuItem.Text = "View";
            // 
            // mnuAllStates
            // 
            mnuAllStates.Name = "mnuAllStates";
            mnuAllStates.Size = new Size(176, 26);
            mnuAllStates.Text = "All states";
            mnuAllStates.Click += mnuAllStates_Click;
            // 
            // mnuStatesLosing
            // 
            mnuStatesLosing.Name = "mnuStatesLosing";
            mnuStatesLosing.Size = new Size(176, 26);
            mnuStatesLosing.Text = "States losing";
            mnuStatesLosing.Click += mnuStatesLosing_Click;
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(133, 26);
            gameToolStripMenuItem.Text = "Game";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(125, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(125, 26);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // mnuSelectParty
            // 
            mnuSelectParty.DropDownItems.AddRange(new ToolStripItem[] { mnuDemocrat, mnuRepublican });
            mnuSelectParty.Name = "mnuSelectParty";
            mnuSelectParty.Size = new Size(99, 24);
            mnuSelectParty.Text = "Select Party";
            // 
            // mnuDemocrat
            // 
            mnuDemocrat.ForeColor = Color.Blue;
            mnuDemocrat.Name = "mnuDemocrat";
            mnuDemocrat.Size = new Size(205, 26);
            mnuDemocrat.Text = "Democratic Party";
            mnuDemocrat.Click += mnuDemocrat_Click;
            // 
            // mnuRepublican
            // 
            mnuRepublican.ForeColor = Color.Red;
            mnuRepublican.Name = "mnuRepublican";
            mnuRepublican.Size = new Size(205, 26);
            mnuRepublican.Text = "Republican Party";
            mnuRepublican.Click += mnuRepublican_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 24);
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnRally);
            groupBox3.Controls.Add(btnAdvertisements);
            groupBox3.Controls.Add(btnCampaigner);
            groupBox3.Font = new Font("Noto Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(522, 278);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(613, 164);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Campaign";
            // 
            // btnRally
            // 
            btnRally.Font = new Font("Noto Sans", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRally.Location = new Point(434, 48);
            btnRally.Name = "btnRally";
            btnRally.Size = new Size(173, 91);
            btnRally.TabIndex = 12;
            btnRally.Text = "Rally: $10000";
            btnRally.UseVisualStyleBackColor = true;
            btnRally.Click += btnCampaignRally_Click;
            // 
            // btnAdvertisements
            // 
            btnAdvertisements.Font = new Font("Noto Sans", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdvertisements.Location = new Point(215, 48);
            btnAdvertisements.Name = "btnAdvertisements";
            btnAdvertisements.Size = new Size(173, 91);
            btnAdvertisements.TabIndex = 11;
            btnAdvertisements.Text = "Advertisements: $4000";
            btnAdvertisements.UseVisualStyleBackColor = true;
            btnAdvertisements.Click += btnAdvertisements_Click;
            // 
            // btnCampaigner
            // 
            btnCampaigner.Font = new Font("Noto Sans", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCampaigner.Location = new Point(6, 48);
            btnCampaigner.Name = "btnCampaigner";
            btnCampaigner.Size = new Size(173, 91);
            btnCampaigner.TabIndex = 10;
            btnCampaigner.Text = "Campaigner: $2000";
            btnCampaigner.UseVisualStyleBackColor = true;
            btnCampaigner.Click += btnCampaigner_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(label2);
            groupBox5.Controls.Add(label1);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(label13);
            groupBox5.Font = new Font("Noto Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(1141, 40);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(199, 601);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Useful info:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Noto Sans", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 337);
            label5.Name = "label5";
            label5.Size = new Size(174, 40);
            label5.TabIndex = 11;
            label5.Text = "Holding a rally will generate\r\n+4 polling in a state.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Noto Sans", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 273);
            label2.Name = "label2";
            label2.Size = new Size(197, 40);
            label2.TabIndex = 10;
            label2.Text = "An advertisement will generate \r\n+2 polling in a state.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 202);
            label1.Name = "label1";
            label1.Size = new Size(184, 60);
            label1.TabIndex = 9;
            label1.Text = "Campaigners will generate \r\n+1 polling for a random state \r\nper turn.";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Noto Sans", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(5, 108);
            label15.Name = "label15";
            label15.Size = new Size(173, 80);
            label15.TabIndex = 8;
            label15.Text = "This game uses polling to\r\ndeclare each state, then the\r\nelectoral college votes are\r\nallocated.";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Noto Sans", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(6, 55);
            label13.Name = "label13";
            label13.Size = new Size(177, 40);
            label13.TabIndex = 6;
            label13.Text = "Donators generate between\r\n$350 and $500 every turn.";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(listActionLog);
            groupBox6.Font = new Font("Noto Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox6.Location = new Point(9, 650);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(645, 163);
            groupBox6.TabIndex = 8;
            groupBox6.TabStop = false;
            groupBox6.Text = "Your Action Log:";
            // 
            // listActionLog
            // 
            listActionLog.Font = new Font("Noto Sans", 11F);
            listActionLog.FormattingEnabled = true;
            listActionLog.ItemHeight = 27;
            listActionLog.Location = new Point(0, 39);
            listActionLog.Name = "listActionLog";
            listActionLog.ScrollAlwaysVisible = true;
            listActionLog.Size = new Size(639, 112);
            listActionLog.TabIndex = 10;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(lblDifficulty);
            groupBox7.Controls.Add(lblFundsAI);
            groupBox7.Controls.Add(lblDonatorsAI);
            groupBox7.Controls.Add(lblCampaignersAI);
            groupBox7.Font = new Font("Noto Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox7.Location = new Point(743, 480);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(392, 164);
            groupBox7.TabIndex = 14;
            groupBox7.TabStop = false;
            groupBox7.Text = "AI";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Font = new Font("Noto Sans", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDifficulty.Location = new Point(273, 22);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(95, 20);
            lblDifficulty.TabIndex = 12;
            lblDifficulty.Text = "Difficulty: Easy";
            // 
            // lblFundsAI
            // 
            lblFundsAI.AutoSize = true;
            lblFundsAI.Font = new Font("Noto Sans", 12F);
            lblFundsAI.Location = new Point(6, 40);
            lblFundsAI.Name = "lblFundsAI";
            lblFundsAI.Size = new Size(145, 30);
            lblFundsAI.TabIndex = 5;
            lblFundsAI.Text = "Funds: $10000";
            // 
            // lblDonatorsAI
            // 
            lblDonatorsAI.AutoSize = true;
            lblDonatorsAI.Font = new Font("Noto Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDonatorsAI.Location = new Point(6, 102);
            lblDonatorsAI.Name = "lblDonatorsAI";
            lblDonatorsAI.Size = new Size(132, 30);
            lblDonatorsAI.TabIndex = 6;
            lblDonatorsAI.Text = "Donators: 12";
            // 
            // lblCampaignersAI
            // 
            lblCampaignersAI.AutoSize = true;
            lblCampaignersAI.Font = new Font("Noto Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCampaignersAI.Location = new Point(6, 70);
            lblCampaignersAI.Name = "lblCampaignersAI";
            lblCampaignersAI.Size = new Size(169, 30);
            lblCampaignersAI.TabIndex = 5;
            lblCampaignersAI.Text = "Campaigners: 30";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(listActionLogAI);
            groupBox8.Font = new Font("Noto Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox8.Location = new Point(686, 650);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(645, 163);
            groupBox8.TabIndex = 11;
            groupBox8.TabStop = false;
            groupBox8.Text = "Computer Action Log:";
            // 
            // listActionLogAI
            // 
            listActionLogAI.Font = new Font("Noto Sans", 11F);
            listActionLogAI.FormattingEnabled = true;
            listActionLogAI.ItemHeight = 27;
            listActionLogAI.Location = new Point(0, 39);
            listActionLogAI.Name = "listActionLogAI";
            listActionLogAI.ScrollAlwaysVisible = true;
            listActionLogAI.Size = new Size(639, 112);
            listActionLogAI.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1355, 822);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(btnGetResults);
            Controls.Add(btnEndTurn);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(listStates);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1373, 864);
            Name = "Form1";
            Text = "Win538";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listStates;
        private Label lblResultsAI;
        private Label lblResultsYou;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private GroupBox groupBox2;
        private Label lblTurns;
        private Label lblFunds;
        private Label lblParty;
        private Label lblNationalPolls;
        private Label lblStatePolling;
        private Label lblCampaigners;
        private Label lblDonators;
        private GroupBox groupBox4;
        private Button btnEndTurn;
        private Button btnGetResults;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem mnuSelectParty;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem mnuDemocrat;
        private ToolStripMenuItem mnuRepublican;
        private GroupBox groupBox3;
        private Button btnCampaigner;
        private Button btnDonator;
        private Button btnRally;
        private Button btnAdvertisements;
        private GroupBox groupBox5;
        private Label label13;
        private GroupBox groupBox6;
        private ListBox listActionLog;
        private Label label15;
        private ToolStripMenuItem toolStripMenuItem1;
        private Label label5;
        private Label label2;
        private Label label1;
        private Label lblStateElectors;
        private GroupBox groupBox7;
        private Label lblFundsAI;
        private Label lblDonatorsAI;
        private Label lblCampaignersAI;
        private GroupBox groupBox8;
        private ListBox listActionLogAI;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem mnuAllStates;
        private ToolStripMenuItem mnuStatesLosing;
        private Label lblRaceCall;
        private Label lblDifficulty;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
    }
}
