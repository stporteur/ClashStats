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
    public partial class WarriorSelectionForm : Form
    {
        public Warrior SelectedWarrior { get; private set; }
        private readonly List<Warrior> _warriors;

        public WarriorSelectionForm(List<Warrior> warriors)
        {
            InitializeComponent();
            _warriors = warriors;
        }

        private void WarriorSelectionForm_Load(object sender, EventArgs e)
        {
            warriorsComboBox.DataSource = _warriors;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedWarrior = warriorsComboBox.SelectedItem as Warrior;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedWarrior = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
