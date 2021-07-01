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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryDataAccess _categoryDataAccess;

        public CategoryController(ICategoryDataAccess categoryDataAccess)
        {
            _categoryDataAccess = categoryDataAccess;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<Category> GetCategory([FromRoute] int id)
        {
            return _categoryDataAccess.GetCategory(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddTextPost([FromBody] Category category)
        {
            var response = _categoryDataAccess.AddCategory(category);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
