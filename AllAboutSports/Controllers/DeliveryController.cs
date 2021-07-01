using AllAboutSports.Models;
using AllAboutSports.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutSports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryProviderDataAccess _categoryDataAccess;

        public DeliveryController(IDeliveryProviderDataAccess categoryDataAccess)
        {
            _categoryDataAccess = categoryDataAccess;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<DeliveryProvider> GetCategory([FromRoute] int id)
        {
            return _categoryDataAccess.GetCategory(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddTextPost([FromBody] DeliveryProvider delivery)
        {
            var response = _categoryDataAccess.AddCategory(delivery);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
