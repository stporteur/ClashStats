using ClashBusiness.ScoreOptions;
using ClashData;
using ClashData.DataEntities;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashBusiness.Tests.ScoreOptionsTests
{
    public class SaveTests
    {
        private IScoreOptionsDal _scoreOptionsDal;
        private ISeniorityScoreOptionsDal _seniorityScoreOptionsDal;
        private ITownHallLevelScoreOptionsDal _townHallLevelScoreOptionsDal;
        private IScoreOptionsManagement _scoreOptionsManagement;
        private List<ScoreOption> _options;

        [SetUp]
        public void Setup()
        {
            _scoreOptionsDal = Substitute.For<IScoreOptionsDal>();

            _options = new List<ScoreOption>
            {
                new ScoreOption { Id = 1, ScoreType = "LEAGUE", ScoreName = "ScoreStarResults", ScoreValue = "true"},
                new ScoreOption { Id = 2, ScoreType = "LEAGUE", ScoreName = "ScoreHigherTownHallVillageAttack", ScoreValue = "true"},
                new ScoreOption { Id = 3, ScoreType = "LEAGUE", ScoreName = "HigherTownHallAttackMinimumStars", ScoreValue = "2"},
                new ScoreOption { Id = 4, ScoreType = "LEAGUE", ScoreName = "HigherTownHallAttackPoints", ScoreValue = "10"},
                new ScoreOption { Id = 5, ScoreType = "LEAGUE", ScoreName = "ScoreNoAttackDone", ScoreValue = "true"},
                new ScoreOption { Id = 6, ScoreType = "LEAGUE", ScoreName = "NoAttackDonePoints", ScoreValue = "20"},
                new ScoreOption { Id = 7, ScoreType = "LEAGUE", ScoreName = "ScoreIncoherentAttack", ScoreValue = "true"},
                new ScoreOption { Id = 8, ScoreType = "LEAGUE", ScoreName = "IncoherentAttackPoints", ScoreValue = "30"},
                new ScoreOption { Id = 9, ScoreType = "LEAGUE", ScoreName = "ScoreNotFollowedStrategy", ScoreValue = "true"},
                new ScoreOption { Id = 10, ScoreType = "LEAGUE", ScoreName = "NotFollowedStrategyPoints", ScoreValue = "40"},
                new ScoreOption { Id = 11, ScoreType = "LEAGUE", ScoreName = "ScoreFailedWarFault", ScoreValue = "true"},
                new ScoreOption { Id = 12, ScoreType = "LEAGUE", ScoreName = "FailedWarFaultPoints", ScoreValue = "50"},
                new ScoreOption { Id = 13, ScoreType = "WARRIOR", ScoreName = "ScoreStarResults", ScoreValue = "false"}
            };
            _scoreOptionsDal.GetAll().Returns(_options);

            _seniorityScoreOptionsDal = Substitute.For<ISeniorityScoreOptionsDal>();
            _townHallLevelScoreOptionsDal = Substitute.For<ITownHallLevelScoreOptionsDal>();
            _scoreOptionsManagement = new ScoreOptionsManagement(_scoreOptionsDal, _seniorityScoreOptionsDal, _townHallLevelScoreOptionsDal);
        }

        [Test]
        public void Should_save_all_entity_properties()
        {
            var optionsToSave = _scoreOptionsManagement.LoadLeagueScoreOptions();
            _scoreOptionsManagement.SaveLeagueScoreOptions(optionsToSave);

            var expectedScores = optionsToSave.GetType().GetProperties().Select(x => x.Name).ToList();

            _scoreOptionsDal.Received(expectedScores.Count).Update(Arg.Is<ScoreOption>(x => expectedScores.Contains(x.ScoreName)));
        }

        [Test]
        public void Should_not_update_non_expected_options()
        {
            var optionsToSave = _scoreOptionsManagement.LoadLeagueScoreOptions();
            _scoreOptionsManagement.SaveLeagueScoreOptions(optionsToSave);

            var expectedScores = optionsToSave.GetType().GetProperties().Select(x=>x.Name).ToList();

            _scoreOptionsDal.DidNotReceive().Update(Arg.Is<ScoreOption>(x => !expectedScores.Contains(x.ScoreName)));
        }
    }
}