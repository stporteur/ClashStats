using ClashBusiness;
using ClashStats.LetsPlay;
using ClashStats.Organization;
using ClashStats.ScoreOptionControls;
using ClashStats.Simulation;
using System;
using System.Windows.Forms;

namespace ClashStats
{
    public partial class MainForm : Form
    {
        private const string FormName = "Clash Stats";

        public MainForm()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(var simulation = new SimulationMainForm())
            {
                simulation.ShowDialog();
            }
        }

        private void leagueOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContainerPanel(new LeagueScoreOptionControl(), "Options de calcul des ligues");
        }

        private void AddContainerPanel(UserControl userControl, string name)
        {
            CleanContainerPanel();
            containerPanel.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.AutoScroll = true;
            this.Text = $"{FormName} - {name}";
        }

        private void CleanContainerPanel()
        {
            if(containerPanel.Controls.Count > 0)
            {
                var userControl = containerPanel.Controls[0];
                containerPanel.Controls.Remove(userControl);
                userControl.Dispose();
            }
        }

        private void warriorOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContainerPanel(new WarriorScoreOptionControl(), "Options de calcul des guerriers");
        }

        private void clansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContainerPanel(new ClansControl(), "Gestion des clans");
        }

        private void warriorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContainerPanel(new WarriorsControl(), "Gestion des guerriers");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void startNewLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(var clanSelection = new ClanSelectionForm())
            {
                if(clanSelection.ShowDialog() == DialogResult.OK)
                {
                    AddContainerPanel(new StartLeagueControl(clanSelection.SelectedClan), "Enregistrer une nouvelle ligue");
                }
            }

        }

        private void latestLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var clanSelection = new ClanSelectionForm())
            {
                if (clanSelection.ShowDialog() == DialogResult.OK)
                {
                    AddContainerPanel(new CurrentLeagueControl(clanSelection.SelectedClan), "Mettre à jour la ligue en cours");
                }
            }
        }

        private void executeScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fileSelection = new SelectScriptForm())
            {
                if (fileSelection.ShowDialog() == DialogResult.OK)
                {
                    AutofacFactory.Instance.GetInstance<IApplicationManagement>().ExecuteScript(fileSelection.File);
                }
            }
        }
    }
}
