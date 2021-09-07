
namespace ClashStats.LetsPlay.Games
{
    partial class CurrentGameControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label gamesDateLabel;
            System.Windows.Forms.Label gamesEndedLabel;
            System.Windows.Forms.Label clanIdLabel;
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gamesDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.gamesEndedCheckBox = new System.Windows.Forms.CheckBox();
            this.clanIdComboBox = new System.Windows.Forms.ComboBox();
            this.clanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip8 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameWarriorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameWarriorDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            gamesDateLabel = new System.Windows.Forms.Label();
            gamesEndedLabel = new System.Windows.Forms.Label();
            clanIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clanBindingSource)).BeginInit();
            this.menuStrip8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameWarriorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameWarriorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesDateLabel
            // 
            gamesDateLabel.AutoSize = true;
            gamesDateLabel.Location = new System.Drawing.Point(25, 65);
            gamesDateLabel.Name = "gamesDateLabel";
            gamesDateLabel.Size = new System.Drawing.Size(78, 13);
            gamesDateLabel.TabIndex = 1;
            gamesDateLabel.Text = "Date des jeux :";
            // 
            // gamesEndedLabel
            // 
            gamesEndedLabel.AutoSize = true;
            gamesEndedLabel.Location = new System.Drawing.Point(26, 93);
            gamesEndedLabel.Name = "gamesEndedLabel";
            gamesEndedLabel.Size = new System.Drawing.Size(77, 13);
            gamesEndedLabel.TabIndex = 2;
            gamesEndedLabel.Text = "Jeux terminés :";
            // 
            // clanIdLabel
            // 
            clanIdLabel.AutoSize = true;
            clanIdLabel.Location = new System.Drawing.Point(26, 38);
            clanIdLabel.Name = "clanIdLabel";
            clanIdLabel.Size = new System.Drawing.Size(34, 13);
            clanIdLabel.TabIndex = 4;
            clanIdLabel.Text = "Clan :";
            // 
            // gameBindingSource
            // 
            this.gameBindingSource.DataSource = typeof(ClashEntities.Game);
            // 
            // gamesDateDateTimePicker
            // 
            this.gamesDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameBindingSource, "GamesDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gamesDateDateTimePicker.Location = new System.Drawing.Point(109, 62);
            this.gamesDateDateTimePicker.Name = "gamesDateDateTimePicker";
            this.gamesDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.gamesDateDateTimePicker.TabIndex = 2;
            // 
            // gamesEndedCheckBox
            // 
            this.gamesEndedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameBindingSource, "GamesEnded", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gamesEndedCheckBox.Location = new System.Drawing.Point(109, 88);
            this.gamesEndedCheckBox.Name = "gamesEndedCheckBox";
            this.gamesEndedCheckBox.Size = new System.Drawing.Size(104, 24);
            this.gamesEndedCheckBox.TabIndex = 3;
            this.gamesEndedCheckBox.UseVisualStyleBackColor = true;
            // 
            // clanIdComboBox
            // 
            this.clanIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameBindingSource, "ClanId", true));
            this.clanIdComboBox.DataSource = this.clanBindingSource;
            this.clanIdComboBox.DisplayMember = "Name";
            this.clanIdComboBox.Enabled = false;
            this.clanIdComboBox.FormattingEnabled = true;
            this.clanIdComboBox.Location = new System.Drawing.Point(109, 35);
            this.clanIdComboBox.Name = "clanIdComboBox";
            this.clanIdComboBox.Size = new System.Drawing.Size(200, 21);
            this.clanIdComboBox.TabIndex = 5;
            this.clanIdComboBox.ValueMember = "Id";
            // 
            // clanBindingSource
            // 
            this.clanBindingSource.AllowNew = false;
            this.clanBindingSource.DataSource = typeof(ClashEntities.Clan);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(161, 137);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(37, 23);
            this.btnAddPlayer.TabIndex = 17;
            this.btnAddPlayer.Text = "+";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Joueurs inscrits aux jeux";
            // 
            // menuStrip8
            // 
            this.menuStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.menuStrip8.Location = new System.Drawing.Point(0, 0);
            this.menuStrip8.Name = "menuStrip8";
            this.menuStrip8.Size = new System.Drawing.Size(995, 24);
            this.menuStrip8.TabIndex = 18;
            this.menuStrip8.Text = "menuStrip8";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::ClashStats.Properties.Resources.Save_16x;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.saveToolStripMenuItem.Text = "Sauver";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::ClashStats.Properties.Resources.Cancel_16x;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.cancelToolStripMenuItem.Text = "Annuler";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // gameWarriorBindingSource
            // 
            this.gameWarriorBindingSource.AllowNew = false;
            this.gameWarriorBindingSource.DataSource = this.playersBindingSource;
            // 
            // playersBindingSource
            // 
            this.playersBindingSource.DataMember = "Players";
            this.playersBindingSource.DataSource = this.gameBindingSource;
            // 
            // gameWarriorDataGridView
            // 
            this.gameWarriorDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gameWarriorDataGridView.AutoGenerateColumns = false;
            this.gameWarriorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameWarriorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.gameWarriorDataGridView.DataSource = this.gameWarriorBindingSource;
            this.gameWarriorDataGridView.Location = new System.Drawing.Point(33, 166);
            this.gameWarriorDataGridView.Name = "gameWarriorDataGridView";
            this.gameWarriorDataGridView.RowHeadersVisible = false;
            this.gameWarriorDataGridView.Size = new System.Drawing.Size(415, 567);
            this.gameWarriorDataGridView.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Warrior";
            this.dataGridViewTextBoxColumn5.HeaderText = "Guerrier";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Score";
            this.dataGridViewTextBoxColumn6.DecimalPlaces = 0;
            this.dataGridViewTextBoxColumn6.DefaultValue = 0;
            this.dataGridViewTextBoxColumn6.HeaderText = "Score";
            this.dataGridViewTextBoxColumn6.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // CurrentGameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameWarriorDataGridView);
            this.Controls.Add(this.menuStrip8);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(clanIdLabel);
            this.Controls.Add(this.clanIdComboBox);
            this.Controls.Add(gamesEndedLabel);
            this.Controls.Add(this.gamesEndedCheckBox);
            this.Controls.Add(gamesDateLabel);
            this.Controls.Add(this.gamesDateDateTimePicker);
            this.Name = "CurrentGameControl";
            this.Size = new System.Drawing.Size(995, 769);
            this.Load += new System.EventHandler(this.CurrentGameControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clanBindingSource)).EndInit();
            this.menuStrip8.ResumeLayout(false);
            this.menuStrip8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameWarriorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameWarriorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource gameBindingSource;
        private System.Windows.Forms.DateTimePicker gamesDateDateTimePicker;
        private System.Windows.Forms.CheckBox gamesEndedCheckBox;
        private System.Windows.Forms.ComboBox clanIdComboBox;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip8;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.BindingSource gameWarriorBindingSource;
        private System.Windows.Forms.DataGridView gameWarriorDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource clanBindingSource;
        private System.Windows.Forms.BindingSource playersBindingSource;
    }
}
