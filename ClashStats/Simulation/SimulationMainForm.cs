using ClashBusiness.Rewards;
using ClashBusiness.ScoreOptions;
using ClashData;
using ClashEntities;
using ClashEntities.Rewards;
using ClashEntities.ScoreOptions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClashStats.Simulation
{
    public partial class SimulationMainForm : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _rectangle;

        private League _leagueWar;
        private Clan _clan;
        private List<SimulationWarrior> _warriors;

        private LeagueScoreOptions _leagueOptions;
        private WarriorScoreOptions _warriorOptions;
        private IScoreOptionsManagement _scoreOptionsLoader;

        private List<IScoreRewardManagement> _scoreRewardManagements;

        private ILeagueDal _leagueWarDal;
        private IWarDal _clanWarDal;
        private IGameWarriorDal _gameWarriorDal;
        private IGameDal _gameDal;


        private RewardManagement _rewardManagement;

        public SimulationMainForm()
        {
            InitializeComponent();
            tabControlClash.TabPages.Remove(tabPageGames);
            tabControlClash.TabPages.Remove(tabPageWars);

            dataGridViewWarriors.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
        }

        private void SimulationMainForm_Load(object sender, EventArgs e)
        {
            InitializeClan();
            InitializeWarriors();
            InitializeLeague();
            InitializeLeagueOptions();
            InitializeWarriorOptions();

            _scoreOptionsLoader = Substitute.For<IScoreOptionsManagement>();
            _scoreOptionsLoader.LoadLeagueScoreOptions().Returns(_leagueOptions);
            _scoreOptionsLoader.LoadWarriorScoreOptions().Returns(_warriorOptions);

            _leagueWarDal = Substitute.For<ILeagueDal>();
            _clanWarDal = Substitute.For<IWarDal>();
            _gameWarriorDal = Substitute.For<IGameWarriorDal>();
            _gameDal = Substitute.For<IGameDal>();

            _scoreRewardManagements = new List<IScoreRewardManagement>
            {
                new LeagueRewardManagement(_scoreOptionsLoader),
                new WarriorRewardManagement(_scoreOptionsLoader, _leagueWarDal, _clanWarDal, _gameWarriorDal, _gameDal)
            };

            _rewardManagement = new RewardManagement(_scoreRewardManagements);
        }

        private void InitializeLeagueOptions()
        {
            _leagueOptions = new LeagueScoreOptions
            {
                FailedWarFaultPoints = 100,
                HigherTownHallAttackMinimumStars = 2,
                HigherTownHallAttackPoints = 50,
                IncoherentAttackPoints = 50,
                NoAttackDonePoints = 75,
                NotFollowedStrategyPoints = 25
            };
            leagueScoreOptionsBindingSource.DataSource = _leagueOptions;
        }

        private void InitializeWarriorOptions()
        {
            _warriorOptions = new WarriorScoreOptions
            {
                GameParticipationPoints = 100,
                LeagueParticipationPoints = 100,
                MinimumGamePoints = 100,
                MinimumGamePointsThreshold = 1000,
                WarParticipationPoints = 100,
                TownHallLevelPoints = new List<TownHallMaturityBonus>
                {
                    new TownHallMaturityBonus { TownHallLevel = 13, Maturity = TownHallLevelMaturities.Max, Bonus = 0},
                    new TownHallMaturityBonus { TownHallLevel = 13, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 30},
                    new TownHallMaturityBonus { TownHallLevel = 13, Maturity = TownHallLevelMaturities.Beginning, Bonus = 50},
                    new TownHallMaturityBonus { TownHallLevel = 13, Maturity = TownHallLevelMaturities.Premature, Bonus = 5},
                    new TownHallMaturityBonus { TownHallLevel = 12, Maturity = TownHallLevelMaturities.Max, Bonus = 10},
                    new TownHallMaturityBonus { TownHallLevel = 12, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 50},
                    new TownHallMaturityBonus { TownHallLevel = 12, Maturity = TownHallLevelMaturities.Beginning, Bonus = 70},
                    new TownHallMaturityBonus { TownHallLevel = 12, Maturity = TownHallLevelMaturities.Premature, Bonus = 5},
                    new TownHallMaturityBonus { TownHallLevel = 11, Maturity = TownHallLevelMaturities.Max, Bonus = 20},
                    new TownHallMaturityBonus { TownHallLevel = 11, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 40},
                    new TownHallMaturityBonus { TownHallLevel = 11, Maturity = TownHallLevelMaturities.Beginning, Bonus = 50},
                    new TownHallMaturityBonus { TownHallLevel = 11, Maturity = TownHallLevelMaturities.Premature, Bonus = 5},
                    new TownHallMaturityBonus { TownHallLevel = 10, Maturity = TownHallLevelMaturities.Max, Bonus = 30},
                    new TownHallMaturityBonus { TownHallLevel = 10, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 50},
                    new TownHallMaturityBonus { TownHallLevel = 10, Maturity = TownHallLevelMaturities.Beginning, Bonus = 75},
                    new TownHallMaturityBonus { TownHallLevel = 10, Maturity = TownHallLevelMaturities.Premature, Bonus = 5},
                    new TownHallMaturityBonus { TownHallLevel = 9, Maturity = TownHallLevelMaturities.Max, Bonus = 20},
                    new TownHallMaturityBonus { TownHallLevel = 9, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 50},
                    new TownHallMaturityBonus { TownHallLevel = 9, Maturity = TownHallLevelMaturities.Beginning, Bonus = 75},
                    new TownHallMaturityBonus { TownHallLevel = 9, Maturity = TownHallLevelMaturities.Premature, Bonus = 5},
                    new TownHallMaturityBonus { TownHallLevel = 8, Maturity = TownHallLevelMaturities.Max, Bonus = 10},
                    new TownHallMaturityBonus { TownHallLevel = 8, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 40},
                    new TownHallMaturityBonus { TownHallLevel = 8, Maturity = TownHallLevelMaturities.Beginning, Bonus = 50},
                    new TownHallMaturityBonus { TownHallLevel = 8, Maturity = TownHallLevelMaturities.Premature, Bonus = 5},
                    new TownHallMaturityBonus { TownHallLevel = 7, Maturity = TownHallLevelMaturities.Max, Bonus = 20},
                    new TownHallMaturityBonus { TownHallLevel = 7, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 75},
                    new TownHallMaturityBonus { TownHallLevel = 7, Maturity = TownHallLevelMaturities.Beginning, Bonus = 95},
                    new TownHallMaturityBonus { TownHallLevel = 7, Maturity = TownHallLevelMaturities.Premature, Bonus = 5},
                    new TownHallMaturityBonus { TownHallLevel = 6, Maturity = TownHallLevelMaturities.Max, Bonus = 40},
                    new TownHallMaturityBonus { TownHallLevel = 6, Maturity = TownHallLevelMaturities.Intermediate, Bonus = 75},
                    new TownHallMaturityBonus { TownHallLevel = 6, Maturity = TownHallLevelMaturities.Beginning, Bonus = 95},
                    new TownHallMaturityBonus { TownHallLevel = 6, Maturity = TownHallLevelMaturities.Premature, Bonus = 5},
                },
                SeniorityPoints = new List<SeniorityBonus>
                {
                    new SeniorityBonus { MinimumMonth = 0, MaximumMonth = 1, Bonus = 20 },
                    new SeniorityBonus { MinimumMonth = 2, MaximumMonth = 6, Bonus = 30 },
                    new SeniorityBonus { MinimumMonth = 6, MaximumMonth = 12, Bonus = 40 },
                    new SeniorityBonus { MinimumMonth = 12, MaximumMonth = 120, Bonus = 10 }
                }
            };
            warriorScoreOptionsBindingSource.DataSource = _warriorOptions;
        }

        private void InitializeClan()
        {
            _clan = new Clan { Id = 1, Name = "clash of adulte" };
        }

        private void InitializeWarriors()
        {
            _warriors = new List<SimulationWarrior>();

            _warriors.Add(GetWarrior("TH 13 Max", 13, TownHallLevelMaturities.Max, DateTime.Today.AddDays(-5)));
            _warriors.Add(GetWarrior("TH 13 Intermédiaire", 13, TownHallLevelMaturities.Intermediate, DateTime.Today.AddMonths(-5)));
            _warriors.Add(GetWarrior("TH 13 Nouveau", 13, TownHallLevelMaturities.Beginning, DateTime.Today.AddMonths(-48)));

            _warriors.Add(GetWarrior("TH 12 Max", 12, TownHallLevelMaturities.Max, DateTime.Today.AddMonths(-5)));
            _warriors.Add(GetWarrior("TH 12 Intermédiaire", 12, TownHallLevelMaturities.Intermediate, DateTime.Today.AddMonths(-1)));
            _warriors.Add(GetWarrior("TH 12 Nouveau", 12, TownHallLevelMaturities.Beginning, DateTime.Today.AddMonths(-5)));

            _warriors.Add(GetWarrior("TH 11 Max", 11, TownHallLevelMaturities.Max, DateTime.Today.AddMonths(-15)));
            _warriors.Add(GetWarrior("TH 11 Intermédiaire", 11, TownHallLevelMaturities.Intermediate, DateTime.Today.AddMonths(-48)));
            _warriors.Add(GetWarrior("TH 11 Nouveau", 11, TownHallLevelMaturities.Beginning, DateTime.Today.AddMonths(-48)));

            _warriors.Add(GetWarrior("TH 10 Max", 10, TownHallLevelMaturities.Max, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 10 Intermédiaire", 10, TownHallLevelMaturities.Intermediate, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 10 Nouveau", 10, TownHallLevelMaturities.Beginning, DateTime.Today.AddMonths(-32)));

            _warriors.Add(GetWarrior("TH 9 Max", 09, TownHallLevelMaturities.Max, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 9 Intermédiaire", 09, TownHallLevelMaturities.Intermediate, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 9 Nouveau", 09, TownHallLevelMaturities.Beginning, DateTime.Today.AddMonths(-32)));

            _warriors.Add(GetWarrior("TH 8 Max", 08, TownHallLevelMaturities.Max, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 8 Intermédiaire", 08, TownHallLevelMaturities.Intermediate, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 8 Nouveau", 08, TownHallLevelMaturities.Beginning, DateTime.Today.AddMonths(-32)));

            _warriors.Add(GetWarrior("TH 7 Max", 07, TownHallLevelMaturities.Max, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 7 Intermédiaire", 07, TownHallLevelMaturities.Intermediate, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 7 Nouveau", 07, TownHallLevelMaturities.Beginning, DateTime.Today.AddMonths(-32)));

            _warriors.Add(GetWarrior("TH 6 Max", 06, TownHallLevelMaturities.Max, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 6 Intermédiaire", 06, TownHallLevelMaturities.Intermediate, DateTime.Today.AddMonths(-32)));
            _warriors.Add(GetWarrior("TH 6 Préma", 06, TownHallLevelMaturities.Premature, DateTime.Today.AddMonths(-32)));

            warriorBindingSource.DataSource = _warriors;
        }

        private SimulationWarrior GetWarrior(string name, int thLevel, TownHallLevelMaturities thMaturity, DateTime arrivalDate)
        {
            var today = DateTime.Today;
            var warriorSeniorityInMonths = ((today.Year - arrivalDate.Year) * 12) + today.Month - arrivalDate.Month;

            return new SimulationWarrior
            {
                Id = _warriors.Count + 1,
                Name = name,
                TownHallLevel = thLevel,
                TownHallLevelMaturity = thMaturity,
                ArrivalDate = arrivalDate,
                TotalNumberOfLeagues = warriorSeniorityInMonths,
                TotalNumberOfGames = warriorSeniorityInMonths,
                TotalNumberOfWars = warriorSeniorityInMonths * 4 * 3,
                Clan = _clan,
                ClanId = _clan.Id
            };
        }

        private void InitializeLeague()
        {
            _leagueWar = new League();
            _leagueWar.Players = _warriors.Cast<Warrior>().ToList();

            _leagueWar.PlayersPerDay = new Dictionary<int, List<LeagueAttack>>();

            AddLeagueDay(1, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            dayOneBindingSource.DataSource = _leagueWar.PlayersPerDay[1];
            dayOneBindingSource.ResetBindings(false);
            ResetLeagueGridLayout(dayOneDataGridView);

            AddLeagueDay(2, new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 });
            dayTwoBindingSource.DataSource = _leagueWar.PlayersPerDay[2];
            dayTwoBindingSource.ResetBindings(false);
            ResetLeagueGridLayout(dayTwoDataGridView);

            AddLeagueDay(3, new List<int> { 0, 2, 4, 6, 8, 10, 12, 14, 16, 17, 18, 19, 20, 21, 22 });
            dayThreeBindingSource.DataSource = _leagueWar.PlayersPerDay[3];
            dayThreeBindingSource.ResetBindings(false);
            ResetLeagueGridLayout(dayThreeDataGridView);

            AddLeagueDay(4, new List<int> { 0, 1, 2, 3, 4, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23 });
            dayFourBindingSource.DataSource = _leagueWar.PlayersPerDay[4];
            dayFourBindingSource.ResetBindings(false);
            ResetLeagueGridLayout(dayFourDataGridView);

            AddLeagueDay(5, new List<int> { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 });
            dayFiveBindingSource.DataSource = _leagueWar.PlayersPerDay[5];
            dayFiveBindingSource.ResetBindings(false);
            ResetLeagueGridLayout(dayFiveDataGridView);

            AddLeagueDay(6, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            daySixBindingSource.DataSource = _leagueWar.PlayersPerDay[6];
            daySixBindingSource.ResetBindings(false);
            ResetLeagueGridLayout(daySixDataGridView);

            AddLeagueDay(7, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            daySevenBindingSource.DataSource = _leagueWar.PlayersPerDay[7];
            daySevenBindingSource.ResetBindings(false);
            ResetLeagueGridLayout(daySevenDataGridView);
        }

        private void AddLeagueDay(int day, List<int> players)
        {
            _leagueWar.PlayersPerDay.Add(day, new List<LeagueAttack>());
            foreach (var playerIndex in players)
            {
                AddPlayerToDay(_leagueWar.PlayersPerDay[day], _warriors[playerIndex], 2, _warriors[playerIndex].TownHallLevel, true, true, true);
            }
        }

        private void AddPlayerToDay(List<LeagueAttack> leagueDay, Warrior warrior, int stars, int attackedThLevel, bool attackDone,
            bool hasFollowedStrategy, bool isCoherentAttack)
        {
            var dayPlayer = new LeagueAttack();
            dayPlayer.Warrior = warrior;
            dayPlayer.WarriorId = warrior.Id;
            dayPlayer.Position = leagueDay.Count + 1;
            dayPlayer.AttackDone = attackDone;
            dayPlayer.AttackedThLevel = attackedThLevel;
            dayPlayer.CurrentThLevel = warrior.TownHallLevel;
            dayPlayer.HasFollowedStrategy = hasFollowedStrategy;
            dayPlayer.IsCoherentAttack = isCoherentAttack;
            dayPlayer.LeagueId = _leagueWar.Id;
            dayPlayer.Stars = stars;

            leagueDay.Add(dayPlayer);
        }

        private void SetLeagueStars(int day, List<int> stars)
        {
            for(int i=0; i < 15; i++)
            {
                _leagueWar.PlayersPerDay[day][i].Stars = stars[i]; 
            }
        }

        private void ResetLeagueGridLayout(DataGridView dgv)
        {
            var dgvColumns = new List<DataGridViewColumn>();

            DataGridViewColumn column;

            foreach (var col in dgv.Columns)
            {
                column = col as DataGridViewColumn;
                column.Visible = false;
                column.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                dgvColumns.Add(col as DataGridViewColumn);
            }


            column = dgvColumns.Single(c => c.DataPropertyName == "Position");
            column.Visible = true;
            column.DisplayIndex = 0;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            column = dgvColumns.Single(c => c.DataPropertyName == "PlayerName");
            column.Visible = true;
            column.DisplayIndex = 1;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            column = dgvColumns.Single(c => c.DataPropertyName == "AttackDone");
            column.Visible = true;
            column.DisplayIndex = 2;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            column = dgvColumns.Single(c => c.DataPropertyName == "Stars");
            column.Visible = true;
            column.DisplayIndex = 3;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            column = dgvColumns.Single(c => c.DataPropertyName == "AttackedThLevel");
            column.Visible = true;
            column.DisplayIndex = 4;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            column = dgvColumns.Single(c => c.DataPropertyName == "IsCoherentAttack");
            column.Visible = true;
            column.DisplayIndex = 5;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            column = dgvColumns.Single(c => c.DataPropertyName == "HasFollowedStrategy");
            column.Visible = true;
            column.DisplayIndex = 6;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            column = dgvColumns.Single(c => c.DataPropertyName == "FailedWarFault");
            column.Visible = true;
            column.DisplayIndex = 7;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void ComputeLeagueRewards()
        {
            rewardBindingSource.DataSource = _rewardManagement.GetRankSuggestion(_leagueWar);
            rewardBindingSource.ResetBindings(false);
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            ResetSubstitions();
            ComputeLeagueRewards();
        }

        private void ResetSubstitions()
        {
            foreach (var warrior in _warriors)
            {
                _leagueWarDal.GetLeaguesCount(warrior.ArrivalDate).Returns(warrior.TotalNumberOfLeagues);
                _leagueWarDal.GetLeaguesCount(warrior.Id).Returns(warrior.ParticipateToLeagues);

                _clanWarDal.GetWarsCount(warrior.ArrivalDate).Returns(warrior.TotalNumberOfWars);
                _clanWarDal.GetWarsCount(warrior.Id).Returns(warrior.ParticipateToWars);

                _gameDal.GetGamesCount(warrior.ArrivalDate).Returns(warrior.TotalNumberOfGames);
                var games = GenerateGamesForWarrior(warrior);
                _gameWarriorDal.GetGames(warrior.Id).Returns(games);
            }
        }

        private List<GameWarrior> GenerateGamesForWarrior(SimulationWarrior warrior)
        {
            var games = new List<GameWarrior>();

            var nbSucceedeed = 0;
            for (int i = 0; i < warrior.ParticipateToGames; i++, nbSucceedeed++)
            {
                var gameWarrior = new GameWarrior
                {
                    Warrior = warrior,
                    Score = nbSucceedeed < warrior.SucceedeedGames ? 4000 : 0
                };
            }

            return games;
        }

        private void btnHdvLevel_Click(object sender, EventArgs e)
        {
            using (var form = new TownhallLevelParameters(_warriorOptions.TownHallLevelPoints))
            {
                form.ShowDialog();
            }
        }

        private void btnSeniority_Click(object sender, EventArgs e)
        {
            using (var form = new SeniorityParameters(_warriorOptions.SeniorityPoints))
            {
                form.ShowDialog();
            }
        }

        private void dataGridViewWarriors_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == arrivalDateDataGridViewTextBoxColumn.Index)
            {
                var warriorData = dataGridViewWarriors.Rows[e.RowIndex].DataBoundItem as SimulationWarrior;
                if (warriorData != null)
                {
                    var today = DateTime.Today;
                    var warriorSeniorityInMonths = ((today.Year - warriorData.ArrivalDate.Year) * 12) + today.Month - warriorData.ArrivalDate.Month;

                    warriorData.TotalNumberOfLeagues = warriorSeniorityInMonths;
                    if (warriorData.ParticipateToLeagues > warriorData.TotalNumberOfLeagues)
                    {
                        warriorData.ParticipateToLeagues = warriorData.TotalNumberOfLeagues;
                    }

                    warriorData.TotalNumberOfGames = warriorSeniorityInMonths;
                    if (warriorData.ParticipateToGames > warriorData.TotalNumberOfGames)
                    {
                        warriorData.ParticipateToGames = warriorData.TotalNumberOfGames;
                    }

                    warriorData.TotalNumberOfWars = warriorSeniorityInMonths * 4 * 3;
                    if (warriorData.ParticipateToWars > warriorData.TotalNumberOfWars)
                    {
                        warriorData.ParticipateToWars = warriorData.TotalNumberOfWars;
                    }
                    dataGridViewWarriors.Refresh();
                }
            }

            if (e.ColumnIndex == ParticipateToLeagues.Index)
            {
                var warriorData = dataGridViewWarriors.Rows[e.RowIndex].DataBoundItem as SimulationWarrior;
                if (warriorData != null)
                {
                    if (warriorData.ParticipateToLeagues > warriorData.TotalNumberOfLeagues)
                    {
                        MessageBox.Show("Un guerrier ne peut pas participer à plus de ligues que le total de celles-ci", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        warriorData.ParticipateToLeagues = warriorData.TotalNumberOfLeagues;
                        dataGridViewWarriors.Refresh();
                    }
                }
            }

            if (e.ColumnIndex == ParticipateToWars.Index)
            {
                var warriorData = dataGridViewWarriors.Rows[e.RowIndex].DataBoundItem as SimulationWarrior;
                if (warriorData != null)
                {
                    if (warriorData.ParticipateToWars > warriorData.TotalNumberOfWars)
                    {
                        MessageBox.Show("Un guerrier ne peut pas participer à plus de GDC que le total de celles-ci", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        warriorData.ParticipateToWars = warriorData.TotalNumberOfWars;
                        dataGridViewWarriors.Refresh();
                    }
                }
            }

            if (e.ColumnIndex == ParticipateToGames.Index)
            {
                var warriorData = dataGridViewWarriors.Rows[e.RowIndex].DataBoundItem as SimulationWarrior;
                if (warriorData != null)
                {
                    if (warriorData.ParticipateToGames > warriorData.TotalNumberOfGames)
                    {
                        MessageBox.Show("Un guerrier ne peut pas participer à plus de Jeux que le total de ceux-ci", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        warriorData.ParticipateToGames = warriorData.TotalNumberOfGames;
                        dataGridViewWarriors.Refresh();
                    }
                }
            }

            if (e.ColumnIndex == SucceedeedGames.Index)
            {
                var warriorData = dataGridViewWarriors.Rows[e.RowIndex].DataBoundItem as SimulationWarrior;
                if (warriorData != null)
                {
                    if (warriorData.SucceedeedGames > warriorData.TotalNumberOfGames)
                    {
                        MessageBox.Show("Un guerrier ne peut pas réussir plus de Jeux que le total de ceux-ci", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        warriorData.SucceedeedGames = warriorData.TotalNumberOfGames;
                        dataGridViewWarriors.Refresh();
                    }
                }
            }
        }

        private void dataGridViewWarriors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == arrivalDateDataGridViewTextBoxColumn.Index)
            {
                dtp.Visible = false;
                _rectangle = dataGridViewWarriors.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                dtp.Size = new Size(_rectangle.Width, _rectangle.Height); //  
                dtp.Location = new Point(_rectangle.X, _rectangle.Y);
                var warriorData = dataGridViewWarriors.Rows[e.RowIndex].DataBoundItem as SimulationWarrior;
                dtp.Value = warriorData.ArrivalDate;
                dtp.Visible = true;
            }
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            var warriorData = dataGridViewWarriors.Rows[dataGridViewWarriors.CurrentCell.OwningRow.Index].DataBoundItem as SimulationWarrior;
            warriorData.ArrivalDate = dtp.Value;
            dataGridViewWarriors.Refresh();
        }

        private void dataGridViewWarriors_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dataGridViewWarriors_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void rewardDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DetailsColumn.Index)
            {
                var rewardData = rewardDataGridView.Rows[e.RowIndex].DataBoundItem as Reward;
                var details = new ScoreDetails(rewardData);
                details.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (var form = new HelpForm())
            {
                form.LoadHelp("Simulation/SimulationHelp.rtf");
                form.ShowDialog();
            }
        }
    }
}
