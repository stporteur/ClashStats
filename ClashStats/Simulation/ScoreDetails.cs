﻿using ClashEntities.Rewards;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClashStats.Simulation
{
    public partial class ScoreDetails : Form
    {
        private readonly Reward _warriorReward;

        public ScoreDetails(Reward warriorReward)
        {
            InitializeComponent();
            _warriorReward = warriorReward;
        }

        private void ScoreDetails_Load(object sender, EventArgs e)
        {
            leagueRewardBindingSource.DataSource = _warriorReward.RewardDetails.Single(r => r is LeagueReward);
            warriorRewardBindingSource.DataSource = _warriorReward.RewardDetails.Single(r => r is WarriorReward);
        }
    }
}
