using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapp.Api.Data.Model;
using Dapper;

namespace Dapp.Api.Data
{
    public class DeviceRepository : RepositoryBase, IDeviceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRepository"/> class.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        public DeviceRepository(IDbTransaction transaction)
            : base(transaction)
        {
        }

        /// <inheritdoc />
        public IEnumerable<Device> All()
        {
            return Connection.Query<Device>("SELECT * FROM Devices", transaction: Transaction);
        }

        /// <inheritdoc />
        public Device Find(int id)
        {
            return Connection.Query<Device>(
                "SELECT * FROM Device WHERE DeviceId = @DeviceId",
                param: new { DeviceId = id },
                transaction: Transaction
            ).FirstOrDefault();
        }

        /// <inheritdoc />
        public void Add(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            device.DeviceId = Connection.ExecuteScalar<Guid>(
                "INSERT INTO Devices(DeviceId, DeviceTitle) VALUES(@DeviceId, @DeviceTitle); SELECT SCOPE_IDENTITY()",
                new { device.DeviceId, device.DeviceTitle },
                Transaction
            );
        }

        /// <inheritdoc />
        public void Update(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            Connection.Execute(
                "UPDATE Devices SET DeviceTitle = @DeviceTitle WHERE DeviceId = @DeviceId",
                new { device.DeviceTitle },
                Transaction
            );
        }

        /// <inheritdoc />
        public void Remove(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            Remove(device.DeviceId);
        }

        /// <inheritdoc />
        public void Remove(Guid id)
        {
            Connection.Execute(
                "DELETE FROM Cat WHERE CatId = @CatId",
                param: new { CatId = id },
                transaction: Transaction
            );
        }

        /// <inheritdoc />
        public IEnumerable<Device> FindByDeviceId(Guid deviceId)
        {
            return Connection.Query<Device>(
                "SELECT * FROM Devices WHERE DeviceId = @DeviceId",
                new { DeviceId = deviceId },
                Transaction
            );
        }
    }
}
