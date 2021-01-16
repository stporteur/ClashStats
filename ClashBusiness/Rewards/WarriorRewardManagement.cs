using ClashBusiness.ScoreOptions;
using ClashData;
using ClashEntities;
using ClashEntities.Rewards;
using ClashEntities.ScoreOptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Rewards
{
    public class WarriorRewardManagement : IScoreRewardManagement
    {
        private readonly IScoreOptionsLoader _scoreOptionsLoader;
        private readonly ILeagueDal _leagueWarDal;
        private readonly IWarDal _clanWarDal;
        private readonly IGameDal _gameDal;
        private readonly IGameWarriorDal _gameWarriorDal;

        public WarriorRewardManagement(IScoreOptionsLoader scoreOptionsLoader, ILeagueDal leagueWarDal, IWarDal clanWarDal, IGameWarriorDal gameWarriorDal, IGameDal gameDal)
        {
            _leagueWarDal = leagueWarDal;
            _clanWarDal = clanWarDal;
            _gameWarriorDal = gameWarriorDal;
            _gameDal = gameDal;
            _scoreOptionsLoader = scoreOptionsLoader;
        }

        public List<IAbstractReward> ComputeLeagueScore(League leagueWar)
        {
            var rewards = ComputeWarriorsScore(leagueWar, _scoreOptionsLoader.LoadWarriorScoreOptions());

            return rewards.Cast<IAbstractReward>().ToList();
        }

        private List<WarriorReward> ComputeWarriorsScore(League leagueWar, WarriorScoreOptions options)
        {
            var rewards = InitializeRewards(leagueWar.Players);

            SetIndividualScores(SetIndividualScoreWithLeagueParticipation, options.ScoreLeagueParticipation, rewards, options);
            SetIndividualScores(SetIndividualScoreWithWarParticipation, options.ScoreWarParticipation, rewards, options);
            SetIndividualScores(SetIndividualScoreWithGameParticipation, options.ScoreGameParticipation, rewards, options);
            SetIndividualScores(SetIndividualScoreWithGameThreshold, options.ScoreMinimumGamePoints, rewards, options);
            SetIndividualScores(SetIndividualScoreWithTownhallLevel, options.ScoreTownHallLevel, rewards, options);
            SetIndividualScores(SetIndividualScoreWithSeniority, options.ScoreSeniority, rewards, options);

            return rewards.OrderByDescending(x => x.Score).ToList();
        }

        private List<WarriorReward> InitializeRewards(List<Warrior> warriors)
        {
            var rewards = new List<WarriorReward>();

            foreach (var player in warriors)
            {
                rewards.Add(new WarriorReward { Warrior = player, Score = 0 });
            }

            return rewards;
        }

        private void SetIndividualScores(Action<WarriorReward, WarriorScoreOptions> individualScoreAction, bool isOptionActivated, List<WarriorReward> rewards, WarriorScoreOptions options)
        {
            if (isOptionActivated)
            {
                foreach (var reward in rewards)
                {
                    individualScoreAction(reward, options);
                }
            }
        }

        private void SetIndividualScoreWithLeagueParticipation(WarriorReward reward, WarriorScoreOptions options)
        {
            int leaguesCount = _leagueWarDal.GetLeaguesCount(reward.Warrior.ArrivalDate);
            int warriorParticipation = _leagueWarDal.GetLeaguesCount(reward.Warrior.Id);

            var ratio = (double)warriorParticipation / leaguesCount;

            reward.LeagueParticipationRatio = ratio;
            reward.LeagueParticipationScore = (int)(ratio * (double)options.LeagueParticipationPoints);
            reward.Score += reward.LeagueParticipationScore;
        }

        private void SetIndividualScoreWithWarParticipation(WarriorReward reward, WarriorScoreOptions options)
        {
            int warsCount = _clanWarDal.GetWarsCount(reward.Warrior.ArrivalDate);
            int warriorParticipation = _clanWarDal.GetWarsCount(reward.Warrior.Id);

            var ratio = (double)warriorParticipation / warsCount;

            reward.WarParticipationRatio = ratio;
            reward.WarParticipationScore = (int)(ratio * (double)options.WarParticipationPoints);
            reward.Score += reward.WarParticipationScore;
        }

        private void SetIndividualScoreWithGameParticipation(WarriorReward reward, WarriorScoreOptions options)
        {
            int gamesCount = _gameDal.GetGamesCount(reward.Warrior.ArrivalDate);
            int warriorParticipation = _gameWarriorDal.GetGames(reward.Warrior.Id).Count;

            double ratio = 0;
            if (warriorParticipation != 0)
            {
                ratio = (double)warriorParticipation / gamesCount;
            }

            reward.GameParticipationRatio = ratio;
            reward.GameParticipationScore = (int)(ratio * (double)options.GameParticipationPoints);
            reward.Score += reward.GameParticipationScore;
        }

        private void SetIndividualScoreWithGameThreshold(WarriorReward reward, WarriorScoreOptions options)
        {
            var warriorGames = _gameWarriorDal.GetGames(reward.Warrior.Id);

            var succeedeedGames = warriorGames.Count(x => x.Score >= options.MinimumGamePointsThreshold);

            double ratio = 0;
            if(succeedeedGames != 0)
            {
               ratio = (double)succeedeedGames / warriorGames.Count;
            }

            reward.SucceedeedGameRatio = ratio;
            reward.SucceedeedGameScore = (int)(ratio * (double)options.MinimumGamePoints);
            reward.Score += reward.SucceedeedGameScore;
        }

        private void SetIndividualScoreWithTownhallLevel(WarriorReward reward, WarriorScoreOptions options)
        {
            var townHallLevelPoints = options.TownHallLevelPoints.Where(t =>
                t.TownHallLevel == reward.Warrior.TownHallLevel &&
                t.Maturity == reward.Warrior.TownHallLevelMaturity).FirstOrDefault();

            if (townHallLevelPoints != null)
            {
                reward.TownhallLevelScore = townHallLevelPoints.Bonus;
                reward.Score += reward.TownhallLevelScore;
            }
        }

        private void SetIndividualScoreWithSeniority(WarriorReward reward, WarriorScoreOptions options)
        {
            var today = DateTime.Today;
            var arrival = reward.Warrior.ArrivalDate;
            var warriorSeniority = ((today.Year - arrival.Year) * 12) + today.Month - arrival.Month;
            if((today - arrival).TotalDays < 31)
            {
                warriorSeniority = 0;
            }

            var matchingReward = options.SeniorityPoints.OrderBy(x => x.MinimumMonth).First(x => warriorSeniority < x.MaximumMonth);

            reward.SeniorityScore = matchingReward.Bonus;
            reward.Score += reward.SeniorityScore;
        }
    }
}
