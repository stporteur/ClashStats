using ClashBusiness;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashStats.Management
{
    public partial class ExportForm : Form
    {
        public class ExportItem
        {
            public int Id { get; set; }
            public DateTime DateToExport { get; set; }

            public override string ToString()
            {
                return DateToExport.ToShortDateString();
            }
        }

        private IWarManagement _warManagement;
        private IGameManagement _gameManagement;
        private ILeagueManagement _leagueManagement;
        private IApplicationManagement _applicationManagement;

        private List<War> _clanWars;
        private List<Game> _clanGames;
        private List<League> _clanLeagues;

        public ExportForm()
        {
            InitializeComponent();
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            _warManagement = AutofacFactory.Instance.GetInstance<IWarManagement>();
            _gameManagement = AutofacFactory.Instance.GetInstance<IGameManagement>();
            _leagueManagement = AutofacFactory.Instance.GetInstance<ILeagueManagement>();
            _applicationManagement = AutofacFactory.Instance.GetInstance<IApplicationManagement>();
            clanBindingSource.DataSource = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans();
            clanBindingSource.ResetBindings(false);
        }

        private void rbTypes_CheckedChanged(object sender, EventArgs e)
        {
            LoadDates();
        }

        private void clanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDates();
        }

        private void LoadDates()
        {
            if (clanComboBox.SelectedItem == null) return;

            var clanId = ((Clan)clanComboBox.SelectedItem).Id;
            if (rbGames.Checked)
            {
                LoadGameDates(clanId);
            }
            else if (rbWars.Checked)
            {
                LoadWarDates(clanId);
            }
            else if (rbLeagues.Checked)
            {
                LoadLeagueDates(clanId);
            }
        }

        private void LoadWarDates(int clanId)
        {
            _clanWars = _warManagement.GetClanWars(clanId);
            var exportItems = _clanWars.Select(x=> new ExportItem { Id = x.Id, DateToExport = x.WarDate }).ToList();
            FillCheckedListBox(exportItems);
        }

        private void LoadLeagueDates(int clanId)
        {
            _clanLeagues = _leagueManagement.GetClanLeagues(clanId);
            var exportItems = _clanLeagues.Select(x => new ExportItem { Id = x.Id, DateToExport = x.LeagueDate }).ToList();
            FillCheckedListBox(exportItems);
        }

        private void LoadGameDates(int clanId)
        {
            _clanGames = _gameManagement.GetGamesOfClan(clanId);
            var exportItems = _clanGames.Select(x => new ExportItem { Id = x.Id, DateToExport = x.GamesDate }).ToList();
            FillCheckedListBox(exportItems);
        }

        private void FillCheckedListBox(List<ExportItem> items)
        {
            datesToExportCheckedListBox.Items.Clear();
            items.OrderByDescending(x => x.DateToExport).ToList().ForEach(x => datesToExportCheckedListBox.Items.Add(x));
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var idsToExport = new List<int>();
            foreach (var selectedDate in datesToExportCheckedListBox.CheckedItems)
            {
                var exportItem = selectedDate as ExportItem;
                if (exportItem != null)
                {
                    idsToExport.Add(exportItem.Id);
                }
            }

            bool exportResult = false;
            if (rbGames.Checked)
            {
                List<Game> games = _gameManagement.LoadGames(idsToExport);
                exportResult = _applicationManagement.ExportData(games, folderTextBox.Text);
            }
            else if (rbWars.Checked)
            {
                List<War> wars = _warManagement.LoadWars(idsToExport);
                exportResult = _applicationManagement.ExportData(wars, folderTextBox.Text);
            }
            else if (rbLeagues.Checked)
            {
                List<League> leagues = _leagueManagement.LoadLeagues(idsToExport);
                exportResult = _applicationManagement.ExportData(leagues, folderTextBox.Text);
            }

            if (exportResult)
            {
                if(MessageBox.Show("L'export des données est terminée. Veux-tu ouvrir le dossier d'export ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start(folderTextBox.Text);
                }
            }
            else
            {
                MessageBox.Show("Un truc ne s'est pas bien passé lors de l'export", "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
