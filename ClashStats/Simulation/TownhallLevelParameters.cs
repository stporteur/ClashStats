using ClashEntities;
using ClashEntities.ScoreOptions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClashStats.Simulation
{
    public partial class TownhallLevelParameters : Form
    {
        private List<TownHallMaturityBonus> _parameters;
        public TownhallLevelParameters(List<TownHallMaturityBonus> parameters)
        {
            InitializeComponent();
            _parameters = parameters;
        }

        private void TownhallLevelParameters_Load(object sender, EventArgs e)
        {
            maturityDataGridViewTextBoxColumn.DataSource = Enum.GetValues(typeof(TownHallLevelMaturities));

            townHallLevelPointsBindingSource.DataSource = _parameters;
            townHallLevelPointsBindingSource.ResetBindings(false);
        }

        private void townHallLevelPointsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == maturityDataGridViewTextBoxColumn.Index)
            {
                townHallLevelPointsDataGridView.Rows[e.RowIndex].Cells[maturityDataGridViewTextBoxColumn.Index].Value = (TownHallLevelMaturities)((int)townHallLevelPointsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
        }

        private void townHallLevelPointsDataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.DataBoundItem != null)
            {
                e.Row.Cells[maturityDataGridViewTextBoxColumn.Index].Value = (TownHallLevelMaturities)((int)e.Row.Cells[maturityDataGridViewTextBoxColumn.Index].Value);
            }
        }
    }
}
