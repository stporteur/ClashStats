using ClashBusiness.Rewards;
using ClashEntities;
using ClashEntities.ScoreOptions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClashStats
{
    public partial class SimulationMainForm : Form
    {
        private LeagueWar _leagueWar;
        private Clan _clan;
        private List<Warrior> _warriors;
        private LeagueScoreOptions _leagueOptions;
        private LeagueRewardManagement _leagueRewardManagement;

        public SimulationMainForm()
        {
            InitializeComponent();
            tabControlClash.TabPages.Remove(tabPageGames);
            tabControlClash.TabPages.Remove(tabPageWars);
        }

        private void SimulationMainForm_Load(object sender, EventArgs e)
        {
            _leagueRewardManagement = new LeagueRewardManagement();

            InitializeClan();
            InitializeWarriors();
            InitializeLeague();
            InitializeLeagueOptions();
        }

        private void InitializeLeagueOptions()
        {
            _leagueOptions = new LeagueScoreOptions();
            leagueScoreOptionsBindingSource.DataSource = _leagueOptions;
        }

        private void InitializeClan()
        {
            _clan = new Clan { Id = 1, Name = "clash of adulte" };
        }

        private void InitializeWarriors()
        {
            _warriors = new List<Warrior>();
            
            _warriors.Add(GetWarrior("TH13 Max", 13));
            _warriors.Add(GetWarrior("TH13 Intermediate", 13));
            _warriors.Add(GetWarrior("TH13 Beginner", 13));
            
            _warriors.Add(GetWarrior("TH12 Max", 12));
            _warriors.Add(GetWarrior("TH12 Intermediate", 12));
            _warriors.Add(GetWarrior("TH12 Beginner", 12));
            
            _warriors.Add(GetWarrior("TH11 Max", 11));
            _warriors.Add(GetWarrior("TH11 Intermediate", 11));
            _warriors.Add(GetWarrior("TH11 Beginner", 11));
            
            _warriors.Add(GetWarrior("TH10 Max", 10));
            _warriors.Add(GetWarrior("TH10 Intermediate", 10));
            _warriors.Add(GetWarrior("TH10 Beginner", 10));
            
            _warriors.Add(GetWarrior("TH09 Max", 09));
            _warriors.Add(GetWarrior("TH09 Intermediate", 09));
            _warriors.Add(GetWarrior("TH09 Beginner", 09));
            
            _warriors.Add(GetWarrior("TH08 Max", 08));
            _warriors.Add(GetWarrior("TH08 Intermediate", 08));
            _warriors.Add(GetWarrior("TH08 Beginner", 08));
            
            _warriors.Add(GetWarrior("TH07 Max", 07));
            _warriors.Add(GetWarrior("TH07 Intermediate", 07));
            _warriors.Add(GetWarrior("TH07 Beginner", 07));
            
            _warriors.Add(GetWarrior("TH06 Max", 06));
            _warriors.Add(GetWarrior("TH06 Intermediate", 06));
            _warriors.Add(GetWarrior("TH06 Beginner", 06));
            
            warriorBindingSource.DataSource = _warriors;
        }

        private Warrior GetWarrior(string name, int thLevel)
        {
            return new Warrior
            {
                Id = _warriors.Count + 1,
                Name = name,
                TownHallLevel = thLevel,
                Clan = _clan,
                ClanId = _clan.Id
            };
        }

        private void InitializeLeague()
        {
            _leagueWar = new LeagueWar();
            _leagueWar.Players = _warriors;

            _leagueWar.PlayersPerDay = new Dictionary<int, List<LeagueWarPlayer>>();

            _leagueWar.PlayersPerDay.Add(1, new List<LeagueWarPlayer>());
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[0], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[1], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[2], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[3], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[4], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[5], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[6], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[7], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[8], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[9], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[10], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[11], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[12], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[13], 1, 13, true, true, true);
            AddPlayerToDay(_leagueWar.PlayersPerDay[1], _warriors[14], 1, 13, true, true, true);

            dayOneBindingSource.DataSource = _leagueWar.PlayersPerDay[1];
        }

        private void AddPlayerToDay(List<LeagueWarPlayer> leagueDay, Warrior warrior, int stars, int attackedThLevel, bool attackDone,
            bool hasFollowedStrategy, bool isCoherentAttack)
        {
            var dayPlayer = new LeagueWarPlayer();
            dayPlayer.Id = leagueDay.Count + 1;
            dayPlayer.Player = warrior;
            dayPlayer.PlayerId = warrior.Id;
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

        private void ComputeLeagueRewards()
        {
            rewardBindingSource.DataSource = _leagueRewardManagement.ComputeLeagueScore(_leagueWar, _leagueOptions);
            rewardBindingSource.ResetBindings(false);
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            ComputeLeagueRewards();
        }
    }
}
