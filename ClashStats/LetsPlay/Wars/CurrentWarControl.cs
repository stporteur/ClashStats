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
        private IEnumerable<WarriorSummary> _warriorSummaries;


        public CurrentWarControl(Clan clan)
        {
            InitializeComponent();
            _clan = clan;
        }

        private void CurrentWarControl_Load(object sender, EventArgs e)
        {
            clanBindingSource.DataSource = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans();
            _warManagement = AutofacFactory.Instance.GetInstance<IWarManagement>();

            var maxTh = int.Parse(AutofacFactory.Instance.GetInstance<IApplicationManagement>().GetApplicationSetting("TownHallMax"));
            firstAttackAttackedThLevelNumericUpDown.Minimum = 0;
            firstAttackAttackedThLevelNumericUpDown.Maximum = maxTh;
            firstAttackCurrentThLevelNumericUpDown.Minimum = 0;
            firstAttackCurrentThLevelNumericUpDown.Maximum = maxTh;
            secondAttackAttackedThLevelNumericUpDown.Minimum = 0;
            secondAttackAttackedThLevelNumericUpDown.Maximum = maxTh;
            secondAttackCurrentThLevelNumericUpDown.Minimum = 0;
            secondAttackCurrentThLevelNumericUpDown.Maximum = maxTh;
            dataGridViewNumericUpDownColumn1.Minimum = 0;
            dataGridViewNumericUpDownColumn1.Maximum = maxTh;

            SetupWar();
        }

        private void SetupWar()
        {
            this.currentWarControl_WarriorSummaryDataGridView.CellValueChanged -= new DataGridViewCellEventHandler(this.currentWarControl_WarriorSummaryDataGridView_CellValueChanged);

            _war = _warManagement.LoadCurrentWar(_clan.Id);
            if (_war == null)
            {
                GoToNextScreen(this, new ClashEventArgs("Aucune Guerre de Clan en cours. Veux-tu en démarrer une nouvelle ?", typeof(StartWarControl), _clan));
            }
            else
            {
                warBindingSource.DataSource = _war;
                _warriorSummaries = _war.Players.Select(x => new WarriorSummary { WarPlayer = x });
                warriorSummaryBindingSource.DataSource = _warriorSummaries;

                clanIdComboBox.SelectedValue = _war.ClanId;
            }
            this.currentWarControl_WarriorSummaryDataGridView.CellValueChanged += new DataGridViewCellEventHandler(this.currentWarControl_WarriorSummaryDataGridView_CellValueChanged);

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

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var grid = currentWarControl_WarriorSummaryDataGridView;
            if (grid.SelectedRows.Count == 1)
            {
                var playerIndex = grid.SelectedRows[0].Index;
                if (playerIndex > 0)
                {
                    var playerToMove = _war.Players[playerIndex];
                    playerToMove.Position--;
                    _war.Players.Remove(playerToMove);
                    _war.Players.Insert(playerIndex - 1, playerToMove);
                    _war.Players[playerIndex].Position++;
                    playersBindingSource.ResetBindings(false);
                    foreach (DataGridViewRow row in grid.SelectedRows)
                    {
                        row.Selected = false;
                    }
                    grid.Rows[playerIndex - 1].Selected = true;
                }
            }
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var grid = currentWarControl_WarriorSummaryDataGridView;
            if (grid.SelectedRows.Count == 1)
            {
                var playerIndex = grid.SelectedRows[0].Index;
                if (playerIndex > 0)
                {
                    var playerToMove = _war.Players[playerIndex];
                    playerToMove.Position++;
                    _war.Players.Remove(playerToMove);
                    _war.Players.Insert(playerIndex + 1, playerToMove);
                    _war.Players[playerIndex].Position--;
                    playersBindingSource.ResetBindings(false);
                    foreach (DataGridViewRow row in grid.SelectedRows)
                    {
                        row.Selected = false;
                    }
                    grid.Rows[playerIndex + 1].Selected = true;
                }
            }
        }

        private void currentWarControl_WarriorSummaryDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dataGridView = sender as DataGridView;
                WarAttack warAttack = null;
                if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == "FirstAttackStars")
                {
                    var summary = dataGridView.Rows[e.RowIndex].DataBoundItem as WarriorSummary;
                    warAttack = summary.WarPlayer.FirstAttack;
                }
                if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == "SecondAttackStars")
                {
                    var summary = dataGridView.Rows[e.RowIndex].DataBoundItem as WarriorSummary;
                    warAttack = summary.WarPlayer.SecondAttack;
                }

                if (warAttack != null)
                {
                    if (warAttack.AttackDone == false && warAttack.Stars > 0)
                    {
                        warAttack.AttackDone = true;
                        warAttack.HasFollowedStrategy = true;
                        warAttack.IsCoherentAttack = true;
                        if (warAttack.AttackedThLevel == 0)
                        {
                            warAttack.AttackedThLevel = warAttack.CurrentThLevel;
                        }
                    }

                    ResetTotalStars();

                }
            }
        }

        private void ResetTotalStars()
        {
            //if (_warriorSummaries != null)
            //{
            //    _war.OurStars = _warriorSummaries.Sum(x => x.FirstAttackStars + x.SecondAttackStars);
            //    warBindingSource.ResetBindings(false);
            //}
        }

        private void firstAttackStarsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ResetTotalStars();

        }

        private void secondAttackStarsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ResetTotalStars();

        }
    }
}
