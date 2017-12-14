using System;
using System.Collections.Generic;
using Business.Dtos.Atomic;
using Business.Services;
using Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unit.Tests.Base;

namespace Unit.Tests
{
    [TestClass]
    public class PressureServiceUnitTests : BasePressureServiceUnitTests
    {
        [TestMethod]
        public void Given_AddPressureRecord_When_AddingAValidPressureRecord_Then_PressureRecordShouldBeAddedAndIdReturned()
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

            Mapper.Setup(x => x.Map<PressureRecord>(It.IsAny<AddPressureRecordDto>())).Returns(toStore);

            var sut = CreateSut();
            
            //Act
            var result = sut.AddPressureRecord(new AddPressureRecordDto());

            //Assert
            Repo.Verify(x => x.Add(It.IsAny<PressureRecord>()), Times.Once);
            Repo.Verify(x => x.SaveChanges(), Times.Once);
            result.Should().Be(expectedId);
        }

        [TestMethod]
        public void Given_GetAllPressureRecords_Then_PressureRecordsShouldBeReturned()
        {
            //Arrange
            var records = new List<PressureRecord>
            {
                new PressureRecord()
            };

            Repo.Setup(x => x.GetAll()).Returns(records);

            var sut = CreateSut();

            //Act
            sut.GetAllPressureRecords();

            //Assert
            Mapper.Verify(x => x.Map<List<PressureRecord>, List<GetPressureRecordWithUserDto>>(It.IsAny<List<PressureRecord>>()), Times.Once());
        }

        [TestMethod]
        public void Given_GetPressureRecordsOfAUser_Then_PressureRecordsOfTheUserShouldBeReturned()
        {
            //Arrange
            var records = new List<PressureRecord>
            {
                new PressureRecord()
            };

            Repo.Setup(x => x.GetByUserId(It.IsAny<Guid>())).Returns(records);

            var sut = CreateSut();

            //Act
            sut.GetUserPressureRecords(Guid.NewGuid());

            //Assert
            Mapper.Verify(x => x.Map<List<PressureRecord>, List<GetPressureRecordDto>>(It.IsAny<List<PressureRecord>>()), Times.Once());
        }

        private PressureService CreateSut()
        {
            return new PressureService(Repo.Object, Mapper.Object);
        }
    }
}
