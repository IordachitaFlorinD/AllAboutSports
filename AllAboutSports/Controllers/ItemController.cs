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
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<Item> GetItemById([FromRoute] int id)
        {
            return _itemRepository.GetItemById(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddItem([FromBody] Item item)
        {
            var response = _itemRepository.AddItem(item);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("update")]
        public StatusCodeResult UpdateItem([FromBody] Item updateditem)
        {
            var respone = _itemRepository.UpdateItem(updateditem);
            if (respone.Result > 0)
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public StatusCodeResult DeleteItem([FromRoute] int id)
        {
            var respone = _itemRepository.DeleteItem(id)
;
            if (respone.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
