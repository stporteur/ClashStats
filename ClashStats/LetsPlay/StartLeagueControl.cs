using ClashBusiness;
using ClashEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClashStats.LetsPlay
{
    public partial class StartLeagueControl : UserControl
    {
        private readonly Clan _clan;

        public StartLeagueControl(Clan clan)
        {
            InitializeComponent();
            _clan = clan;
        }

        private void StartLeagueControl_Load(object sender, EventArgs e)
        {
            var clans = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans().OrderBy(x => x.Name).ToList();
            clans.ForEach(x => clansCheckedListBox.Items.Add(x, _clan.Id == x.Id));
            leagueDateDateTimePicker.Value = DateTime.Today;
        }

        private void btnLoadPlayers_Click(object sender, EventArgs e)
        {
            if (clansCheckedListBox.CheckedItems.Count > 0)
            {
                availableCheckedListBox.Items.Clear();
                var warriorManagement = AutofacFactory.Instance.GetInstance<IWarriorManagement>();
                var allWarriors = new List<Warrior>();
                foreach (var selectedClan in clansCheckedListBox.CheckedItems)
                {
                    var clan = selectedClan as Clan;
                    if (clan != null)
                    {
                        var warriors = warriorManagement.GetWarriors(clan.Id).OrderBy(x => x.Name).ToList();
                        warriors.ForEach(x => x.Clan = clan);
                        allWarriors.AddRange(warriors);
                    }
                }
                allWarriors.ForEach(x => availableCheckedListBox.Items.Add(x, false));
            }
            else
            {
                MessageBox.Show("Sélectionne au moins un clan petit malin :)", "Toujours aussi nul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (availableCheckedListBox.CheckedItems.Count > 0)
            {
                var alreadySelectedPlayers = new List<Warrior>();
                foreach (var selectedPlayer in selectedCheckedListBox.CheckedItems)
                {
                    var player = selectedPlayer as Warrior;
                    if (player != null)
                    {
                        alreadySelectedPlayers.Add(player);
                    }
                }

                var playersToMove = new List<Warrior>();
                foreach (var selectedPlayer in availableCheckedListBox.CheckedItems)
                {
                    var player = selectedPlayer as Warrior;
                    if (player != null)
                    {
                        playersToMove.Add(player);
                        if (alreadySelectedPlayers.All(x => x.Id == player.Id))
                        {
                            selectedCheckedListBox.Items.Add(player);
                        }
                    }
                }
                playersToMove.ForEach(x => availableCheckedListBox.Items.Remove(x));

                var nbRequiredPlayers = rbLeagueSize15.Checked ? 15 : 30;
                lblWarning.Visible = selectedCheckedListBox.Items.Count < nbRequiredPlayers;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedCheckedListBox.CheckedItems.Count > 0)
            {
                var playersToMove = new List<Warrior>();
                foreach (var selectedPlayer in selectedCheckedListBox.CheckedItems)
                {
                    var player = selectedPlayer as Warrior;
                    if (player != null)
                    {
                        playersToMove.Add(player);
                        availableCheckedListBox.Items.Add(player);
                    }
                }
                playersToMove.ForEach(x => selectedCheckedListBox.Items.Remove(x));

                var nbRequiredPlayers = rbLeagueSize15.Checked ? 15 : 30;
                lblWarning.Visible = selectedCheckedListBox.Items.Count < nbRequiredPlayers;
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if(lblWarning.Visible)
            {
                MessageBox.Show("Bien tenté mais tu n'as pas le nombre de joueurs requis :)", "Toujours aussi nul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var newLeague = new League();
                newLeague.Clan = _clan;
                newLeague.ClanId = _clan.Id;
                newLeague.LeagueDate = leagueDateDateTimePicker.Value;
                newLeague.LeagueSize = rbLeagueSize15.Checked ? 15 : 30;

                var players = new List<Warrior>();
                foreach (var selectedPlayer in selectedCheckedListBox.Items)
                {
                    var player = selectedPlayer as Warrior;
                    if (player != null)
                    {
                        players.Add(player);
                    }
                }
                newLeague.Players = players;

                var leagueManagement = AutofacFactory.Instance.GetInstance<ILeagueManagement>();
                if(leagueManagement.RegisterNewLeague(newLeague))
                {
                    MessageBox.Show("Sauvegarde réussie", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
