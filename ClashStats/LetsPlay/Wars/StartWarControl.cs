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

namespace ClashStats.LetsPlay.Wars
{
    public partial class StartWarControl : UserControl, IClashEventControl
    {
        private readonly Clan _clan;

        public event EventHandler<ClashEventArgs> GoToNextScreen;

        public StartWarControl(Clan clan)
        {
            InitializeComponent();
            _clan = clan;
        }

        private void StartWarControl_Load(object sender, EventArgs e)
        {
            var clans = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans().OrderBy(x => x.Name).ToList();
            clans.ForEach(x => clansCheckedListBox.Items.Add(x, _clan.Id == x.Id));
            warDateDateTimePicker.Value = DateTime.Today;
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

                CheckPlayersCount();
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

                CheckPlayersCount();
            }
        }

        private void CheckPlayersCount()
        {
            int nbRequiredPlayers = GetWarSize();
            lblWarning.Visible = selectedCheckedListBox.Items.Count != nbRequiredPlayers;
        }

        private int GetWarSize()
        {
            return  rbLeagueSize5.Checked ? 5 :
                    rbLeagueSize10.Checked ? 10 : rbLeagueSize15.Checked ? 15 :
                    rbLeagueSize20.Checked ? 20 : rbLeagueSize25.Checked ? 25 :
                    rbLeagueSize30.Checked ? 30 : rbLeagueSize35.Checked ? 35 :
                    rbLeagueSize40.Checked ? 40 : 50;
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (lblWarning.Visible)
            {
                MessageBox.Show("Bien tenté mais tu n'as pas le nombre de joueurs requis :)", "Toujours aussi nul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var newWar = new War();
                newWar.Clan = _clan;
                newWar.ClanId = _clan.Id;
                newWar.WarDate = warDateDateTimePicker.Value;
                newWar.WarSize = GetWarSize();

                var players = new List<WarPlayer>();
                foreach (var selectedPlayer in selectedCheckedListBox.Items)
                {
                    var player = selectedPlayer as Warrior;
                    if (player != null)
                    {
                        players.Add(new WarPlayer { WarriorId = player.Id, Position = players.Count + 1 });
                    }
                }
                newWar.Players = players;

                var warManagement = AutofacFactory.Instance.GetInstance<IWarManagement>();
                if (warManagement.RegisterNewWar(newWar))
                {
                    MessageBox.Show("Sauvegarde réussie", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GoToNextScreen(this, new ClashEventArgs("Guerre démarrée. Veux-tu l'ouvrir ?", typeof(CurrentWarControl), _clan));
                }
            }
        }
    }
}
