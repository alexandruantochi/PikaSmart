using System;
using System.Collections.Generic;
using Business.Dtos;
using Business.Services;
using Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unit.Tests.Base;

namespace Unit.Tests
{
    [TestClass]
    public class AlarmsServiceUnitTests : BaseAlarmsServiceUnitTests
    {
        [TestMethod]
        public void Given_AddAlarmsRecord_When_AddingAValidAlarmsRecord_Then_AlarmsRecordShouldBeAddedAndIdReturned()
        {
            //Arrange
            var expectedId = Guid.NewGuid();
            var toStore = new AlarmsRecord
            {
                Id = expectedId,
                UserId = Guid.NewGuid(),
                Value = 0,
                Time = new DateTime(2017, 11, 10, 12, 12, 12)
            };

            Mapper.Setup(x => x.Map<AlarmsRecord>(It.IsAny<AddAlarmsRecordDto>())).Returns(toStore);

            var sut = CreateSut();
            
            //Act
            var result = sut.AddAlarmsRecord(new AddAlarmsRecordDto());

            //Assert
            Repo.Verify(x => x.Add(It.IsAny<AlarmsRecord>()), Times.Once);
            Repo.Verify(x => x.SaveChanges(), Times.Once);
            result.Should().Be(expectedId);
        }

        [TestMethod]
        public void Given_GetAllAlarmsRecords_Then_AlarmsRecordsShouldBeReturned()
        {
            //Arrange
            var records = new List<AlarmsRecord>
            {
                new AlarmsRecord()
            };

            Repo.Setup(x => x.GetAll()).Returns(records);

            var sut = CreateSut();

            //Act
            sut.GetAllAlarmsRecords();

            //Assert
            Mapper.Verify(x => x.Map<List<AlarmsRecord>, List<GetAlarmsRecordWithUserDto>>(It.IsAny<List<AlarmsRecord>>()), Times.Once());
        }

        [TestMethod]
        public void Given_GetAlarmsRecordsOfAUser_Then_AlarmsRecordsOfTheUserShouldBeReturned()
        {
            //Arrange
            var records = new List<AlarmsRecord>
            {
                new AlarmsRecord()
            };

            Repo.Setup(x => x.GetByUserId(It.IsAny<Guid>())).Returns(records);

            var sut = CreateSut();

            //Act
            sut.GetUserAlarmsRecords(Guid.NewGuid());

            //Assert
            Mapper.Verify(x => x.Map<List<AlarmsRecord>, List<GetAlarmsRecordDto>>(It.IsAny<List<AlarmsRecord>>()), Times.Once());
        }

        private AlarmsService CreateSut()
        {
            return new AlarmsService(Repo.Object, Mapper.Object);
        }
    }
}
