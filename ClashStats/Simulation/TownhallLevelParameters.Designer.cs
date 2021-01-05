
namespace ClashStats.Simulation
{
    partial class TownhallLevelParameters
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
            this.townHallLevelPointsDataGridView = new System.Windows.Forms.DataGridView();
            this.townHallLevelPointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.townHallLevelDataGridViewTextBoxColumn = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.maturityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bonusDataGridViewTextBoxColumn = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            ((System.ComponentModel.ISupportInitialize)(this.townHallLevelPointsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.townHallLevelPointsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // townHallLevelPointsDataGridView
            // 
            this.townHallLevelPointsDataGridView.AutoGenerateColumns = false;
            this.townHallLevelPointsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.townHallLevelPointsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.townHallLevelDataGridViewTextBoxColumn,
            this.maturityDataGridViewTextBoxColumn,
            this.bonusDataGridViewTextBoxColumn});
            this.townHallLevelPointsDataGridView.DataSource = this.townHallLevelPointsBindingSource;
            this.townHallLevelPointsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.townHallLevelPointsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.townHallLevelPointsDataGridView.Name = "townHallLevelPointsDataGridView";
            this.townHallLevelPointsDataGridView.RowHeadersVisible = false;
            this.townHallLevelPointsDataGridView.RowTemplate.Height = 28;
            this.townHallLevelPointsDataGridView.Size = new System.Drawing.Size(430, 426);
            this.townHallLevelPointsDataGridView.TabIndex = 1;
            this.townHallLevelPointsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.townHallLevelPointsDataGridView_CellEndEdit);
            this.townHallLevelPointsDataGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.townHallLevelPointsDataGridView_RowStateChanged);
            // 
            // townHallLevelPointsBindingSource
            // 
            this.townHallLevelPointsBindingSource.AllowNew = false;
            this.townHallLevelPointsBindingSource.DataSource = typeof(ClashEntities.ScoreOptions.TownHallMaturityBonus);
            // 
            // townHallLevelDataGridViewTextBoxColumn
            // 
            this.townHallLevelDataGridViewTextBoxColumn.DataPropertyName = "TownHallLevel";
            this.townHallLevelDataGridViewTextBoxColumn.DecimalPlaces = 0;
            this.townHallLevelDataGridViewTextBoxColumn.DefaultValue = 0;
            this.townHallLevelDataGridViewTextBoxColumn.HeaderText = "HDV";
            this.townHallLevelDataGridViewTextBoxColumn.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.townHallLevelDataGridViewTextBoxColumn.Name = "townHallLevelDataGridViewTextBoxColumn";
            this.townHallLevelDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.townHallLevelDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // maturityDataGridViewTextBoxColumn
            // 
            this.maturityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.maturityDataGridViewTextBoxColumn.DataPropertyName = "Maturity";
            this.maturityDataGridViewTextBoxColumn.HeaderText = "Maturité";
            this.maturityDataGridViewTextBoxColumn.Name = "maturityDataGridViewTextBoxColumn";
            this.maturityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.maturityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.maturityDataGridViewTextBoxColumn.Width = 92;
            // 
            // bonusDataGridViewTextBoxColumn
            // 
            this.bonusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bonusDataGridViewTextBoxColumn.DataPropertyName = "Bonus";
            this.bonusDataGridViewTextBoxColumn.DecimalPlaces = 0;
            this.bonusDataGridViewTextBoxColumn.DefaultValue = 0;
            this.bonusDataGridViewTextBoxColumn.HeaderText = "Bonus";
            this.bonusDataGridViewTextBoxColumn.Name = "bonusDataGridViewTextBoxColumn";
            this.bonusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bonusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TownhallLevelParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 426);
            this.Controls.Add(this.townHallLevelPointsDataGridView);
            this.Name = "TownhallLevelParameters";
            this.Text = "Paramètres Niveaux HDV";
            this.Load += new System.EventHandler(this.TownhallLevelParameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.townHallLevelPointsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.townHallLevelPointsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView townHallLevelPointsDataGridView;
        private System.Windows.Forms.BindingSource townHallLevelPointsBindingSource;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn townHallLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn maturityDataGridViewTextBoxColumn;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn bonusDataGridViewTextBoxColumn;
    }
}