using ClashBusiness;
using ClashBusiness.ScoreOptions;
using ClashEntities;
using ClashEntities.ScoreOptions;
using ClashStats.CustomControls.ComboboxEnum;
using ClashStats.Simulation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClashStats.ScoreOptionControls
{
    public partial class WarriorScoreOptionControl : UserControl
    {
        private List<SeniorityBonus> _deletedSeniorities;
        private List<TownHallMaturityBonus> _deletedThMaturities;
        private IScoreOptionsManagement _optionsLoader;
        public WarriorScoreOptionControl()
        {
            InitializeComponent();
            _optionsLoader = AutofacFactory.Instance.GetInstance<IScoreOptionsManagement>();

            gdvTownHallMaturityColumn.DataSource = EnumHelper.ToList(typeof(TownHallLevelMaturities));
            gdvTownHallMaturityColumn.DisplayMember = "Value";
            gdvTownHallMaturityColumn.ValueMember = "Key";
            _deletedSeniorities = new List<SeniorityBonus>();
            _deletedThMaturities = new List<TownHallMaturityBonus>();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var options = warriorScoreOptionsBindingSource.DataSource as WarriorScoreOptions;
            bool result = _optionsLoader.SaveWarriorScoreOptions(options);
            if(_deletedSeniorities.Count > 0)
            {
                result &= _optionsLoader.DeleteSeniorityScoreOptions(_deletedSeniorities);
            }
            if (_deletedThMaturities.Count > 0)
            {
                result &= _optionsLoader.DeleteTownHallLevelScoreOptions(_deletedThMaturities);
            }

            if (result)
            {
                MessageBox.Show("Sauvegarde réussie.", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erreur lors de la sauvegarde.", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            warriorScoreOptionsBindingSource.DataSource = _optionsLoader.LoadWarriorScoreOptions();
            _deletedSeniorities = new List<SeniorityBonus>();
            _deletedThMaturities = new List<TownHallMaturityBonus>();
        }

        private void WarriorScoreOptionControl_Load(object sender, EventArgs e)
        {
            warriorScoreOptionsBindingSource.DataSource = _optionsLoader.LoadWarriorScoreOptions();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new HelpForm())
            {
                form.LoadHelp("ScoreOptionControls/ScoreHelp.rtf");
                form.ShowDialog();
            }
        }

        private void deleteSeniorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var seniority = seniorityPointsDataGridView.CurrentRow.DataBoundItem as SeniorityBonus;
            if (seniority != null)
            {
                if (seniority.Id > 0)
                {
                    _deletedSeniorities.Add(seniority);
                }
                seniorityPointsBindingSource.Remove(seniority);
            }
        }

        private void deleteThLevelBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var thLevel = townHallLevelPointsDataGridView.CurrentRow.DataBoundItem as TownHallMaturityBonus;
            if (thLevel != null)
            {
                if (thLevel.Id > 0)
                {
                    _deletedThMaturities.Add(thLevel);
                }
                townHallLevelPointsBindingSource.Remove(thLevel);
            }
        }

        private void reorderSeniorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var seniorities = seniorityPointsBindingSource.DataSource as List<SeniorityBonus>;
            seniorityPointsBindingSource.DataSource = seniorities.OrderBy(x => x.MinimumMonth).ToList();
        }

        private void reorderTownHallLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maturities = seniorityPointsBindingSource.DataSource as List<TownHallMaturityBonus>;
            townHallLevelPointsBindingSource.DataSource = maturities.OrderByDescending(x => x.TownHallLevel).ThenBy(x => (int)x.Maturity).ToList();
        }
    }
}
