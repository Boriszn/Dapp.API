using System.ComponentModel.DataAnnotations;
using System.Net;
using Dapp.Api.Data.Model;
using Dapp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger.Annotations;

namespace Dapp.Api.Controllers
{
    /// <summary>
    /// Devices API controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/devices")]
    public class DevicesController : Controller
    {
        private readonly IDeviceService deviceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesController"/> class.
        /// </summary>
        /// <param name="deviceService">The device service.</param>
        public DevicesController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        /// <summary>
        /// Gets the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation("GetDevices")]
        public IActionResult Get([FromQuery][Required]int page, [FromQuery][Required]int pageSize)
        {
            if (!this.ModelState.IsValid)
            {
                return new BadRequestObjectResult(this.ModelState);
            }

            return new ObjectResult(deviceService.GetAll());
        }

        /// <summary>
        /// Posts the specified device model.
        /// </summary>
        /// <param name="deviceViewModel">The device view model.</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("CreateDevice")]
        [SwaggerResponse(HttpStatusCode.NoContent, "Device was saved successfuly")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Error in saving the Device")]
        public IActionResult Post([FromBody]Device deviceViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return new BadRequestObjectResult(this.ModelState);
            }

            deviceService.Add(deviceViewModel);

            return new OkResult();
        }
    }
}
