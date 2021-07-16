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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<Order> GetOrderById([FromRoute] int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddOrder([FromBody] Order order)
        {
            var response = _orderRepository.AddOrder(order);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("update")]
        public StatusCodeResult UpdateOrder([FromBody] Order updatedorder)
        {
            var respone = _orderRepository.UpdateOrder(updatedorder);
            if (respone.Result > 0)
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public StatusCodeResult DeleteOrder([FromRoute] int id)
        {
            var respone = _orderRepository.DeleteOrder(id)
;
            if (respone.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
