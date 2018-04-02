using System.Data;

namespace Dapp.Api.Data
{
    /// <summary>
    /// Connection factory for
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        IDbConnection Connection { get; }
    }
}