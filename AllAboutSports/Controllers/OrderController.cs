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
    public class OrderController : ControllerBase
    {
        private readonly IOrderDataAccess _categoryDataAccess;

        public OrderController(IOrderDataAccess categoryDataAccess)
        {
            _categoryDataAccess = categoryDataAccess;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<Order> GetCategory([FromRoute] int id)
        {
            return _categoryDataAccess.GetCategory(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddTextPost([FromBody] Order order)
        {
            var response = _categoryDataAccess.AddCategory(order);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
