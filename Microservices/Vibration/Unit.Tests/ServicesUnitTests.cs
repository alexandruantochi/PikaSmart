using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Commands.AddVibrationRecord;
using Business.Services.Handlers;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetAllVibrationRecords;
using Business.Services.Queries.GetUserVibrationRecords;
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
        public async Task Given_AddVibrationRecord_When_AddingAValidVibrationRecord_Then_VibrationRecordShouldBeAddedAndIdReturnedAsync()
        {
            //Arrange
            var expectedId = Guid.NewGuid();
            var toStore = new VibrationRecord
            {
                Id = expectedId,
                UserId = Guid.NewGuid(),
                Value = 0,
                Time = new DateTime(2017, 11, 10, 12, 12, 12)
            };

            Mapper.Setup(x => x.Map<VibrationRecord>(It.IsAny<AddVibrationRecordCommand>())).Returns(toStore);

            var sut = new AddVibrationRecordHandler(Repo.Object, Mapper.Object);

            //Act
            var result = await sut.Handle(new AddVibrationRecordCommand(), CancellationToken.None);

            //Assert
            Repo.Verify(x => x.AddAsync(It.IsAny<VibrationRecord>()), Times.Once);
            Repo.Verify(x => x.SaveChangesAsync(), Times.Once);
            result.Id.Should().Be(expectedId);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Given_GetAllVibrationRecords_Then_AllVibrationRecordsShouldBeReturnedAsync()
        {
            //Arrange
            var records = new List<VibrationRecord>
            {
                new VibrationRecord()
            };

            Repo.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(records));

            var sut = new GetAllVibrationRecordsHandler(Repo.Object, Mapper.Object);

            //Act
            await sut.Handle(new GetAllVibrationRecordsQuery(), CancellationToken.None);

            //Assert
            Mapper.Verify(x => x.Map<List<VibrationRecord>, List<GetVibrationRecordWithUserQueryResult>>(It.IsAny<List<VibrationRecord>>()), Times.Once());
        }

        [TestMethod]
        public async Task Given_GetVibrationRecordsOfAUser_Then_VibrationRecordsOfTheUserShouldBeReturnedAsync()
        {
            //Arrange
            var records = new List<VibrationRecord>
            {
                new VibrationRecord()
            };

            Repo.Setup(x => x.GetByUserIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(records));

            var sut = new GetUserVibrationRecordsHandler(Repo.Object, Mapper.Object);

            //Act
            await sut.Handle(new GetUserVibrationRecordsQuery(Guid.NewGuid()), CancellationToken.None);

            //Assert
            Mapper.Verify(x => x.Map<List<VibrationRecord>, List<GetVibrationRecordQueryResult>>(It.IsAny<List<VibrationRecord>>()), Times.Once());
        }
    }
}
