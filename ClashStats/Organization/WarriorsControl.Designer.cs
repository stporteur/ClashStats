
namespace ClashStats.Organization
{
    partial class WarriorsControl
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warriorDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn8 = new ClashStats.CustomControls.DataGridViewDateTimePicker.DataGridViewDateTimePickerColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.dgvMaturityColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.WantsBonus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClashOfStatsLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ClashSpotLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.warriorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewDateTimePickerColumn1 = new ClashStats.CustomControls.DataGridViewDateTimePicker.DataGridViewDateTimePickerColumn();
            this.dataGridViewNumericUpDownColumn1 = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warriorDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warriorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1116, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = "|";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.deleteToolStripMenuItem.Text = "Supprimer";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // warriorDataGridView
            // 
            this.warriorDataGridView.AllowUserToOrderColumns = true;
            this.warriorDataGridView.AutoGenerateColumns = false;
            this.warriorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.warriorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.IsActive,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dgvMaturityColumn,
            this.WantsBonus,
            this.ClashOfStatsLink,
            this.ClashSpotLink});
            this.warriorDataGridView.DataSource = this.warriorBindingSource;
            this.warriorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warriorDataGridView.Location = new System.Drawing.Point(0, 26);
            this.warriorDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.warriorDataGridView.Name = "warriorDataGridView";
            this.warriorDataGridView.Size = new System.Drawing.Size(1116, 900);
            this.warriorDataGridView.TabIndex = 4;
            this.warriorDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.warriorDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // IsActive
            // 
            this.IsActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "IsActive";
            this.IsActive.Name = "IsActive";
            this.IsActive.Width = 71;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ClanId";
            this.dataGridViewTextBoxColumn6.DataSource = this.clanBindingSource;
            this.dataGridViewTextBoxColumn6.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "Clan";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.ValueMember = "Id";
            // 
            // clanBindingSource
            // 
            this.clanBindingSource.DataSource = typeof(ClashEntities.Clan);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ArrivalDate";
            this.dataGridViewTextBoxColumn8.HeaderText = "Date arrivée";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.Width = 110;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Hash";
            this.dataGridViewTextBoxColumn3.HeaderText = "Hash";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 72;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TownHallLevel";
            this.dataGridViewTextBoxColumn4.DecimalPlaces = 0;
            this.dataGridViewTextBoxColumn4.HeaderText = "HDV";
            this.dataGridViewTextBoxColumn4.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.dataGridViewTextBoxColumn4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.Width = 69;
            // 
            // dgvMaturityColumn
            // 
            this.dgvMaturityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvMaturityColumn.DataPropertyName = "TownHallLevelMaturity";
            this.dgvMaturityColumn.HeaderText = "Maturité HDV";
            this.dgvMaturityColumn.Name = "dgvMaturityColumn";
            this.dgvMaturityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaturityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvMaturityColumn.Width = 120;
            // 
            // WantsBonus
            // 
            this.WantsBonus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WantsBonus.DataPropertyName = "WantsBonus";
            this.WantsBonus.HeaderText = "Bonus de ligue";
            this.WantsBonus.Name = "WantsBonus";
            this.WantsBonus.Width = 78;
            // 
            // ClashOfStatsLink
            // 
            this.ClashOfStatsLink.HeaderText = "Clash Of Stats";
            this.ClashOfStatsLink.Name = "ClashOfStatsLink";
            this.ClashOfStatsLink.ReadOnly = true;
            this.ClashOfStatsLink.Text = "Go to...";
            this.ClashOfStatsLink.UseColumnTextForLinkValue = true;
            // 
            // ClashSpotLink
            // 
            this.ClashSpotLink.HeaderText = "Clash Spot";
            this.ClashSpotLink.Name = "ClashSpotLink";
            this.ClashSpotLink.ReadOnly = true;
            this.ClashSpotLink.Text = "Go to...";
            this.ClashSpotLink.UseColumnTextForLinkValue = true;
            // 
            // warriorBindingSource
            // 
            this.warriorBindingSource.DataSource = typeof(ClashEntities.Warrior);
            // 
            // dataGridViewDateTimePickerColumn1
            // 
            this.dataGridViewDateTimePickerColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewDateTimePickerColumn1.DataPropertyName = "ArrivalDate";
            this.dataGridViewDateTimePickerColumn1.HeaderText = "Date arrivée";
            this.dataGridViewDateTimePickerColumn1.Name = "dataGridViewDateTimePickerColumn1";
            this.dataGridViewDateTimePickerColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewNumericUpDownColumn1
            // 
            this.dataGridViewNumericUpDownColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewNumericUpDownColumn1.DataPropertyName = "TownHallLevel";
            this.dataGridViewNumericUpDownColumn1.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn1.HeaderText = "HDV";
            this.dataGridViewNumericUpDownColumn1.Name = "dataGridViewNumericUpDownColumn1";
            this.dataGridViewNumericUpDownColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNumericUpDownColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // WarriorsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.warriorDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WarriorsControl";
            this.Size = new System.Drawing.Size(1116, 926);
            this.Load += new System.EventHandler(this.WarriorsControl_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warriorDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warriorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource warriorBindingSource;
        private System.Windows.Forms.DataGridView warriorDataGridView;
        private System.Windows.Forms.BindingSource clanBindingSource;
        private CustomControls.DataGridViewDateTimePicker.DataGridViewDateTimePickerColumn dataGridViewDateTimePickerColumn1;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn6;
        private CustomControls.DataGridViewDateTimePicker.DataGridViewDateTimePickerColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvMaturityColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn WantsBonus;
        private System.Windows.Forms.DataGridViewLinkColumn ClashOfStatsLink;
        private System.Windows.Forms.DataGridViewLinkColumn ClashSpotLink;
    }
}
