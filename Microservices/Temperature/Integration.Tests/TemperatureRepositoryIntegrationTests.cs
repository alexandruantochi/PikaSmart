using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using FluentAssertions;
using Integration.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;

namespace Integration.Tests
{
    [TestClass]
    public class TemperatureRepositoryIntegrationTests : BaseIntegrationTests
    {
        [TestMethod]
        public async Task Given_TemperatureRepository_When_AddingATemperatureRecord_Then_TheRecordShouldBeMemorizedAsync()
        {
            await RunOnDatabaseAsync(async sut =>
            {
                //Arrange
                var repo = new TemperatureRepository(sut);
                var record = new TemperatureRecord
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Value = 10,
                    Time = new DateTime(2017, 11, 20, 11, 21, 1)
                };

                //Act
                await repo.AddAsync(record);
                await repo.SaveChangesAsync();

                //Assert
                var results = await repo.GetAllAsync();
                results[0].ShouldBeEquivalentTo(record);
            });
        }

        [TestMethod]
        public async Task Given_TemperatureRepository_When_GettingAllTemperatureRecords_Then_AllRecordsShouldBeReturnedAsync()
        {
            await RunOnDatabaseAsync(async sut =>
            {
                //Arrange
                var repo = new TemperatureRepository(sut);
                var record = new TemperatureRecord
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Value = 10,
                    Time = new DateTime(2017, 11, 20, 11, 21, 1)
                };

                //Act
                await repo.AddAsync(record);
                await repo.SaveChangesAsync();

                //Assert
                var results = await repo.GetAllAsync();
                results.Count.Should().Be(1);
            });
        }

        [TestMethod]
        public async Task Given_TemperatureRepository_When_GettingTemperatureRecordsOfAUser_Then_AllRecordsOfThatUserShouldBeReturnedAsync()
        {
            await RunOnDatabaseAsync(async sut =>
            {
                //Arrange
                var repo = new TemperatureRepository(sut);
                var userId = Guid.NewGuid();
                var records = new List<TemperatureRecord>
                {
                    new TemperatureRecord
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        Value = 1,
                        Time = new DateTime(2017, 11, 20, 11, 21, 1)
                    },
                    new TemperatureRecord
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
                    await repo.AddAsync(record);
                }
                await repo.SaveChangesAsync();

                //Assert
                var results = await repo.GetByUserIdAsync(userId);
                results.Count.Should().Be(1);
            });
        }
    }
}
