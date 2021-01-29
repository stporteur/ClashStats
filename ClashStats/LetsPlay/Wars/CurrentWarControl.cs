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
    public partial class CurrentWarControl : UserControl, IClashEventControl
    {
        public class WarriorSummary
        {
            public WarPlayer WarPlayer { get; set; }
            public int Position { get { return WarPlayer.Position; } set { WarPlayer.Position = value; } }
            public string WarriorName { get { return WarPlayer.Warrior.Name; } }
            public string Clan { get { return WarPlayer.Warrior.ClanName; } }
            public int FirstAttackStars { get { return WarPlayer.FirstAttack.Stars; } set { WarPlayer.FirstAttack.Stars = value; } }
            public bool FirstAttackDone { get { return WarPlayer.FirstAttack.AttackDone; } set { WarPlayer.FirstAttack.AttackDone = value; } }
            public int SecondAttackStars { get { return WarPlayer.SecondAttack.Stars; } set { WarPlayer.SecondAttack.Stars = value; } }
            public bool SecondAttackDone { get { return WarPlayer.SecondAttack.AttackDone; } set { WarPlayer.SecondAttack.AttackDone = value; } }
        }

        public event EventHandler<ClashEventArgs> GoToNextScreen;

        private IWarManagement _warManagement;
        private War _war;
        private Clan _clan;

        public CurrentWarControl(Clan clan)
        {
            InitializeComponent();
            _clan = clan;
        }

        private void CurrentWarControl_Load(object sender, EventArgs e)
        {
            clanBindingSource.DataSource = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans();
            _warManagement = AutofacFactory.Instance.GetInstance<IWarManagement>();
            SetupWar();
        }

        private void SetupWar()
        {
            _war = _warManagement.LoadCurrentWar(_clan.Id);
            if (_war == null)
            {
                GoToNextScreen(this, new ClashEventArgs("Aucune Guerre de Clan en cours. Veux-tu en démarrer une nouvelle ?", typeof(StartWarControl), _clan));
            }
            else
            {
                warBindingSource.DataSource = _war;
                warriorSummaryBindingSource.DataSource = _war.Players.Select(x => new WarriorSummary { WarPlayer = x });

                clanIdComboBox.SelectedValue = _war.ClanId;
            }
        }

        private void warriorSummaryBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            playersBindingSource.Position = warriorSummaryBindingSource.Position;
            playersBindingSource.ResetBindings(false);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_warManagement.UpdateWar(_war))
            {
                MessageBox.Show("Sauvegarde réussie", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupWar();
        }
    }
}
