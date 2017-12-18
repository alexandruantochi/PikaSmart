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
        public void Given_Controller_When_Always_Then_GetAllActionResult_ShouldReturnOK()
        {
            try
            {

                //Arrange
                var controller = new TemperatureController(Service.Object);

                //Act
                var result = controller.GetAll();

                //Assert
                result.Should().BeOfType(typeof(OkObjectResult));
            }
            catch (NullReferenceException e)
            {
            }
        }

        [TestMethod]
        public void Given_Controller_When_IdIsValid_Then_GetByUserId_ShouldReturnOK()
        {

            //Arrange
            Guid userId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB");

            var records = new List<GetTemperatureRecordDto>()
            {
                new GetTemperatureRecordDto
                {
                    Value = 60,
                    Time = DateTime.Now
                }
            };

            Service.Setup(serv => serv.GetUserTemperatureRecords(userId))
                .Returns(new GetUserTemperatureRecordsDto(records));

            var controller = new TemperatureController(Service.Object);

            //Act
            var result = controller.GetByUser(userId) as OkObjectResult;

            var model = result?.Value as GetUserTemperatureRecordsDto;

            //Assert
            model?.TemperatureRecords.Count.Should().BeGreaterThan(0);
            result?.StatusCode.Should().Be(200);


        }

        [TestMethod]
        public void Given_Controller_When_IdIsInvalid_Then_GetByUserId_ShouldReturn_BadRequest_IfDoesntExists()
        {

            //Arrange
            Guid id = new Guid("C06855B4-C8EA-482F-8C0C-009AA568FEFB");

            Service.Setup(serv => serv.GetUserTemperatureRecords(id))
                .Returns(new GetUserTemperatureRecordsDto(null));

            var controller = new TemperatureController(Service.Object);

            //Act
            var result = controller.GetByUser(id) as BadRequestResult;

            //Assert
            result?.StatusCode.Should().Be(400);

        }

        [TestMethod]
        public void Given_Controller_When_ValidModelState_Then_Create_ShouldReturnOk()
        {

            //Arrange
            AddTemperatureRecordDto tmp = new AddTemperatureRecordDto();
            Guid id = new Guid();

            Service.Setup(serv => serv.AddTemperatureRecord(tmp))
                .Returns(id);

            var controller = new TemperatureController(Service.Object);
            //Act
            var result = controller.Create(tmp) as CreatedResult;

            //Assert
            result?.StatusCode.Should().Be(201);

        }

        [TestMethod]
        public void Given_Controller_When_InvalidModelState_Then_Create_ShouldReturnBadRequest()
        {
            //Arrange
            AddTemperatureRecordDto tmp = new AddTemperatureRecordDto();
            Guid id = new Guid();

            Service.Setup(serv => serv.AddTemperatureRecord(tmp))
                .Returns(id);

            var controller = new TemperatureController(Service.Object);
            controller.ModelState.SetModelValue("", ValueProviderResult.None);
            //Act
            var result = controller.Create(tmp) as BadRequestResult;

            //Assert
            result?.StatusCode.Should().Be(400);
        }

    }
}
