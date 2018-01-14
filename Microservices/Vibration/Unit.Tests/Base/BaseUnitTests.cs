using AutoMapper;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;

namespace Unit.Tests.Base
{
    public abstract class BaseUnitTests
    {
        protected Mock<IMapper> Mapper;
        protected Mock<IVibrationRepository> Repo;
        protected Mock<IMediator> Mediator;

        [TestInitialize]
        public virtual void Setup()
        {
            Mapper = new Mock<IMapper>();
            Repo = new Mock<IVibrationRepository>();
            Mediator = new Mock<IMediator>();
        }
    }
}
