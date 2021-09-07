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
    public class LoadTests
    {
        private IScoreOptionsDal _scoreOptionsDal;
        private ISeniorityScoreOptionsDal _seniorityScoreOptionsDal;
        private ITownHallLevelScoreOptionsDal _townHallLevelScoreOptionsDal;
        private IScoreOptionsManagement _scoreOptionsManagement;

        [SetUp]
        public void Setup()
        {
            _scoreOptionsDal = Substitute.For<IScoreOptionsDal>();
            _seniorityScoreOptionsDal = Substitute.For<ISeniorityScoreOptionsDal>();
            _townHallLevelScoreOptionsDal = Substitute.For<ITownHallLevelScoreOptionsDal>();

            _scoreOptionsManagement = new ScoreOptionsManagement(_scoreOptionsDal, _seniorityScoreOptionsDal, _townHallLevelScoreOptionsDal);
        }

        [Test]
        public void Should_thrown_exception_when_loading_league_options_and_nothing_is_available_in_database()
        {
            _scoreOptionsDal.GetAll().Returns(new List<ScoreOption>());
            Check.ThatCode(() => _scoreOptionsManagement.LoadLeagueScoreOptions()).Throws<InvalidOperationException>();
        }

        [Test]
        public void Should_thrown_exception_when_loading_warrior_options_and_nothing_is_available_in_database()
        {
            _scoreOptionsDal.GetAll().Returns(new List<ScoreOption>());
            Check.ThatCode(() => _scoreOptionsManagement.LoadWarriorScoreOptions()).Throws<InvalidOperationException>();
        }

        [Test]
        public void Should_thrown_exception_when_league_score_options_are_found_twice_in_database()
        {
            _scoreOptionsDal.GetAll().Returns(new List<ScoreOption>
            {
                new ScoreOption { Id = 1, ScoreType = "LEAGUE", ScoreName = "ScoreStarResults", ScoreValue = "true"},
                new ScoreOption { Id = 1, ScoreType = "LEAGUE", ScoreName = "ScoreStarResults", ScoreValue = "true"}
            });
            Check.ThatCode(() => _scoreOptionsManagement.LoadLeagueScoreOptions()).Throws<InvalidOperationException>();
        }

        [Test]
        public void Should_thrown_exception_when_warrior_score_options_are_found_twice_in_database()
        {
            _scoreOptionsDal.GetAll().Returns(new List<ScoreOption>
            {
                new ScoreOption { Id = 1, ScoreType = "WARRIOR", ScoreName = "ScoreGameParticipation", ScoreValue = "true"},
                new ScoreOption { Id = 1, ScoreType = "WARRIOR", ScoreName = "ScoreGameParticipation", ScoreValue = "true"}
            });
            Check.ThatCode(() => _scoreOptionsManagement.LoadWarriorScoreOptions()).Throws<InvalidOperationException>();
        }

        [Test]
        public void Should_assign_all_entity_properties_when_loading_league_options()
        {
            _scoreOptionsDal.GetAll().Returns(ScoreOptionsHelper.GetLeagueOptions());
            var result = _scoreOptionsManagement.LoadLeagueScoreOptions();
            CheckAssignedProperties(result);
        }

        [Test]
        public void Should_assign_all_entity_properties_when_loading_warrior_options()
        {
            _scoreOptionsDal.GetAll().Returns(ScoreOptionsHelper.GetWarriorOptions());
            var result = _scoreOptionsManagement.LoadWarriorScoreOptions();
            CheckAssignedProperties(result);
            result.SeniorityPoints.ForEach(CheckAssignedProperties);
            result.TownHallLevelPoints.ForEach(CheckAssignedProperties);
        }

        private void CheckAssignedProperties<T>(T result)
        {
            var properties = result.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType.FullName == typeof(bool).ToString())
                {
                    Check.That((bool)property.GetValue(result)).IsTrue();
                }
                else if (property.PropertyType.FullName == typeof(int).ToString())
                {
                    Check.That((int)property.GetValue(result)).IsStrictlyGreaterThan(0);
                }
            }
        }
    }
}