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

namespace ClashStats.Management
{
    public partial class ImportForm : Form
    {
        public string ImportType { get; private set; }
        public List<League> Leagues { get; private set; }
        public List<War> Wars { get; private set; }
        public List<Game> Games { get; private set; }

        public ImportForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
                if(txtFile.Text.Contains("League"))
                {
                    ImportType = "League";
                }
                else if (txtFile.Text.Contains("War"))
                {
                    ImportType = "War";
                }
                else if (txtFile.Text.Contains("Game"))
                {
                    ImportType = "Game";
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var _applicationManagement = AutofacFactory.Instance.GetInstance<IApplicationManagement>();

            if (ImportType == "League")
            {
                Leagues = _applicationManagement.ImportData<League>(txtFile.Text);
            }
            else if (ImportType == "War")
            {
                Wars = _applicationManagement.ImportData<War>(txtFile.Text);
            }
            else if (ImportType == "Game")
            {
                Games = _applicationManagement.ImportData<Game>(txtFile.Text);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
