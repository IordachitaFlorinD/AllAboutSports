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
    public class ItemController : ControllerBase
    {
        private readonly IItemDataAccess _categoryDataAccess;

        public ItemController(IItemDataAccess categoryDataAccess)
        {
            _categoryDataAccess = categoryDataAccess;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<Item> GetCategory([FromRoute] int id)
        {
            return _categoryDataAccess.GetCategory(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddTextPost([FromBody] Item item)
        {
            var response = _categoryDataAccess.AddCategory(item);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
