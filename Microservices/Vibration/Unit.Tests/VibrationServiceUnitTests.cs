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
    public class VibrationServiceUnitTests : BaseVibrationServiceUnitTests
    {
        [TestMethod]
        public void Given_AddVibrationRecord_When_AddingAValidVibrationRecord_Then_VibrationRecordShouldBeAddedAndIdReturned()
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

            Mapper.Setup(x => x.Map<VibrationRecord>(It.IsAny<AddVibrationRecordDto>())).Returns(toStore);

            var sut = CreateSut();
            
            //Act
            var result = sut.AddVibrationRecord(new AddVibrationRecordDto());

            //Assert
            Repo.Verify(x => x.Add(It.IsAny<VibrationRecord>()), Times.Once);
            Repo.Verify(x => x.SaveChanges(), Times.Once);
            result.Should().Be(expectedId);
        }

        [TestMethod]
        public void Given_GetAllVibrationRecords_Then_VibrationRecordsShouldBeReturned()
        {
            //Arrange
            var records = new List<VibrationRecord>
            {
                new VibrationRecord()
            };

            Repo.Setup(x => x.GetAll()).Returns(records);

            var sut = CreateSut();

            //Act
            sut.GetAllVibrationRecords();

            //Assert
            Mapper.Verify(x => x.Map<List<VibrationRecord>, List<GetVibrationRecordWithUserDto>>(It.IsAny<List<VibrationRecord>>()), Times.Once());
        }

        [TestMethod]
        public void Given_GetVibrationRecordsOfAUser_Then_VibrationRecordsOfTheUserShouldBeReturned()
        {
            //Arrange
            var records = new List<VibrationRecord>
            {
                new VibrationRecord()
            };

            Repo.Setup(x => x.GetByUserId(It.IsAny<Guid>())).Returns(records);

            var sut = CreateSut();

            //Act
            sut.GetUserVibrationRecords(Guid.NewGuid());

            //Assert
            Mapper.Verify(x => x.Map<List<VibrationRecord>, List<GetVibrationRecordDto>>(It.IsAny<List<VibrationRecord>>()), Times.Once());
        }

        private VibrationService CreateSut()
        {
            return new VibrationService(Repo.Object, Mapper.Object);
        }
    }
}
