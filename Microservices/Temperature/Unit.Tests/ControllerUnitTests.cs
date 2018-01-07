using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Controllers;
using Business.Dtos;
using Business.Services.Commands.AddTemperatureRecord;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetAllTemperatureRecords;
using Business.Services.Queries.GetUserTemperatureRecords;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unit.Tests.Base;

namespace Unit.Tests
{
    [TestClass]
    public class ControllerUnitTests : BaseUnitTests
    {
        [TestMethod]
        public async Task Given_GetAll_Then_ShouldRespondWithOKAsync()
        {
            //Arrange
            var records = new GetAllTemperatureRecordsQueryResult
            (
                new List<GetTemperatureRecordWithUserQueryResult>()
            );

            Mediator.Setup(med => med.Send(It.IsAny<GetAllTemperatureRecordsQuery>(), CancellationToken.None))
                .Returns(Task.FromResult(records));

            var controller = CreateSut();
            
            //Act
            var response = await controller.GetAll();

            //Assert
            response.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public async Task Given_GetByUser_When_UserIdIsNotEmpty_Then_ShouldReturnUserTemperatureRecordsAndRespondWithOkAsync()
        {
            //Arrange
            var userId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB");

            var records = new GetUserTemperatureRecordsQueryResult
            (
                new List<GetTemperatureRecordQueryResult>()
                {
                    new GetTemperatureRecordQueryResult
                    {
                        Value = 60,
                        Time = DateTime.Now
                    }
                }
            );

            Mediator.Setup(med => med.Send(It.IsAny<GetUserTemperatureRecordsQuery>(), CancellationToken.None))
                .Returns(Task.FromResult(records));

            var controller = CreateSut();

            //Act
            var response = await controller.GetByUser(userId);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var result = (response as OkObjectResult)?.Value;
            var values = (result as GetUserTemperatureRecordsDto)?.TemperatureRecords;
            values?.Count.Should().Be(1);
        }

        [TestMethod]
        public async Task Given_GetByUser_When_UserIdIsEmpty_Then_ShouldRespondWithBadRequestAsync()
        {
            //Arrange
            var id = Guid.Empty;
            var controller = CreateSut();

            //Act
            var response = await controller.GetByUser(id);

            //Assert
            response.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public async Task Given_Create_When_ValidModelState_Then_ShouldRespondWithCreatedAsync()
        {
            //Arrange
            var addRecord = new AddTemperatureRecordDto();
            var id = new Guid();
            var commandResult = new AddTemperatureRecordCommandResult(id);

            Mediator.Setup(med => med.Send(It.IsAny<AddTemperatureRecordCommand>(), CancellationToken.None))
                .Returns(Task.FromResult(commandResult));

            var controller = CreateSut();

            //Act
            var response = await controller.Create(addRecord);

            //Assert
            response.Should().BeOfType<CreatedResult>();
        }

        [TestMethod]
        public async Task Given_Create_When_InvalidModelState_Then_ShouldRespondWithBadRequestAsync()
        {
            //Arrange
            var addRecord = new AddTemperatureRecordDto();

            var controller = CreateSut();
            controller.ModelState.SetModelValue("", ValueProviderResult.None);

            //Act
            var response = await controller.Create(addRecord);

            //Assert
            response.Should().BeOfType<BadRequestResult>();
        }

        private TemperatureController CreateSut()
        {
            return new TemperatureController(Mediator.Object, Mapper.Object);
        }
    }
}
