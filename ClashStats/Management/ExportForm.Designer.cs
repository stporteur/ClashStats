
namespace ClashStats.Management
{
    partial class ExportForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.clanComboBox = new System.Windows.Forms.ComboBox();
            this.clanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.datesToExportCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbGames = new System.Windows.Forms.RadioButton();
            this.rbWars = new System.Windows.Forms.RadioButton();
            this.rbLeagues = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.selectFolderButton = new System.Windows.Forms.Button();
            idLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clanBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(29, 38);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(34, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Clan :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 113);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 13);
            label1.TabIndex = 3;
            label1.Text = "Dates à exporter :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 80);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 13);
            label2.TabIndex = 5;
            label2.Text = "Exporter des :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(29, 351);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(75, 13);
            label3.TabIndex = 7;
            label3.Text = "Exporter vers :";
            // 
            // clanComboBox
            // 
            this.clanComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clanBindingSource, "Id", true));
            this.clanComboBox.DataSource = this.clanBindingSource;
            this.clanComboBox.DisplayMember = "Name";
            this.clanComboBox.FormattingEnabled = true;
            this.clanComboBox.Location = new System.Drawing.Point(155, 30);
            this.clanComboBox.Name = "clanComboBox";
            this.clanComboBox.Size = new System.Drawing.Size(303, 21);
            this.clanComboBox.TabIndex = 1;
            this.clanComboBox.ValueMember = "Id";
            this.clanComboBox.SelectedIndexChanged += new System.EventHandler(this.clanComboBox_SelectedIndexChanged);
            // 
            // clanBindingSource
            // 
            this.clanBindingSource.DataSource = typeof(ClashEntities.Clan);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(383, 408);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Exporter";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(302, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // datesToExportCheckedListBox
            // 
            this.datesToExportCheckedListBox.FormattingEnabled = true;
            this.datesToExportCheckedListBox.Location = new System.Drawing.Point(155, 113);
            this.datesToExportCheckedListBox.Name = "datesToExportCheckedListBox";
            this.datesToExportCheckedListBox.Size = new System.Drawing.Size(303, 229);
            this.datesToExportCheckedListBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbGames);
            this.panel1.Controls.Add(this.rbWars);
            this.panel1.Controls.Add(this.rbLeagues);
            this.panel1.Location = new System.Drawing.Point(155, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 50);
            this.panel1.TabIndex = 6;
            // 
            // rbGames
            // 
            this.rbGames.AutoSize = true;
            this.rbGames.Location = new System.Drawing.Point(230, 19);
            this.rbGames.Name = "rbGames";
            this.rbGames.Size = new System.Drawing.Size(47, 17);
            this.rbGames.TabIndex = 2;
            this.rbGames.Text = "Jeux";
            this.rbGames.UseVisualStyleBackColor = true;
            this.rbGames.CheckedChanged += new System.EventHandler(this.rbTypes_CheckedChanged);
            // 
            // rbWars
            // 
            this.rbWars.AutoSize = true;
            this.rbWars.Location = new System.Drawing.Point(122, 19);
            this.rbWars.Name = "rbWars";
            this.rbWars.Size = new System.Drawing.Size(48, 17);
            this.rbWars.TabIndex = 1;
            this.rbWars.Text = "GDC";
            this.rbWars.UseVisualStyleBackColor = true;
            this.rbWars.CheckedChanged += new System.EventHandler(this.rbTypes_CheckedChanged);
            // 
            // rbLeagues
            // 
            this.rbLeagues.AutoSize = true;
            this.rbLeagues.Checked = true;
            this.rbLeagues.Location = new System.Drawing.Point(20, 19);
            this.rbLeagues.Name = "rbLeagues";
            this.rbLeagues.Size = new System.Drawing.Size(56, 17);
            this.rbLeagues.TabIndex = 0;
            this.rbLeagues.TabStop = true;
            this.rbLeagues.Text = "Ligues";
            this.rbLeagues.UseVisualStyleBackColor = true;
            this.rbLeagues.CheckedChanged += new System.EventHandler(this.rbTypes_CheckedChanged);
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(155, 348);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(303, 20);
            this.folderTextBox.TabIndex = 8;
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(464, 348);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(34, 23);
            this.selectFolderButton.TabIndex = 9;
            this.selectFolderButton.Text = "...";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 453);
            this.Controls.Add(this.selectFolderButton);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(label2);
            this.Controls.Add(this.datesToExportCheckedListBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.clanComboBox);
            this.Name = "ExportForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.ExportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clanBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox clanComboBox;
        private System.Windows.Forms.BindingSource clanBindingSource;
        private System.Windows.Forms.CheckedListBox datesToExportCheckedListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbGames;
        private System.Windows.Forms.RadioButton rbWars;
        private System.Windows.Forms.RadioButton rbLeagues;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button selectFolderButton;
    }
}