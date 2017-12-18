using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;

namespace Unit.Tests.Base
{
    public abstract class BasePressureServiceUnitTests
    {
        protected Mock<IMapper> Mapper;
        protected Mock<IPressureRepository> Repo;

        [TestInitialize]
        public virtual void Setup()
        {
            Mapper = new Mock<IMapper>();
            Repo = new Mock<IPressureRepository>();
        }
    }
}
