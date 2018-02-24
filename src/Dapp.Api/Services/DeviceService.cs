using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapp.Api.Configuration.Settings;
using Dapp.Api.Data.Model;
using Dapper;
using Microsoft.Extensions.Options;

namespace Dapp.Api.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly string connectionString;

        public DeviceService(IOptions<ConnectionSettings> setting)
        {
            connectionString = setting.Value.DefaultConnection;
        }

        private IDbConnection Connection => new SqlConnection(connectionString);

        public void Add(Device device)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Devices (DeviceId, DeviceTitle)" + " VALUES(@DeviceId, @DeviceTitle)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, device);
            }
        }

        public IEnumerable<Device> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Device>("SELECT * FROM Devices");
            }
        }
    }
}
