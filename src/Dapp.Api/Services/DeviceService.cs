using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapp.Api.Configuration.Settings;
using Dapp.Api.Data;
using Dapp.Api.Data.Model;
using Microsoft.Extensions.Options;

namespace Dapp.Api.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceService"/> class.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public DeviceService(IOptions<ConnectionSettings> setting)
        {
            connectionString = setting.Value.DefaultConnection;
        }

        private IDbConnection Connection => new SqlConnection(connectionString);

        /// <summary>
        /// Gets all devices.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Device> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(this.connectionString))
            {
                return unitOfWork.DeviceRepository.All();
            }
        }

        /// <summary>
        /// Adds the specified device.
        /// </summary>
        /// <param name="device">The device.</param>
        public void Add(Device device)
        {
            using (var unitOfWork = new UnitOfWork(this.connectionString))
            {
                // Adds new device
                unitOfWork.DeviceRepository.Add(device);

                // Commit transaction
                unitOfWork.Commit();
            }
        }
    }
}
