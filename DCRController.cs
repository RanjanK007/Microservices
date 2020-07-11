using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABP_AddDC.Models;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABP_AddDC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCRController : ControllerBase
    {
        private readonly IBusControl _bus;
        public DCRController(IBusControl bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDCR(AddDCR addDCR)
        {
            Uri uri = new Uri("rabbitmq://localhost/dcr_queue");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(addDCR);
            return Ok("Success");
        }
    }
}
