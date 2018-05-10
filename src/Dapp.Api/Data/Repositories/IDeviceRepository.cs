using System;
using System.Collections.Generic;
using Dapp.Api.Data.Model;

namespace Dapp.Api.Data.Repositories
{
    public interface IDeviceRepository
    {
        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Device> All();

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Device Find(int id);

        /// <summary>
        /// Adds the specified device.
        /// </summary>
        /// <param name="device">The device.</param>
        void Add(Device device);

        /// <summary>
        /// Updates the specified device.
        /// </summary>
        /// <param name="device">The device.</param>
        void Update(Device device);

        /// <summary>
        /// Removes the specified device.
        /// </summary>
        /// <param name="device">The device.</param>
        void Remove(Device device);

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Remove(Guid id);

        /// <summary>
        /// Finds the by device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        IEnumerable<Device> FindByDeviceId(Guid deviceId);
    }
}