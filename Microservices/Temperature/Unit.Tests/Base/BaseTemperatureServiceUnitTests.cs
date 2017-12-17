using AutoMapper;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;

namespace Unit.Tests.Base
{
    public abstract class BaseTemperatureServiceUnitTests
    {
        protected Mock<IMapper> Mapper;
        protected Mock<ITemperatureRepository> Repo;
        protected Mock<ITemperatureService> Service;

        [TestInitialize]
        public virtual void Setup()
        {
            Mapper = new Mock<IMapper>();
            Service = new Mock<ITemperatureService>();
            Repo = new Mock<ITemperatureRepository>();
        }
    }
}
