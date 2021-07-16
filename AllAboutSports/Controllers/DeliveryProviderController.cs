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
        private readonly IDeliveryProviderRepository _deliveryProviderRepository;

        public DeliveryProviderController(IDeliveryProviderRepository deliveryProviderRepository)
        {
            _deliveryProviderRepository = deliveryProviderRepository;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<DeliveryProvider> GetDeliveryProviderById([FromRoute] int id)
        {
            return _deliveryProviderRepository.GetDeliveryProviderById(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddDeliveryProvider([FromBody] DeliveryProvider deliveryProvider)
        {
            var response = _deliveryProviderRepository.AddDeliveryProvider(deliveryProvider);
            if (response.Result > 0)
                return Ok();

            return BadRequest();


        }

        [HttpPut]
        [Route("update")]
        public StatusCodeResult UpdateDeliveryProvider([FromBody] DeliveryProvider updatedDeliveryProvider)
        {
            var respone = _deliveryProviderRepository.UpdateDeliveryProvider(updatedDeliveryProvider);
            if (respone.Result > 0)
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public StatusCodeResult DeleteDeliveryProvider([FromRoute] int id)
        {
            var respone = _deliveryProviderRepository.DeleteDeliveryProvider(id)
;
            if (respone.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
