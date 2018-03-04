using System;
using Dapp.Api.Configuration.Settings;
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
            this.mockRepository = new MockRepository(MockBehavior.Strict);

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
        public void GetAll_WithDevice_ShouldNotThrowAnyExceptions()
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

        private DeviceService CreateService()
        {
            return new DeviceService(
                this.mockOptions.Object);
        }
    }
}
