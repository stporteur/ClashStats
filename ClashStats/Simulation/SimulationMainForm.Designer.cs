using ClashEntities.Rewards;

namespace ClashStats.Simulation
{
    partial class SimulationMainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label higherTownHallAttackMinimumStarsLabel;
            System.Windows.Forms.Label higherTownHallAttackPointsLabel;
            System.Windows.Forms.Label noAttackDonePointsLabel;
            System.Windows.Forms.Label failedWarFaultPointsLabel;
            System.Windows.Forms.Label notFollowedStrategyPointsLabel;
            System.Windows.Forms.Label incoherentAttackPointsLabel;
            System.Windows.Forms.Label leagueParticipationPointsLabel;
            System.Windows.Forms.Label warParticipationPointsLabel;
            System.Windows.Forms.Label gameParticipationPointsLabel;
            System.Windows.Forms.Label minimumGamePointsLabel;
            System.Windows.Forms.Label minimumGamePointsThresholdLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationMainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlClash = new System.Windows.Forms.TabControl();
            this.tabPageScores = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCompute = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.scoreStarResultsCheckBox = new System.Windows.Forms.CheckBox();
            this.leagueScoreOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scoreHigherTownHallVillageAttackCheckBox = new System.Windows.Forms.CheckBox();
            this.higherTownHallAttackMinimumStarsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.incoherentAttackPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scoreIncoherentAttackCheckBox = new System.Windows.Forms.CheckBox();
            this.higherTownHallAttackPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notFollowedStrategyPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scoreNoAttackDoneCheckBox = new System.Windows.Forms.CheckBox();
            this.scoreNotFollowedStrategyCheckBox = new System.Windows.Forms.CheckBox();
            this.noAttackDonePointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.failedWarFaultPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scoreFailedWarFaultCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.btnSeniority = new System.Windows.Forms.Button();
            this.btnHdvLevel = new System.Windows.Forms.Button();
            this.scoreSeniorityCheckBox = new System.Windows.Forms.CheckBox();
            this.warriorScoreOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scoreTownHallLevelCheckBox = new System.Windows.Forms.CheckBox();
            this.minimumGamePointsThresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minimumGamePointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scoreMinimumGamePointsCheckBox = new System.Windows.Forms.CheckBox();
            this.gameParticipationPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scoreGameParticipationCheckBox = new System.Windows.Forms.CheckBox();
            this.warParticipationPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scoreWarParticipationCheckBox = new System.Windows.Forms.CheckBox();
            this.leagueParticipationPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scoreLeagueParticipationCheckBox = new System.Windows.Forms.CheckBox();
            this.rewardDataGridView = new System.Windows.Forms.DataGridView();
            this.DetailsColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.scoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warrioNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageLeague = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dayOneDataGridView = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayOneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dayTwoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayTwoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dayThreeDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayThreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dayFourDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayFourBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dayFiveDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayFiveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.daySixDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daySixBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.daySevenDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daySevenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageWars = new System.Windows.Forms.TabPage();
            this.tabPageGames = new System.Windows.Forms.TabPage();
            this.tabPageWarriors = new System.Windows.Forms.TabPage();
            this.dataGridViewWarriors = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.townHallLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.townHallLevelMaturityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivalDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalNumberOfLeagues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParticipateToLeagues = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.TotalNumberOfWars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParticipateToWars = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.TotalNumberOfGames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParticipateToGames = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.SucceedeedGames = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.warriorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.leagueWarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leagueIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leagueIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorIdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorNameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leagueIdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorIdDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorNameDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leagueIdDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorIdDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorNameDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leagueIdDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorIdDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorNameDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leagueIdDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorIdDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorNameDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warriorDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leagueIdDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            higherTownHallAttackMinimumStarsLabel = new System.Windows.Forms.Label();
            higherTownHallAttackPointsLabel = new System.Windows.Forms.Label();
            noAttackDonePointsLabel = new System.Windows.Forms.Label();
            failedWarFaultPointsLabel = new System.Windows.Forms.Label();
            notFollowedStrategyPointsLabel = new System.Windows.Forms.Label();
            incoherentAttackPointsLabel = new System.Windows.Forms.Label();
            leagueParticipationPointsLabel = new System.Windows.Forms.Label();
            warParticipationPointsLabel = new System.Windows.Forms.Label();
            gameParticipationPointsLabel = new System.Windows.Forms.Label();
            minimumGamePointsLabel = new System.Windows.Forms.Label();
            minimumGamePointsThresholdLabel = new System.Windows.Forms.Label();
            this.tabControlClash.SuspendLayout();
            this.tabPageScores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leagueScoreOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.higherTownHallAttackMinimumStarsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incoherentAttackPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.higherTownHallAttackPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notFollowedStrategyPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noAttackDonePointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failedWarFaultPointsNumericUpDown)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warriorScoreOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumGamePointsThresholdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumGamePointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameParticipationPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warParticipationPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leagueParticipationPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardBindingSource)).BeginInit();
            this.tabPageLeague.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayOneDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayOneBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayTwoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayTwoBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayThreeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayThreeBindingSource)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayFourDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayFourBindingSource)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayFiveDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayFiveBindingSource)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daySixDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daySixBindingSource)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daySevenDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daySevenBindingSource)).BeginInit();
            this.tabPageWarriors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarriors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warriorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leagueWarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // higherTownHallAttackMinimumStarsLabel
            // 
            higherTownHallAttackMinimumStarsLabel.AutoSize = true;
            higherTownHallAttackMinimumStarsLabel.Location = new System.Drawing.Point(5, 73);
            higherTownHallAttackMinimumStarsLabel.Name = "higherTownHallAttackMinimumStarsLabel";
            higherTownHallAttackMinimumStarsLabel.Size = new System.Drawing.Size(174, 13);
            higherTownHallAttackMinimumStarsLabel.TabIndex = 2;
            higherTownHallAttackMinimumStarsLabel.Text = "Etoiles minimum pour avoir le bonus";
            // 
            // higherTownHallAttackPointsLabel
            // 
            higherTownHallAttackPointsLabel.AutoSize = true;
            higherTownHallAttackPointsLabel.Location = new System.Drawing.Point(5, 97);
            higherTownHallAttackPointsLabel.Name = "higherTownHallAttackPointsLabel";
            higherTownHallAttackPointsLabel.Size = new System.Drawing.Size(37, 13);
            higherTownHallAttackPointsLabel.TabIndex = 4;
            higherTownHallAttackPointsLabel.Text = "Bonus";
            // 
            // noAttackDonePointsLabel
            // 
            noAttackDonePointsLabel.AutoSize = true;
            noAttackDonePointsLabel.Location = new System.Drawing.Point(5, 172);
            noAttackDonePointsLabel.Name = "noAttackDonePointsLabel";
            noAttackDonePointsLabel.Size = new System.Drawing.Size(35, 13);
            noAttackDonePointsLabel.TabIndex = 7;
            noAttackDonePointsLabel.Text = "Malus";
            // 
            // failedWarFaultPointsLabel
            // 
            failedWarFaultPointsLabel.AutoSize = true;
            failedWarFaultPointsLabel.Location = new System.Drawing.Point(5, 252);
            failedWarFaultPointsLabel.Name = "failedWarFaultPointsLabel";
            failedWarFaultPointsLabel.Size = new System.Drawing.Size(35, 13);
            failedWarFaultPointsLabel.TabIndex = 10;
            failedWarFaultPointsLabel.Text = "Malus";
            // 
            // notFollowedStrategyPointsLabel
            // 
            notFollowedStrategyPointsLabel.AutoSize = true;
            notFollowedStrategyPointsLabel.Location = new System.Drawing.Point(5, 329);
            notFollowedStrategyPointsLabel.Name = "notFollowedStrategyPointsLabel";
            notFollowedStrategyPointsLabel.Size = new System.Drawing.Size(35, 13);
            notFollowedStrategyPointsLabel.TabIndex = 13;
            notFollowedStrategyPointsLabel.Text = "Malus";
            // 
            // incoherentAttackPointsLabel
            // 
            incoherentAttackPointsLabel.AutoSize = true;
            incoherentAttackPointsLabel.Location = new System.Drawing.Point(5, 401);
            incoherentAttackPointsLabel.Name = "incoherentAttackPointsLabel";
            incoherentAttackPointsLabel.Size = new System.Drawing.Size(35, 13);
            incoherentAttackPointsLabel.TabIndex = 16;
            incoherentAttackPointsLabel.Text = "Malus";
            // 
            // leagueParticipationPointsLabel
            // 
            leagueParticipationPointsLabel.AutoSize = true;
            leagueParticipationPointsLabel.Location = new System.Drawing.Point(3, 34);
            leagueParticipationPointsLabel.Name = "leagueParticipationPointsLabel";
            leagueParticipationPointsLabel.Size = new System.Drawing.Size(37, 13);
            leagueParticipationPointsLabel.TabIndex = 2;
            leagueParticipationPointsLabel.Text = "Bonus";
            // 
            // warParticipationPointsLabel
            // 
            warParticipationPointsLabel.AutoSize = true;
            warParticipationPointsLabel.Location = new System.Drawing.Point(3, 95);
            warParticipationPointsLabel.Name = "warParticipationPointsLabel";
            warParticipationPointsLabel.Size = new System.Drawing.Size(37, 13);
            warParticipationPointsLabel.TabIndex = 6;
            warParticipationPointsLabel.Text = "Bonus";
            // 
            // gameParticipationPointsLabel
            // 
            gameParticipationPointsLabel.AutoSize = true;
            gameParticipationPointsLabel.Location = new System.Drawing.Point(3, 150);
            gameParticipationPointsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            gameParticipationPointsLabel.Name = "gameParticipationPointsLabel";
            gameParticipationPointsLabel.Size = new System.Drawing.Size(37, 13);
            gameParticipationPointsLabel.TabIndex = 8;
            gameParticipationPointsLabel.Text = "Bonus";
            // 
            // minimumGamePointsLabel
            // 
            minimumGamePointsLabel.AutoSize = true;
            minimumGamePointsLabel.Location = new System.Drawing.Point(3, 229);
            minimumGamePointsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            minimumGamePointsLabel.Name = "minimumGamePointsLabel";
            minimumGamePointsLabel.Size = new System.Drawing.Size(37, 13);
            minimumGamePointsLabel.TabIndex = 10;
            minimumGamePointsLabel.Text = "Bonus";
            // 
            // minimumGamePointsThresholdLabel
            // 
            minimumGamePointsThresholdLabel.AutoSize = true;
            minimumGamePointsThresholdLabel.Location = new System.Drawing.Point(3, 205);
            minimumGamePointsThresholdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            minimumGamePointsThresholdLabel.Name = "minimumGamePointsThresholdLabel";
            minimumGamePointsThresholdLabel.Size = new System.Drawing.Size(171, 13);
            minimumGamePointsThresholdLabel.TabIndex = 12;
            minimumGamePointsThresholdLabel.Text = "Score minimum pour avoir le bonus";
            // 
            // tabControlClash
            // 
            this.tabControlClash.Controls.Add(this.tabPageScores);
            this.tabControlClash.Controls.Add(this.tabPageLeague);
            this.tabControlClash.Controls.Add(this.tabPageWars);
            this.tabControlClash.Controls.Add(this.tabPageGames);
            this.tabControlClash.Controls.Add(this.tabPageWarriors);
            this.tabControlClash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlClash.Location = new System.Drawing.Point(0, 0);
            this.tabControlClash.Name = "tabControlClash";
            this.tabControlClash.SelectedIndex = 0;
            this.tabControlClash.Size = new System.Drawing.Size(1168, 724);
            this.tabControlClash.TabIndex = 0;
            // 
            // tabPageScores
            // 
            this.tabPageScores.Controls.Add(this.splitContainer2);
            this.tabPageScores.Location = new System.Drawing.Point(4, 22);
            this.tabPageScores.Name = "tabPageScores";
            this.tabPageScores.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScores.Size = new System.Drawing.Size(1160, 698);
            this.tabPageScores.TabIndex = 0;
            this.tabPageScores.Text = "Résultats";
            this.tabPageScores.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.rewardDataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(1154, 692);
            this.splitContainer2.SplitterDistance = 459;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnCompute);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(459, 692);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(267, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Paramètres de calcul";
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(32, 6);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(229, 45);
            this.btnCompute.TabIndex = 18;
            this.btnCompute.Text = "Calculer les scores";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(459, 564);
            this.tabControl2.TabIndex = 19;
            // 
            // tabPage8
            // 
            this.tabPage8.AutoScroll = true;
            this.tabPage8.Controls.Add(this.scoreStarResultsCheckBox);
            this.tabPage8.Controls.Add(this.scoreHigherTownHallVillageAttackCheckBox);
            this.tabPage8.Controls.Add(incoherentAttackPointsLabel);
            this.tabPage8.Controls.Add(this.higherTownHallAttackMinimumStarsNumericUpDown);
            this.tabPage8.Controls.Add(this.incoherentAttackPointsNumericUpDown);
            this.tabPage8.Controls.Add(higherTownHallAttackMinimumStarsLabel);
            this.tabPage8.Controls.Add(this.scoreIncoherentAttackCheckBox);
            this.tabPage8.Controls.Add(this.higherTownHallAttackPointsNumericUpDown);
            this.tabPage8.Controls.Add(notFollowedStrategyPointsLabel);
            this.tabPage8.Controls.Add(higherTownHallAttackPointsLabel);
            this.tabPage8.Controls.Add(this.notFollowedStrategyPointsNumericUpDown);
            this.tabPage8.Controls.Add(this.scoreNoAttackDoneCheckBox);
            this.tabPage8.Controls.Add(this.scoreNotFollowedStrategyCheckBox);
            this.tabPage8.Controls.Add(this.noAttackDonePointsNumericUpDown);
            this.tabPage8.Controls.Add(failedWarFaultPointsLabel);
            this.tabPage8.Controls.Add(noAttackDonePointsLabel);
            this.tabPage8.Controls.Add(this.failedWarFaultPointsNumericUpDown);
            this.tabPage8.Controls.Add(this.scoreFailedWarFaultCheckBox);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(451, 538);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Ligue";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // scoreStarResultsCheckBox
            // 
            this.scoreStarResultsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.leagueScoreOptionsBindingSource, "ScoreStarResults", true));
            this.scoreStarResultsCheckBox.Location = new System.Drawing.Point(8, 6);
            this.scoreStarResultsCheckBox.Name = "scoreStarResultsCheckBox";
            this.scoreStarResultsCheckBox.Size = new System.Drawing.Size(170, 24);
            this.scoreStarResultsCheckBox.TabIndex = 1;
            this.scoreStarResultsCheckBox.Text = "Calcul des étoiles";
            this.scoreStarResultsCheckBox.UseVisualStyleBackColor = true;
            // 
            // leagueScoreOptionsBindingSource
            // 
            this.leagueScoreOptionsBindingSource.AllowNew = false;
            this.leagueScoreOptionsBindingSource.DataSource = typeof(ClashEntities.ScoreOptions.LeagueScoreOptions);
            // 
            // scoreHigherTownHallVillageAttackCheckBox
            // 
            this.scoreHigherTownHallVillageAttackCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.leagueScoreOptionsBindingSource, "ScoreHigherTownHallVillageAttack", true));
            this.scoreHigherTownHallVillageAttackCheckBox.Location = new System.Drawing.Point(8, 46);
            this.scoreHigherTownHallVillageAttackCheckBox.Name = "scoreHigherTownHallVillageAttackCheckBox";
            this.scoreHigherTownHallVillageAttackCheckBox.Size = new System.Drawing.Size(258, 24);
            this.scoreHigherTownHallVillageAttackCheckBox.TabIndex = 2;
            this.scoreHigherTownHallVillageAttackCheckBox.Text = "Bonus attaque HDV supérieur";
            this.scoreHigherTownHallVillageAttackCheckBox.UseVisualStyleBackColor = true;
            // 
            // higherTownHallAttackMinimumStarsNumericUpDown
            // 
            this.higherTownHallAttackMinimumStarsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.higherTownHallAttackMinimumStarsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.leagueScoreOptionsBindingSource, "HigherTownHallAttackMinimumStars", true));
            this.higherTownHallAttackMinimumStarsNumericUpDown.Location = new System.Drawing.Point(354, 71);
            this.higherTownHallAttackMinimumStarsNumericUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.higherTownHallAttackMinimumStarsNumericUpDown.Name = "higherTownHallAttackMinimumStarsNumericUpDown";
            this.higherTownHallAttackMinimumStarsNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.higherTownHallAttackMinimumStarsNumericUpDown.TabIndex = 3;
            // 
            // incoherentAttackPointsNumericUpDown
            // 
            this.incoherentAttackPointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.incoherentAttackPointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.leagueScoreOptionsBindingSource, "IncoherentAttackPoints", true));
            this.incoherentAttackPointsNumericUpDown.Location = new System.Drawing.Point(353, 399);
            this.incoherentAttackPointsNumericUpDown.Name = "incoherentAttackPointsNumericUpDown";
            this.incoherentAttackPointsNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.incoherentAttackPointsNumericUpDown.TabIndex = 17;
            // 
            // scoreIncoherentAttackCheckBox
            // 
            this.scoreIncoherentAttackCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.leagueScoreOptionsBindingSource, "ScoreIncoherentAttack", true));
            this.scoreIncoherentAttackCheckBox.Location = new System.Drawing.Point(8, 369);
            this.scoreIncoherentAttackCheckBox.Name = "scoreIncoherentAttackCheckBox";
            this.scoreIncoherentAttackCheckBox.Size = new System.Drawing.Size(227, 24);
            this.scoreIncoherentAttackCheckBox.TabIndex = 16;
            this.scoreIncoherentAttackCheckBox.Text = "Malus attaque incohérente";
            this.scoreIncoherentAttackCheckBox.UseVisualStyleBackColor = true;
            // 
            // higherTownHallAttackPointsNumericUpDown
            // 
            this.higherTownHallAttackPointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.higherTownHallAttackPointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.leagueScoreOptionsBindingSource, "HigherTownHallAttackPoints", true));
            this.higherTownHallAttackPointsNumericUpDown.Location = new System.Drawing.Point(354, 97);
            this.higherTownHallAttackPointsNumericUpDown.Name = "higherTownHallAttackPointsNumericUpDown";
            this.higherTownHallAttackPointsNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.higherTownHallAttackPointsNumericUpDown.TabIndex = 5;
            // 
            // notFollowedStrategyPointsNumericUpDown
            // 
            this.notFollowedStrategyPointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notFollowedStrategyPointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.leagueScoreOptionsBindingSource, "NotFollowedStrategyPoints", true));
            this.notFollowedStrategyPointsNumericUpDown.Location = new System.Drawing.Point(353, 327);
            this.notFollowedStrategyPointsNumericUpDown.Name = "notFollowedStrategyPointsNumericUpDown";
            this.notFollowedStrategyPointsNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.notFollowedStrategyPointsNumericUpDown.TabIndex = 14;
            // 
            // scoreNoAttackDoneCheckBox
            // 
            this.scoreNoAttackDoneCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.leagueScoreOptionsBindingSource, "ScoreNoAttackDone", true));
            this.scoreNoAttackDoneCheckBox.Location = new System.Drawing.Point(8, 143);
            this.scoreNoAttackDoneCheckBox.Name = "scoreNoAttackDoneCheckBox";
            this.scoreNoAttackDoneCheckBox.Size = new System.Drawing.Size(218, 24);
            this.scoreNoAttackDoneCheckBox.TabIndex = 7;
            this.scoreNoAttackDoneCheckBox.Text = "Malus attaque non faite";
            this.scoreNoAttackDoneCheckBox.UseVisualStyleBackColor = true;
            // 
            // scoreNotFollowedStrategyCheckBox
            // 
            this.scoreNotFollowedStrategyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.leagueScoreOptionsBindingSource, "ScoreNotFollowedStrategy", true));
            this.scoreNotFollowedStrategyCheckBox.Location = new System.Drawing.Point(8, 297);
            this.scoreNotFollowedStrategyCheckBox.Name = "scoreNotFollowedStrategyCheckBox";
            this.scoreNotFollowedStrategyCheckBox.Size = new System.Drawing.Size(227, 24);
            this.scoreNotFollowedStrategyCheckBox.TabIndex = 13;
            this.scoreNotFollowedStrategyCheckBox.Text = "Malus stratégie non suivie";
            this.scoreNotFollowedStrategyCheckBox.UseVisualStyleBackColor = true;
            // 
            // noAttackDonePointsNumericUpDown
            // 
            this.noAttackDonePointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.noAttackDonePointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.leagueScoreOptionsBindingSource, "NoAttackDonePoints", true));
            this.noAttackDonePointsNumericUpDown.Location = new System.Drawing.Point(353, 170);
            this.noAttackDonePointsNumericUpDown.Name = "noAttackDonePointsNumericUpDown";
            this.noAttackDonePointsNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.noAttackDonePointsNumericUpDown.TabIndex = 8;
            // 
            // failedWarFaultPointsNumericUpDown
            // 
            this.failedWarFaultPointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.failedWarFaultPointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.leagueScoreOptionsBindingSource, "FailedWarFaultPoints", true));
            this.failedWarFaultPointsNumericUpDown.Location = new System.Drawing.Point(354, 252);
            this.failedWarFaultPointsNumericUpDown.Name = "failedWarFaultPointsNumericUpDown";
            this.failedWarFaultPointsNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.failedWarFaultPointsNumericUpDown.TabIndex = 11;
            // 
            // scoreFailedWarFaultCheckBox
            // 
            this.scoreFailedWarFaultCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.leagueScoreOptionsBindingSource, "ScoreFailedWarFault", true));
            this.scoreFailedWarFaultCheckBox.Location = new System.Drawing.Point(8, 222);
            this.scoreFailedWarFaultCheckBox.Name = "scoreFailedWarFaultCheckBox";
            this.scoreFailedWarFaultCheckBox.Size = new System.Drawing.Size(282, 24);
            this.scoreFailedWarFaultCheckBox.TabIndex = 10;
            this.scoreFailedWarFaultCheckBox.Text = "Malus guerre perdue par sa faute";
            this.scoreFailedWarFaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.AutoScroll = true;
            this.tabPage9.Controls.Add(this.btnSeniority);
            this.tabPage9.Controls.Add(this.btnHdvLevel);
            this.tabPage9.Controls.Add(this.scoreSeniorityCheckBox);
            this.tabPage9.Controls.Add(this.scoreTownHallLevelCheckBox);
            this.tabPage9.Controls.Add(minimumGamePointsThresholdLabel);
            this.tabPage9.Controls.Add(this.minimumGamePointsThresholdNumericUpDown);
            this.tabPage9.Controls.Add(minimumGamePointsLabel);
            this.tabPage9.Controls.Add(this.minimumGamePointsNumericUpDown);
            this.tabPage9.Controls.Add(this.scoreMinimumGamePointsCheckBox);
            this.tabPage9.Controls.Add(gameParticipationPointsLabel);
            this.tabPage9.Controls.Add(this.gameParticipationPointsNumericUpDown);
            this.tabPage9.Controls.Add(this.scoreGameParticipationCheckBox);
            this.tabPage9.Controls.Add(this.warParticipationPointsNumericUpDown);
            this.tabPage9.Controls.Add(warParticipationPointsLabel);
            this.tabPage9.Controls.Add(this.scoreWarParticipationCheckBox);
            this.tabPage9.Controls.Add(leagueParticipationPointsLabel);
            this.tabPage9.Controls.Add(this.leagueParticipationPointsNumericUpDown);
            this.tabPage9.Controls.Add(this.scoreLeagueParticipationCheckBox);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(451, 538);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Guerrier";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // btnSeniority
            // 
            this.btnSeniority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeniority.Location = new System.Drawing.Point(368, 282);
            this.btnSeniority.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeniority.Name = "btnSeniority";
            this.btnSeniority.Size = new System.Drawing.Size(69, 23);
            this.btnSeniority.TabIndex = 18;
            this.btnSeniority.Text = "Paramètres";
            this.btnSeniority.UseVisualStyleBackColor = true;
            this.btnSeniority.Click += new System.EventHandler(this.btnSeniority_Click);
            // 
            // btnHdvLevel
            // 
            this.btnHdvLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHdvLevel.Location = new System.Drawing.Point(368, 254);
            this.btnHdvLevel.Margin = new System.Windows.Forms.Padding(2);
            this.btnHdvLevel.Name = "btnHdvLevel";
            this.btnHdvLevel.Size = new System.Drawing.Size(69, 23);
            this.btnHdvLevel.TabIndex = 17;
            this.btnHdvLevel.Text = "Paramètres";
            this.btnHdvLevel.UseVisualStyleBackColor = true;
            this.btnHdvLevel.Click += new System.EventHandler(this.btnHdvLevel_Click);
            // 
            // scoreSeniorityCheckBox
            // 
            this.scoreSeniorityCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.warriorScoreOptionsBindingSource, "ScoreSeniority", true));
            this.scoreSeniorityCheckBox.Location = new System.Drawing.Point(3, 287);
            this.scoreSeniorityCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.scoreSeniorityCheckBox.Name = "scoreSeniorityCheckBox";
            this.scoreSeniorityCheckBox.Size = new System.Drawing.Size(129, 16);
            this.scoreSeniorityCheckBox.TabIndex = 16;
            this.scoreSeniorityCheckBox.Text = "Bonus ancienneté";
            this.scoreSeniorityCheckBox.UseVisualStyleBackColor = true;
            // 
            // warriorScoreOptionsBindingSource
            // 
            this.warriorScoreOptionsBindingSource.DataSource = typeof(ClashEntities.ScoreOptions.WarriorScoreOptions);
            // 
            // scoreTownHallLevelCheckBox
            // 
            this.scoreTownHallLevelCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.warriorScoreOptionsBindingSource, "ScoreTownHallLevel", true));
            this.scoreTownHallLevelCheckBox.Location = new System.Drawing.Point(2, 259);
            this.scoreTownHallLevelCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.scoreTownHallLevelCheckBox.Name = "scoreTownHallLevelCheckBox";
            this.scoreTownHallLevelCheckBox.Size = new System.Drawing.Size(121, 16);
            this.scoreTownHallLevelCheckBox.TabIndex = 15;
            this.scoreTownHallLevelCheckBox.Text = "Bonus Niveau HDV";
            this.scoreTownHallLevelCheckBox.UseVisualStyleBackColor = true;
            // 
            // minimumGamePointsThresholdNumericUpDown
            // 
            this.minimumGamePointsThresholdNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumGamePointsThresholdNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.warriorScoreOptionsBindingSource, "MinimumGamePointsThreshold", true));
            this.minimumGamePointsThresholdNumericUpDown.Location = new System.Drawing.Point(390, 203);
            this.minimumGamePointsThresholdNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.minimumGamePointsThresholdNumericUpDown.Name = "minimumGamePointsThresholdNumericUpDown";
            this.minimumGamePointsThresholdNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.minimumGamePointsThresholdNumericUpDown.TabIndex = 13;
            // 
            // minimumGamePointsNumericUpDown
            // 
            this.minimumGamePointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumGamePointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.warriorScoreOptionsBindingSource, "MinimumGamePoints", true));
            this.minimumGamePointsNumericUpDown.Location = new System.Drawing.Point(390, 228);
            this.minimumGamePointsNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.minimumGamePointsNumericUpDown.Name = "minimumGamePointsNumericUpDown";
            this.minimumGamePointsNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.minimumGamePointsNumericUpDown.TabIndex = 11;
            // 
            // scoreMinimumGamePointsCheckBox
            // 
            this.scoreMinimumGamePointsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.warriorScoreOptionsBindingSource, "ScoreMinimumGamePoints", true));
            this.scoreMinimumGamePointsCheckBox.Location = new System.Drawing.Point(3, 184);
            this.scoreMinimumGamePointsCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.scoreMinimumGamePointsCheckBox.Name = "scoreMinimumGamePointsCheckBox";
            this.scoreMinimumGamePointsCheckBox.Size = new System.Drawing.Size(221, 16);
            this.scoreMinimumGamePointsCheckBox.TabIndex = 10;
            this.scoreMinimumGamePointsCheckBox.Text = "Bonus score minimum atteint aux jeux";
            this.scoreMinimumGamePointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameParticipationPointsNumericUpDown
            // 
            this.gameParticipationPointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameParticipationPointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.warriorScoreOptionsBindingSource, "GameParticipationPoints", true));
            this.gameParticipationPointsNumericUpDown.Location = new System.Drawing.Point(390, 149);
            this.gameParticipationPointsNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.gameParticipationPointsNumericUpDown.Name = "gameParticipationPointsNumericUpDown";
            this.gameParticipationPointsNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.gameParticipationPointsNumericUpDown.TabIndex = 9;
            // 
            // scoreGameParticipationCheckBox
            // 
            this.scoreGameParticipationCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.warriorScoreOptionsBindingSource, "ScoreGameParticipation", true));
            this.scoreGameParticipationCheckBox.Location = new System.Drawing.Point(5, 129);
            this.scoreGameParticipationCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.scoreGameParticipationCheckBox.Name = "scoreGameParticipationCheckBox";
            this.scoreGameParticipationCheckBox.Size = new System.Drawing.Size(168, 16);
            this.scoreGameParticipationCheckBox.TabIndex = 8;
            this.scoreGameParticipationCheckBox.Text = "Bonus participation aux jeux";
            this.scoreGameParticipationCheckBox.UseVisualStyleBackColor = true;
            // 
            // warParticipationPointsNumericUpDown
            // 
            this.warParticipationPointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.warParticipationPointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.warriorScoreOptionsBindingSource, "WarParticipationPoints", true));
            this.warParticipationPointsNumericUpDown.Location = new System.Drawing.Point(390, 94);
            this.warParticipationPointsNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.warParticipationPointsNumericUpDown.Name = "warParticipationPointsNumericUpDown";
            this.warParticipationPointsNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.warParticipationPointsNumericUpDown.TabIndex = 7;
            // 
            // scoreWarParticipationCheckBox
            // 
            this.scoreWarParticipationCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.warriorScoreOptionsBindingSource, "ScoreWarParticipation", true));
            this.scoreWarParticipationCheckBox.Location = new System.Drawing.Point(5, 68);
            this.scoreWarParticipationCheckBox.Name = "scoreWarParticipationCheckBox";
            this.scoreWarParticipationCheckBox.Size = new System.Drawing.Size(185, 24);
            this.scoreWarParticipationCheckBox.TabIndex = 5;
            this.scoreWarParticipationCheckBox.Text = "Bonus participation aux guerres";
            this.scoreWarParticipationCheckBox.UseVisualStyleBackColor = true;
            // 
            // leagueParticipationPointsNumericUpDown
            // 
            this.leagueParticipationPointsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leagueParticipationPointsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.warriorScoreOptionsBindingSource, "LeagueParticipationPoints", true));
            this.leagueParticipationPointsNumericUpDown.Location = new System.Drawing.Point(390, 32);
            this.leagueParticipationPointsNumericUpDown.Name = "leagueParticipationPointsNumericUpDown";
            this.leagueParticipationPointsNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.leagueParticipationPointsNumericUpDown.TabIndex = 3;
            // 
            // scoreLeagueParticipationCheckBox
            // 
            this.scoreLeagueParticipationCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.warriorScoreOptionsBindingSource, "ScoreLeagueParticipation", true));
            this.scoreLeagueParticipationCheckBox.Location = new System.Drawing.Point(5, 6);
            this.scoreLeagueParticipationCheckBox.Name = "scoreLeagueParticipationCheckBox";
            this.scoreLeagueParticipationCheckBox.Size = new System.Drawing.Size(179, 24);
            this.scoreLeagueParticipationCheckBox.TabIndex = 1;
            this.scoreLeagueParticipationCheckBox.Text = "Bonus participation aux ligues";
            this.scoreLeagueParticipationCheckBox.UseVisualStyleBackColor = true;
            // 
            // rewardDataGridView
            // 
            this.rewardDataGridView.AutoGenerateColumns = false;
            this.rewardDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rewardDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetailsColumn,
            this.scoreDataGridViewTextBoxColumn,
            this.warrioNameDataGridViewTextBoxColumn,
            this.warriorDataGridViewTextBoxColumn});
            this.rewardDataGridView.DataSource = this.rewardBindingSource;
            this.rewardDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rewardDataGridView.Location = new System.Drawing.Point(0, 0);
            this.rewardDataGridView.Name = "rewardDataGridView";
            this.rewardDataGridView.RowHeadersVisible = false;
            this.rewardDataGridView.Size = new System.Drawing.Size(691, 692);
            this.rewardDataGridView.TabIndex = 0;
            this.rewardDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rewardDataGridView_CellContentClick);
            // 
            // DetailsColumn
            // 
            this.DetailsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DetailsColumn.HeaderText = "Détails";
            this.DetailsColumn.Name = "DetailsColumn";
            this.DetailsColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DetailsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DetailsColumn.Text = "...";
            this.DetailsColumn.UseColumnTextForButtonValue = true;
            this.DetailsColumn.Width = 64;
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            this.scoreDataGridViewTextBoxColumn.DataPropertyName = "Score";
            this.scoreDataGridViewTextBoxColumn.HeaderText = "Score";
            this.scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            // 
            // warrioNameDataGridViewTextBoxColumn
            // 
            this.warrioNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.warrioNameDataGridViewTextBoxColumn.DataPropertyName = "WarrioName";
            this.warrioNameDataGridViewTextBoxColumn.HeaderText = "Guerrier";
            this.warrioNameDataGridViewTextBoxColumn.Name = "warrioNameDataGridViewTextBoxColumn";
            this.warrioNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // warriorDataGridViewTextBoxColumn
            // 
            this.warriorDataGridViewTextBoxColumn.DataPropertyName = "Warrior";
            this.warriorDataGridViewTextBoxColumn.HeaderText = "Warrior";
            this.warriorDataGridViewTextBoxColumn.Name = "warriorDataGridViewTextBoxColumn";
            this.warriorDataGridViewTextBoxColumn.Visible = false;
            // 
            // rewardBindingSource
            // 
            this.rewardBindingSource.AllowNew = false;
            this.rewardBindingSource.DataSource = typeof(ClashEntities.Rewards.Reward);
            // 
            // tabPageLeague
            // 
            this.tabPageLeague.AutoScroll = true;
            this.tabPageLeague.Controls.Add(this.label1);
            this.tabPageLeague.Controls.Add(this.tabControl1);
            this.tabPageLeague.Location = new System.Drawing.Point(4, 22);
            this.tabPageLeague.Name = "tabPageLeague";
            this.tabPageLeague.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLeague.Size = new System.Drawing.Size(1160, 698);
            this.tabPageLeague.TabIndex = 1;
            this.tabPageLeague.Text = "Ligue en cours";
            this.tabPageLeague.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Simulation des résultats de journées de ligue";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(6, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(701, 453);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dayOneDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(693, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Jour 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dayOneDataGridView
            // 
            this.dayOneDataGridView.AutoGenerateColumns = false;
            this.dayOneDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dayOneDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.playerNameColumn,
            this.idDataGridViewTextBoxColumn1,
            this.warriorIdDataGridViewTextBoxColumn,
            this.warriorNameDataGridViewTextBoxColumn,
            this.warriorDataGridViewTextBoxColumn1,
            this.leagueIdDataGridViewTextBoxColumn});
            this.dayOneDataGridView.DataSource = this.dayOneBindingSource;
            this.dayOneDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayOneDataGridView.Location = new System.Drawing.Point(3, 3);
            this.dayOneDataGridView.Name = "dayOneDataGridView";
            this.dayOneDataGridView.RowHeadersVisible = false;
            this.dayOneDataGridView.Size = new System.Drawing.Size(687, 421);
            this.dayOneDataGridView.TabIndex = 0;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            // 
            // playerNameColumn
            // 
            this.playerNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.playerNameColumn.DataPropertyName = "PlayerName";
            this.playerNameColumn.HeaderText = "Guerrier";
            this.playerNameColumn.Name = "playerNameColumn";
            this.playerNameColumn.ReadOnly = true;
            // 
            // dayOneBindingSource
            // 
            this.dayOneBindingSource.AllowNew = false;
            this.dayOneBindingSource.DataSource = typeof(ClashEntities.LeaguePlayer);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dayTwoDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(693, 427);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Jour 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dayTwoDataGridView
            // 
            this.dayTwoDataGridView.AutoGenerateColumns = false;
            this.dayTwoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.idDataGridViewTextBoxColumn2,
            this.warriorIdDataGridViewTextBoxColumn1,
            this.warriorNameDataGridViewTextBoxColumn1,
            this.warriorDataGridViewTextBoxColumn2,
            this.leagueIdDataGridViewTextBoxColumn1});
            this.dayTwoDataGridView.DataSource = this.dayTwoBindingSource;
            this.dayTwoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayTwoDataGridView.Location = new System.Drawing.Point(3, 3);
            this.dayTwoDataGridView.Name = "dayTwoDataGridView";
            this.dayTwoDataGridView.RowHeadersVisible = false;
            this.dayTwoDataGridView.Size = new System.Drawing.Size(687, 421);
            this.dayTwoDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Position";
            this.dataGridViewTextBoxColumn1.HeaderText = "Position";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 69;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PlayerName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dayTwoBindingSource
            // 
            this.dayTwoBindingSource.AllowNew = false;
            this.dayTwoBindingSource.DataSource = typeof(ClashEntities.LeaguePlayer);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dayThreeDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(693, 427);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Jour 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dayThreeDataGridView
            // 
            this.dayThreeDataGridView.AutoGenerateColumns = false;
            this.dayThreeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dayThreeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn7,
            this.idDataGridViewTextBoxColumn3,
            this.warriorIdDataGridViewTextBoxColumn2,
            this.warriorNameDataGridViewTextBoxColumn2,
            this.warriorDataGridViewTextBoxColumn3,
            this.leagueIdDataGridViewTextBoxColumn2});
            this.dayThreeDataGridView.DataSource = this.dayThreeBindingSource;
            this.dayThreeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayThreeDataGridView.Location = new System.Drawing.Point(3, 3);
            this.dayThreeDataGridView.Name = "dayThreeDataGridView";
            this.dayThreeDataGridView.RowHeadersVisible = false;
            this.dayThreeDataGridView.Size = new System.Drawing.Size(687, 421);
            this.dayThreeDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PlayerName";
            this.dataGridViewTextBoxColumn8.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Position";
            this.dataGridViewTextBoxColumn7.HeaderText = "Position";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dayThreeBindingSource
            // 
            this.dayThreeBindingSource.AllowNew = false;
            this.dayThreeBindingSource.DataSource = typeof(ClashEntities.LeaguePlayer);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dayFourDataGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(693, 427);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Jour 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dayFourDataGridView
            // 
            this.dayFourDataGridView.AutoGenerateColumns = false;
            this.dayFourDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dayFourDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn11,
            this.idDataGridViewTextBoxColumn4,
            this.warriorIdDataGridViewTextBoxColumn3,
            this.warriorNameDataGridViewTextBoxColumn3,
            this.warriorDataGridViewTextBoxColumn4,
            this.leagueIdDataGridViewTextBoxColumn3});
            this.dayFourDataGridView.DataSource = this.dayFourBindingSource;
            this.dayFourDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayFourDataGridView.Location = new System.Drawing.Point(3, 3);
            this.dayFourDataGridView.Name = "dayFourDataGridView";
            this.dayFourDataGridView.RowHeadersVisible = false;
            this.dayFourDataGridView.Size = new System.Drawing.Size(687, 421);
            this.dayFourDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PlayerName";
            this.dataGridViewTextBoxColumn12.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Position";
            this.dataGridViewTextBoxColumn11.HeaderText = "Position";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dayFourBindingSource
            // 
            this.dayFourBindingSource.AllowNew = false;
            this.dayFourBindingSource.DataSource = typeof(ClashEntities.LeaguePlayer);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dayFiveDataGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(693, 427);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Jour 5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dayFiveDataGridView
            // 
            this.dayFiveDataGridView.AutoGenerateColumns = false;
            this.dayFiveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dayFiveDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn15,
            this.idDataGridViewTextBoxColumn5,
            this.warriorIdDataGridViewTextBoxColumn4,
            this.warriorNameDataGridViewTextBoxColumn4,
            this.warriorDataGridViewTextBoxColumn5,
            this.leagueIdDataGridViewTextBoxColumn4});
            this.dayFiveDataGridView.DataSource = this.dayFiveBindingSource;
            this.dayFiveDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayFiveDataGridView.Location = new System.Drawing.Point(3, 3);
            this.dayFiveDataGridView.Name = "dayFiveDataGridView";
            this.dayFiveDataGridView.RowHeadersVisible = false;
            this.dayFiveDataGridView.Size = new System.Drawing.Size(687, 421);
            this.dayFiveDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "PlayerName";
            this.dataGridViewTextBoxColumn16.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Position";
            this.dataGridViewTextBoxColumn15.HeaderText = "Position";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dayFiveBindingSource
            // 
            this.dayFiveBindingSource.AllowNew = false;
            this.dayFiveBindingSource.DataSource = typeof(ClashEntities.LeaguePlayer);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.daySixDataGridView);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(693, 427);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Jour 6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // daySixDataGridView
            // 
            this.daySixDataGridView.AutoGenerateColumns = false;
            this.daySixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.daySixDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn19,
            this.idDataGridViewTextBoxColumn6,
            this.warriorIdDataGridViewTextBoxColumn5,
            this.warriorNameDataGridViewTextBoxColumn5,
            this.warriorDataGridViewTextBoxColumn6,
            this.leagueIdDataGridViewTextBoxColumn5});
            this.daySixDataGridView.DataSource = this.daySixBindingSource;
            this.daySixDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.daySixDataGridView.Location = new System.Drawing.Point(3, 3);
            this.daySixDataGridView.Name = "daySixDataGridView";
            this.daySixDataGridView.RowHeadersVisible = false;
            this.daySixDataGridView.Size = new System.Drawing.Size(687, 421);
            this.daySixDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "PlayerName";
            this.dataGridViewTextBoxColumn20.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Position";
            this.dataGridViewTextBoxColumn19.HeaderText = "Position";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // daySixBindingSource
            // 
            this.daySixBindingSource.AllowNew = false;
            this.daySixBindingSource.DataSource = typeof(ClashEntities.LeaguePlayer);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.daySevenDataGridView);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(693, 427);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Jour 7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // daySevenDataGridView
            // 
            this.daySevenDataGridView.AutoGenerateColumns = false;
            this.daySevenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.daySevenDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn23,
            this.idDataGridViewTextBoxColumn7,
            this.warriorIdDataGridViewTextBoxColumn6,
            this.warriorNameDataGridViewTextBoxColumn6,
            this.warriorDataGridViewTextBoxColumn7,
            this.leagueIdDataGridViewTextBoxColumn6});
            this.daySevenDataGridView.DataSource = this.daySevenBindingSource;
            this.daySevenDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.daySevenDataGridView.Location = new System.Drawing.Point(3, 3);
            this.daySevenDataGridView.Name = "daySevenDataGridView";
            this.daySevenDataGridView.RowHeadersVisible = false;
            this.daySevenDataGridView.Size = new System.Drawing.Size(687, 421);
            this.daySevenDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn24.DataPropertyName = "PlayerName";
            this.dataGridViewTextBoxColumn24.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Position";
            this.dataGridViewTextBoxColumn23.HeaderText = "Position";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // daySevenBindingSource
            // 
            this.daySevenBindingSource.AllowNew = false;
            this.daySevenBindingSource.DataSource = typeof(ClashEntities.LeaguePlayer);
            // 
            // tabPageWars
            // 
            this.tabPageWars.Location = new System.Drawing.Point(4, 22);
            this.tabPageWars.Name = "tabPageWars";
            this.tabPageWars.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWars.Size = new System.Drawing.Size(1160, 698);
            this.tabPageWars.TabIndex = 2;
            this.tabPageWars.Text = "GDC";
            this.tabPageWars.UseVisualStyleBackColor = true;
            // 
            // tabPageGames
            // 
            this.tabPageGames.Location = new System.Drawing.Point(4, 22);
            this.tabPageGames.Name = "tabPageGames";
            this.tabPageGames.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGames.Size = new System.Drawing.Size(1160, 698);
            this.tabPageGames.TabIndex = 3;
            this.tabPageGames.Text = "Games";
            this.tabPageGames.UseVisualStyleBackColor = true;
            // 
            // tabPageWarriors
            // 
            this.tabPageWarriors.Controls.Add(this.dataGridViewWarriors);
            this.tabPageWarriors.Location = new System.Drawing.Point(4, 22);
            this.tabPageWarriors.Name = "tabPageWarriors";
            this.tabPageWarriors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWarriors.Size = new System.Drawing.Size(1160, 698);
            this.tabPageWarriors.TabIndex = 4;
            this.tabPageWarriors.Text = "Guerriers";
            this.tabPageWarriors.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWarriors
            // 
            this.dataGridViewWarriors.AutoGenerateColumns = false;
            this.dataGridViewWarriors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarriors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.hashDataGridViewTextBoxColumn,
            this.townHallLevelDataGridViewTextBoxColumn,
            this.townHallLevelMaturityDataGridViewTextBoxColumn,
            this.clanDataGridViewTextBoxColumn,
            this.arrivalDateDataGridViewTextBoxColumn,
            this.TotalNumberOfLeagues,
            this.ParticipateToLeagues,
            this.TotalNumberOfWars,
            this.ParticipateToWars,
            this.TotalNumberOfGames,
            this.ParticipateToGames,
            this.SucceedeedGames});
            this.dataGridViewWarriors.DataSource = this.warriorBindingSource;
            this.dataGridViewWarriors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWarriors.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWarriors.Name = "dataGridViewWarriors";
            this.dataGridViewWarriors.RowHeadersVisible = false;
            this.dataGridViewWarriors.Size = new System.Drawing.Size(1154, 692);
            this.dataGridViewWarriors.TabIndex = 0;
            this.dataGridViewWarriors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWarriors_CellClick);
            this.dataGridViewWarriors.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWarriors_CellEndEdit);
            this.dataGridViewWarriors.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridViewWarriors_ColumnWidthChanged);
            this.dataGridViewWarriors.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewWarriors_Scroll);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // hashDataGridViewTextBoxColumn
            // 
            this.hashDataGridViewTextBoxColumn.DataPropertyName = "Hash";
            this.hashDataGridViewTextBoxColumn.HeaderText = "Hash";
            this.hashDataGridViewTextBoxColumn.Name = "hashDataGridViewTextBoxColumn";
            this.hashDataGridViewTextBoxColumn.Visible = false;
            // 
            // townHallLevelDataGridViewTextBoxColumn
            // 
            this.townHallLevelDataGridViewTextBoxColumn.DataPropertyName = "TownHallLevel";
            this.townHallLevelDataGridViewTextBoxColumn.HeaderText = "Niveau HDV";
            this.townHallLevelDataGridViewTextBoxColumn.Name = "townHallLevelDataGridViewTextBoxColumn";
            // 
            // townHallLevelMaturityDataGridViewTextBoxColumn
            // 
            this.townHallLevelMaturityDataGridViewTextBoxColumn.DataPropertyName = "TownHallLevelMaturity";
            this.townHallLevelMaturityDataGridViewTextBoxColumn.HeaderText = "Maturité HDV";
            this.townHallLevelMaturityDataGridViewTextBoxColumn.Name = "townHallLevelMaturityDataGridViewTextBoxColumn";
            // 
            // clanDataGridViewTextBoxColumn
            // 
            this.clanDataGridViewTextBoxColumn.DataPropertyName = "Clan";
            this.clanDataGridViewTextBoxColumn.HeaderText = "Clan";
            this.clanDataGridViewTextBoxColumn.Name = "clanDataGridViewTextBoxColumn";
            this.clanDataGridViewTextBoxColumn.Visible = false;
            // 
            // arrivalDateDataGridViewTextBoxColumn
            // 
            this.arrivalDateDataGridViewTextBoxColumn.DataPropertyName = "ArrivalDate";
            this.arrivalDateDataGridViewTextBoxColumn.HeaderText = "Date d\'arrivée";
            this.arrivalDateDataGridViewTextBoxColumn.Name = "arrivalDateDataGridViewTextBoxColumn";
            // 
            // TotalNumberOfLeagues
            // 
            this.TotalNumberOfLeagues.DataPropertyName = "TotalNumberOfLeagues";
            this.TotalNumberOfLeagues.HeaderText = "Nb Ligues total";
            this.TotalNumberOfLeagues.Name = "TotalNumberOfLeagues";
            this.TotalNumberOfLeagues.ReadOnly = true;
            // 
            // ParticipateToLeagues
            // 
            this.ParticipateToLeagues.DataPropertyName = "ParticipateToLeagues";
            this.ParticipateToLeagues.DecimalPlaces = 0;
            this.ParticipateToLeagues.DefaultValue = 0;
            this.ParticipateToLeagues.HeaderText = "Ligues participées";
            this.ParticipateToLeagues.Name = "ParticipateToLeagues";
            this.ParticipateToLeagues.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ParticipateToLeagues.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TotalNumberOfWars
            // 
            this.TotalNumberOfWars.DataPropertyName = "TotalNumberOfWars";
            this.TotalNumberOfWars.HeaderText = "Nb GDC Total";
            this.TotalNumberOfWars.Name = "TotalNumberOfWars";
            this.TotalNumberOfWars.ReadOnly = true;
            // 
            // ParticipateToWars
            // 
            this.ParticipateToWars.DataPropertyName = "ParticipateToWars";
            this.ParticipateToWars.DecimalPlaces = 0;
            this.ParticipateToWars.DefaultValue = 0;
            this.ParticipateToWars.HeaderText = "GDC participées";
            this.ParticipateToWars.Name = "ParticipateToWars";
            this.ParticipateToWars.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ParticipateToWars.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TotalNumberOfGames
            // 
            this.TotalNumberOfGames.DataPropertyName = "TotalNumberOfGames";
            this.TotalNumberOfGames.HeaderText = "Nb Jeux total";
            this.TotalNumberOfGames.Name = "TotalNumberOfGames";
            this.TotalNumberOfGames.ReadOnly = true;
            // 
            // ParticipateToGames
            // 
            this.ParticipateToGames.DataPropertyName = "ParticipateToGames";
            this.ParticipateToGames.DecimalPlaces = 0;
            this.ParticipateToGames.DefaultValue = 0;
            this.ParticipateToGames.HeaderText = "Jeux participés";
            this.ParticipateToGames.Name = "ParticipateToGames";
            this.ParticipateToGames.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ParticipateToGames.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SucceedeedGames
            // 
            this.SucceedeedGames.DataPropertyName = "SucceedeedGames";
            this.SucceedeedGames.DecimalPlaces = 0;
            this.SucceedeedGames.DefaultValue = 0;
            this.SucceedeedGames.HeaderText = "Nb jeux réussis";
            this.SucceedeedGames.Name = "SucceedeedGames";
            this.SucceedeedGames.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SucceedeedGames.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // warriorBindingSource
            // 
            this.warriorBindingSource.AllowNew = false;
            this.warriorBindingSource.DataSource = typeof(ClashStats.Simulation.SimulationWarrior);
            // 
            // leagueWarBindingSource
            // 
            this.leagueWarBindingSource.DataSource = typeof(ClashEntities.League);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "WarrioName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Stars";
            this.dataGridViewTextBoxColumn6.HeaderText = "Etoiles";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn27.DataPropertyName = "WarrioName";
            this.dataGridViewTextBoxColumn27.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Score";
            this.dataGridViewTextBoxColumn28.HeaderText = "Score";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn29.DataPropertyName = "Stars";
            this.dataGridViewTextBoxColumn29.HeaderText = "Etoiles";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn30.DataPropertyName = "AttackedThLevel";
            this.dataGridViewTextBoxColumn30.HeaderText = "Niveau HDV attaqué";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn31.DataPropertyName = "AttackedThLevel";
            this.dataGridViewTextBoxColumn31.HeaderText = "Niveau HDV attaqué";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // warriorIdDataGridViewTextBoxColumn
            // 
            this.warriorIdDataGridViewTextBoxColumn.DataPropertyName = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn.HeaderText = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn.Name = "warriorIdDataGridViewTextBoxColumn";
            // 
            // warriorNameDataGridViewTextBoxColumn
            // 
            this.warriorNameDataGridViewTextBoxColumn.DataPropertyName = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn.HeaderText = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn.Name = "warriorNameDataGridViewTextBoxColumn";
            this.warriorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // warriorDataGridViewTextBoxColumn1
            // 
            this.warriorDataGridViewTextBoxColumn1.DataPropertyName = "Warrior";
            this.warriorDataGridViewTextBoxColumn1.HeaderText = "Warrior";
            this.warriorDataGridViewTextBoxColumn1.Name = "warriorDataGridViewTextBoxColumn1";
            // 
            // leagueIdDataGridViewTextBoxColumn
            // 
            this.leagueIdDataGridViewTextBoxColumn.DataPropertyName = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn.HeaderText = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn.Name = "leagueIdDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            // 
            // warriorIdDataGridViewTextBoxColumn1
            // 
            this.warriorIdDataGridViewTextBoxColumn1.DataPropertyName = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn1.HeaderText = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn1.Name = "warriorIdDataGridViewTextBoxColumn1";
            // 
            // warriorNameDataGridViewTextBoxColumn1
            // 
            this.warriorNameDataGridViewTextBoxColumn1.DataPropertyName = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn1.HeaderText = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn1.Name = "warriorNameDataGridViewTextBoxColumn1";
            this.warriorNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // warriorDataGridViewTextBoxColumn2
            // 
            this.warriorDataGridViewTextBoxColumn2.DataPropertyName = "Warrior";
            this.warriorDataGridViewTextBoxColumn2.HeaderText = "Warrior";
            this.warriorDataGridViewTextBoxColumn2.Name = "warriorDataGridViewTextBoxColumn2";
            // 
            // leagueIdDataGridViewTextBoxColumn1
            // 
            this.leagueIdDataGridViewTextBoxColumn1.DataPropertyName = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn1.HeaderText = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn1.Name = "leagueIdDataGridViewTextBoxColumn1";
            // 
            // idDataGridViewTextBoxColumn3
            // 
            this.idDataGridViewTextBoxColumn3.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn3.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn3.Name = "idDataGridViewTextBoxColumn3";
            // 
            // warriorIdDataGridViewTextBoxColumn2
            // 
            this.warriorIdDataGridViewTextBoxColumn2.DataPropertyName = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn2.HeaderText = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn2.Name = "warriorIdDataGridViewTextBoxColumn2";
            // 
            // warriorNameDataGridViewTextBoxColumn2
            // 
            this.warriorNameDataGridViewTextBoxColumn2.DataPropertyName = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn2.HeaderText = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn2.Name = "warriorNameDataGridViewTextBoxColumn2";
            this.warriorNameDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // warriorDataGridViewTextBoxColumn3
            // 
            this.warriorDataGridViewTextBoxColumn3.DataPropertyName = "Warrior";
            this.warriorDataGridViewTextBoxColumn3.HeaderText = "Warrior";
            this.warriorDataGridViewTextBoxColumn3.Name = "warriorDataGridViewTextBoxColumn3";
            // 
            // leagueIdDataGridViewTextBoxColumn2
            // 
            this.leagueIdDataGridViewTextBoxColumn2.DataPropertyName = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn2.HeaderText = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn2.Name = "leagueIdDataGridViewTextBoxColumn2";
            // 
            // idDataGridViewTextBoxColumn4
            // 
            this.idDataGridViewTextBoxColumn4.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn4.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn4.Name = "idDataGridViewTextBoxColumn4";
            // 
            // warriorIdDataGridViewTextBoxColumn3
            // 
            this.warriorIdDataGridViewTextBoxColumn3.DataPropertyName = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn3.HeaderText = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn3.Name = "warriorIdDataGridViewTextBoxColumn3";
            // 
            // warriorNameDataGridViewTextBoxColumn3
            // 
            this.warriorNameDataGridViewTextBoxColumn3.DataPropertyName = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn3.HeaderText = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn3.Name = "warriorNameDataGridViewTextBoxColumn3";
            this.warriorNameDataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // warriorDataGridViewTextBoxColumn4
            // 
            this.warriorDataGridViewTextBoxColumn4.DataPropertyName = "Warrior";
            this.warriorDataGridViewTextBoxColumn4.HeaderText = "Warrior";
            this.warriorDataGridViewTextBoxColumn4.Name = "warriorDataGridViewTextBoxColumn4";
            // 
            // leagueIdDataGridViewTextBoxColumn3
            // 
            this.leagueIdDataGridViewTextBoxColumn3.DataPropertyName = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn3.HeaderText = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn3.Name = "leagueIdDataGridViewTextBoxColumn3";
            // 
            // idDataGridViewTextBoxColumn5
            // 
            this.idDataGridViewTextBoxColumn5.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn5.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn5.Name = "idDataGridViewTextBoxColumn5";
            // 
            // warriorIdDataGridViewTextBoxColumn4
            // 
            this.warriorIdDataGridViewTextBoxColumn4.DataPropertyName = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn4.HeaderText = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn4.Name = "warriorIdDataGridViewTextBoxColumn4";
            // 
            // warriorNameDataGridViewTextBoxColumn4
            // 
            this.warriorNameDataGridViewTextBoxColumn4.DataPropertyName = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn4.HeaderText = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn4.Name = "warriorNameDataGridViewTextBoxColumn4";
            this.warriorNameDataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // warriorDataGridViewTextBoxColumn5
            // 
            this.warriorDataGridViewTextBoxColumn5.DataPropertyName = "Warrior";
            this.warriorDataGridViewTextBoxColumn5.HeaderText = "Warrior";
            this.warriorDataGridViewTextBoxColumn5.Name = "warriorDataGridViewTextBoxColumn5";
            // 
            // leagueIdDataGridViewTextBoxColumn4
            // 
            this.leagueIdDataGridViewTextBoxColumn4.DataPropertyName = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn4.HeaderText = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn4.Name = "leagueIdDataGridViewTextBoxColumn4";
            // 
            // idDataGridViewTextBoxColumn6
            // 
            this.idDataGridViewTextBoxColumn6.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn6.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn6.Name = "idDataGridViewTextBoxColumn6";
            // 
            // warriorIdDataGridViewTextBoxColumn5
            // 
            this.warriorIdDataGridViewTextBoxColumn5.DataPropertyName = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn5.HeaderText = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn5.Name = "warriorIdDataGridViewTextBoxColumn5";
            // 
            // warriorNameDataGridViewTextBoxColumn5
            // 
            this.warriorNameDataGridViewTextBoxColumn5.DataPropertyName = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn5.HeaderText = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn5.Name = "warriorNameDataGridViewTextBoxColumn5";
            this.warriorNameDataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // warriorDataGridViewTextBoxColumn6
            // 
            this.warriorDataGridViewTextBoxColumn6.DataPropertyName = "Warrior";
            this.warriorDataGridViewTextBoxColumn6.HeaderText = "Warrior";
            this.warriorDataGridViewTextBoxColumn6.Name = "warriorDataGridViewTextBoxColumn6";
            // 
            // leagueIdDataGridViewTextBoxColumn5
            // 
            this.leagueIdDataGridViewTextBoxColumn5.DataPropertyName = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn5.HeaderText = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn5.Name = "leagueIdDataGridViewTextBoxColumn5";
            // 
            // idDataGridViewTextBoxColumn7
            // 
            this.idDataGridViewTextBoxColumn7.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn7.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn7.Name = "idDataGridViewTextBoxColumn7";
            // 
            // warriorIdDataGridViewTextBoxColumn6
            // 
            this.warriorIdDataGridViewTextBoxColumn6.DataPropertyName = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn6.HeaderText = "WarriorId";
            this.warriorIdDataGridViewTextBoxColumn6.Name = "warriorIdDataGridViewTextBoxColumn6";
            // 
            // warriorNameDataGridViewTextBoxColumn6
            // 
            this.warriorNameDataGridViewTextBoxColumn6.DataPropertyName = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn6.HeaderText = "WarriorName";
            this.warriorNameDataGridViewTextBoxColumn6.Name = "warriorNameDataGridViewTextBoxColumn6";
            this.warriorNameDataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // warriorDataGridViewTextBoxColumn7
            // 
            this.warriorDataGridViewTextBoxColumn7.DataPropertyName = "Warrior";
            this.warriorDataGridViewTextBoxColumn7.HeaderText = "Warrior";
            this.warriorDataGridViewTextBoxColumn7.Name = "warriorDataGridViewTextBoxColumn7";
            // 
            // leagueIdDataGridViewTextBoxColumn6
            // 
            this.leagueIdDataGridViewTextBoxColumn6.DataPropertyName = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn6.HeaderText = "LeagueId";
            this.leagueIdDataGridViewTextBoxColumn6.Name = "leagueIdDataGridViewTextBoxColumn6";
            // 
            // SimulationMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1168, 724);
            this.Controls.Add(this.tabControlClash);
            this.Name = "SimulationMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulateur de calcul";
            this.Load += new System.EventHandler(this.SimulationMainForm_Load);
            this.tabControlClash.ResumeLayout(false);
            this.tabPageScores.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leagueScoreOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.higherTownHallAttackMinimumStarsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incoherentAttackPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.higherTownHallAttackPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notFollowedStrategyPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noAttackDonePointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failedWarFaultPointsNumericUpDown)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warriorScoreOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumGamePointsThresholdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumGamePointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameParticipationPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warParticipationPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leagueParticipationPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardBindingSource)).EndInit();
            this.tabPageLeague.ResumeLayout(false);
            this.tabPageLeague.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayOneDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayOneBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayTwoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayTwoBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayThreeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayThreeBindingSource)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayFourDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayFourBindingSource)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayFiveDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayFiveBindingSource)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.daySixDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daySixBindingSource)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.daySevenDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daySevenBindingSource)).EndInit();
            this.tabPageWarriors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarriors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warriorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leagueWarBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlClash;
        private System.Windows.Forms.TabPage tabPageScores;
        private System.Windows.Forms.TabPage tabPageLeague;
        private System.Windows.Forms.TabPage tabPageWars;
        private System.Windows.Forms.TabPage tabPageGames;
        private System.Windows.Forms.TabPage tabPageWarriors;
        private System.Windows.Forms.DataGridView dataGridViewWarriors;
        private System.Windows.Forms.BindingSource warriorBindingSource;
        private System.Windows.Forms.BindingSource leagueScoreOptionsBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox scoreHigherTownHallVillageAttackCheckBox;
        private System.Windows.Forms.CheckBox scoreStarResultsCheckBox;
        private System.Windows.Forms.NumericUpDown higherTownHallAttackPointsNumericUpDown;
        private System.Windows.Forms.NumericUpDown higherTownHallAttackMinimumStarsNumericUpDown;
        private System.Windows.Forms.NumericUpDown noAttackDonePointsNumericUpDown;
        private System.Windows.Forms.CheckBox scoreNoAttackDoneCheckBox;
        private System.Windows.Forms.CheckBox scoreFailedWarFaultCheckBox;
        private System.Windows.Forms.NumericUpDown failedWarFaultPointsNumericUpDown;
        private System.Windows.Forms.CheckBox scoreNotFollowedStrategyCheckBox;
        private System.Windows.Forms.NumericUpDown notFollowedStrategyPointsNumericUpDown;
        private System.Windows.Forms.CheckBox scoreIncoherentAttackCheckBox;
        private System.Windows.Forms.NumericUpDown incoherentAttackPointsNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.BindingSource leagueWarBindingSource;
        private System.Windows.Forms.DataGridView dayOneDataGridView;
        private System.Windows.Forms.BindingSource dayOneBindingSource;
        private System.Windows.Forms.DataGridView dayTwoDataGridView;
        private System.Windows.Forms.DataGridView dayThreeDataGridView;
        private System.Windows.Forms.DataGridView dayFourDataGridView;
        private System.Windows.Forms.DataGridView dayFiveDataGridView;
        private System.Windows.Forms.DataGridView daySixDataGridView;
        private System.Windows.Forms.DataGridView daySevenDataGridView;
        private System.Windows.Forms.BindingSource dayTwoBindingSource;
        private System.Windows.Forms.BindingSource dayThreeBindingSource;
        private System.Windows.Forms.BindingSource dayFourBindingSource;
        private System.Windows.Forms.BindingSource dayFiveBindingSource;
        private System.Windows.Forms.BindingSource daySixBindingSource;
        private System.Windows.Forms.BindingSource daySevenBindingSource;
        private System.Windows.Forms.DataGridView rewardDataGridView;
        private System.Windows.Forms.BindingSource rewardBindingSource;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource warriorScoreOptionsBindingSource;
        private System.Windows.Forms.CheckBox scoreWarParticipationCheckBox;
        private System.Windows.Forms.NumericUpDown leagueParticipationPointsNumericUpDown;
        private System.Windows.Forms.CheckBox scoreLeagueParticipationCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.NumericUpDown warParticipationPointsNumericUpDown;
        private System.Windows.Forms.NumericUpDown gameParticipationPointsNumericUpDown;
        private System.Windows.Forms.CheckBox scoreGameParticipationCheckBox;
        private System.Windows.Forms.CheckBox scoreMinimumGamePointsCheckBox;
        private System.Windows.Forms.NumericUpDown minimumGamePointsThresholdNumericUpDown;
        private System.Windows.Forms.NumericUpDown minimumGamePointsNumericUpDown;
        private System.Windows.Forms.CheckBox scoreTownHallLevelCheckBox;
        private System.Windows.Forms.CheckBox scoreSeniorityCheckBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSeniority;
        private System.Windows.Forms.Button btnHdvLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn townHallLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn townHallLevelMaturityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivalDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalNumberOfLeagues;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn ParticipateToLeagues;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalNumberOfWars;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn ParticipateToWars;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalNumberOfGames;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn ParticipateToGames;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn SucceedeedGames;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewButtonColumn DetailsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warrioNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn15;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn18;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn19;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn22;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn23;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerNameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn attackDoneDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attackedThLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCoherentAttackDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasFollowedStrategyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn failedWarFaultDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn leagueIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn leagueIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorIdDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorNameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn leagueIdDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorIdDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorNameDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn leagueIdDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorIdDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorNameDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn leagueIdDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorIdDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorNameDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn leagueIdDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorIdDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorNameDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn warriorDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn leagueIdDataGridViewTextBoxColumn6;
    }
}

