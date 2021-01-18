using ClashBusiness;
using ClashBusiness.ScoreOptions;
using ClashEntities.ScoreOptions;
using ClashStats.Simulation;
using System;
using System.Windows.Forms;

namespace ClashStats.ScoreOptionControls
{
    public partial class LeagueScoreOptionControl : UserControl
    {
        private IScoreOptionsManagement _optionsLoader;
        public LeagueScoreOptionControl()
        {
            InitializeComponent();
            _optionsLoader = AutofacFactory.Instance.GetInstance<IScoreOptionsManagement>();
        }

        private void LeagueScoreOptionControl_Load(object sender, EventArgs e)
        {
            leagueScoreOptionsBindingSource.DataSource = _optionsLoader.LoadLeagueScoreOptions();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var options = leagueScoreOptionsBindingSource.DataSource as LeagueScoreOptions;
            var result = _optionsLoader.SaveLeagueScoreOptions(options);
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
            leagueScoreOptionsBindingSource.DataSource = _optionsLoader.LoadLeagueScoreOptions();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new HelpForm())
            {
                form.LoadHelp("ScoreOptionControls/ScoreHelp.rtf");
                form.ShowDialog();
            }
        }
    }
}
