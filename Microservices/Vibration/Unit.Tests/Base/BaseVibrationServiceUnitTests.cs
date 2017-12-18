using AutoMapper;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;

namespace Unit.Tests.Base
{
    public abstract class BaseVibrationServiceUnitTests
    {
        protected Mock<IMapper> Mapper;
        protected Mock<IVibrationRepository> Repo;
        protected Mock<IVibrationService> Service;

        [TestInitialize]
        public virtual void Setup()
        {
            Mapper = new Mock<IMapper>();
            Service = new Mock<IVibrationService>();
            Repo = new Mock<IVibrationRepository>();
        }
    }
}
