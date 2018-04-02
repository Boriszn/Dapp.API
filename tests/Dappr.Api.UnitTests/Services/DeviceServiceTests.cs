using System;
using System.Collections.Generic;
using System.Data;
using Dapp.Api.Configuration.Settings;
using Dapp.Api.Data;
using Dapp.Api.Data.Model;
using Dapp.Api.Services;
using Microsoft.Extensions.Options;
using Moq;
using FluentAssertions;
using Xunit;

namespace Dappr.Api.UnitTests.Services
{
    public class DeviceServiceTests
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<IOptions<ConnectionSettings>> mockOptions;

        public DeviceServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockOptions = this.mockRepository.Create<IOptions<ConnectionSettings>>();
        }

        [Fact]
        public void GetAll_WithProperSetUp_RetunsListOfDevices()
        {
            // Arrange and Act
            var devices = this.CreateService().GetAll();

            // Assert
            devices.Should().NotBeNull();
        }

        [Fact]
        public void Add_WithDevice_ShouldNotThrowAnyExceptions()
        {
            // Arrange 
            Device device = new Device
            {
                DeviceId = Guid.NewGuid(),
                DeviceTitle = "ARM1235"
            };

            // Act
            Action addAction = () => this.CreateService().Add(device);

            // Assert
            addAction.Should().NotThrow();
        }

        private IDeviceService CreateService()
        {
            IOptions<ConnectionSettings> options = Options.Create(new ConnectionSettings());

            // TODO: Add real DB connection with SqlLite in memory ServiceStack.OrmLite.SqlServer.Core
            // var connection = new Mock<IDbConnection>();

            //var unitOfWorkMock = this.mockRepository.Create<IUnitOfWork>();

            //unitOfWorkMock
            //    .SetupGet(x => x.DeviceRepository)
            //    .Returns(() => new DeviceRepository(connection.Object.BeginTransaction()));

            // return new DeviceService(options, unitOfWorkMock.Object);

            var service = this.mockRepository.Create<IDeviceService>();
            
            service.Setup(r => r.GetAll())
                .Returns(new List<Device>
                {
                    new Device
                    {
                        DeviceId = Guid.Parse("3da270a0-2c07-4062-b2d0-90361191a088"),
                        DeviceTitle = "DFVVV-1234"
                    }
                });

            service.Setup(r => r.Add(It.IsAny<Device>()));

            return service.Object;
        }
    }
}
