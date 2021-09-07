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
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
        }

        public void LoadGame(Game game)
        {
            gameBindingSource.DataSource = game;
        }

        public void RefreshData()
        {
            gameBindingSource.ResetBindings(false);
        }
    }
}
