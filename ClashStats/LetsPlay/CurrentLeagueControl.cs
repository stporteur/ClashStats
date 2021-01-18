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

namespace ClashStats.LetsPlay
{
    public partial class CurrentLeagueControl : UserControl
    {
        private ILeagueManagement _leagueManagement;
        private readonly Clan _clan;
        private League _league;
        private List<Warrior> _availablePlayers;
        private readonly Dictionary<int, BindingSource> _bindingsByDay;
        private Dictionary<int, DataGridView> _gridsByDay;

        public CurrentLeagueControl(Clan clan)
        {
            InitializeComponent();
            _clan = clan;
            _bindingsByDay = new Dictionary<int, BindingSource>
            {
                {1, playersDay1BindingSource },
                {2, playersDay2BindingSource },
                {3, playersDay3BindingSource },
                {4, playersDay4BindingSource },
                {5, playersDay5BindingSource },
                {6, playersDay6BindingSource },
                {7, playersDay7BindingSource }
            };

            InitGrids();
            InitPlayerMenus();
        }

        private void InitPlayerMenus()
        {
            upPlayerDay1ToolStripMenuItem.Click += upPlayerDayToolStripMenuItem_Click;
            upPlayerDay2ToolStripMenuItem.Click += upPlayerDayToolStripMenuItem_Click;
            upPlayerDay3ToolStripMenuItem.Click += upPlayerDayToolStripMenuItem_Click;
            upPlayerDay4ToolStripMenuItem.Click += upPlayerDayToolStripMenuItem_Click;
            upPlayerDay5ToolStripMenuItem.Click += upPlayerDayToolStripMenuItem_Click;
            upPlayerDay6ToolStripMenuItem.Click += upPlayerDayToolStripMenuItem_Click;
            upPlayerDay7ToolStripMenuItem.Click += upPlayerDayToolStripMenuItem_Click;

            downPlayerDay1ToolStripMenuItem.Click += downPlayerDayToolStripMenuItem_Click;
            downPlayerDay2ToolStripMenuItem.Click += downPlayerDayToolStripMenuItem_Click;
            downPlayerDay3ToolStripMenuItem.Click += downPlayerDayToolStripMenuItem_Click;
            downPlayerDay4ToolStripMenuItem.Click += downPlayerDayToolStripMenuItem_Click;
            downPlayerDay5ToolStripMenuItem.Click += downPlayerDayToolStripMenuItem_Click;
            downPlayerDay6ToolStripMenuItem.Click += downPlayerDayToolStripMenuItem_Click;
            downPlayerDay7ToolStripMenuItem.Click += downPlayerDayToolStripMenuItem_Click;

        }

        private void InitGrids()
        {
            _gridsByDay = new Dictionary<int, DataGridView>
            {
                {1, day1DataGridView },
                {2, day2DataGridView },
                {3, day3DataGridView },
                {4, day4DataGridView },
                {5, day5DataGridView },
                {6, day6DataGridView },
                {7, day7DataGridView }
            };

            foreach(var grid in _gridsByDay.Values)
            {
                grid.CellEndEdit += dataGridView_CellEndEdit;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void CurrentLeagueControl_Load(object sender, EventArgs e)
        {
            clanBindingSource.DataSource = AutofacFactory.Instance.GetInstance<IClanManagement>().GetClans();
            _leagueManagement = AutofacFactory.Instance.GetInstance<ILeagueManagement>();
            SetupLeague();
        }

        private void SetupLeague()
        {
            leagueBindingSource.DataSource = _league = _leagueManagement.LoadCurrentLeague(_clan.Id);
            clanIdComboBox.SelectedValue = _league.ClanId;

            FillAvailablePlayerList(1);
            for (int i = 1; i <= 7; i++)
            {
                FillDayPlayers(i);
            }
        }

        private void FillAvailablePlayerList(int day)
        {
            var assignedPlayers = _league.PlayersPerDay[day].Select(x => x.WarriorId).ToList();
            playersBindingSource.DataSource = _availablePlayers = _league.Players.Where(x => !assignedPlayers.Contains(x.Id)).ToList();
        }

        private void FillDayPlayers(int day)
        {
            _bindingsByDay[day].DataSource = _league.PlayersPerDay[day];
            _bindingsByDay[day].ResetBindings(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPlayerToDay(playersTabControl.SelectedIndex + 1);
        }

        private void AddPlayerToDay(int day)
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                var warrior = playersDataGridView.SelectedRows[0].DataBoundItem as Warrior;

                if(_league.PlayersPerDay[day].Count() == _league.LeagueSize)
                {
                    var warriors = _league.PlayersPerDay[day].Select(x => x.Warrior).ToList();
                    using (var warriorSelectionForm = new WarriorSelectionForm(warriors))
                    {
                        var result = warriorSelectionForm.ShowDialog();
                        if (result == DialogResult.Cancel) return;

                        var warriorAttack = _league.PlayersPerDay[day].Single(x => x.WarriorId == warriorSelectionForm.SelectedWarrior.Id);
                        _league.PlayersPerDay[day].Remove(warriorAttack);
                    }
                }

                _league.PlayersPerDay[day].Add(new LeagueAttack
                {
                    WarriorId = warrior.Id,
                    Warrior = warrior,
                    Day = day,
                    CurrentThLevel = warrior.TownHallLevel,
                    Position = _league.PlayersPerDay[day].Count + 1
                });
                _availablePlayers.Remove(warrior);

                playersBindingSource.ResetBindings(false);
                _bindingsByDay[day].ResetBindings(false);
            }
        }

        private void playersTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAvailablePlayerList(playersTabControl.SelectedIndex + 1);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_leagueManagement.UpdateLeague(_league))
            {
                MessageBox.Show("Sauvegarde réussie", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupLeague();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if(dataGridView.Columns[e.ColumnIndex].DataPropertyName == "Stars")
            {
                var attack = dataGridView.Rows[e.RowIndex].DataBoundItem as LeagueAttack;
                if(attack.AttackDone == false && attack.Stars > 0)
                {
                    attack.AttackDone = true;
                }
            }
        }

        private void upPlayerDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var day = playersTabControl.SelectedIndex + 1;

            if (_gridsByDay[day].SelectedRows.Count == 1)
            {
                var playerIndex = _gridsByDay[day].SelectedRows[0].Index;
                if (playerIndex > 0)
                {
                    var attackToMove = _league.PlayersPerDay[day][playerIndex];
                    _league.PlayersPerDay[day].RemoveAt(playerIndex);
                    _league.PlayersPerDay[day].Insert(playerIndex - 1, attackToMove);
                    _bindingsByDay[day].ResetBindings(false);
                }
            }
        }

        private void downPlayerDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var day = playersTabControl.SelectedIndex + 1;

            if (_gridsByDay[day].SelectedRows.Count == 1)
            {
                var playerIndex = _gridsByDay[day].SelectedRows[0].Index;
                if (playerIndex < _league.LeagueSize - 1)
                {
                    var attackToMove = _league.PlayersPerDay[day][playerIndex];
                    _league.PlayersPerDay[day].RemoveAt(playerIndex);
                    _league.PlayersPerDay[day].Insert(playerIndex + 1, attackToMove);
                    _bindingsByDay[day].ResetBindings(false);
                }
            }
        }
    }
}
