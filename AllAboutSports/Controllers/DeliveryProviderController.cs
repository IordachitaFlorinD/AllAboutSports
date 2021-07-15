using AllAboutSports.Models;
using AllAboutSports.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryProviderController : ControllerBase
    {
        private readonly IDeliveryProviderRepository _deliveryProvider;

        public DeliveryProviderController(IDeliveryProviderRepository deliveryProvider)
        {
            _deliveryProvider = deliveryProvider;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<DeliveryProvider> GetDeliveryProviderById([FromRoute] int id)
        {
            return _deliveryProvider.GetDeliveryProviderById(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddDeliveryProvider([FromBody] DeliveryProvider deliveryProvider)
        {
            var response = _deliveryProvider.AddDeliveryProvider(deliveryProvider);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
