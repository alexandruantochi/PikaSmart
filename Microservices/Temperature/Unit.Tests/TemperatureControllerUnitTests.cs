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
    public class TemperatureControllerUnitTests : BaseTemperatureServiceUnitTests
    {
        [TestMethod]
        public void Given_GetAll_Then_ShouldRespondWithOK()
        {
            //Arrange
            var records = new GetAllTemperatureRecordsDto
            (
                new List<GetTemperatureRecordWithUserDto>()
            );

            Service.Setup(serv => serv.GetAllTemperatureRecords())
                .Returns(records);

            var controller = CreateSut();

            //Act
            var response = controller.GetAll();

            //Assert
            response.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public void Given_GetByUser_When_UserIdIsNotEmpty_Then_ShouldReturnUserTemperatureRecordsAndRespondWithOk()
        {
            //Arrange
            var userId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB");

            var records = new GetUserTemperatureRecordsDto
            (
                new List<GetTemperatureRecordDto>()
                {
                    new GetTemperatureRecordDto
                    {
                        Value = 60,
                        Time = DateTime.Now
                    }
                }
            );

            Service.Setup(serv => serv.GetUserTemperatureRecords(userId))
                .Returns(records);

            var controller = CreateSut();

            //Act
            var response = controller.GetByUser(userId);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var result = (response as OkObjectResult)?.Value;
            var values = (result as GetUserTemperatureRecordsDto)?.TemperatureRecords;
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
            var addRecord = new AddTemperatureRecordDto();
            var id = new Guid();

            Service.Setup(serv => serv.AddTemperatureRecord(addRecord))
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
            var addRecord = new AddTemperatureRecordDto();
            var id = new Guid();

            Service.Setup(serv => serv.AddTemperatureRecord(addRecord))
                .Returns(id);

            var controller = CreateSut();
            controller.ModelState.SetModelValue("", ValueProviderResult.None);

            //Act
            var response = controller.Create(addRecord);

            //Assert
            response.Should().BeOfType<BadRequestResult>();
        }

        private TemperatureController CreateSut()
        {
            return new TemperatureController(Service.Object);
        }
    }
}
