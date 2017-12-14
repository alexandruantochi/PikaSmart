using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;

namespace Unit.Tests.Base
{
    public abstract class BaseTemperatureServiceUnitTests
    {
        protected Mock<IMapper> Mapper;
        protected Mock<ITemperatureRepository> Repo;

        [TestInitialize]
        public virtual void Setup()
        {
            Mapper = new Mock<IMapper>();
            Repo = new Mock<ITemperatureRepository>();
        }
    }
}
