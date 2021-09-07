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
        private readonly IScoreOptionsManagement _scoreOptionsLoader;
        private readonly ILeagueDal _leagueWarDal;
        private readonly IWarDal _clanWarDal;
        private readonly IGameDal _gameDal;
        private readonly IGameWarriorDal _gameWarriorDal;
        private readonly ILeagueBonusDal _leagueBonusDal;
        private List<int> _clanIds;

        public WarriorRewardManagement(
            IScoreOptionsManagement scoreOptionsLoader,
            ILeagueDal leagueWarDal,
            IWarDal clanWarDal,
            IGameWarriorDal gameWarriorDal,
            IGameDal gameDal,
            ILeagueBonusDal leagueBonusDal)
        {
            _leagueWarDal = leagueWarDal;
            _clanWarDal = clanWarDal;
            _gameWarriorDal = gameWarriorDal;
            _gameDal = gameDal;
            _scoreOptionsLoader = scoreOptionsLoader;
            _leagueBonusDal = leagueBonusDal;
        }

        public List<IAbstractReward> ComputeLeagueScore(League league)
        {
            InitializeClans(league);
            var rewards = ComputeWarriorsScore(league, _scoreOptionsLoader.LoadWarriorScoreOptions());

            return rewards.Cast<IAbstractReward>().ToList();
        }

        private void InitializeClans(League league)
        {
            _clanIds = league.Players.Select(x => x.ClanId).Distinct().ToList();
        }

        private List<WarriorReward> ComputeWarriorsScore(League leagueWar, WarriorScoreOptions options)
        {
            var rewards = InitializeRewards(leagueWar.Players);

            SetIndividualScores(SetIndividualScoreWithLeagueParticipation, options.ScoreLeagueParticipation, rewards, options);
            SetIndividualScores(SetIndividualScoreWithWarParticipation, options.ScoreWarParticipation, rewards, options);
            SetIndividualScores(SetIndividualScoreWithGameParticipation, options.ScoreGameParticipation, rewards, options);
            SetIndividualScores(SetIndividualScoreWithGameThreshold, options.ScoreMinimumGamePoints, rewards, options);
            SetIndividualScores(SetIndividualScoreWithSnippedGame, options.ScoreSnippedGame, rewards, options);
            SetIndividualScores(SetIndividualScoreWithTownhallLevel, options.ScoreTownHallLevel, rewards, options);
            SetIndividualScores(SetIndividualScoreWithSeniority, options.ScoreSeniority, rewards, options);
            SetIndividualScores(SetIndividualScoreWithLastLeagueBonus, options.ScoreLastLeagueBonus, rewards, options);
            
            return rewards.OrderByDescending(x => x.Score).ToList();
        }

        private List<WarriorReward> InitializeRewards(List<Warrior> warriors)
        {
            var rewards = new List<WarriorReward>();

            foreach (var player in warriors)
            {
                rewards.Add(new WarriorReward { Warrior = player, WarriorId = player.Id, Score = 0 });
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
            var arrivalDate = reward.Warrior.ArrivalDate;
            var leaguesCount = _leagueWarDal.GetLeagues(arrivalDate, _clanIds).Select(x => new DateTime(x.LeagueDate.Year, x.LeagueDate.Month, 1)).Distinct().Count();

            int warriorParticipation = _leagueWarDal.GetLeaguesCount(reward.Warrior.Id);

            double ratio = 0;
            if (warriorParticipation != 0)
            {
                ratio = (double)warriorParticipation / leaguesCount;
            }

            reward.LeagueParticipationRatio = ratio;
            reward.LeagueParticipationScore = (int)(ratio * (double)options.LeagueParticipationPoints);
            reward.Score += reward.LeagueParticipationScore;
        }

        private void SetIndividualScoreWithWarParticipation(WarriorReward reward, WarriorScoreOptions options)
        {
            int warsCount = _clanWarDal.GetWarsCount(reward.Warrior.ArrivalDate, reward.Warrior.ClanId);
            var warriorParticipation = _clanWarDal.GetWars(reward.Warrior.Id);
            int warriorParticipationCount = warriorParticipation.Count();

            double ratio = 0;
            if (warriorParticipationCount != 0)
            {
                ratio = (double)warriorParticipationCount / warsCount;
            }

            if (ratio > 1) ratio = 1;

            reward.WarParticipationRatio = ratio;
            reward.WarParticipationScore = (int)(ratio * (double)options.WarParticipationPoints);
            reward.Score += reward.WarParticipationScore;
        }

        private void SetIndividualScoreWithGameParticipation(WarriorReward reward, WarriorScoreOptions options)
        {
            var gamesCount = _gameDal.GetGames(reward.Warrior.ArrivalDate, _clanIds).Select(x => new DateTime(x.GamesDate.Year, x.GamesDate.Month, 1)).Distinct().Count();
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

        private void SetIndividualScoreWithSnippedGame(WarriorReward reward, WarriorScoreOptions options)
        {
            var warriorGames = _gameWarriorDal.GetGames(reward.Warrior.Id);

            var snippedGames = warriorGames.Count(x => x.Score < options.MinimumGamePointsThreshold);

            double ratio = 0;
            if (snippedGames != 0)
            {
                ratio = (double)snippedGames / warriorGames.Count;
            }

            reward.SnippedGameRatio = ratio;
            reward.SnippedGameScore = (int)(ratio * (double)options.SnippedGamePoints);
            reward.Score -= reward.SnippedGameScore;
        }

        private void SetIndividualScoreWithGameThreshold(WarriorReward reward, WarriorScoreOptions options)
        {
            var warriorGames = _gameWarriorDal.GetGames(reward.Warrior.Id);

            var succeedeedGames = warriorGames.Count(x => x.Score >= options.MinimumGamePointsThreshold);

            double ratio = 0;
            if (succeedeedGames != 0)
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
            if ((today - arrival).TotalDays < 31)
            {
                warriorSeniority = 0;
            }

            var matchingReward = options.SeniorityPoints.OrderBy(x => x.MinimumMonth).First(x => warriorSeniority < x.MaximumMonth);

            reward.SeniorityScore = matchingReward.Bonus;
            reward.Score += reward.SeniorityScore;
        }

        private void SetIndividualScoreWithLastLeagueBonus(WarriorReward reward, WarriorScoreOptions options)
        {
            var today = DateTime.Today;
            var lastBonusDate = _leagueBonusDal.GetLastBonus(reward.WarriorId);
            if (!lastBonusDate.HasValue)
            {
                lastBonusDate = reward.Warrior.ArrivalDate;
            }

            var lastBonusInMonths = ((today.Year - lastBonusDate.Value.Year) * 12) + today.Month - lastBonusDate.Value.Month;
            if ((today - lastBonusDate.Value).TotalDays < 30)
            {
                lastBonusInMonths = 0;
            }

            var bonusScore = lastBonusInMonths * options.LastLeagueBonusPoints;

            reward.LastBonusInMonth = lastBonusInMonths;
            reward.LastBonusScore = bonusScore;
            reward.Score += reward.LastBonusScore;
        }
    }
}
