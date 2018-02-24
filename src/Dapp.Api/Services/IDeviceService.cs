using System.Collections.Generic;
using Dapp.Api.Data.Model;

namespace Dapp.Api.Services
{
    public interface IDeviceService
    {
        /// <summary>
        /// Adds the specified device.
        /// </summary>
        /// <param name="device">The device.</param>
        void Add(Device device);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Device> GetAll();
    }
}