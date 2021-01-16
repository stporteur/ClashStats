using ClashEntities.ScoreOptions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClashStats.Simulation
{
    public partial class SeniorityParameters : Form
    {
        private List<SeniorityBonus> _parameters;
        public SeniorityParameters(List<SeniorityBonus> parameters)
        {
            InitializeComponent();
            _parameters = parameters;
        }

        private void SeniorityParameters_Load(object sender, EventArgs e)
        {
            seniorityPointsBindingSource.DataSource = _parameters;
        }
    }
}
