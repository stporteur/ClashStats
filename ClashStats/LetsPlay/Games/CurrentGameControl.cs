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
    public partial class CurrentGameControl : UserControl, IClashEventControl
    {
        public event EventHandler<ClashEventArgs> GoToNextScreen;

        private IGameManagement _gameManagement;
        private readonly Clan _clan;
        private Game _game;

        public CurrentGameControl(Clan clan)
        {
            InitializeComponent();
            _clan = clan;
        }

        private void CurrentGameControl_Load(object sender, EventArgs e)
        {
            clanBindingSource.DataSource = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans();
            _gameManagement = AutofacFactory.Instance.GetInstance<IGameManagement>();

            _game = _gameManagement.LoadCurrentGames(_clan.Id);
            if (_game == null)
            {
                GoToNextScreen(this, new ClashEventArgs("Aucun Jeux de Clan en cours. Veux-tu en démarrer de nouveaux ?", typeof(StartGameControl), _clan));
            }
            else
            {
                gameBindingSource.DataSource = _game;
                clanIdComboBox.SelectedValue = _game.ClanId;
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            var unregisteredWarriors = _gameManagement.GetUnregisteredWarriors(_game.Players.Select(x => x.Warrior).ToList());
            using (var warriorSelectionForm = new WarriorSelectionForm(unregisteredWarriors))
            {
                var result = warriorSelectionForm.ShowDialog();
                if (result == DialogResult.Cancel) return;

                _game.Players.Add(new GameWarrior
                {
                    WarriorId = warriorSelectionForm.SelectedWarrior.Id,
                    Warrior = warriorSelectionForm.SelectedWarrior
                });
                gameWarriorBindingSource.ResetBindings(false);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gameManagement.UpdateGames(_game))
            {
                MessageBox.Show("Sauvegarde réussie", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameBindingSource.DataSource = _game = _gameManagement.LoadCurrentGames(_clan.Id);
        }


    }
}
