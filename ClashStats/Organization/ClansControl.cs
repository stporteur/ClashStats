using ClashBusiness;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClashStats.Organization
{
    public partial class ClansControl : UserControl
    {
        private IClanManagement _clanManagement;
        private List<Clan> _deletedClans;

        public ClansControl()
        {
            InitializeComponent();
            _clanManagement = AutofacFactory.Instance.GetInstance<IClanManagement>();
            _deletedClans = new List<Clan>();
        }

        private void ClansControl_Load(object sender, EventArgs e)
        {
            clanBindingSource.DataSource = _clanManagement.GetClans();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clanDataGridView.EndEdit();
            var clans = clanBindingSource.DataSource as List<Clan>;
            bool result = _clanManagement.SaveClans(clans.Where(x => !string.IsNullOrEmpty(x.Name)).ToList());
            if (_deletedClans.Count > 0)
            {
                result &= _clanManagement.DeleteClans(_deletedClans);
            }

            if(result)
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
            _deletedClans = new List<Clan>();
            clanBindingSource.DataSource = _clanManagement.GetClans();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clan = clanDataGridView.CurrentRow.DataBoundItem as Clan;
            if (clan != null)
            {
                if (clan.Id > 0)
                {
                    _deletedClans.Add(clan);
                }
                clanBindingSource.Remove(clan);
            }
        }
    }
}
