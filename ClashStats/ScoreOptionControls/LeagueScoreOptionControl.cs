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
        private LeagueScoreOptions _options;
        private IScoreOptionsManagement _optionsLoader;
        public LeagueScoreOptionControl()
        {
            InitializeComponent();
        }

        private void LeagueScoreOptionControl_Load(object sender, EventArgs e)
        {
            _optionsLoader = AutofacFactory.Instance.GetInstance<IScoreOptionsManagement>();
            leagueScoreOptionsBindingSource.DataSource = _options = _optionsLoader.LoadLeagueScoreOptions();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = _optionsLoader.SaveLeagueScoreOptions(_options);
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
            leagueScoreOptionsBindingSource.DataSource = _options = _optionsLoader.LoadLeagueScoreOptions();
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
