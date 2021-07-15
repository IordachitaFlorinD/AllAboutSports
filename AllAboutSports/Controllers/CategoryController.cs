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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<Category> GetCategoryById([FromRoute] int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddTextPost([FromBody] Category category)
        {
            var response = _categoryRepository.AddCategory(category);
            if (response.Result > 0)
                return Ok();

            return BadRequest();
        }
    }
}
