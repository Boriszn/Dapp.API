using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapp.Api.Configuration.Settings;
using Dapp.Api.Data;
using Dapp.Api.Data.Model;
using Microsoft.Extensions.Options;

namespace Dapp.Api.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public DeviceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all devices.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Device> GetAll()
        {
            unitOfWork.BeginTransaction();

            return unitOfWork.DeviceRepository.All().ToList();
        }

        /// <summary>
        /// Adds the specified device.
        /// </summary>
        /// <param name="device">The device.</param>
        public void Add(Device device)
        {
            unitOfWork.BeginTransaction();

            // Adds new device
            unitOfWork.DeviceRepository.Add(device);

            // Commit transaction
            unitOfWork.Commit();
        }
    }
}
