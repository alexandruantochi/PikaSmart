using System;
using System.Collections.Generic;
using Domain.Entities;
using FluentAssertions;
using Integration.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;

namespace Integration.Tests
{
    [TestClass]
    public class AlarmsRepositoryIntegrationTests : BaseIntegrationTests
    {
        [TestMethod]
        public void Given_AlarmsRepository_When_AddingAAlarmsRecord_Then_TheRecordShouldBeMemorized()
        {
            RunOnDatabase(sut =>
            {
                //Arrange
                var repo = new AlarmsRepository(sut);
                var record = new AlarmsRecord
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Value = 10,
                    Time = new DateTime(2017, 11, 20, 11, 21, 1)
                };

                //Act
                repo.Add(record);
                repo.SaveChanges();

                //Assert
                var results = repo.GetAll();
                results[0].ShouldBeEquivalentTo(record);
            });
        }

        [TestMethod]
        public void Given_AlarmsRepository_When_GettingAllAlarmsRecords_Then_AllRecordsShouldBeReturned()
        {
            RunOnDatabase(sut =>
            {
                //Arrange
                var repo = new AlarmsRepository(sut);
                var record = new AlarmsRecord
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Value = 10,
                    Time = new DateTime(2017, 11, 20, 11, 21, 1)
                };

                //Act
                repo.Add(record);
                repo.SaveChanges();

                //Assert
                var results = repo.GetAll();
                results.Count.Should().Be(1);
            });
        }

        [TestMethod]
        public void Given_AlarmsRepository_When_GettingAlarmsRecordsOfAUser_Then_AllRecordsOfThatUserShouldBeReturned()
        {
            RunOnDatabase(sut =>
            {
                //Arrange
                var repo = new AlarmsRepository(sut);
                var userId = Guid.NewGuid();
                var records = new List<AlarmsRecord>
                {
                    new AlarmsRecord
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        Value = 1,
                        Time = new DateTime(2017, 11, 20, 11, 21, 1)
                    },
                    new AlarmsRecord
                    {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        Value = 2,
                        Time = new DateTime(2017, 11, 20, 11, 21, 1)
                    }
                };

                //Act
                foreach (var record in records)
                {
                    repo.Add(record);
                }
                repo.SaveChanges();

                //Assert
                var results = repo.GetByUserId(userId);
                results.Count.Should().Be(1);
            });
        }
    }
}
