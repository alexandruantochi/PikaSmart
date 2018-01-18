using AutoMapper;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;

namespace Unit.Tests.Base
{
    public abstract class BaseAlarmsServiceUnitTests
    {
        protected Mock<IMapper> Mapper;
        protected Mock<IAlarmsRepository> Repo;
        protected Mock<IAlarmsService> Service;

        [TestInitialize]
        public virtual void Setup()
        {
            Mapper = new Mock<IMapper>();
            Repo = new Mock<IAlarmsRepository>();
            Service = new Mock<IAlarmsService>();
        }
    }
}
