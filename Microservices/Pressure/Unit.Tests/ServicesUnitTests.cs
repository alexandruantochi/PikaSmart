using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Commands.AddPressureRecord;
using Business.Services.Handlers;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetAllPressureRecords;
using Business.Services.Queries.GetUserPressureRecords;
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
        public async Task Given_AddPressureRecord_When_AddingAValidPressureRecord_Then_PressureRecordShouldBeAddedAndIdReturnedAsync()
        {
            //Arrange
            var expectedId = Guid.NewGuid();
            var toStore = new PressureRecord
            {
                Id = expectedId,
                UserId = Guid.NewGuid(),
                Value = 0,
                Time = new DateTime(2017, 11, 10, 12, 12, 12)
            };

            Mapper.Setup(x => x.Map<PressureRecord>(It.IsAny<AddPressureRecordCommand>())).Returns(toStore);

            var sut = new AddPressureRecordHandler(Repo.Object, Mapper.Object);

            //Act
            var result = await sut.Handle(new AddPressureRecordCommand(), CancellationToken.None);

            //Assert
            Repo.Verify(x => x.AddAsync(It.IsAny<PressureRecord>()), Times.Once);
            Repo.Verify(x => x.SaveChangesAsync(), Times.Once);
            result.Id.Should().Be(expectedId);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Given_GetAllPressureRecords_Then_AllPressureRecordsShouldBeReturnedAsync()
        {
            //Arrange
            var records = new List<PressureRecord>
            {
                new PressureRecord()
            };

            Repo.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(records));

            var sut = new GetAllPressureRecordsHandler(Repo.Object, Mapper.Object);

            //Act
            await sut.Handle(new GetAllPressureRecordsQuery(), CancellationToken.None);

            //Assert
            Mapper.Verify(x => x.Map<List<PressureRecord>, List<GetPressureRecordWithUserQueryResult>>(It.IsAny<List<PressureRecord>>()), Times.Once());
        }

        [TestMethod]
        public async Task Given_GetPressureRecordsOfAUser_Then_PressureRecordsOfTheUserShouldBeReturnedAsync()
        {
            //Arrange
            var records = new List<PressureRecord>
            {
                new PressureRecord()
            };

            Repo.Setup(x => x.GetByUserIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(records));

            var sut = new GetUserPressureRecordsHandler(Repo.Object, Mapper.Object);

            //Act
            await sut.Handle(new GetUserPressureRecordsQuery(Guid.NewGuid()), CancellationToken.None);

            //Assert
            Mapper.Verify(x => x.Map<List<PressureRecord>, List<GetPressureRecordQueryResult>>(It.IsAny<List<PressureRecord>>()), Times.Once());
        }
    }
}
