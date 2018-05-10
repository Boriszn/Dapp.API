namespace Dapp.Api.Data
{
    /// <summary>
    /// Represents repository/object creation and transaction management
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the device repository.
        /// </summary>
        /// <value>
        /// The device repository.
        /// </value>
        IDeviceRepository DeviceRepository { get; }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        void Dispose();
    }
}