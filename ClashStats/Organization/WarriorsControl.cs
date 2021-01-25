using ClashBusiness;
using ClashEntities;
using ClashStats.CustomControls.ComboboxEnum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ClashStats.Organization
{
    public partial class WarriorsControl : UserControl
    {
        private IApplicationManagement _applicationManagement;
        private IWarriorManagement _warriorManagement;
        private List<Warrior> _deletedWarriors;

        public WarriorsControl()
        {
            InitializeComponent();
            dgvMaturityColumn.DataSource = EnumHelper.ToList(typeof(TownHallLevelMaturities));
            dgvMaturityColumn.DisplayMember = "Value";
            dgvMaturityColumn.ValueMember = "Key";

            var clans = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans().OrderBy(x => x.Name).ToList();
            clans.Insert(0, new Clan { Id = 0, Name = "<Sélectionner un clan>" });
            clanBindingSource.DataSource = clans;

            _warriorManagement = AutofacFactory.Instance.GetInstance<IWarriorManagement>();
            _applicationManagement = AutofacFactory.Instance.GetInstance<IApplicationManagement>();
            _deletedWarriors = new List<Warrior>();
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            warriorDataGridView.EndEdit();
            var warriors = warriorBindingSource.DataSource as List<Warrior>;
            bool result = _warriorManagement.SaveWarriors(warriors.Where(x => !string.IsNullOrEmpty(x.Name)).ToList());
            if (_deletedWarriors.Count > 0)
            {
                result &= _warriorManagement.DeleteWarriors(_deletedWarriors);
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

        private void cancelToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _deletedWarriors = new List<Warrior>();
            warriorBindingSource.DataSource = _warriorManagement.GetWarriors();
        }

        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var warrior = warriorDataGridView.CurrentRow.DataBoundItem as Warrior;
            if (warrior != null)
            {
                if (warrior.Id > 0)
                {
                    _deletedWarriors.Add(warrior);
                }
                warriorBindingSource.Remove(warrior);
            }
        }

        private void WarriorsControl_Load(object sender, System.EventArgs e)
        {
            warriorBindingSource.DataSource = _warriorManagement.GetWarriors();
        }

        private void warriorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var warrior = warriorDataGridView.CurrentRow.DataBoundItem as Warrior;
            if (e.ColumnIndex == ClashOfStatsLink.Index)
            {
                OpenLink("ClashOfStatsPlayerLink", warrior);
            }
            else if (e.ColumnIndex == ClashSpotLink.Index)
            {
                OpenLink("ClashSpotPlayerLink", warrior);
            }
        }

        private void OpenLink(string appSettingKey, Warrior warrior)
        {
            var url = _applicationManagement.GetApplicationSetting(appSettingKey);
            url = string.Format(url, warrior.Hash.Replace("#", ""));
            Process.Start(url);
        }
    }
}
