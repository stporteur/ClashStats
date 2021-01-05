
namespace ClashStats.Simulation
{
    partial class SeniorityParameters
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
            this.seniorityPointsDataGridView = new System.Windows.Forms.DataGridView();
            this.seniorityPointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.dataGridViewTextBoxColumn2 = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            this.dataGridViewTextBoxColumn3 = new ClashStats.CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn();
            ((System.ComponentModel.ISupportInitialize)(this.seniorityPointsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seniorityPointsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // seniorityPointsDataGridView
            // 
            this.seniorityPointsDataGridView.AutoGenerateColumns = false;
            this.seniorityPointsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seniorityPointsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.seniorityPointsDataGridView.DataSource = this.seniorityPointsBindingSource;
            this.seniorityPointsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seniorityPointsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.seniorityPointsDataGridView.Name = "seniorityPointsDataGridView";
            this.seniorityPointsDataGridView.RowHeadersVisible = false;
            this.seniorityPointsDataGridView.RowTemplate.Height = 28;
            this.seniorityPointsDataGridView.Size = new System.Drawing.Size(379, 343);
            this.seniorityPointsDataGridView.TabIndex = 1;
            // 
            // seniorityPointsBindingSource
            // 
            this.seniorityPointsBindingSource.AllowNew = false;
            this.seniorityPointsBindingSource.DataSource = typeof(ClashEntities.ScoreOptions.SeniorityBonus);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MinimumMonth";
            this.dataGridViewTextBoxColumn1.DecimalPlaces = 0;
            this.dataGridViewTextBoxColumn1.DefaultValue = 0;
            this.dataGridViewTextBoxColumn1.HeaderText = "De (en mois)";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MaximumMonth";
            this.dataGridViewTextBoxColumn2.DecimalPlaces = 0;
            this.dataGridViewTextBoxColumn2.DefaultValue = 0;
            this.dataGridViewTextBoxColumn2.HeaderText = "A (en mois)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Bonus";
            this.dataGridViewTextBoxColumn3.DecimalPlaces = 0;
            this.dataGridViewTextBoxColumn3.DefaultValue = 0;
            this.dataGridViewTextBoxColumn3.HeaderText = "Bonus";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SeniorityParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 343);
            this.Controls.Add(this.seniorityPointsDataGridView);
            this.Name = "SeniorityParameters";
            this.Text = "Paramètres ancienneté";
            this.Load += new System.EventHandler(this.SeniorityParameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seniorityPointsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seniorityPointsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource seniorityPointsBindingSource;
        private System.Windows.Forms.DataGridView seniorityPointsDataGridView;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn dataGridViewTextBoxColumn1;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn dataGridViewTextBoxColumn2;
        private CustomControls.DataGridViewNumericUpDown.DataGridViewNumericUpDownColumn dataGridViewTextBoxColumn3;
    }
}