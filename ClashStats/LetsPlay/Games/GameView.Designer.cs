
namespace ClashStats.LetsPlay.Games
{
    partial class GameView
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
            System.Windows.Forms.Label nameLabel;
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gamesDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.gamesEndedCheckBox = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            gamesDateLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gameBindingSource
            // 
            this.gameBindingSource.DataSource = typeof(ClashEntities.Game);
            // 
            // gamesDateLabel
            // 
            gamesDateLabel.AutoSize = true;
            gamesDateLabel.Location = new System.Drawing.Point(25, 51);
            gamesDateLabel.Name = "gamesDateLabel";
            gamesDateLabel.Size = new System.Drawing.Size(36, 13);
            gamesDateLabel.TabIndex = 3;
            gamesDateLabel.Text = "Date :";
            // 
            // gamesDateDateTimePicker
            // 
            this.gamesDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameBindingSource, "GamesDate", true));
            this.gamesDateDateTimePicker.Enabled = false;
            this.gamesDateDateTimePicker.Location = new System.Drawing.Point(67, 47);
            this.gamesDateDateTimePicker.Name = "gamesDateDateTimePicker";
            this.gamesDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.gamesDateDateTimePicker.TabIndex = 4;
            // 
            // gamesEndedCheckBox
            // 
            this.gamesEndedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameBindingSource, "GamesEnded", true));
            this.gamesEndedCheckBox.Enabled = false;
            this.gamesEndedCheckBox.Location = new System.Drawing.Point(67, 73);
            this.gamesEndedCheckBox.Name = "gamesEndedCheckBox";
            this.gamesEndedCheckBox.Size = new System.Drawing.Size(200, 24);
            this.gamesEndedCheckBox.TabIndex = 6;
            this.gamesEndedCheckBox.Text = "Jeux terminés";
            this.gamesEndedCheckBox.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(27, 24);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(34, 13);
            nameLabel.TabIndex = 13;
            nameLabel.Text = "Clan :";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameBindingSource, "Clan.Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(67, 21);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(316, 20);
            this.nameTextBox.TabIndex = 14;
            // 
            // playersBindingSource
            // 
            this.playersBindingSource.DataMember = "Players";
            this.playersBindingSource.DataSource = this.gameBindingSource;
            // 
            // playersDataGridView
            // 
            this.playersDataGridView.AllowUserToAddRows = false;
            this.playersDataGridView.AllowUserToDeleteRows = false;
            this.playersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playersDataGridView.AutoGenerateColumns = false;
            this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.playersDataGridView.DataSource = this.playersBindingSource;
            this.playersDataGridView.Location = new System.Drawing.Point(14, 103);
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.ReadOnly = true;
            this.playersDataGridView.RowHeadersVisible = false;
            this.playersDataGridView.Size = new System.Drawing.Size(582, 724);
            this.playersDataGridView.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "WarriorName";
            this.dataGridViewTextBoxColumn5.HeaderText = "WarriorName";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Score";
            this.dataGridViewTextBoxColumn6.HeaderText = "Score";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.playersDataGridView);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(gamesDateLabel);
            this.Controls.Add(this.gamesDateDateTimePicker);
            this.Controls.Add(this.gamesEndedCheckBox);
            this.Name = "GameView";
            this.Size = new System.Drawing.Size(614, 846);
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource gameBindingSource;
        private System.Windows.Forms.DateTimePicker gamesDateDateTimePicker;
        private System.Windows.Forms.CheckBox gamesEndedCheckBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private System.Windows.Forms.DataGridView playersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
