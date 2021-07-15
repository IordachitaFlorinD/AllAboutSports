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
    public class ShippingAddressController : ControllerBase
    {
        private readonly IShippingAddressRepository _shippingAddressRepository;

        public ShippingAddressController(IShippingAddressRepository shippingAddressRepository)
        {
            _shippingAddressRepository = shippingAddressRepository;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<ShippingAddress> GetShippingAddressById([FromRoute] int id)
        {
            return _shippingAddressRepository.GetShippingAddressById(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddShippingAddress([FromBody] ShippingAddress shippingAddress)
        {
            var response = _shippingAddressRepository.AddShippingAddress(shippingAddress);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
