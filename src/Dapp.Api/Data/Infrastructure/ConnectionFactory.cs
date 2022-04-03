using System.Data;
using Dapp.Api.Configuration.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Dapp.Api.Data.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFactory"/> class.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public ConnectionFactory(IOptions<ConnectionSettings> setting)
        {
            this.connectionString = setting.Value.DefaultConnection;
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public IDbConnection Connection => new SqlConnection(connectionString);
    }
}