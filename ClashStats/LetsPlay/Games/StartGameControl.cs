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

namespace ClashStats.LetsPlay.Games
{
    public partial class StartGameControl : UserControl, IClashEventControl
    {
        private readonly Clan _clan;

        public event EventHandler<ClashEventArgs> GoToNextScreen;

        public StartGameControl(Clan clan)
        {
            InitializeComponent();
            _clan = clan;
        }

        private void StartGameControl_Load(object sender, EventArgs e)
        {
            var clans = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans().OrderBy(x => x.Name).ToList();
            clans.ForEach(x => clansCheckedListBox.Items.Add(x, _clan.Id == x.Id));
            gamesDateDateTimePicker.Value = DateTime.Today;
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
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var game = new Game();
            game.Clan = _clan;
            game.ClanId = _clan.Id;
            game.GamesDate = gamesDateDateTimePicker.Value;

            var players = new List<GameWarrior>();
            foreach (var selectedPlayer in selectedCheckedListBox.Items)
            {
                var player = selectedPlayer as Warrior;
                if (player != null)
                {
                    players.Add(new GameWarrior { WarriorId = player.Id });
                }
            }
            game.Players = players;

            var gamesManagement = AutofacFactory.Instance.GetInstance<IGameManagement>();
            if (gamesManagement.RegisterNewGames(game))
            {
                MessageBox.Show("Sauvegarde réussie", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GoToNextScreen(this, new ClashEventArgs("Jeux de Clan démarrés. Veux-tu les ouvrir ?", typeof(CurrentGameControl), _clan));
            }
        }
    }
}
