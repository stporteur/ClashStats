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
    public partial class GameMergeControl : UserControl
    {
        private IGameManagement _gameManagement;
        private IMergeManagement _mergeManagement;
        private Game _importedGame;
        private Game _databaseGame;
        public GameMergeControl()
        {
            InitializeComponent();
        }

        private void gameViewDatabase_Load(object sender, EventArgs e)
        {
            _gameManagement = AutofacFactory.Instance.GetInstance<IGameManagement>();
            _mergeManagement = AutofacFactory.Instance.GetInstance<IMergeManagement>();
        }

        public void LoadGame(Game game)
        {
            game.Id = 0;
            _importedGame = game;
            gameViewImport.LoadGame(_importedGame);
            LoadDatabaseGame();
        }

        private void LoadDatabaseGame()
        {
            _databaseGame = _gameManagement.LoadClanGame(_importedGame.Clan.Hash, _importedGame.GamesDate);
            if (_databaseGame != null)
            {
                gameViewDatabase.LoadGame(_databaseGame);
                gameViewDatabase.RefreshData();
            }
            else
            {
                btnMerge.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadDatabaseGame();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            _mergeManagement.MergeGames(_importedGame, _databaseGame);
            gameViewDatabase.RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(btnMerge.Enabled)
            {
                _gameManagement.SaveImportedGame(_databaseGame);
            }
            else
            {
                _gameManagement.SaveImportedGame(_importedGame);
            }
        }
    }
}
