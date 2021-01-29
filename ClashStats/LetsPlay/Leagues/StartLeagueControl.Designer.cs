
namespace ClashStats.LetsPlay.Leagues
{
    partial class StartLeagueControl
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
            this.clansCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadPlayers = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLeagueSize30 = new System.Windows.Forms.RadioButton();
            this.rbLeagueSize15 = new System.Windows.Forms.RadioButton();
            this.availableCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectedCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.leagueDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clansCheckedListBox
            // 
            this.clansCheckedListBox.FormattingEnabled = true;
            this.clansCheckedListBox.Location = new System.Drawing.Point(29, 104);
            this.clansCheckedListBox.Name = "clansCheckedListBox";
            this.clansCheckedListBox.Size = new System.Drawing.Size(280, 94);
            this.clansCheckedListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Charger les joueurs des clans suivants :";
            // 
            // btnLoadPlayers
            // 
            this.btnLoadPlayers.Location = new System.Drawing.Point(234, 204);
            this.btnLoadPlayers.Name = "btnLoadPlayers";
            this.btnLoadPlayers.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPlayers.TabIndex = 2;
            this.btnLoadPlayers.Text = "Charger";
            this.btnLoadPlayers.UseVisualStyleBackColor = true;
            this.btnLoadPlayers.Click += new System.EventHandler(this.btnLoadPlayers_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLeagueSize30);
            this.groupBox1.Controls.Add(this.rbLeagueSize15);
            this.groupBox1.Location = new System.Drawing.Point(29, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 55);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Taille de la ligue";
            // 
            // rbLeagueSize30
            // 
            this.rbLeagueSize30.AutoSize = true;
            this.rbLeagueSize30.Location = new System.Drawing.Point(146, 19);
            this.rbLeagueSize30.Name = "rbLeagueSize30";
            this.rbLeagueSize30.Size = new System.Drawing.Size(60, 17);
            this.rbLeagueSize30.TabIndex = 1;
            this.rbLeagueSize30.Text = "30 x 30";
            this.rbLeagueSize30.UseVisualStyleBackColor = true;
            // 
            // rbLeagueSize15
            // 
            this.rbLeagueSize15.AutoSize = true;
            this.rbLeagueSize15.Checked = true;
            this.rbLeagueSize15.Location = new System.Drawing.Point(6, 19);
            this.rbLeagueSize15.Name = "rbLeagueSize15";
            this.rbLeagueSize15.Size = new System.Drawing.Size(60, 17);
            this.rbLeagueSize15.TabIndex = 0;
            this.rbLeagueSize15.TabStop = true;
            this.rbLeagueSize15.Text = "15 x 15";
            this.rbLeagueSize15.UseVisualStyleBackColor = true;
            // 
            // availableCheckedListBox
            // 
            this.availableCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.availableCheckedListBox.FormattingEnabled = true;
            this.availableCheckedListBox.Location = new System.Drawing.Point(29, 280);
            this.availableCheckedListBox.Name = "availableCheckedListBox";
            this.availableCheckedListBox.Size = new System.Drawing.Size(280, 394);
            this.availableCheckedListBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Joueurs disponibles :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Joueurs Sélectionnés :";
            // 
            // selectedCheckedListBox
            // 
            this.selectedCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectedCheckedListBox.FormattingEnabled = true;
            this.selectedCheckedListBox.Location = new System.Drawing.Point(487, 280);
            this.selectedCheckedListBox.Name = "selectedCheckedListBox";
            this.selectedCheckedListBox.Size = new System.Drawing.Size(280, 394);
            this.selectedCheckedListBox.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(373, 430);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(373, 473);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(65, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(515, 209);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(201, 37);
            this.lblWarning.TabIndex = 10;
            this.lblWarning.Text = "Attention le nombre de joeurs minimum requis n\'est pas atteind";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLaunch.Location = new System.Drawing.Point(268, 694);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(286, 71);
            this.btnLaunch.TabIndex = 11;
            this.btnLaunch.Text = "On va tout casser !";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // leagueDateDateTimePicker
            // 
            this.leagueDateDateTimePicker.Location = new System.Drawing.Point(567, 28);
            this.leagueDateDateTimePicker.Name = "leagueDateDateTimePicker";
            this.leagueDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.leagueDateDateTimePicker.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Date de la ligue";
            // 
            // StartLeagueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.leagueDateDateTimePicker);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectedCheckedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.availableCheckedListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoadPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clansCheckedListBox);
            this.Name = "StartLeagueControl";
            this.Size = new System.Drawing.Size(1122, 823);
            this.Load += new System.EventHandler(this.StartLeagueControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clansCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadPlayers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLeagueSize30;
        private System.Windows.Forms.RadioButton rbLeagueSize15;
        private System.Windows.Forms.CheckedListBox availableCheckedListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox selectedCheckedListBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.DateTimePicker leagueDateDateTimePicker;
        private System.Windows.Forms.Label label4;
    }
}
