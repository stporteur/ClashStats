using ClashBusiness;
using ClashBusiness.Rewards;
using ClashBusiness.ScoreOptions;
using ClashEntities;
using ClashEntities.Rewards;
using ClashStats.ScoreOptionControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashStats.LetsPlay.Leagues
{
    public partial class RewardAndCloseLeagueForm : Form
    {
        private League _league;
        private IRewardManagement _rewardManagement;
        public RewardAndCloseLeagueForm(League league)
        {
            InitializeComponent();
            _league = league;
        }

        private void RewardAndCloseLeagueForm_Load(object sender, EventArgs e)
        {

            _rewardManagement = AutofacFactory.Instance.GetInstance<IRewardManagement>();
            var warriorScoreOptions = new WarriorScoreOptionControl();
            tabPageWarriorScoreOptions.Controls.Add(warriorScoreOptions);
            warriorScoreOptions.Dock = DockStyle.Fill;
            warriorScoreOptions.AutoScroll = true;

            var leagueScoreOptions = new LeagueScoreOptionControl();
            tabPageLeagueScoreOptions.Controls.Add(leagueScoreOptions);
            leagueScoreOptions.Dock = DockStyle.Fill;
            leagueScoreOptions.AutoScroll = true;
        }

        private void warriorDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            rewardBindingSource.DataSource = _rewardManagement.GetRankSuggestion(_league);

            var optionsLoader = AutofacFactory.Instance.GetInstance<IScoreOptionsManagement>();
            warriorScoreOptionsBindingSource.DataSource = optionsLoader.LoadWarriorScoreOptions();
            leagueScoreOptionsBindingSource.DataSource = optionsLoader.LoadLeagueScoreOptions();
        }

        private void rewardDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (rewardDataGridView.CurrentRow != null)
            {
                var currentReward = rewardDataGridView.SelectedRows[0].DataBoundItem as Reward;
                leagueRewardBindingSource.DataSource = currentReward.RewardDetails.Single(x => x is LeagueReward);
                warriorRewardBindingSource.DataSource = currentReward.RewardDetails.Single(x => x is WarriorReward);
            }
        }

        private void btnReward_Click(object sender, EventArgs e)
        {
            var playersId = new List<int>();
            var playersName = new List<string>();
            foreach (DataGridViewRow row in rewardDataGridView.Rows)
            {
                if(((bool?)row.Cells["SelectedWarriorCheckBoxColumn"].Value) == true)
                {
                    var reward = row.DataBoundItem as Reward;
                    playersId.Add(reward.Warrior.Id);
                    playersName.Add(reward.WarriorName);
                }
            }

            _rewardManagement.GiveRewards(_league.LeagueDate, playersId);
            MessageBox.Show(string.Format("Ils ont leur bonus ! {0}", string.Join(" ", playersName)));
        }
    }
}
