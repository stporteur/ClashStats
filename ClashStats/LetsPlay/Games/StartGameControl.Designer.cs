
namespace ClashStats.LetsPlay.Games
{
    partial class StartGameControl
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
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gamesDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.availableCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.btnLoadPlayers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clansCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.selectedCheckedListBox = new System.Windows.Forms.CheckedListBox();
            gamesDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesDateLabel
            // 
            gamesDateLabel.AutoSize = true;
            gamesDateLabel.Location = new System.Drawing.Point(20, 28);
            gamesDateLabel.Name = "gamesDateLabel";
            gamesDateLabel.Size = new System.Drawing.Size(69, 13);
            gamesDateLabel.TabIndex = 1;
            gamesDateLabel.Text = "Games Date:";
            // 
            // gameBindingSource
            // 
            this.gameBindingSource.DataSource = typeof(ClashEntities.Game);
            // 
            // gamesDateDateTimePicker
            // 
            this.gamesDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameBindingSource, "GamesDate", true));
            this.gamesDateDateTimePicker.Location = new System.Drawing.Point(95, 24);
            this.gamesDateDateTimePicker.Name = "gamesDateDateTimePicker";
            this.gamesDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.gamesDateDateTimePicker.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Joueurs disponibles :";
            // 
            // availableCheckedListBox
            // 
            this.availableCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.availableCheckedListBox.FormattingEnabled = true;
            this.availableCheckedListBox.Location = new System.Drawing.Point(23, 255);
            this.availableCheckedListBox.Name = "availableCheckedListBox";
            this.availableCheckedListBox.Size = new System.Drawing.Size(280, 394);
            this.availableCheckedListBox.TabIndex = 9;
            // 
            // btnLoadPlayers
            // 
            this.btnLoadPlayers.Location = new System.Drawing.Point(228, 179);
            this.btnLoadPlayers.Name = "btnLoadPlayers";
            this.btnLoadPlayers.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPlayers.TabIndex = 8;
            this.btnLoadPlayers.Text = "Charger";
            this.btnLoadPlayers.UseVisualStyleBackColor = true;
            this.btnLoadPlayers.Click += new System.EventHandler(this.btnLoadPlayers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Charger les joueurs des clans suivants :";
            // 
            // clansCheckedListBox
            // 
            this.clansCheckedListBox.FormattingEnabled = true;
            this.clansCheckedListBox.Location = new System.Drawing.Point(23, 79);
            this.clansCheckedListBox.Name = "clansCheckedListBox";
            this.clansCheckedListBox.Size = new System.Drawing.Size(280, 94);
            this.clansCheckedListBox.TabIndex = 6;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLaunch.Location = new System.Drawing.Point(280, 695);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(286, 71);
            this.btnLaunch.TabIndex = 16;
            this.btnLaunch.Text = "On va tout casser !";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(366, 448);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(65, 23);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(366, 405);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Joueurs Sélectionnés :";
            // 
            // selectedCheckedListBox
            // 
            this.selectedCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectedCheckedListBox.FormattingEnabled = true;
            this.selectedCheckedListBox.Location = new System.Drawing.Point(480, 255);
            this.selectedCheckedListBox.Name = "selectedCheckedListBox";
            this.selectedCheckedListBox.Size = new System.Drawing.Size(280, 394);
            this.selectedCheckedListBox.TabIndex = 12;
            // 
            // StartGameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectedCheckedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.availableCheckedListBox);
            this.Controls.Add(this.btnLoadPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clansCheckedListBox);
            this.Controls.Add(gamesDateLabel);
            this.Controls.Add(this.gamesDateDateTimePicker);
            this.Name = "StartGameControl";
            this.Size = new System.Drawing.Size(779, 818);
            this.Load += new System.EventHandler(this.StartGameControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource gameBindingSource;
        private System.Windows.Forms.DateTimePicker gamesDateDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox availableCheckedListBox;
        private System.Windows.Forms.Button btnLoadPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clansCheckedListBox;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox selectedCheckedListBox;
    }
}
