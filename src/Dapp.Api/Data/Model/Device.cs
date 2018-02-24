﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Dapp.Api.Data.Model
{
    /// <summary>
    /// The Device data model
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [Key]
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the device title.
        /// </summary>
        /// <value>
        /// The device title.
        /// </value>
        public string DeviceTitle { get; set; }
    }
}
