using System.Data;

namespace Dapp.Api.Data.Infrastructure
{
    public abstract class RepositoryBase
    {
        /// <summary>
        /// Gets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        protected IDbTransaction Transaction { get; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        protected IDbConnection Connection => Transaction.Connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        protected RepositoryBase(IDbTransaction transaction)
        {
            Transaction = transaction;
        }
    }
}