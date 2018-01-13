using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Commands.AddTemperatureRecord;
using Business.Services.Handlers;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetAllTemperatureRecords;
using Business.Services.Queries.GetUserTemperatureRecords;
using Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unit.Tests.Base;

namespace Unit.Tests
{
    [TestClass]
    public class ServicesUnitTests : BaseUnitTests
    {
        [TestMethod]
        public async Task Given_AddTemperatureRecord_When_AddingAValidTemperatureRecord_Then_TemperatureRecordShouldBeAddedAndIdReturnedAsync()
        {
            //Arrange
            var expectedId = Guid.NewGuid();
            var toStore = new TemperatureRecord
            {
                Id = expectedId,
                UserId = Guid.NewGuid(),
                Value = 0,
                Time = new DateTime(2017, 11, 10, 12, 12, 12)
            };

            Mapper.Setup(x => x.Map<TemperatureRecord>(It.IsAny<AddTemperatureRecordCommand>())).Returns(toStore);

            var sut = new AddTemperatureRecordHandler(Repo.Object, Mapper.Object);

            //Act
            var result = await sut.Handle(new AddTemperatureRecordCommand(), CancellationToken.None);

            //Assert
            Repo.Verify(x => x.AddAsync(It.IsAny<TemperatureRecord>()), Times.Once);
            Repo.Verify(x => x.SaveChangesAsync(), Times.Once);
            result.Id.Should().Be(expectedId);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Given_GetAllTemperatureRecords_Then_AllTemperatureRecordsShouldBeReturnedAsync()
        {
            //Arrange
            var records = new List<TemperatureRecord>
            {
                new TemperatureRecord()
            };

            Repo.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(records));

            var sut = new GetAllTemperatureRecordsHandler(Repo.Object, Mapper.Object);

            //Act
            await sut.Handle(new GetAllTemperatureRecordsQuery(), CancellationToken.None);

            //Assert
            Mapper.Verify(x => x.Map<List<TemperatureRecord>, List<GetTemperatureRecordWithUserQueryResult>>(It.IsAny<List<TemperatureRecord>>()), Times.Once());
        }

        [TestMethod]
        public async Task Given_GetTemperatureRecordsOfAUser_Then_TemperatureRecordsOfTheUserShouldBeReturnedAsync()
        {
            //Arrange
            var records = new List<TemperatureRecord>
            {
                new TemperatureRecord()
            };

            Repo.Setup(x => x.GetByUserIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(records));

            var sut = new GetUserTemperatureRecordsHandler(Repo.Object, Mapper.Object);

            //Act
            await sut.Handle(new GetUserTemperatureRecordsQuery(Guid.NewGuid()), CancellationToken.None);

            //Assert
            Mapper.Verify(x => x.Map<List<TemperatureRecord>, List<GetTemperatureRecordQueryResult>>(It.IsAny<List<TemperatureRecord>>()), Times.Once());
        }
    }
}
