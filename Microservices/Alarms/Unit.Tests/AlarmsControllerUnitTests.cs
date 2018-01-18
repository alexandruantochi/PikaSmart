using System;
using System.Collections.Generic;
using Api.Controllers;
using Business.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit.Tests.Base;

namespace Unit.Tests
{
    [TestClass]
    public class AlarmsControllerUnitTests : BaseAlarmsServiceUnitTests
    {
        [TestMethod]
        public void Given_GetAll_Then_ShouldRespondWithOK()
        {
            //Arrange
            var records = new GetAllAlarmsRecordsDto
            (
                new List<GetAlarmsRecordWithUserDto>()
            );

            Service.Setup(serv => serv.GetAllAlarmsRecords())
                .Returns(records);

            var controller = CreateSut();

            //Act
            var response = controller.GetAll();

            //Assert
            response.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public void Given_GetByUser_When_UserIdIsNotEmpty_Then_ShouldReturnUserAlarmsRecordsAndRespondWithOk()
        {
            //Arrange
            var userId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB");

            var records = new GetUserAlarmsRecordsDto
            (
                new List<GetAlarmsRecordDto>()
                {
                    new GetAlarmsRecordDto
                    {
                        Value = 60,
                        Time = DateTime.Now
                    }
                }
            );

            Service.Setup(serv => serv.GetUserAlarmsRecords(userId))
                .Returns(records);

            var controller = CreateSut();

            //Act
            var response = controller.GetByUser(userId);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var result = (response as OkObjectResult)?.Value;
            var values = (result as GetUserAlarmsRecordsDto)?.AlarmsRecords;
            values?.Count.Should().Be(1);
        }

        [TestMethod]
        public void Given_GetByUser_When_UserIdIsEmpty_Then_ShouldRespondWithBadRequest()
        {
            //Arrange
            var id = Guid.Empty;
            var controller = CreateSut();

            //Act
            var response = controller.GetByUser(id);

            //Assert
            response.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void Given_Create_When_ValidModelState_Then_ShouldRespondWithCreated()
        {
            //Arrange
            var addRecord = new AddAlarmsRecordDto();
            var id = new Guid();

            Service.Setup(serv => serv.AddAlarmsRecord(addRecord))
                .Returns(id);

            var controller = CreateSut();

            //Act
            var response = controller.Create(addRecord);

            //Assert
            response.Should().BeOfType<CreatedResult>();
        }

        [TestMethod]
        public void Given_Create_When_InvalidModelState_Then_ShouldRespondWithBadRequest()
        {
            //Arrange
            var addRecord = new AddAlarmsRecordDto();
            var id = new Guid();

            Service.Setup(serv => serv.AddAlarmsRecord(addRecord))
                .Returns(id);

            var controller = CreateSut();
            controller.ModelState.SetModelValue("", ValueProviderResult.None);

            //Act
            var response = controller.Create(addRecord);

            //Assert
            response.Should().BeOfType<BadRequestResult>();
        }

        private AlarmsController CreateSut()
        {
            return new AlarmsController(Service.Object);
        }
    }
}
