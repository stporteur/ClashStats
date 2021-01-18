using ClashBusiness;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashStats.LetsPlay
{
    public partial class ClanSelectionForm : Form
    {
        public Clan SelectedClan { get; private set; }

        public ClanSelectionForm()
        {
            InitializeComponent();
        }

        private void ClanSelectionForm_Load(object sender, EventArgs e)
        {
            clansComboBox.DataSource = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans().OrderBy(x => x.Name).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedClan = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedClan = clansComboBox.SelectedItem as Clan;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
