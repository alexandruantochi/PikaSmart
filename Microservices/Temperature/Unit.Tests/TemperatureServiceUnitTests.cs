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
    public class TemperatureServiceUnitTests : BaseTemperatureServiceUnitTests
    {
        [TestMethod]
        public void Given_AddTemperatureRecord_When_AddingAValidTemperatureRecord_Then_TemperatureRecordShouldBeAddedAndIdReturned()
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

            Mapper.Setup(x => x.Map<TemperatureRecord>(It.IsAny<AddTemperatureRecordDto>())).Returns(toStore);

            var sut = CreateSut();
            
            //Act
            var result = sut.AddTemperatureRecord(new AddTemperatureRecordDto());

            //Assert
            Repo.Verify(x => x.Add(It.IsAny<TemperatureRecord>()), Times.Once);
            Repo.Verify(x => x.SaveChanges(), Times.Once);
            result.Should().Be(expectedId);
        }

        [TestMethod]
        public void Given_GetAllTemperatureRecords_Then_TemperatureRecordsShouldBeReturned()
        {
            //Arrange
            var records = new List<TemperatureRecord>
            {
                new TemperatureRecord()
            };

            Repo.Setup(x => x.GetAll()).Returns(records);

            var sut = CreateSut();

            //Act
            sut.GetAllTemperatureRecords();

            //Assert
            Mapper.Verify(x => x.Map<List<TemperatureRecord>, List<GetTemperatureRecordWithUserDto>>(It.IsAny<List<TemperatureRecord>>()), Times.Once());
        }

        [TestMethod]
        public void Given_GetTemperatureRecordsOfAUser_Then_TemperatureRecordsOfTheUserShouldBeReturned()
        {
            //Arrange
            var records = new List<TemperatureRecord>
            {
                new TemperatureRecord()
            };

            Repo.Setup(x => x.GetByUserId(It.IsAny<Guid>())).Returns(records);

            var sut = CreateSut();

            //Act
            sut.GetUserTemperatureRecords(Guid.NewGuid());

            //Assert
            Mapper.Verify(x => x.Map<List<TemperatureRecord>, List<GetTemperatureRecordDto>>(It.IsAny<List<TemperatureRecord>>()), Times.Once());
        }

        private TemperatureService CreateSut()
        {
            return new TemperatureService(Repo.Object, Mapper.Object);
        }
    }
}
